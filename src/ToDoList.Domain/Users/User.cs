using ToDoList.Domain.Abstractions;

namespace ToDoList.Domain.Users;

public sealed class User : Entity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string Username { get; set; }
    
    public ICollection<UserPermission> UserPermissions { get; }
    
    public User(
        Guid id,
        string firstName,
        string lastName,
        string email,
        string password,
        string username) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PasswordHash = password;
        Username = username;
    }

    public User Create(
        string firstName,
        string lastName,
        string email,
        string password,
        string username)
    {
        return new User(
            Guid.NewGuid(),
            firstName,
            lastName,
            email,
            password,
            username);
    }
}