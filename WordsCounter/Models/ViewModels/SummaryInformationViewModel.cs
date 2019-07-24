namespace WordsCounter.Models.ViewModels
{
    public class SummaryInformationViewModel
    {
        /// Tárolja a Szavak számát
        public int WordsCount { get; set; }

        /// Tárolja a Karakterek számát
        public int CharactersCount { get; set; }

        /// Tárolja a karakterek számát "üres karakterek" (Szóközök) nélkül
        public int CharactersCountWithoutSpaces { get; set; }

        /// Tárolja a mondatok számát
        public int SentencesCount { get; set; }

        /// Tárolja a paragrafusok számát
        public int ParagraphsCount { get; set; }

        /// Tárolja az Alfanumerikus karakterek számát
        public int AlphanumericCharactersCount { get; set; }

        /// Tárolja az Alfa karakterek számát
        public int AlphaCharactersCount { get; set; }

        /// Tárolja a Numerikus karakterek számát
        public int NumericCharactersCount { get; set; }

        /// Tárolja az egyedi szavak számát
        public int UniqueWordsCount { get; set; }

        /// Tárolja a rövid szavak számát
        public int ShortWordsCount { get; set; }

        /// Tárolja a hosszú szavak számát
        public int LongWordsCount { get; set; }
    }
}