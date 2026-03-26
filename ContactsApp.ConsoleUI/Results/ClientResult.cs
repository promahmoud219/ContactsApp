using System.Net;

namespace ContactsApp.ConsoleUI.Results
{
    public sealed record NoContent;

    public enum ClientErrorType
    {
        None,
        Validation,
        NotFound,
        Unauthorized,
        ServerError,
        NetworkFailure,
        Timeout
    }

    public class ClientResult<T>
    {
        public bool IsSuccess { get; }
        public HttpStatusCode StatusCode { get; }
        public T? Data { get; }
        public string? ErrorMessage { get; }
        public ClientErrorType ErrorType { get; }

        private ClientResult(
            bool isSuccess,
            HttpStatusCode statusCode,
            T? data = default,
            string? errorMessage = null,
            ClientErrorType errorType = ClientErrorType.None)
        {
            IsSuccess = isSuccess;
            StatusCode = statusCode;
            Data = data;
            ErrorMessage = errorMessage;
            ErrorType = errorType;
        }

        public static ClientResult<T> Success(HttpStatusCode code, T data) =>
            new(true, code, data);

        public static ClientResult<T> Success(HttpStatusCode code) =>
            new(true, code);

        public static ClientResult<T> Failure(HttpStatusCode code, string error, ClientErrorType errorType) =>
            new(false, code, default, error, errorType);
    }
}