using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordsCounter.Controllers.Classes.Operations
{
    public class SummaryInformationOperations
    {
        private string inputText;

        /// <summary>
        ///     Konstruktor
        /// </summary>
        /// <param name="inputText">A felhasználó által megadott InputText</param>
        public SummaryInformationOperations(string inputText)
        {
            this.inputText = inputText;
        }

        #region PublicMethods
        /// <summary>
        ///     Visszatéríti, hogy hány darab szó található a Konstruktorban inicializált
        ///     inputText-ben
        /// </summary>
        /// <returns>Szavak száma az InputText-ben</returns>
        public int GetWordsCount()
        {
            return Regex.Matches(inputText, @"[\S]+").Count;
        }

        /// <summary>
        ///     Visszatéríti, hogy hány darab karakter található a Konstruktorban
        ///     inicializált inputText-ben
        /// </summary>
        /// <returns>Karakterek száma az InputText-ben</returns>
        public int GetCharactersCount()
        {
            return inputText.Replace("\n","").Length;
        }

        /// <summary>
        ///     Visszatéríti, hogy hány darab karakter található a Konstruktorban
        ///     inicializált inputText-ben, amely nem egyenlő az "üres karakterrel"
        ///     (szóközök)
        /// </summary>
        /// <returns>
        ///     Karakterek száma "üres karakterek" (Szóközök) nélkül az InputText-ben
        /// </returns>
        public int GetCharacterCountsWithoutSpaces()
        {
            return inputText.Count(c => !Char.IsWhiteSpace(c));
        }

        /// <summary>
        ///     Visszatéríti, hogy hány darab mondat található a Konstruktorban
        ///     inicializált inputText-ben
        /// </summary>
        /// <returns>Mondatok száma az InputText-ben</returns>
        public int GetSentencesCount()
        {
            return inputText.Split(GlobalData.sentenceSeparators, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        /// <summary>
        ///     Visszatéríti, hogy hány darab paragrafus található a Konstruktorban
        ///     inicializált inputText-ben
        /// </summary>
        /// <returns>Paragrafusok száma az InputText-ben</returns>
        public int GetParagraphCount()
        {
            return GetWordsCount() != 0 ? inputText.Count(x => (x == GlobalData.paragraphSeparator)) + 1 : 0;
        }

        /// <summary>
        ///     Visszatéríti, hogy hány darab alfanumerikus karakter található a
        ///     Konstruktorban inicializált inputText-ben
        /// </summary>
        /// <returns>Alfanumerikus karakterek száma az InputText-ben</returns>
        public int GetAlphanumericCharactersCount()
        {
            return inputText.Count(char.IsLetterOrDigit);
        }

        /// <summary>
        ///     Visszatéríti, hogy hány darab Alfa karakter található a
        ///     Konstruktorban inicializált inputText-ben
        /// </summary>
        /// <returns>Alfa karakterek száma az InputText-ben</returns>
        public int GetAlphaCharactersCount()
        {
            return GetAlphanumericCharactersCount() - GetNumericCharactersCount();
        }

        /// <summary>
        ///     Visszatéríti, hogy hány darab Numerikus karakter található
        ///     a Konstruktorban inicializált inputText-ben
        /// </summary>
        /// <returns>Numerikus karakterek száma az InputText-ben</returns>
        public int GetNumericCharactersCount()
        {
            return inputText.Count(char.IsDigit);
        }

        /// <summary>
        ///     Visszatéríti, hogy hány darab egyedi szó található a
        ///     Konstruktorban inicializált inputText-ben
        /// </summary>
        /// <returns>Az egyedi szavak száma az InputText-ben</returns>
        public int GetUniqueWordsCount()
        {
            return new HashSet<String>(inputText.Split(GlobalData.wordSeparators, StringSplitOptions.RemoveEmptyEntries),
              StringComparer.OrdinalIgnoreCase).Count;
        }

        /// <summary>
        ///     Visszatéríti, hogy hány darab rövid szó található a
        ///     Konstruktorban inicializált inputText-ben
        /// </summary>
        /// <returns>Rövid szavak száma az InputText-ben</returns>
        public int GetShortWordsCount()
        {
            return inputText.Split(GlobalData.wordSeparators, StringSplitOptions.RemoveEmptyEntries)
                .Where(x => (x.Length <= GlobalData.ShortWordsLength && !x.EndsWith(":")) ||
                      (x.EndsWith(":") && x.Length <= (GlobalData.ShortWordsLength + 1)))
                .ToList()
                .Count;
        }

        /// <summary>
        ///     Visszatéríti, hogy hány darab hosszú szó található a
        ///     Konstruktorban inicializált inputText-ben
        /// </summary>
        /// <returns>Rövid szavak száma az InputText-ben</returns>
        public int GetLongWordsCount()
        {
            return inputText.Split(GlobalData.wordSeparators, StringSplitOptions.RemoveEmptyEntries)
                .Where(x => (x.Length >= GlobalData.LongWordsLength && !x.EndsWith(":")) ||
                      (x.EndsWith(":") && x.Length > GlobalData.LongWordsLength))
                .ToList()
                .Count;
        }
        #endregion
    }
}