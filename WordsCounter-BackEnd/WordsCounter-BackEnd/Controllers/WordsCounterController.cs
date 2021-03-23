using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Application.Web.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{api-version:apiVersion}/[controller]")]
    public class WordsCounterController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WordsCounterController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
