using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.BusinessLogicLayer.MediatR;
using Application.BusinessLogicLayer.Modules.WordsCounter.Enums;
using Application.BusinessLogicLayer.Modules.WordsCounter.RequestModels;
using Application.BusinessLogicLayer.Modules.WordsCounter.ResponseModels;
using Application.BusinessLogicLayer.Modules.WordsCounter.Services.Interfaces;
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
        private readonly IWordService _wordService;

        public GetTextAnalysisDataQueryHandler(WordsCounterReadOnlyDbContext context, IWordService wordService) : base(context)
        {
            _wordService = wordService;
        }

        public override async Task<GetTextAnalysisDataResponseModel> Handle(GetTextAnalysisDataQuery request, CancellationToken cancellationToken)
        {
            ReadOnlyDictionary<TextAnalysisType, int> textAnalysisData = await Task.Run(() => GetTextAnalysisData(request.InputText), cancellationToken);

            return new GetTextAnalysisDataResponseModel
            {
                TextAnalysisElements = textAnalysisData
            };
        }

        private ReadOnlyDictionary<TextAnalysisType, int> GetTextAnalysisData(string inputText)
        {
            IEnumerable<string> words = _wordService.GetWords(inputText);

            Dictionary<TextAnalysisType, int> result = new()
            {
                { TextAnalysisType.ParagraphsCount, GetParagraphsCount(inputText) },
                { TextAnalysisType.AlphanumericCharactersCount, GetAlphanumericCharactersCount(inputText) },
                { TextAnalysisType.NumericCharactersCount, GetNumericCharactersCount(inputText) },
                { TextAnalysisType.AlphaCharactersCount, GetAlphaCharactersCount(inputText) },
                { TextAnalysisType.UniqueWordsCount, GetUniqueWordsCount(words) },
                { TextAnalysisType.ShortWordsCount, GetShortWordsCount(words) },
            };

            return new ReadOnlyDictionary<TextAnalysisType, int>(result);
        }

        private static int GetParagraphsCount(string inputText)
        {
            const string paragraphSeparator = "\n";

            return inputText.Split(paragraphSeparator, StringSplitOptions.RemoveEmptyEntries).Length;
        }

        private static int GetAlphanumericCharactersCount(string inputText)
        {
            return inputText.Count(char.IsLetterOrDigit);
        }

        private static int GetNumericCharactersCount(string inputText)
        {
            return inputText.Count(char.IsDigit);
        }

        private static int GetAlphaCharactersCount(string inputText)
        {
            return inputText.Count(char.IsLetter);
        }

        private static int GetUniqueWordsCount(IEnumerable<string> words)
        {
            return new HashSet<string>(words.Select(x => x.ToLower())).Count;
        }

        private static int GetShortWordsCount(IEnumerable<string> words)
        {
            const int MAX_LENGTH = 3;

            return words.Count(x => x.Length <= MAX_LENGTH);
        }
    }
}
