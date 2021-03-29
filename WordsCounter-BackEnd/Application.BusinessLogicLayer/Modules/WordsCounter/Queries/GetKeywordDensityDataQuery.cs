using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
            IEnumerable<string> words = _wordService.GetWords(inputText)
                                             .Select(x => x.ToLower())
                                             .ToList();

            int allWordsCount = GetAllWordsCount(words);

            return words.ToHashSet()
                        .Select(x =>
                        {
                            int quantity = words.Count(y => y == x);

                            return new KeywordDensityListItemResponseModel
                            {
                                Keyword = x,
                                Quantity = quantity,
                                Percentage = Math.Round((double)quantity / allWordsCount * 100d, 1, MidpointRounding.AwayFromZero)
                            };
                        })
                        .OrderByDescending(x => x.Quantity)
                        .ThenBy(x => x.Keyword)
                        .ToList();
        }

        private static int GetAllWordsCount(IEnumerable<string> words)
        {
            return words.Count();
        }
    }
}
