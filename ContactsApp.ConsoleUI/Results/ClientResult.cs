public record ClientResult<T>(bool IsSuccess, T? Data = default, string? ErrorMessage = null)
{
    public static ClientResult<T> Success(T data) => new(true, data);
    public static ClientResult<T> Failure(string error) => new(false, default, error);
}