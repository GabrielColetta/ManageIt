using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManageIt.Exceptions
{
    public class BusinessException : ExceptionBase
    {
        public BusinessException(string errorDescription, int statusCode = StatusCodes.Status400BadRequest)
            : base()
        {
            ErrorDescription = (string.IsNullOrEmpty(errorDescription) ? "ApplicationError" : errorDescription);
            this.statusCode = statusCode;
        }
    }
}
