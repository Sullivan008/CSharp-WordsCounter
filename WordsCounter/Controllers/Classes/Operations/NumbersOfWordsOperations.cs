using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordsCounter.Controllers.Classes.Operations
{
    public class NumbersOfWordsOperations
    {
        private string inputText;
        private SortedDictionary<string, int> finalWordsDictionary;

        /// <summary>
        ///     Konstruktor
        /// </summary>
        /// <param name="inputText">A vizsgálandó szöveg</param>
        public NumbersOfWordsOperations(string inputText)
        {
            this.inputText = inputText.ToLower();

            this.finalWordsDictionary = new SortedDictionary<string, int>();
        }

        #region PublicMethods
        /// <summary>
        ///     Elkészít egy olyan listát, amely tartalmazza az egyedi szavakat
        ///     (A szükségtelen szavak nélkül) darabszámmal, szósűrűséggel.
        /// </summary>
        /// <returns>Lista, amely tartalmazza az egyedi szavakat, darabszámmal, szósűrűséggel.</returns>
        public List<KeyValuePair<string, Tuple<int, double>>> GetNumberOfWordsTable()
        {
            /// Olyan táblázat elkészítése, amely tartalmazza az egyedi szavakat
            CreateUniqueWordsTable();

            /// A felesleges szavak eltávolítása az előző lépésben elkészített táblázatból
            RemoveUnnecessaryWords();

            /// Szavak előfordulásának, szósűrűségének megszámlálása
            return CountWords();
        }
        #endregion

        #region Helpers
        /// <summary>
        ///     Elkészít egy olyan Listát, amelyben csak az egyedi szavak találhatóak
        ///     meg.
        /// </summary>
        private void CreateUniqueWordsTable()
        {
            /// Tároljuk azokat a szavakat amelyek egyediek
            HashSet<string> uniqueWordsSet = GetUniqueWordsCount();
            string currentItem;

            /// Bejárjuk a HashSet-et
            foreach (string item in uniqueWordsSet)
            {
                /// Karakterlánc tisztítása, a felesleges szóközöktől
                currentItem = ClearWhitespacesFromString(item);

                /// Vizsgálat, hogy a karakterlánc tartalmazza e a végén a kettőspont karaktert.
                /// Ha igen, azt eltávolítjuk a Stringből
                if (currentItem.EndsWith(":"))
                {
                    currentItem = RemoveColonCharacter(currentItem);
                }

                try
                {
                    /// Az elkészített, letisztított szó, hozzáadása a SortedDictionary-hoz
                    AddNewWordToTheSortedDictionary(currentItem, finalWordsDictionary);
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
            bool currentWordIsUnnecessary;

            /// Lista, amelyben tárolni fogjuk azokat a szavakat, amelyek nem feleslegesek
            SortedDictionary<string, int> currentWordsDictionary = new SortedDictionary<string, int>();

            /// Bejárjuk az egyedi szavakat tartalmazó Dictionary-t
            foreach (KeyValuePair<string, int> item in finalWordsDictionary)
            {
                currentWordIsUnnecessary = false;

                /// Bejárjuk a szükségtelen szavak tömböt
                for (int i = 0; i < GlobalData.unnecessaryWords.Length; i++)
                {
                    /// Vizsgáljuk, hogy az aktuális szó megegyezik-e valamelyik,
                    /// szükségtelen szóval
                    if (item.Key == GlobalData.unnecessaryWords[i].ToLower())
                    {
                        currentWordIsUnnecessary = true;
                        break;
                    }
                }

                /// Megvizsgáljuk, hogy az aktuális szó, szükségtelen-e. Ha nem,
                /// akkor hozzáadjuk a listához
                if (!currentWordIsUnnecessary)
                {
                    AddNewWordToTheSortedDictionary(item.Key, currentWordsDictionary);
                }
            }

            /// Átadjuk az aktuális SortedDictionary referenciáját a végeleges SortedDictionary-nak
            finalWordsDictionary = currentWordsDictionary;
        }

        /// <summary>
        ///     Megszámolja a szavak előfordulásának, majd a szavak szósűrűségének számát
        /// </summary>
        private List<KeyValuePair<string, Tuple<int, double>>> CountWords()
        {
            /// Lekérdezzük az összes szószámot
            int wordsCount = GetWordsCount();

            /// Lista, amelyben tárolni fogjuk az egyedi szavakat, az előfordulási számukkal
            SortedDictionary<string, int> currentWordsDictionary = new SortedDictionary<string, int>();

            /// Lista, amelyben csökkenő sorrendben fogjuk tárolni a szavakat
            List<KeyValuePair<string, int>> orderedWordsDictionary;

            /// Lista, amelyben tárolni fogjuk az egyedi szavakat, az előfordulási számukkal, és a szósűrűségi értékkel
            List<KeyValuePair<string, Tuple<int, double>>> finalWordsDictionaryList;

            /// Bejárjuk az egyedi szavakat tartalmazó Dictionary-t
            foreach (KeyValuePair<string, int> item in finalWordsDictionary)
            {
                /// Hozzadjuk az aktuális Dictionary-nkhoz az egyedi szót, az előfordulási számmal együtt
                AddNewWordToTheSortedDictionaryWithIncidence(item.Key,
                    Regex.Matches(inputText, ("\\b" + item.Key + "\\b")).Count, currentWordsDictionary);
            }

            /// Lista, amelyben csökkenő sorrendben fogjuk tárolni a szavakat
            orderedWordsDictionary = currentWordsDictionary.OrderByDescending(x => x.Value).ToList();

            finalWordsDictionaryList = new List<KeyValuePair<string, Tuple<int, double>>>();

            /// Bejárjuk a csökkenő sorrendbe rendezett SortedDictionary-t
            foreach (KeyValuePair<string, int> item in orderedWordsDictionary)
            {
                AddNewWordToTheSortedDictionaryWithIncidenceAndDensity(item.Key, item.Value, ((double)item.Value / (double)wordsCount) * 100, finalWordsDictionaryList);
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
        /// <param name="wordsDictionary">Dictionary amelyhez hozzáadjuk a szükséges szót</param>
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
        ///     Függvény, amely kitörli a felesleges szóközöket, a
        ///     String-ből
        /// </summary>
        /// <param name="currentItem">Karakterlánc, amelyet tisztítani szeretnénk</param>
        /// <returns>Egy olyan karakterlánc, amely nem tartalmazza a felesleges szóközöket</returns>
        private string ClearWhitespacesFromString(string currentItem)
        {
            return currentItem.Replace(" ", string.Empty);
        }

        /// <summary>
        ///     Visszatéríti, az egyedi szavakat a 
        ///     Konstruktorban inicializált inputText-ben
        /// </summary>
        /// <returns>Az egyedi szavak száma az InputText-ben</returns>
        private HashSet<String> GetUniqueWordsCount()
        {
            return new HashSet<String>(inputText.Split(GlobalData.wordSeparators, StringSplitOptions.RemoveEmptyEntries),
              StringComparer.OrdinalIgnoreCase);
        }

        /// <summary>
        ///     Visszatéríti, hogy hány darab szó található a Konstruktorban inicializált
        ///     inputText-ben
        /// </summary>
        /// <returns>Szavak száma az InputText-ben</returns>
        public int GetWordsCount()
        {
            return Regex.Matches(inputText, @"[\S]+").Count;
        }
        #endregion
    }
}