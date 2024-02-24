using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ArticleUploadedFileTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "ArticleUploadedFiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArticleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UploadedFileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OldPath = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    NewPath = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
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
                    table.PrimaryKey("PK_ArticleUploadedFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticleUploadedFiles_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleUploadedFiles_UploadedFiles_UploadedFileId",
                        column: x => x.UploadedFileId,
                        principalTable: "UploadedFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "ModifiedBy", "ModifiedDate", "Name", "Status" },
                values: new object[] { new Guid("b2aef235-58da-4dda-97bc-68f6aec2c096"), "Admin", new DateTime(2024, 2, 24, 21, 37, 6, 272, DateTimeKind.Local).AddTicks(1974), null, null, null, "Admin", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedBy", "CreatedDate", "CultureType", "DeletedDate", "Email", "FirstName", "LastName", "ModifiedBy", "ModifiedDate", "PasswordHash", "PasswordSalt", "Status" },
                values: new object[] { new Guid("c70cd0e4-a393-4139-b4c9-cb2b7bc3dd02"), 0, "Admin", new DateTime(2024, 2, 24, 21, 37, 6, 275, DateTimeKind.Local).AddTicks(8941), 0, null, "admin@admin.com", "Admin", "Admin", null, null, new byte[] { 31, 226, 135, 76, 159, 161, 246, 195, 159, 167, 113, 66, 28, 98, 156, 218, 133, 230, 156, 86, 153, 66, 210, 192, 113, 44, 251, 156, 147, 202, 135, 70, 92, 100, 165, 193, 233, 175, 100, 115, 76, 231, 143, 122, 229, 51, 54, 189, 15, 34, 99, 79, 139, 112, 171, 129, 85, 165, 217, 7, 27, 82, 84, 230 }, new byte[] { 12, 48, 31, 169, 141, 42, 112, 22, 211, 157, 166, 56, 216, 137, 137, 114, 241, 94, 238, 45, 170, 13, 71, 76, 50, 139, 28, 12, 18, 198, 6, 22, 104, 47, 192, 3, 122, 68, 74, 149, 165, 131, 208, 184, 183, 212, 12, 243, 248, 149, 182, 167, 9, 116, 163, 217, 54, 44, 131, 144, 63, 88, 62, 223, 212, 71, 253, 24, 14, 40, 109, 116, 1, 0, 78, 32, 234, 195, 128, 108, 32, 186, 236, 88, 153, 252, 115, 111, 90, 63, 139, 159, 107, 182, 233, 128, 115, 30, 55, 71, 26, 113, 31, 182, 245, 240, 183, 220, 179, 111, 126, 248, 65, 28, 143, 46, 141, 79, 75, 85, 90, 206, 203, 50, 244, 193, 251, 105 }, 1 });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "ModifiedBy", "ModifiedDate", "OperationClaimId", "Status", "UserId" },
                values: new object[] { new Guid("fcc8c9a2-f214-429b-8b0d-91ae5a4a8969"), "Admin", new DateTime(2024, 2, 24, 21, 37, 6, 277, DateTimeKind.Local).AddTicks(791), null, null, null, new Guid("b2aef235-58da-4dda-97bc-68f6aec2c096"), 1, new Guid("c70cd0e4-a393-4139-b4c9-cb2b7bc3dd02") });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleUploadedFiles_ArticleId",
                table: "ArticleUploadedFiles",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleUploadedFiles_UploadedFileId",
                table: "ArticleUploadedFiles",
                column: "UploadedFileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleUploadedFiles");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("fcc8c9a2-f214-429b-8b0d-91ae5a4a8969"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("b2aef235-58da-4dda-97bc-68f6aec2c096"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c70cd0e4-a393-4139-b4c9-cb2b7bc3dd02"));

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
        }
    }
}
