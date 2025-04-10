using Timealonia.Todos;

namespace Timealonia.TimeEntries;

public interface ITracker
{
    Todo Track(Todo todo);
    
    Todo Stop(Todo todo);
    
    IEnumerable<Todo> StopAll();
    
    IEnumerable<Todo> GetActivelyTrackedTodos();
}