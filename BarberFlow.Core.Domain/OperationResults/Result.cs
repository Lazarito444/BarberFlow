namespace BarberFlow.Core.Domain.OperationResults;

public class Result<T>
    where T : class
{
    public bool IsSuccess { get; init; }

    public bool IsFailure => !IsSuccess;

    public T? Data { get; init; }

    public string? ErrorMessage { get; init; }

    public static Result<T> Success(T data) => new()
    {
        IsSuccess = true,
        Data = data
    };

    public static Result<T> Failure(string errorMessage) => new()
    {
        IsSuccess = false,
        ErrorMessage = errorMessage
    };
}
