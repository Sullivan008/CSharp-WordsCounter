using System;
using System.Collections.Generic;
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
    public class GetBasicDataQuery : IRequest<GetBasicDataResponseModel>
    {
        public string InputText { get; }

        public GetBasicDataQuery(GetBasicDataRequestModel requestModel)
        {
            InputText = requestModel.InputText;
        }
    }

    public class GetBasicDataQueryHandler : QueryBase<GetBasicDataQuery, GetBasicDataResponseModel>
    {
        private readonly IWordService _wordService;

        public GetBasicDataQueryHandler(WordsCounterReadOnlyDbContext context, IWordService wordService) : base(context)
        {
            _wordService = wordService;
        }

        public override async Task<GetBasicDataResponseModel> Handle(GetBasicDataQuery request, CancellationToken cancellationToken)
        {
            GetBasicDataResponseModel responseModel = new GetBasicDataResponseModel
            {
                CharactersCount = await Task.Run(() => GetCharactersCount(request.InputText), cancellationToken),
                CharactersWithoutSpacesCount = await Task.Run(() => GetCharactersWithoutSpacesCount(request.InputText), cancellationToken),
                WordsCount = await Task.Run(() => GetWordsCount(request.InputText), cancellationToken),
                SentencesCount = await Task.Run(() => GetSentencesCount(request.InputText), cancellationToken)
            };

            return responseModel;
        }

        private static int GetCharactersCount(string inputText)
        {
            const string newLineCharacter = "\n";

            return inputText.Replace(newLineCharacter, string.Empty).Length;
        }

        private static int GetCharactersWithoutSpacesCount(string inputText)
        {
            return inputText.Count(x => !char.IsWhiteSpace(x));
        }

        private int GetWordsCount(string inputText)
        {
            IEnumerable<string> words = _wordService.GetWords(inputText);

            return words.Count();
        }

        private static int GetSentencesCount(string inputText)
        {
            char[] splitChars = { '.', '?', '!' };

            return inputText.Split(splitChars, StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
}
