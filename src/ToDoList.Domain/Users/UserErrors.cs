using ToDoList.Domain.Abstractions;

namespace ToDoList.Domain.Users;

public static class UserErrors
{
    public static Error NotFound = new(
        "Booking.Found",
        "The user with the specified identifier was not found");
}