using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using Application.BusinessLogicLayer.MediatR;
using Application.BusinessLogicLayer.Modules.WordsCounter.Enums;
using Application.BusinessLogicLayer.Modules.WordsCounter.RequestModels;
using Application.BusinessLogicLayer.Modules.WordsCounter.ResponseModels;
using Application.DataAccessLayer.Context;
using MediatR;

namespace Application.BusinessLogicLayer.Modules.WordsCounter.Queries
{
    public class GetTextAnalysisDataQuery : IRequest<GetTextAnalysisDataResponseModel>
    {
        public string InputText { get; }

        public GetTextAnalysisDataQuery(GetTextAnalysisDataRequestModel requestModel)
        {
            InputText = requestModel.InputText;
        }
    }

    public class GetTextAnalysisDataQueryHandler : QueryBase<GetTextAnalysisDataQuery, GetTextAnalysisDataResponseModel>
    {
        public GetTextAnalysisDataQueryHandler(WordsCounterReadOnlyDbContext context) : base(context)
        { }

        public override async Task<GetTextAnalysisDataResponseModel> Handle(GetTextAnalysisDataQuery request, CancellationToken cancellationToken)
        {
            ReadOnlyDictionary<TextAnalysisType, int> textAnalysisData = await Task.Run(GetTextAnalysisData, cancellationToken);

            return new GetTextAnalysisDataResponseModel
            {
                TextAnalysisElements = textAnalysisData
            };
        }

        private static ReadOnlyDictionary<TextAnalysisType, int> GetTextAnalysisData()
        {
            Dictionary<TextAnalysisType, int> result = new();

            return new ReadOnlyDictionary<TextAnalysisType, int>(result);
        }
    }
}
