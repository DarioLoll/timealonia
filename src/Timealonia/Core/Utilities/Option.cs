namespace Timealonia.Core.Utilities;

public class Option<T> where T : class
{
    public T? Value { get; private set; }
    
    public Option(T? value) 
    {
        Value = value;
    }
    
    public bool IsSome => Value != null;
    public bool IsNone => Value == null;
    
    public static Option<T> Some(T value) => new(value);
    public static Option<T> None() => new(null);
    
    public static implicit operator Option<T>(T? value) => new(value);
    
    public Option<T> Map(Func<T, T> func)
    {
        if (IsNone) return this;
        Value = func(Value!);
        return this;
    }
    
    public Option<T2> Map<T2>(Func<T, T2> func) where T2 : class
    {
        if (IsNone) return Option<T2>.None();
        return Option<T2>.Some(func(Value!));
    }
    
    public Option<T> Bind(Func<T, Option<T>> func)
    {
        if (IsNone) return this;
        return func(Value!);
    }
    
    public Option<T> Filter(Func<T, bool> predicate)
    {
        if (IsNone || !predicate(Value!)) return None();
        return this;
    }
    
    public T OrElse(T value)
    {
        if (IsSome) return Value!;
        return value;
    }
}