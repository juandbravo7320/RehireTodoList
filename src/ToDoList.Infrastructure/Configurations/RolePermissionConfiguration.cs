using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Domain.Users;

namespace ToDoList.Infrastructure.Configurations;

public class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermission>
{
    public void Configure(EntityTypeBuilder<RolePermission> builder)
    {
        builder.ToTable(nameof(RolePermission));
        builder.HasKey(x => new { x.RoleId, x.PermissionId });
        
        builder.HasOne(x => x.Role)
            .WithMany(x => x.RolePermissions)
            .HasForeignKey(x => x.RoleId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(x => x.Permission)
            .WithMany()
            .HasForeignKey(x => x.PermissionId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasData(
            // Admin Role Permissions
            new RolePermission(
                Guid.Parse("d2b3fb32-95c1-4703-aec2-c98a36762138"),
                Guid.Parse("ebd92069-30cd-4d60-8ac2-9fa5fd384ed5")),
            new RolePermission(
                Guid.Parse("d2b3fb32-95c1-4703-aec2-c98a36762138"),
                Guid.Parse("d2b3fb32-95c1-4703-aec2-c98a36762138")),
            new RolePermission(
                Guid.Parse("d2b3fb32-95c1-4703-aec2-c98a36762138"),
                Guid.Parse("2ee1b98c-3aac-4eba-aaa6-210c6a4133a3")),
            new RolePermission(
                Guid.Parse("d2b3fb32-95c1-4703-aec2-c98a36762138"),
                Guid.Parse("c0161d02-d8df-491b-b8c0-78eafaaf3b1c")),
            new RolePermission(
                Guid.Parse("d2b3fb32-95c1-4703-aec2-c98a36762138"),
                Guid.Parse("61c1c4e4-468f-4825-8097-4e0611304c85")),
        
            // Level 2 Role Permissions
            new RolePermission(
                    Guid.Parse("f55cbc28-01c4-427d-9a40-ed271472da7d"),
                    Guid.Parse("d2b3fb32-95c1-4703-aec2-c98a36762138")),
            new RolePermission(
                    Guid.Parse("f55cbc28-01c4-427d-9a40-ed271472da7d"),
                    Guid.Parse("2ee1b98c-3aac-4eba-aaa6-210c6a4133a3")),
            new RolePermission(
                    Guid.Parse("f55cbc28-01c4-427d-9a40-ed271472da7d"),
                    Guid.Parse("c0161d02-d8df-491b-b8c0-78eafaaf3b1c")),
            new RolePermission(
                    Guid.Parse("f55cbc28-01c4-427d-9a40-ed271472da7d"),
                    Guid.Parse("61c1c4e4-468f-4825-8097-4e0611304c85")),
            
            // Level 1 Role Permissions
            new RolePermission(
                    Guid.Parse("cce065f9-acb8-429d-8deb-3e75f7b1e2a0"),
                    Guid.Parse("d2b3fb32-95c1-4703-aec2-c98a36762138")),
            new RolePermission(
                    Guid.Parse("cce065f9-acb8-429d-8deb-3e75f7b1e2a0"),
                    Guid.Parse("2ee1b98c-3aac-4eba-aaa6-210c6a4133a3"))
        );
    }
}