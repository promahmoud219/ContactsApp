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
    public record ClientResult<T>( 
        bool IsSuccess,
        HttpStatusCode StatusCode,
        T? Data = default, 
        string? ErrorMessage = null,
        ClientErrorType ErrorType = ClientErrorType.None
    )
    {
        public static ClientResult<T> Success(HttpStatusCode code, T data) => new(true, code, data);

        // this is for cases where we want to indicate success but don't have data to return, e.g. after a successful delete operation
        public static ClientResult<T> Success(HttpStatusCode code) => new(true, code);
        
        public static ClientResult<T> Failure(HttpStatusCode code, string error, ClientErrorType errorType) => new(false, code, default, error, errorType);
    }
}