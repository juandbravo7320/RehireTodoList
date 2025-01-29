using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Domain.Users;

namespace ToDoList.Infrastructure.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(150);
        
        builder.HasData(
            new Role(
            Guid.Parse("d2b3fb32-95c1-4703-aec2-c98a36762138"),
            "Admin", 
            "Has full access to the application, including managing users, assigning roles, and performing all task-related actions (create, read, update, and delete). Admins can also configure system settings and oversee overall application functionality."),
            
            new Role(
            Guid.Parse("f55cbc28-01c4-427d-9a40-ed271472da7d"),
            "Level 2", 
            "Has advanced permissions, allowing them to create, read, update, and delete tasks. However, they do not have administrative privileges such as user management or system settings modification."),
            
            new Role(
            Guid.Parse("cce065f9-acb8-429d-8deb-3e75f7b1e2a0"),
            "Level 1",
            "Has basic permissions, typically limited to creating and reading their own tasks. Level 1 users do not have the ability to update or delete tasks, nor can they manage other users or system settings.")
            
        );
    }
}