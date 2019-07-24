using System;

namespace WordsCounter.Controllers.Classes
{
    public class GlobalData
    {
        #region Separators
        /// Szeparátorok, amelyek meghatározzák, hogy
        /// hol kell a karakterláncot megtörni, hogy egy új
        /// szót kapjunk.
        public static Char[] wordSeparators = new Char[] { ' ', '\r', '\n', '\t', ',', '.', ';', '!', '?' };

        /// Szeparátorok, amelyek meghatározzák, hogy
        /// hol kell a karakterláncot megtörni, hogy egy új
        /// mondatot kapjunk.
        public static Char[] sentenceSeparators = new Char[] { '.', '!', '?' };

        /// Szeparátor, amely meghatározza, hogy hol kell
        /// a karakterláncot megtörni, hogy egy új paragrafust
        /// kapjunk.
        public static Char paragraphSeparator = '\n';

        #endregion

        #region WordsLength
        /// Tárolja, hogy milyen hosszúságú lehet maximum egy rövid
        /// szó hossza
        public static int ShortWordsLength = 3;

        /// Tárolja, hogy milyen hosszúságú lehet maximum egy hosszú
        /// szó hossza
        public static int LongWordsLength = 7;

        #endregion

        #region Arrays
        /// Tároljuk azokat a szavakat, amelyeket nem számoltatunk meg
        /// a szövegben. (Túl sokszor fordulnának elő (személyes névmások, 
        /// stb.))
        public static string[] unnecessaryWords =
            new string[] { "it's", "i", "am", "you", "are", "he", "she", "it", "we", "they", "is", "the",
                           "a", "an", "i'm", "you're", "he's", "she's", "we're", "they're", "for", "of",
                           "so", "in", "if", "at", "or", "and", "as", "to", "use", "would", "be", "too",
                           "off", "no", "any", "do", "then", "my", "your", "his", "her", "its", "our",
                           "their", "mine", "yours", "hers", "ours", "theirs", "him", "her", "us",
                           "some"};
        #endregion
    }
}