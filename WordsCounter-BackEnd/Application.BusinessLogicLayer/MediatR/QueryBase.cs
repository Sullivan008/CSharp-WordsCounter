using System.Threading;
using System.Threading.Tasks;
using Application.DataAccessLayer.Context;
using MediatR;

namespace Application.BusinessLogicLayer.MediatR
{
    public abstract class QueryBase<TQuery, TResult> : IRequestHandler<TQuery, TResult> where TQuery : IRequest<TResult>
    {
        protected WordsCounterReadOnlyDbContext Context;

        protected QueryBase(WordsCounterReadOnlyDbContext context)
        {
            Context = context;
        }

        public abstract Task<TResult> Handle(TQuery request, CancellationToken cancellationToken);
    }
}
