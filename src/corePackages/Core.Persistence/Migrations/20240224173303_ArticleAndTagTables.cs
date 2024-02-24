using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ArticleAndTagTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("deaf24d2-1aeb-4cbb-815f-e0c07f707bc2"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("53d61cc4-d55e-4ec3-8f9b-74fc17b4eecf"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("751482fa-5642-4dc8-9db0-9714b5e14c43"));

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ViewCount = table.Column<int>(type: "int", nullable: false),
                    CommentCount = table.Column<int>(type: "int", nullable: false),
                    SeoAuthor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SeoDescription = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Articles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    ArticleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_Tags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tags_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "ModifiedBy", "ModifiedDate", "Name", "Status" },
                values: new object[] { new Guid("3b7e5d76-f724-49f2-8487-3e53a99afc7b"), "Admin", new DateTime(2024, 2, 24, 20, 33, 0, 139, DateTimeKind.Local).AddTicks(1497), null, null, null, "Admin", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedBy", "CreatedDate", "CultureType", "DeletedDate", "Email", "FirstName", "LastName", "ModifiedBy", "ModifiedDate", "PasswordHash", "PasswordSalt", "Status" },
                values: new object[] { new Guid("6412d162-bf41-4b02-a199-df89b82d25de"), 0, "Admin", new DateTime(2024, 2, 24, 20, 33, 0, 141, DateTimeKind.Local).AddTicks(8419), 0, null, "admin@admin.com", "Admin", "Admin", null, null, new byte[] { 149, 69, 175, 114, 181, 21, 141, 203, 239, 203, 116, 190, 4, 54, 224, 196, 146, 169, 81, 234, 37, 12, 170, 158, 13, 137, 137, 195, 244, 197, 7, 61, 202, 198, 173, 102, 231, 234, 228, 211, 91, 21, 142, 94, 140, 127, 120, 129, 124, 148, 194, 116, 53, 60, 127, 200, 54, 21, 182, 16, 158, 129, 102, 189 }, new byte[] { 198, 125, 125, 95, 198, 49, 124, 194, 20, 41, 40, 117, 21, 56, 167, 28, 192, 101, 55, 127, 211, 248, 114, 183, 168, 205, 82, 180, 8, 77, 38, 184, 128, 164, 204, 104, 130, 112, 64, 128, 137, 9, 158, 112, 243, 50, 233, 91, 123, 205, 236, 186, 187, 109, 189, 115, 56, 114, 151, 112, 141, 193, 219, 132, 156, 232, 68, 243, 120, 97, 51, 33, 228, 96, 164, 222, 122, 70, 120, 92, 109, 144, 216, 20, 174, 52, 222, 132, 94, 192, 7, 160, 183, 50, 66, 153, 44, 232, 238, 68, 39, 246, 209, 31, 17, 6, 253, 106, 241, 142, 191, 233, 117, 183, 211, 101, 249, 133, 2, 61, 4, 32, 208, 67, 246, 39, 221, 28 }, 1 });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "ModifiedBy", "ModifiedDate", "OperationClaimId", "Status", "UserId" },
                values: new object[] { new Guid("1d3cbe95-f329-4044-8704-8efe433d9ee0"), "Admin", new DateTime(2024, 2, 24, 20, 33, 0, 142, DateTimeKind.Local).AddTicks(8442), null, null, null, new Guid("3b7e5d76-f724-49f2-8487-3e53a99afc7b"), 1, new Guid("6412d162-bf41-4b02-a199-df89b82d25de") });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_CategoryId",
                table: "Articles",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Articles_UserId",
                table: "Articles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_ArticleId",
                table: "Tags",
                column: "ArticleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("1d3cbe95-f329-4044-8704-8efe433d9ee0"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("3b7e5d76-f724-49f2-8487-3e53a99afc7b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6412d162-bf41-4b02-a199-df89b82d25de"));

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "ModifiedBy", "ModifiedDate", "Name", "Status" },
                values: new object[] { new Guid("53d61cc4-d55e-4ec3-8f9b-74fc17b4eecf"), "Admin", new DateTime(2024, 2, 13, 17, 43, 28, 190, DateTimeKind.Local).AddTicks(7867), null, null, null, "Admin", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedBy", "CreatedDate", "CultureType", "DeletedDate", "Email", "FirstName", "LastName", "ModifiedBy", "ModifiedDate", "PasswordHash", "PasswordSalt", "Status" },
                values: new object[] { new Guid("751482fa-5642-4dc8-9db0-9714b5e14c43"), 0, "Admin", new DateTime(2024, 2, 13, 17, 43, 28, 203, DateTimeKind.Local).AddTicks(3585), 0, null, "admin@admin.com", "Admin", "Admin", null, null, new byte[] { 222, 235, 191, 112, 161, 223, 198, 37, 92, 225, 41, 38, 84, 50, 127, 233, 49, 251, 45, 203, 170, 60, 109, 47, 7, 109, 242, 40, 151, 51, 89, 47, 76, 159, 144, 51, 66, 6, 34, 130, 53, 61, 83, 220, 151, 118, 121, 68, 65, 193, 135, 151, 27, 50, 26, 54, 17, 97, 91, 205, 230, 38, 158, 112 }, new byte[] { 6, 0, 170, 230, 221, 106, 44, 69, 254, 181, 107, 135, 54, 208, 186, 120, 200, 228, 92, 98, 218, 159, 133, 55, 25, 136, 12, 203, 102, 101, 98, 152, 63, 52, 248, 35, 22, 219, 86, 35, 5, 206, 140, 95, 73, 165, 127, 182, 235, 73, 64, 217, 135, 190, 19, 75, 143, 179, 1, 166, 198, 77, 78, 46, 167, 229, 139, 214, 51, 120, 249, 131, 200, 33, 47, 222, 235, 10, 122, 221, 73, 219, 108, 201, 238, 230, 193, 125, 131, 255, 49, 160, 119, 135, 164, 115, 103, 188, 157, 7, 154, 93, 148, 167, 12, 53, 166, 31, 162, 79, 236, 92, 112, 18, 244, 113, 79, 232, 134, 162, 95, 87, 240, 45, 37, 67, 172, 185 }, 1 });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "ModifiedBy", "ModifiedDate", "OperationClaimId", "Status", "UserId" },
                values: new object[] { new Guid("deaf24d2-1aeb-4cbb-815f-e0c07f707bc2"), "Admin", new DateTime(2024, 2, 13, 17, 43, 28, 203, DateTimeKind.Local).AddTicks(8832), null, null, null, new Guid("53d61cc4-d55e-4ec3-8f9b-74fc17b4eecf"), 1, new Guid("751482fa-5642-4dc8-9db0-9714b5e14c43") });
        }
    }
}
