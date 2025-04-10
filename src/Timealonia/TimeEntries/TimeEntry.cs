namespace Timealonia.TimeEntries;

public record TimeEntry(TimeSpan Duration, string Description)
{
    public static TimeEntry CreateConcrete(DateTimeOffset start, TimeSpan duration, string description = "")
    {
        return new ConcreteTimeEntry(start, duration, description);
    }
    
    public static TimeEntry Empty => new(TimeSpan.Zero, string.Empty);
    
    public static TimeEntry Create(TimeSpan duration, string description = "")
    {
        return new TimeEntry(duration, description);
    }
}

public record ConcreteTimeEntry(DateTimeOffset Start, TimeSpan Duration, string Description) 
    : TimeEntry(Duration, Description)
{
    public DateTimeOffset End => Start + Duration;
}