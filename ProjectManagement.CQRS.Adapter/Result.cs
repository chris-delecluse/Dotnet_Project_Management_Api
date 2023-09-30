namespace ProjectManagement.CQRS.Adapter;

public class Result<TData>
{
    public bool IsSuccess { get; init; }
    public TData? Data { get; init; }
    public string? ErrorMessage { get; init; }
    
    private Result(bool isSuccess, TData? data, string? errorMessage)
    {
        IsSuccess = isSuccess;
        Data = data;
        ErrorMessage = errorMessage;
    }

    public static Result<TData> Success(TData data) => new(true, data, null);

    public static Result<TData> Failure(string errorMessage) => new(false, default, errorMessage);
}
