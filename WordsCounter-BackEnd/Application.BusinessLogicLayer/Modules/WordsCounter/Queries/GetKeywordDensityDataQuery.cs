using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using Application.BusinessLogicLayer.MediatR;
using Application.BusinessLogicLayer.Modules.WordsCounter.RequestModels;
using Application.BusinessLogicLayer.Modules.WordsCounter.ResponseModels;
using Application.BusinessLogicLayer.Modules.WordsCounter.Services.Interfaces;
using Application.DataAccessLayer.Context;
using MediatR;

namespace Application.BusinessLogicLayer.Modules.WordsCounter.Queries
{
    public class GetKeywordDensityDataQuery : IRequest<GetKeywordDensityDataResponseModel>
    {
        public string InputText { get; init; }

        public GetKeywordDensityDataQuery(GetKeywordDensityDataRequestModel requestModel)
        {
            InputText = requestModel.InputText;
        }
    }

    public class GetKeywordDensityDataQueryHandler : QueryBase<GetKeywordDensityDataQuery, GetKeywordDensityDataResponseModel>
    {
        private readonly IWordService _wordService;

        public GetKeywordDensityDataQueryHandler(WordsCounterReadOnlyDbContext context, IWordService wordService) : base(context)
        {
            _wordService = wordService;
        }

        public override async Task<GetKeywordDensityDataResponseModel> Handle(GetKeywordDensityDataQuery request, CancellationToken cancellationToken)
        {
            IList<KeywordDensityListItemResponseModel> keywordDensityList = await Task.Run(() => GetKeywordDensityList(request.InputText), cancellationToken);

            return new GetKeywordDensityDataResponseModel
            {
                KeywordDensityList = new ReadOnlyCollection<KeywordDensityListItemResponseModel>(keywordDensityList)
            };
        }

        private IList<KeywordDensityListItemResponseModel> GetKeywordDensityList(string inputText)
        {
            IList<KeywordDensityListItemResponseModel> result = new List<KeywordDensityListItemResponseModel>();

            return result;
        }
    }
}
