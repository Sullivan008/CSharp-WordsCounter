namespace Application.BusinessLogicLayer.Modules.WordsCounter.ResponseModels
{
    public class KeywordDensityListItemResponseModel
    {
        public string Keyword { get; init; }

        public int Quantity { get; init; }

        public double Percentage { get; init; }
    }
}
