namespace WordsCounter.Controllers.Classes
{
    public class GlobalData
    {
        #region Separators
        public static char[] WordSeparators = { ' ', '\r', '\n', '\t', ',', '.', ';', '!', '?' };

        public static char[] SentenceSeparators = { '.', '!', '?' };

        public static char ParagraphSeparator = '\n';

        #endregion

        #region WordsLength

        public static int ShortWordsLength = 3;

        public static int LongWordsLength = 7;

        #endregion

        #region Arrays

        public static string[] UnnecessaryWords =
            { "it's", "i", "am", "you", "are", "he", "she", "it", "we", "they", "is", "the",
                "a", "an", "i'm", "you're", "he's", "she's", "we're", "they're", "for", "of",
                "so", "in", "if", "at", "or", "and", "as", "to", "use", "would", "be", "too",
                "off", "no", "any", "do", "then", "my", "your", "his", "her", "its", "our", 
                "their", "mine", "yours", "hers", "ours", "theirs", "him", "her", "us", "some"};

        #endregion
    }
}