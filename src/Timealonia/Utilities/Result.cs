namespace Timealonia.Utilities;

public class Result
{
    private readonly string? _error;
    
    public string Error 
    {
        get
        {
            if (IsSuccess)
                throw new InvalidOperationException("Cannot access Error when Result is successful.");
            return _error!;
        }
    }
    public bool IsSuccess { get; }

    protected Result(string? error, bool isSuccess)
    {
        if (!isSuccess && error is null)
            throw new ArgumentException("Error cannot be null when Result is not successful.");
        _error = error;
        IsSuccess = isSuccess;
    }

    public static Result Success() => new(null, true);
    public static Result Fail(string error) => new(error, false);
    
    public static implicit operator Result(string error)
    {
        return Fail(error);
    }
}

public class Result<T> : Result
    where T : class
{
    private readonly T? _value;
    public T Value 
    {
        get
        {
            if (!IsSuccess)
                throw new InvalidOperationException("Cannot access Value when Result is not successful.");
            return _value!;
        }
    }

    private Result(T? value, string? error, bool isSuccess) : base(error, isSuccess)
    {
        if (value is null && isSuccess)
            throw new ArgumentException("Value cannot be null when Result is successful.");
        _value = value;
    }

    public static Result<T> Success(T value) => new(value, null, true);
    public new static Result<T> Fail(string error) => new(null, error, false);
    
    public static implicit operator Result<T>(T value)
    {
        return Success(value);
    }
    public static implicit operator Result<T>(string error)
    {
        return Fail(error);
    }
}