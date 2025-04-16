namespace Timealonia.Core.Utilities;

public static class EnumerableExtensions
{
    public static Option<T> FirstOrNone<T>(this IEnumerable<T> source) where T : class
    {
        using var enumerator = source.GetEnumerator();
        if (enumerator.MoveNext())
        {
            return Option<T>.Some(enumerator.Current);
        }
        return Option<T>.None();
    }
    
    public static Option<T> FirstOrNone<T>(this IEnumerable<T> source, Func<T, bool> predicate) where T : class
    {
        foreach (var item in source)
        {
            if (predicate(item))
            {
                return Option<T>.Some(item);
            }
        }
        return Option<T>.None();
    }
    
    public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
    {
        foreach (var item in source)
        {
            action(item);
        }
    }
}