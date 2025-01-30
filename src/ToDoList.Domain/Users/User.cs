using ToDoList.Domain.Abstractions;

namespace ToDoList.Domain.Users;

public sealed class User : Entity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string Username { get; set; }

    public Guid RoleId { get; set; }
    public Role Role { get; }

    public ICollection<UserPermission> UserPermissions { get; }
    
    public User(Guid id) : base(id)
    {
    }
    
    public User(
        Guid id,
        string firstName,
        string lastName,
        string email,
        string password,
        string username,
        Guid roleId) : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PasswordHash = password;
        Username = username;
        RoleId = roleId;
    }

    public static User Create(
        string firstName,
        string lastName,
        string email,
        string password,
        string username,
        Guid roleId)
    {
        return new User(
            Guid.NewGuid(),
            firstName,
            lastName,
            email,
            password,
            username,
            roleId);
    }
}