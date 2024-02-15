using Microsoft.AspNetCore.Mvc.Filters;

namespace concord_users.Src.Infra.Http.Filters.Handlers
{
    public class InternalExceptionHandler : ExceptionHandler
    {
        public override void Handle(ActionExecutedContext context)
        {
            DefaultHandler(context);
        }
    }
}
