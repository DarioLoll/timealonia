using System.Collections.Immutable;
using Timealonia.Core.TimeEntries;

namespace Timealonia.Core.Todos;

public record Todo(int Number, string Name, string Description, IImmutableList<TimeEntry> TimeEntries)
{
    public static Todo Empty => new(0, $"Task 0", string.Empty, ImmutableList<TimeEntry>.Empty);
    
    public static Todo Create(int number, string name, string description = "", IEnumerable<TimeEntry>? timeEntries = null)
    {
        return new Todo(number, name, description, timeEntries?.ToImmutableList() ?? ImmutableList<TimeEntry>.Empty);
    }
    
    public Todo AddTimeEntry(TimeEntry timeEntry)
    {
        return this with { TimeEntries = TimeEntries.Add(timeEntry) };
    }
    
    public Todo RemoveTimeEntry(TimeEntry timeEntry)
    {
        return this with { TimeEntries = TimeEntries.Remove(timeEntry) };
    }
}