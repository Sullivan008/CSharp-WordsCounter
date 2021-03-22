using Application.Core.ErrorHandling.Enums;

namespace Application.Core.ErrorHandling.Models
{
    public class ApiErrorModel
    {
        public ApiExceptionCode ExceptionCode { get; init; }

        public string Message { get; init; }

        public string Exception { get; init; }
    }
}
