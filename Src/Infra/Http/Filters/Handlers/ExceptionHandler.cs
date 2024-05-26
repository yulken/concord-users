using concord_users.Src.Infra.Http.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace concord_users.Src.Infra.Http.Filters.Handlers
{
    public abstract class ExceptionHandler
    {
        public abstract void Handle(ActionExecutedContext context);

        protected void DefaultHandler(ActionExecutedContext context)
        {
            context.Result = new ObjectResult(new ErrorResponse())
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
            context.ExceptionHandled = true;

            return;
        }
    }
}
