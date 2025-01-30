using ToDoList.Domain.Abstractions;

namespace ToDoList.Domain.Users;

public sealed class Permission : Entity
{
    public string Name { get; private set; }
    public string Description { get; private set; }

    public Permission(Guid id) : base(id)
    {
    }
    
    public Permission(
        Guid id,
        string name,
        string description) : base(id)
    {
        Name = name;
        Description = description;
    }
    
    // Seed Data
    
    public static readonly Permission ManageUsers = new(
        Guid.Parse("ebd92069-30cd-4d60-8ac2-9fa5fd384ed5"),
        "Manage Users",
        "Allows the user to manage other users within the application. This includes creating new user accounts, updating user information, assigning or modifying roles and permissions, deactivating or deleting accounts, and overseeing user activity as needed. This permission is typically reserved for administrators or higher-level users.");

    public static readonly Permission CreateTask = new(
        Guid.Parse("d2b3fb32-95c1-4703-aec2-c98a36762138"),
        "Create Task",
        "Allows the user to add new tasks to the list, assigning a description, and any other relevant details.");

    public static readonly Permission ReadTask = new(
        Guid.Parse("2ee1b98c-3aac-4eba-aaa6-210c6a4133a3"),
        "Read Task",
        "Allows the user to view existing tasks, including their properties, and additional details.");

    public static readonly Permission UpdateTask = new(
        Guid.Parse("c0161d02-d8df-491b-b8c0-78eafaaf3b1c"),
        "Update Task",
        "Allows the user to modify existing tasks, including changing the description, status or any other task attributes");

    public static readonly Permission DeleteTask = new(
        Guid.Parse("61c1c4e4-468f-4825-8097-4e0611304c85"),
        "Delete Task",
        "Allows the user to remove tasks from the list, either deleting a single task or multiple selected tasks.");
}