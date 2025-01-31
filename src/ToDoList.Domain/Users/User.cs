using ToDoList.Domain.Abstractions;

namespace ToDoList.Domain.Users;

public sealed class User : Entity
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public string PasswordHash { get; set; }
    public string Username { get; private set; }

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

    public void Update(
        string firstName,
        string lastname,
        string username)
    {
        if (FirstName == firstName && 
            LastName == lastname && 
            Username == username) return;
        
        FirstName = firstName;
        LastName = lastname;
        Username = username;
    }
}