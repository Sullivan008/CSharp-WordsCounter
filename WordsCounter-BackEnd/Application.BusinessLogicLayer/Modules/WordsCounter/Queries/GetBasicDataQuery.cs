using System;
using System.Threading;
using System.Threading.Tasks;
using Application.BusinessLogicLayer.MediatR;
using Application.BusinessLogicLayer.Modules.WordsCounter.RequestModels;
using Application.BusinessLogicLayer.Modules.WordsCounter.ResponseModels;
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

    public class GetBasicDataQueryHandler: QueryBase<GetBasicDataQuery, GetBasicDataResponseModel>
    {
        public GetBasicDataQueryHandler(WordsCounterReadOnlyDbContext context) : base(context)
        { }

        public override async Task<GetBasicDataResponseModel> Handle(GetBasicDataQuery request, CancellationToken cancellationToken)
        {
            GetBasicDataResponseModel responseModel = new GetBasicDataResponseModel
            {
                Characters = await Task.Run(() => GetCharactersCount(request.InputText), cancellationToken)
            };

            return responseModel;
        }

        private static int GetCharactersCount(string inputText)
        {
            return inputText.Replace(Environment.NewLine, string.Empty).Length;
        }
    }
}
