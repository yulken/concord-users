using concord_users.Src.Infra.Http.Filters.Handlers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace concord_users.Src.Infra.Http.Filters
{
    public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        private readonly HandlerStrategy handler = new();
        public int Order => int.MaxValue - 10;

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception == null)
            {
                return;
            }

            handler.GetStrategy(context.Exception).Handle(context);
        }
    }
}
