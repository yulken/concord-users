using concord_users.Src.Domain.Exceptions;
using concord_users.Src.Infra.Http.Dtos;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace concord_users.Src.Infra.Http.Filters.Handlers
{
    public class UnauthorizedExceptionHandler : ExceptionHandler
    {
        public override void Handle(ActionExecutedContext context)
        {
            if (context.Exception is not UnauthorizedException exception)
            {
                DefaultHandler(context);
                return;
            }
            context.Result = new ObjectResult(new ErrorResponse(StatusCodes.Status401Unauthorized, exception.Message))
            {
                StatusCode = StatusCodes.Status401Unauthorized
            };

            context.ExceptionHandled = true;
        }
    }
}