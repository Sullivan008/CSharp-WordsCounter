using System.Collections.ObjectModel;

namespace Application.BusinessLogicLayer.Modules.WordsCounter.ResponseModels
{
    public class GetKeywordDensityDataResponseModel
    {
        public ReadOnlyCollection<KeywordDensityListItemResponseModel> KeywordDensityList { get; init; }
    }
}
