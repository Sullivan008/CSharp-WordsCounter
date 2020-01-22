using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordsCounter.Controllers.Classes.Operations
{
    public class NumbersOfWordsOperations
    {
        private readonly string _inputText;
        private SortedDictionary<string, int> _finalWordsDictionary;

        /// <summary>
        ///     Konstruktor
        /// </summary>
        /// <param name="inputText">A vizsgálandó szöveg</param>
        public NumbersOfWordsOperations(string inputText)
        {
            _inputText = inputText.ToLower();

            _finalWordsDictionary = new SortedDictionary<string, int>();
        }

        /// <summary>
        ///     Elkészít egy olyan listát, amely tartalmazza az egyedi szavakat
        ///     (A szükségtelen szavak nélkül) darabszámmal, szósűrűséggel.
        /// </summary>
        /// <returns>Lista, amely tartalmazza az egyedi szavakat, darabszámmal, szósűrűséggel.</returns>
        public List<KeyValuePair<string, Tuple<int, double>>> GetNumberOfWordsTable()
        {
            CreateUniqueWordsTable();

            RemoveUnnecessaryWords();

            return CountWords();
        }

        #region PRIVATE Helper Methods

        /// <summary>
        ///     Elkészít egy olyan Listát, amelyben csak az egyedi szavak találhatóak
        ///     meg.
        /// </summary>
        private void CreateUniqueWordsTable()
        {
            HashSet<string> uniqueWordsSet = GetUniqueWordsCount();

            foreach (string item in uniqueWordsSet)
            {
                string currentItem = ClearWhitespacesFromString(item);

                if (currentItem.EndsWith(":"))
                {
                    currentItem = RemoveColonCharacter(currentItem);
                }

                try
                {
                    AddNewWordToTheSortedDictionary(currentItem, _finalWordsDictionary);
                }
                catch (ArgumentException ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex);
                }
            }
        }

        /// <summary>
        ///     A felesleges szavak eltávolítása, a már egyedi szavakkal feltöltött
        ///     SortedDictionary-ban
        /// </summary>
        private void RemoveUnnecessaryWords()
        {
            SortedDictionary<string, int> currentWordsDictionary = new SortedDictionary<string, int>();

            foreach (KeyValuePair<string, int> item in _finalWordsDictionary)
            {
                bool currentWordIsUnnecessary = false;

                foreach (string unnecessaryWord in GlobalData.UnnecessaryWords)
                {
                    if (item.Key == unnecessaryWord.ToLower())
                    {
                        currentWordIsUnnecessary = true;
                        break;
                    }
                }

                if (!currentWordIsUnnecessary)
                {
                    AddNewWordToTheSortedDictionary(item.Key, currentWordsDictionary);
                }
            }

            _finalWordsDictionary = currentWordsDictionary;
        }

        /// <summary>
        ///     Megszámolja a szavak előfordulásának, majd a szavak szósűrűségének számát
        /// </summary>
        private List<KeyValuePair<string, Tuple<int, double>>> CountWords()
        {
            int wordsCount = GetWordsCount();

            SortedDictionary<string, int> currentWordsDictionary = new SortedDictionary<string, int>();

            foreach (KeyValuePair<string, int> item in _finalWordsDictionary)
            {
                AddNewWordToTheSortedDictionaryWithIncidence(item.Key,
                    Regex.Matches(_inputText, ("\\b" + item.Key + "\\b")).Count, currentWordsDictionary);
            }

            List<KeyValuePair<string, int>> orderedWordsDictionary =
                currentWordsDictionary.OrderByDescending(x => x.Value).ToList();

            List<KeyValuePair<string, Tuple<int, double>>> finalWordsDictionaryList = new List<KeyValuePair<string, Tuple<int, double>>>();

            foreach (KeyValuePair<string, int> item in orderedWordsDictionary)
            {
                AddNewWordToTheSortedDictionaryWithIncidenceAndDensity(item.Key, item.Value, (item.Value / (double)wordsCount) * 100, finalWordsDictionaryList);
            }

            return finalWordsDictionaryList;
        }

        /// <summary>
        ///     Hozzáadunk egy új szót a rendezett szótárunkhoz
        /// </summary>
        /// <param name="item">A hozzáadandó szó</param>
        /// <param name="wordsDictionary">Dictionary amelyhez hozzáadjuk a szükséges szót</param>
        private void AddNewWordToTheSortedDictionary(string item, SortedDictionary<string, int> wordsDictionary)
        {
            wordsDictionary.Add(item.ToLower(), 0);
        }

        /// <summary>
        ///     Hozzáadunk egy új szót a rendezett szótárunkhoz szószámmal
        /// </summary>
        /// <param name="item">A hozzáadandó szó</param>
        /// <param name="count">Szó szám</param>
        /// <param name="wordsDictionary">Dictionary amelyhez hozzáadjuk a szükséges szót</param>
        private void AddNewWordToTheSortedDictionaryWithIncidence(string item, int count, SortedDictionary<string, int> wordsDictionary)
        {
            wordsDictionary.Add(item.ToLower(), count);
        }

        /// <summary>
        ///     Hozzáadunk egy új szót a rendezett szótárunkhoz szószámmal és szósűrűséggel
        /// </summary>
        /// <param name="item">A hozzáadandó szó</param>
        /// <param name="count">Szó szám</param>
        /// <param name="finalWordsDictionaryList">Dictionary amelyhez hozzáadjuk a szükséges szót</param>
        /// <param name="density">Szó sűrűsége</param>
        private void AddNewWordToTheSortedDictionaryWithIncidenceAndDensity(string item, int count, double density, List<KeyValuePair<string, Tuple<int, double>>> finalWordsDictionaryList)
        {
            finalWordsDictionaryList.Add(new KeyValuePair<string, Tuple<int, double>>(item, new Tuple<int, double>(count, Math.Round(density, 2, MidpointRounding.AwayFromZero))));
        }

        /// <summary>
        ///     Eltávolítja az utolsó karaktert, a karakterláncról.
        ///     Ez esetben azért van rá szükség, mert feltételezhető, hogy a
        ///     kapott karakterlánc tartalmaz egy kettőspontot a karakterlánc végén.
        /// </summary>
        /// <param name="currentItem">A tisztítandó karakterlánc</param>
        /// <returns>Egy olyan karakterlánc, amely nem tartalmazza az utolsó karaktert</returns>
        private string RemoveColonCharacter(string currentItem)
        {
            return currentItem.Substring(0, currentItem.Length - 1);
        }

        /// <summary>
        ///     Függvény, amely kitörli a felesleges szóközöket, a string-ből
        /// </summary>
        /// <param name="currentItem">Karakterlánc, amelyet tisztítani szeretnénk</param>
        /// <returns>Egy olyan karakterlánc, amely nem tartalmazza a felesleges szóközöket</returns>
        private string ClearWhitespacesFromString(string currentItem)
        {
            return currentItem.Replace(" ", string.Empty);
        }

        /// <summary>
        ///     Visszatéríti, az egyedi szavakat a Konstruktorban inicializált inputText-ben
        /// </summary>
        /// <returns>Az egyedi szavak száma az InputText-ben</returns>
        private HashSet<string> GetUniqueWordsCount()
        {
            return new HashSet<string>(_inputText.Split(GlobalData.WordSeparators, StringSplitOptions.RemoveEmptyEntries),
              StringComparer.OrdinalIgnoreCase);
        }

        /// <summary>
        ///     Visszatéríti, hogy hány darab szó található a Konstruktorban inicializált
        ///     inputText-ben
        /// </summary>
        /// <returns>Szavak száma az InputText-ben</returns>
        private int GetWordsCount()
        {
            return Regex.Matches(_inputText, @"[\S]+").Count;
        }

        #endregion
    }
}