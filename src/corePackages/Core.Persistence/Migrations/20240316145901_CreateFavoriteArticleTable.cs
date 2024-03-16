using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreateFavoriteArticleTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FavoriteArticles",
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
                    table.PrimaryKey("PK_FavoriteArticles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavoriteArticles_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FavoriteArticles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("19afb672-bf92-47b0-ac84-2997c4320245"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 228, 32, 168, 155, 25, 197, 69, 129, 213, 54, 194, 113, 253, 200, 44, 218, 206, 53, 17, 217, 229, 85, 224, 128, 94, 34, 212, 55, 204, 24, 151, 242, 138, 227, 85, 4, 235, 235, 230, 190, 15, 56, 157, 240, 120, 22, 104, 170, 129, 49, 186, 125, 18, 10, 249, 169, 180, 235, 216, 147, 201, 141, 130, 83 }, new byte[] { 166, 145, 199, 201, 252, 233, 243, 227, 206, 12, 101, 172, 37, 226, 212, 113, 185, 230, 216, 202, 27, 192, 123, 0, 210, 158, 200, 219, 22, 67, 16, 137, 120, 130, 70, 112, 235, 4, 109, 80, 83, 200, 58, 139, 12, 116, 102, 13, 120, 114, 67, 107, 244, 103, 212, 139, 146, 113, 171, 156, 107, 34, 87, 192, 167, 49, 11, 111, 250, 233, 64, 182, 151, 95, 185, 163, 15, 159, 200, 133, 115, 129, 187, 216, 160, 0, 7, 167, 87, 14, 237, 176, 39, 194, 222, 208, 152, 42, 180, 211, 185, 187, 64, 218, 68, 201, 237, 228, 81, 94, 193, 235, 71, 60, 142, 220, 62, 189, 118, 10, 239, 31, 140, 124, 46, 96, 104, 250 } });

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteArticles_ArticleId",
                table: "FavoriteArticles",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteArticles_UserId",
                table: "FavoriteArticles",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FavoriteArticles");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("19afb672-bf92-47b0-ac84-2997c4320245"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 60, 59, 17, 68, 235, 166, 173, 97, 126, 116, 148, 120, 228, 145, 247, 220, 229, 198, 112, 59, 78, 26, 157, 145, 238, 86, 15, 90, 10, 209, 212, 174, 10, 102, 192, 95, 251, 67, 121, 124, 197, 197, 28, 98, 102, 40, 223, 223, 86, 34, 81, 217, 113, 107, 74, 84, 209, 13, 224, 228, 90, 185, 68, 142 }, new byte[] { 152, 235, 104, 55, 87, 66, 154, 235, 5, 189, 116, 61, 101, 35, 165, 219, 165, 50, 148, 94, 221, 160, 232, 142, 109, 77, 38, 219, 50, 236, 137, 84, 132, 119, 150, 62, 96, 207, 193, 13, 116, 182, 142, 96, 213, 229, 110, 77, 209, 229, 20, 254, 85, 184, 79, 204, 104, 51, 236, 209, 45, 158, 124, 254, 30, 69, 36, 214, 218, 0, 155, 153, 147, 165, 22, 210, 40, 228, 51, 251, 207, 199, 198, 110, 81, 175, 79, 17, 8, 146, 53, 11, 12, 95, 201, 75, 186, 210, 39, 123, 10, 36, 36, 143, 131, 97, 12, 37, 211, 3, 245, 160, 159, 113, 117, 252, 253, 228, 241, 128, 202, 172, 143, 146, 153, 173, 70, 79 } });
        }
    }
}
