using ToDoList.Domain.Abstractions;

namespace ToDoList.Domain.Tasks;

public static class TaskErrors
{
    public static Error NotFound = new(
        "Task.Found",
        "The task with the specified identifier was not found");
    
    public static Error NotOwner = new(
        "Task.NotOwner",
        "The task does not belong to the current user");
}