namespace concord_users.Src.Infra.Http.Dtos
{
    public class ErrorResponse
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public DateTime Timestamp { get; }

        public ErrorResponse()
        {
            StatusCode = StatusCodes.Status500InternalServerError;
            Message = "An internal error has ocurred";
            Timestamp = DateTime.Now;
        }

        public ErrorResponse(string message)
        {
            Message = message;
            Timestamp = DateTime.Now;
        }

        public ErrorResponse(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
            Timestamp = DateTime.Now;
        }
    }
}
