using ToDoList.Domain.Abstractions;

namespace ToDoList.Domain.Tasks;

public static class TaskErrors
{
    public static Error NotFound = new(
        "Booking.Found",
        "The task with the specified identifier was not found");
}