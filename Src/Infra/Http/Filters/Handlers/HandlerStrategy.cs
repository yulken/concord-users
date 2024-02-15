using concord_users.Src.Domain.Exceptions;

namespace concord_users.Src.Infra.Http.Filters.Handlers
{
    public class HandlerStrategy
    {
        private readonly Dictionary<Type, ExceptionHandler> _handlers;

        public HandlerStrategy()
        {
            _handlers = [];
            _handlers.Add(typeof(ConflictingDataException), new ConflictingDataHandler());
        }


        public ExceptionHandler GetStrategy(Exception exception)
        {
            try
            {
                return _handlers[exception.GetType()];
            }catch (Exception)
            {
                return new InternalExceptionHandler();
            }
        }


    }
}
