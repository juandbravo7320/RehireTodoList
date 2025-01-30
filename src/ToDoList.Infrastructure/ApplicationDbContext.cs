using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Abstractions;
using ToDoList.Domain.Users;
using Task = ToDoList.Domain.Tasks.Task;

namespace ToDoList.Infrastructure;

public sealed class ApplicationDbContext(DbContextOptions options) : DbContext(options), IUnitOfWork
{
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<UserPermission> UserPermissions { get; set; }
    public DbSet<RolePermission> RolePermissions { get; set; }
    public DbSet<Task> Tasks { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
    
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker
            .Entries();
        
        foreach (var entry in entries)
        {
            ((Entity)entry.Entity).UpdatedAtUtc = DateTime.UtcNow;

            if (entry.State == EntityState.Added)
            {
                ((Entity)entry.Entity).CreatedAtUtc = DateTime.UtcNow;
                ((Entity)entry.Entity).CreatedBy = "System";
            }
        }

        return await base.SaveChangesAsync(cancellationToken);
    }
}