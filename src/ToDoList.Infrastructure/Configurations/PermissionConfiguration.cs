using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Domain.Users;

namespace ToDoList.Infrastructure.Configurations;

public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.ToTable(nameof(Permission));
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).IsRequired().HasMaxLength(30);
        builder.Property(x => x.Description).IsRequired().HasMaxLength(400);

        builder.HasData(
            Permission.ManageUsers,
            Permission.CreateTask,
            Permission.ReadTask,
            Permission.UpdateTask,
            Permission.DeleteTask);
    }
}