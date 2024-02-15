using concord_users.Src.Domain.Exceptions;
using concord_users.Src.Infra.Http.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace concord_users.Src.Infra.Http.Filters.Handlers
{
    public class ConflictingDataHandler: ExceptionHandler
    {
        public override void Handle(ActionExecutedContext context) {
            if (context.Exception is not ConflictingDataException exception)
            {
                DefaultHandler(context);
                return;
            }
                context.Result = new ObjectResult(new ErrorResponse(StatusCodes.Status409Conflict, exception.Message))
            {
                StatusCode = StatusCodes.Status409Conflict
            };

            context.ExceptionHandled = true;
        }
    }
}
