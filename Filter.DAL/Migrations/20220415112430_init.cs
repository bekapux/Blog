using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Blog.DAL.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    PermissionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PermissionName = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    PermissionActionName = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: true),
                    PermissionDateCreated = table.Column<string>(type: "nchar(10)", fixedLength: true, maxLength: 10, nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.PermissionID);
                });

            migrationBuilder.CreateTable(
                name: "PostCategories",
                columns: table => new
                {
                    PostCategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostCategoryParentID = table.Column<int>(type: "int", nullable: true),
                    PostCategoryName = table.Column<string>(type: "nvarchar(70)", maxLength: 70, nullable: true),
                    PostCategoryDateCreated = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostCategories", x => x.PostCategoryID);
                    table.ForeignKey(
                        name: "FK_PostCategories_PostCategories",
                        column: x => x.PostCategoryParentID,
                        principalTable: "PostCategories",
                        principalColumn: "PostCategoryID");
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    RoleDateCreated = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleID);
                });

            migrationBuilder.CreateTable(
                name: "RolesPermissions",
                columns: table => new
                {
                    RolePermissionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleID = table.Column<int>(type: "int", nullable: false),
                    PermissionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolesPermissions", x => x.RolePermissionID);
                    table.ForeignKey(
                        name: "FK_RolesPermissions_Permissions",
                        column: x => x.PermissionID,
                        principalTable: "Permissions",
                        principalColumn: "PermissionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolesPermissions_Roles",
                        column: x => x.RoleID,
                        principalTable: "Roles",
                        principalColumn: "RoleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    UserFirstname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UserLastname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UserEmail = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    UserPhoneNumber = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    UserPasswordHashed = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    UserDateCreated = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "(getdate())"),
                    UserDeleted = table.Column<bool>(type: "bit", nullable: false),
                    UserRoleID = table.Column<int>(type: "int", nullable: true),
                    UserHasConfirmedEmail = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Users_Roles",
                        column: x => x.UserRoleID,
                        principalTable: "Roles",
                        principalColumn: "RoleID");
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostTitle = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PostShortVersion = table.Column<string>(type: "nvarchar(400)", maxLength: 400, nullable: true),
                    PostFullVersion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostCategoryID = table.Column<int>(type: "int", nullable: true),
                    PostAuthorUserID = table.Column<int>(type: "int", nullable: false),
                    PostIsVisible = table.Column<bool>(type: "bit", nullable: false),
                    PostDateCreated = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostID);
                    table.ForeignKey(
                        name: "FK_Posts_PostCategories",
                        column: x => x.PostCategoryID,
                        principalTable: "PostCategories",
                        principalColumn: "PostCategoryID");
                    table.ForeignKey(
                        name: "FK_Posts_Users",
                        column: x => x.PostAuthorUserID,
                        principalTable: "Users",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateTable(
                name: "PostComments",
                columns: table => new
                {
                    PostCommentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostComment = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    PostCommentPostID = table.Column<int>(type: "int", nullable: false),
                    PostCommentIsVisible = table.Column<bool>(type: "bit", nullable: false),
                    PostDateCreated = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostComments", x => x.PostCommentID);
                    table.ForeignKey(
                        name: "FK_PostComments_Posts",
                        column: x => x.PostCommentPostID,
                        principalTable: "Posts",
                        principalColumn: "PostID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostCategories_PostCategoryParentID",
                table: "PostCategories",
                column: "PostCategoryParentID");

            migrationBuilder.CreateIndex(
                name: "IX_PostComments_PostCommentPostID",
                table: "PostComments",
                column: "PostCommentPostID");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_PostAuthorUserID",
                table: "Posts",
                column: "PostAuthorUserID");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_PostCategoryID",
                table: "Posts",
                column: "PostCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_RolesPermissions_PermissionID",
                table: "RolesPermissions",
                column: "PermissionID");

            migrationBuilder.CreateIndex(
                name: "IX_RolesPermissions_RoleID",
                table: "RolesPermissions",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserRoleID",
                table: "Users",
                column: "UserRoleID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostComments");

            migrationBuilder.DropTable(
                name: "RolesPermissions");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "PostCategories");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
