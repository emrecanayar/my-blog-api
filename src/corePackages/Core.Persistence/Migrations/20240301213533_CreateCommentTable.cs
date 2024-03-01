using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreateCommentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("1c5decf2-cf7d-4553-838b-53fa5eee4573"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("dbcf0471-5852-47bd-b3ef-65ca7d440257"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9ed31b90-87a7-43b1-bc71-bb83a905fbf9"));

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AuthorName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AuthorEmail = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    AuhorWebsite = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Content = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    DatePosted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SendNewPosts = table.Column<bool>(type: "bit", nullable: false),
                    SendNewComments = table.Column<bool>(type: "bit", nullable: false),
                    RememberMe = table.Column<bool>(type: "bit", nullable: false),
                    ArticleId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 250, nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 250, nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    CreatedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "ModifiedBy", "ModifiedDate", "Name", "Status" },
                values: new object[] { new Guid("e41b2335-290e-4c49-a88c-8366cf928375"), "Admin", new DateTime(2024, 3, 2, 0, 35, 28, 701, DateTimeKind.Local).AddTicks(4028), null, null, null, "Admin", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedBy", "CreatedDate", "CultureType", "DeletedDate", "Email", "FirstName", "LastName", "ModifiedBy", "ModifiedDate", "PasswordHash", "PasswordSalt", "Status" },
                values: new object[] { new Guid("19afb672-bf92-47b0-ac84-2997c4320245"), 0, "Admin", new DateTime(2024, 3, 2, 0, 35, 28, 703, DateTimeKind.Local).AddTicks(6834), 0, null, "admin@admin.com", "Admin", "Admin", null, null, new byte[] { 28, 132, 218, 157, 95, 180, 241, 123, 243, 210, 251, 108, 128, 91, 54, 34, 5, 104, 176, 212, 20, 230, 106, 138, 65, 38, 91, 22, 167, 206, 234, 186, 85, 63, 144, 148, 119, 144, 9, 244, 248, 242, 201, 15, 57, 174, 15, 109, 213, 177, 159, 108, 170, 124, 208, 201, 44, 242, 250, 150, 147, 72, 242, 239 }, new byte[] { 225, 163, 85, 56, 95, 214, 204, 123, 9, 231, 16, 2, 207, 216, 136, 90, 230, 44, 249, 9, 114, 68, 58, 9, 20, 70, 26, 178, 135, 220, 6, 35, 143, 151, 252, 199, 6, 156, 90, 188, 86, 38, 95, 155, 166, 149, 82, 105, 54, 209, 105, 187, 91, 144, 92, 131, 93, 19, 79, 25, 126, 215, 172, 243, 193, 57, 75, 131, 133, 95, 147, 79, 119, 77, 214, 13, 182, 103, 37, 112, 101, 168, 4, 97, 207, 129, 128, 188, 44, 105, 55, 81, 182, 46, 126, 18, 130, 237, 23, 248, 14, 147, 12, 173, 192, 83, 28, 254, 110, 148, 15, 248, 25, 2, 246, 160, 14, 148, 106, 55, 3, 173, 78, 60, 60, 156, 177, 134 }, 1 });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "ModifiedBy", "ModifiedDate", "OperationClaimId", "Status", "UserId" },
                values: new object[] { new Guid("827de17a-7223-4246-bda9-7f6caaeec155"), "Admin", new DateTime(2024, 3, 2, 0, 35, 28, 704, DateTimeKind.Local).AddTicks(4928), null, null, null, new Guid("e41b2335-290e-4c49-a88c-8366cf928375"), 1, new Guid("19afb672-bf92-47b0-ac84-2997c4320245") });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ArticleId",
                table: "Comments",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("827de17a-7223-4246-bda9-7f6caaeec155"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("e41b2335-290e-4c49-a88c-8366cf928375"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("19afb672-bf92-47b0-ac84-2997c4320245"));

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "ModifiedBy", "ModifiedDate", "Name", "Status" },
                values: new object[] { new Guid("dbcf0471-5852-47bd-b3ef-65ca7d440257"), "Admin", new DateTime(2024, 3, 1, 16, 3, 25, 747, DateTimeKind.Local).AddTicks(6932), null, null, null, "Admin", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedBy", "CreatedDate", "CultureType", "DeletedDate", "Email", "FirstName", "LastName", "ModifiedBy", "ModifiedDate", "PasswordHash", "PasswordSalt", "Status" },
                values: new object[] { new Guid("9ed31b90-87a7-43b1-bc71-bb83a905fbf9"), 0, "Admin", new DateTime(2024, 3, 1, 16, 3, 25, 749, DateTimeKind.Local).AddTicks(5843), 0, null, "admin@admin.com", "Admin", "Admin", null, null, new byte[] { 177, 199, 239, 65, 223, 188, 148, 143, 2, 77, 46, 213, 41, 234, 37, 253, 130, 57, 27, 195, 134, 175, 125, 139, 252, 78, 84, 175, 85, 72, 38, 22, 68, 174, 50, 64, 50, 154, 245, 128, 191, 101, 190, 194, 214, 27, 207, 63, 151, 16, 177, 34, 160, 26, 209, 253, 32, 192, 13, 145, 187, 188, 207, 30 }, new byte[] { 74, 93, 194, 98, 95, 61, 96, 22, 231, 3, 73, 234, 173, 76, 37, 224, 112, 177, 155, 6, 201, 85, 178, 121, 252, 253, 28, 55, 220, 194, 51, 84, 36, 98, 32, 73, 31, 26, 252, 93, 178, 194, 163, 43, 89, 228, 222, 45, 187, 36, 10, 163, 40, 46, 114, 77, 165, 48, 241, 56, 137, 17, 151, 153, 220, 99, 125, 107, 101, 40, 1, 36, 132, 109, 165, 185, 44, 6, 15, 161, 125, 100, 79, 57, 246, 68, 254, 132, 69, 203, 12, 250, 244, 220, 11, 157, 19, 195, 109, 98, 198, 211, 38, 197, 231, 64, 102, 72, 87, 194, 74, 77, 38, 61, 131, 12, 72, 242, 61, 169, 39, 240, 78, 56, 17, 184, 35, 109 }, 1 });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "ModifiedBy", "ModifiedDate", "OperationClaimId", "Status", "UserId" },
                values: new object[] { new Guid("1c5decf2-cf7d-4553-838b-53fa5eee4573"), "Admin", new DateTime(2024, 3, 1, 16, 3, 25, 750, DateTimeKind.Local).AddTicks(3782), null, null, null, new Guid("dbcf0471-5852-47bd-b3ef-65ca7d440257"), 1, new Guid("9ed31b90-87a7-43b1-bc71-bb83a905fbf9") });
        }
    }
}
