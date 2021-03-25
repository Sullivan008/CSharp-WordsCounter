using System.Collections.ObjectModel;
using Application.BusinessLogicLayer.Modules.WordsCounter.Enums;

namespace Application.BusinessLogicLayer.Modules.WordsCounter.ResponseModels
{
    public class GetTextAnalysisDataResponseModel
    {
        public ReadOnlyDictionary<TextAnalysisType, int> TextAnalysisElements { get; init; }
    }
}
