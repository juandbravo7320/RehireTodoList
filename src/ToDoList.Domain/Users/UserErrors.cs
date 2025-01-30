using ToDoList.Domain.Abstractions;

namespace ToDoList.Domain.Users;

public static class UserErrors
{
    public static Error NotFound = new(
        "User.Found",
        "The user with the specified identifier was not found");
    
    public static Error EmailAlreadyExist = new(
        "User.EmailAlreadyExist",
        "The email address is already in use");
}