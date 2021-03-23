namespace Application.BusinessLogicLayer.Modules.WordsCounter.ResponseModels
{
    public class GetBasicDataResponseModel
    {
        public int Characters { get; init; }

        public int CharactersWithoutSpaces { get; init; }

        public int Words { get; init; }

        public int Sentences { get; init; }
    }
}
