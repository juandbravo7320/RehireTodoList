using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Abstractions;
using ToDoList.Domain.Users;
using Task = ToDoList.Domain.Tasks.Task;

namespace ToDoList.Infrastructure;

public sealed class ApplicationDbContext(DbContextOptions options) : DbContext(options), IUnitOfWork
{
    internal DbSet<User> Users { get; set; }
    internal DbSet<Role> Roles { get; set; }
    internal DbSet<Permission> Permissions { get; set; }
    internal DbSet<UserPermission> UserPermissions { get; set; }
    internal DbSet<RolePermission> RolePermissions { get; set; }
    internal DbSet<Task> Tasks { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}