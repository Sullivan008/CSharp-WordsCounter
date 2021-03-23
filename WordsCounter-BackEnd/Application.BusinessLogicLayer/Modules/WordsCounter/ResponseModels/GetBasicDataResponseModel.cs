namespace Application.BusinessLogicLayer.Modules.WordsCounter.ResponseModels
{
    public class GetBasicDataResponseModel
    {
        public int CharactersCount { get; init; }

        public int CharactersWithoutSpacesCount { get; init; }

        public int WordsCount { get; init; }

        public int SentencesCount { get; init; }
    }
}
