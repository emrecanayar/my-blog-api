using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreateEditorArticlePickTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EditorArticlePicks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_EditorArticlePicks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EditorArticlePicks_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EditorArticlePicks_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("19afb672-bf92-47b0-ac84-2997c4320245"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 37, 190, 235, 225, 235, 221, 193, 190, 8, 216, 7, 202, 142, 177, 32, 213, 226, 77, 169, 223, 203, 82, 119, 105, 191, 84, 198, 84, 149, 131, 193, 10, 193, 100, 62, 245, 228, 48, 109, 206, 65, 91, 14, 82, 212, 3, 239, 16, 26, 222, 248, 188, 92, 180, 105, 56, 82, 134, 26, 185, 130, 140, 204, 184 }, new byte[] { 37, 95, 131, 38, 238, 152, 130, 99, 107, 9, 67, 161, 197, 115, 172, 153, 120, 213, 126, 83, 173, 243, 53, 1, 33, 147, 79, 247, 180, 113, 66, 167, 221, 246, 9, 179, 201, 222, 196, 118, 153, 251, 228, 102, 235, 84, 79, 203, 157, 143, 223, 107, 147, 137, 246, 174, 152, 220, 21, 186, 56, 92, 66, 94, 5, 35, 37, 108, 119, 80, 197, 131, 75, 5, 229, 120, 119, 8, 15, 207, 210, 47, 105, 119, 111, 202, 135, 103, 19, 209, 157, 114, 184, 129, 220, 111, 213, 10, 64, 98, 57, 114, 140, 190, 180, 113, 180, 71, 16, 159, 94, 79, 149, 46, 136, 8, 6, 198, 175, 65, 163, 155, 136, 108, 39, 20, 121, 220 } });

            migrationBuilder.CreateIndex(
                name: "IX_EditorArticlePicks_ArticleId",
                table: "EditorArticlePicks",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_EditorArticlePicks_UserId",
                table: "EditorArticlePicks",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EditorArticlePicks");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("19afb672-bf92-47b0-ac84-2997c4320245"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 105, 148, 66, 190, 52, 99, 65, 184, 83, 100, 85, 107, 5, 97, 121, 104, 158, 3, 200, 84, 41, 155, 0, 50, 54, 214, 203, 145, 67, 128, 87, 106, 160, 193, 189, 16, 33, 198, 49, 42, 185, 108, 243, 7, 209, 89, 172, 248, 226, 12, 204, 242, 3, 70, 252, 133, 23, 58, 95, 139, 47, 237, 232, 120 }, new byte[] { 200, 7, 108, 87, 250, 88, 243, 237, 134, 14, 155, 248, 114, 202, 139, 169, 159, 89, 64, 241, 49, 41, 72, 83, 79, 27, 79, 138, 114, 217, 174, 62, 41, 188, 50, 38, 63, 159, 3, 55, 32, 14, 95, 47, 46, 183, 122, 129, 194, 249, 46, 9, 254, 142, 105, 182, 230, 145, 26, 117, 155, 92, 254, 100, 22, 0, 209, 81, 140, 178, 57, 1, 43, 152, 93, 0, 243, 188, 185, 164, 175, 228, 0, 239, 90, 86, 92, 60, 55, 207, 92, 126, 116, 184, 139, 227, 179, 160, 40, 104, 84, 22, 180, 250, 244, 237, 166, 1, 197, 183, 97, 164, 31, 78, 204, 59, 23, 152, 51, 22, 7, 251, 0, 174, 78, 238, 219, 149 } });
        }
    }
}
