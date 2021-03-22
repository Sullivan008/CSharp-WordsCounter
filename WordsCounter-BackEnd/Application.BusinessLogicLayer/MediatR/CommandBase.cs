using System.Threading;
using System.Threading.Tasks;
using Application.DataAccessLayer.Context;
using MediatR;

namespace Application.BusinessLogicLayer.MediatR
{
    public abstract class CommandBase<TCommand, TResult> : IRequestHandler<TCommand, TResult> where TCommand : IRequest<TResult>
    {
        protected readonly WordsCounterDbContext Context;

        protected CommandBase(WordsCounterDbContext context)
        {
            Context = context;
        }

        public abstract Task<TResult> Handle(TCommand request, CancellationToken cancellationToken);
    }
}
