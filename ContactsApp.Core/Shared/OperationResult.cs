namespace ContactsApp.Core.Shared
{
    public sealed record OperationResult<T>(
        OperationStatus Status,
        T? Output = default,
        string? ErrorMessage = null
    )
    {
        public static OperationResult<T> Success(T output) => 
            new(OperationStatus.Success, output, null);
        public static OperationResult<T> Failure(string? errorMessage) => 
            new(OperationStatus.Failure, default, errorMessage);
        public static OperationResult<T> ValidationError(string? errorMessage) =>
            new(OperationStatus.ValidationError, default, errorMessage);
        public static OperationResult<T> NotFound(string? errorMessage = null) =>
            new(OperationStatus.NotFound, default, errorMessage);
        public static OperationResult<T> NeedsConfirmation(string? errorMessage = null) =>
            new(OperationStatus.NeedsConfirmation, default, errorMessage);
    }

    public enum OperationStatus
    {
        Success,
        Failure,
        NotFound,
        ValidationError,
        NeedsConfirmation
    }
}