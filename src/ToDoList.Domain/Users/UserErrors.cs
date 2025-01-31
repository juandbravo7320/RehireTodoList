using ToDoList.Domain.Abstractions;

namespace ToDoList.Domain.Users;

public static class UserErrors
{
    public static Error NotFound = new(
        "User.NotFound",
        "The user with the specified identifier was not found");
    
    public static Error EmailAlreadyExist = new(
        "User.EmailAlreadyExist",
        "The email address is already in use");
    
    public static Error IncorrectCredentials = new(
        "User.IncorrectCredentials",
        "The email address or password is incorrect");
    
    public static Error RoleNotFound = new(
        "User.Role.NotFound",
        "The role with the specified identifier was not found");
}