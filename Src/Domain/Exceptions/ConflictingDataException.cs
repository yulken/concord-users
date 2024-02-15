namespace concord_users.Src.Domain.Exceptions
{
    public class ConflictingDataException: Exception
    {
        public ConflictingDataException()
        {
        }

        public ConflictingDataException(string message)
            : base(message)
        {
        }

        public ConflictingDataException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
