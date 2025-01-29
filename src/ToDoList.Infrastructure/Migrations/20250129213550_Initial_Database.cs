using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToDoList.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Permission",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "character varying(400)", maxLength: 400, nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    Username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RolePermission",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(type: "uuid", nullable: false),
                    PermissionId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermission", x => new { x.RoleId, x.PermissionId });
                    table.ForeignKey(
                        name: "FK_RolePermission_Permission_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePermission_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    OwnerId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Task_User_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserPermission",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    PermissionId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: false),
                    UpdatedAtUtc = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPermission", x => new { x.UserId, x.PermissionId });
                    table.ForeignKey(
                        name: "FK_UserPermission_User_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserPermission_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Permission",
                columns: new[] { "Id", "CreatedAtUtc", "CreatedBy", "Description", "Name", "UpdatedAtUtc", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("2ee1b98c-3aac-4eba-aaa6-210c6a4133a3"), new DateTime(2025, 1, 29, 21, 35, 50, 7, DateTimeKind.Utc).AddTicks(7560), "System", "Allows the user to view existing tasks, including their properties, and additional details.", "Read Task", null, null },
                    { new Guid("61c1c4e4-468f-4825-8097-4e0611304c85"), new DateTime(2025, 1, 29, 21, 35, 50, 7, DateTimeKind.Utc).AddTicks(7560), "System", "Allows the user to remove tasks from the list, either deleting a single task or multiple selected tasks.", "Delete Task", null, null },
                    { new Guid("c0161d02-d8df-491b-b8c0-78eafaaf3b1c"), new DateTime(2025, 1, 29, 21, 35, 50, 7, DateTimeKind.Utc).AddTicks(7560), "System", "Allows the user to modify existing tasks, including changing the description, status or any other task attributes", "Update Task", null, null },
                    { new Guid("d2b3fb32-95c1-4703-aec2-c98a36762138"), new DateTime(2025, 1, 29, 21, 35, 50, 7, DateTimeKind.Utc).AddTicks(7560), "System", "Allows the user to add new tasks to the list, assigning a description, and any other relevant details.", "Create Task", null, null },
                    { new Guid("ebd92069-30cd-4d60-8ac2-9fa5fd384ed5"), new DateTime(2025, 1, 29, 21, 35, 50, 7, DateTimeKind.Utc).AddTicks(7560), "System", "Allows the user to manage other users within the application. This includes creating new user accounts, updating user information, assigning or modifying roles and permissions, deactivating or deleting accounts, and overseeing user activity as needed. This permission is typically reserved for administrators or higher-level users.", "Manage Users", null, null }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "CreatedAtUtc", "CreatedBy", "Description", "Name", "UpdatedAtUtc", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("cce065f9-acb8-429d-8deb-3e75f7b1e2a0"), new DateTime(2025, 1, 29, 21, 35, 50, 7, DateTimeKind.Utc).AddTicks(8280), "System", "Has basic permissions, typically limited to creating and reading their own tasks. Level 1 users do not have the ability to update or delete tasks, nor can they manage other users or system settings.", "Level 1", null, null },
                    { new Guid("d2b3fb32-95c1-4703-aec2-c98a36762138"), new DateTime(2025, 1, 29, 21, 35, 50, 7, DateTimeKind.Utc).AddTicks(8280), "System", "Has full access to the application, including managing users, assigning roles, and performing all task-related actions (create, read, update, and delete). Admins can also configure system settings and oversee overall application functionality.", "Admin", null, null },
                    { new Guid("f55cbc28-01c4-427d-9a40-ed271472da7d"), new DateTime(2025, 1, 29, 21, 35, 50, 7, DateTimeKind.Utc).AddTicks(8280), "System", "Has advanced permissions, allowing them to create, read, update, and delete tasks. However, they do not have administrative privileges such as user management or system settings modification.", "Level 2", null, null }
                });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "PermissionId", "RoleId", "CreatedAtUtc", "CreatedBy", "UpdatedAtUtc", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("2ee1b98c-3aac-4eba-aaa6-210c6a4133a3"), new Guid("cce065f9-acb8-429d-8deb-3e75f7b1e2a0"), new DateTime(2025, 1, 29, 21, 35, 50, 8, DateTimeKind.Utc).AddTicks(8340), "System", null, null },
                    { new Guid("d2b3fb32-95c1-4703-aec2-c98a36762138"), new Guid("cce065f9-acb8-429d-8deb-3e75f7b1e2a0"), new DateTime(2025, 1, 29, 21, 35, 50, 8, DateTimeKind.Utc).AddTicks(8340), "System", null, null },
                    { new Guid("2ee1b98c-3aac-4eba-aaa6-210c6a4133a3"), new Guid("d2b3fb32-95c1-4703-aec2-c98a36762138"), new DateTime(2025, 1, 29, 21, 35, 50, 8, DateTimeKind.Utc).AddTicks(8330), "System", null, null },
                    { new Guid("61c1c4e4-468f-4825-8097-4e0611304c85"), new Guid("d2b3fb32-95c1-4703-aec2-c98a36762138"), new DateTime(2025, 1, 29, 21, 35, 50, 8, DateTimeKind.Utc).AddTicks(8330), "System", null, null },
                    { new Guid("c0161d02-d8df-491b-b8c0-78eafaaf3b1c"), new Guid("d2b3fb32-95c1-4703-aec2-c98a36762138"), new DateTime(2025, 1, 29, 21, 35, 50, 8, DateTimeKind.Utc).AddTicks(8330), "System", null, null },
                    { new Guid("d2b3fb32-95c1-4703-aec2-c98a36762138"), new Guid("d2b3fb32-95c1-4703-aec2-c98a36762138"), new DateTime(2025, 1, 29, 21, 35, 50, 8, DateTimeKind.Utc).AddTicks(8330), "System", null, null },
                    { new Guid("ebd92069-30cd-4d60-8ac2-9fa5fd384ed5"), new Guid("d2b3fb32-95c1-4703-aec2-c98a36762138"), new DateTime(2025, 1, 29, 21, 35, 50, 8, DateTimeKind.Utc).AddTicks(8330), "System", null, null },
                    { new Guid("2ee1b98c-3aac-4eba-aaa6-210c6a4133a3"), new Guid("f55cbc28-01c4-427d-9a40-ed271472da7d"), new DateTime(2025, 1, 29, 21, 35, 50, 8, DateTimeKind.Utc).AddTicks(8340), "System", null, null },
                    { new Guid("61c1c4e4-468f-4825-8097-4e0611304c85"), new Guid("f55cbc28-01c4-427d-9a40-ed271472da7d"), new DateTime(2025, 1, 29, 21, 35, 50, 8, DateTimeKind.Utc).AddTicks(8340), "System", null, null },
                    { new Guid("c0161d02-d8df-491b-b8c0-78eafaaf3b1c"), new Guid("f55cbc28-01c4-427d-9a40-ed271472da7d"), new DateTime(2025, 1, 29, 21, 35, 50, 8, DateTimeKind.Utc).AddTicks(8340), "System", null, null },
                    { new Guid("d2b3fb32-95c1-4703-aec2-c98a36762138"), new Guid("f55cbc28-01c4-427d-9a40-ed271472da7d"), new DateTime(2025, 1, 29, 21, 35, 50, 8, DateTimeKind.Utc).AddTicks(8330), "System", null, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_RolePermission_PermissionId",
                table: "RolePermission",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Task_OwnerId",
                table: "Task",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserPermission_PermissionId",
                table: "UserPermission",
                column: "PermissionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RolePermission");

            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "UserPermission");

            migrationBuilder.DropTable(
                name: "Permission");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
