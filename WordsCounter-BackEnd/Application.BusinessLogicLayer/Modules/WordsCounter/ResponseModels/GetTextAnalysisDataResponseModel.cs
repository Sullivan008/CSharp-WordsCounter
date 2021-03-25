namespace Application.BusinessLogicLayer.Modules.WordsCounter.ResponseModels
{
    public class GetTextAnalysisDataResponseModel
    {
        public int ParagraphsCount { get; init; }

        public int AlphanumericCharactersCount { get; init; }

        public int NumericCharactersCount { get; init; }

        public int AlphaCharactersCount { get; init; }

        public int UniqueWordsCount { get; init; }

        public int ShortWordsCount { get; init; }

        public int LongWordsCount { get; init; }
    }
}
