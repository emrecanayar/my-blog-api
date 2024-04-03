using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreateArticleReportTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArticleReports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReportType = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
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
                    table.PrimaryKey("PK_ArticleReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticleReports_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("19afb672-bf92-47b0-ac84-2997c4320245"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 143, 186, 58, 1, 174, 44, 70, 188, 134, 196, 61, 214, 56, 153, 33, 214, 108, 112, 90, 146, 81, 243, 1, 193, 131, 108, 64, 69, 192, 137, 12, 130, 33, 188, 87, 234, 247, 223, 189, 66, 204, 240, 118, 145, 108, 25, 222, 13, 95, 68, 170, 158, 94, 130, 205, 176, 114, 231, 116, 255, 199, 8, 37, 196 }, new byte[] { 203, 120, 89, 162, 13, 111, 106, 148, 168, 155, 56, 7, 247, 211, 43, 77, 213, 147, 59, 175, 205, 104, 168, 192, 32, 32, 35, 22, 64, 61, 135, 203, 50, 107, 66, 27, 163, 143, 153, 91, 11, 149, 113, 93, 90, 8, 131, 0, 65, 220, 224, 0, 47, 43, 92, 175, 157, 236, 96, 70, 133, 37, 16, 42, 66, 220, 163, 147, 240, 186, 8, 86, 183, 175, 147, 253, 235, 135, 173, 146, 233, 117, 226, 95, 28, 1, 106, 112, 112, 35, 75, 102, 64, 233, 151, 176, 202, 146, 175, 236, 191, 179, 223, 66, 176, 124, 172, 135, 134, 95, 32, 72, 64, 234, 193, 209, 209, 17, 79, 231, 68, 124, 159, 20, 117, 158, 173, 142 } });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleReports_ArticleId",
                table: "ArticleReports",
                column: "ArticleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleReports");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("19afb672-bf92-47b0-ac84-2997c4320245"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 53, 64, 195, 30, 182, 101, 115, 18, 109, 72, 224, 249, 211, 188, 132, 49, 124, 214, 199, 33, 79, 75, 220, 63, 44, 80, 17, 132, 183, 182, 164, 200, 212, 248, 1, 23, 243, 226, 5, 247, 235, 167, 236, 185, 239, 228, 195, 28, 100, 98, 236, 90, 152, 126, 131, 167, 190, 165, 95, 117, 159, 130, 127, 14 }, new byte[] { 186, 215, 103, 104, 6, 213, 183, 15, 70, 249, 113, 108, 86, 231, 247, 224, 70, 34, 124, 179, 116, 205, 223, 66, 145, 81, 58, 54, 111, 252, 156, 39, 186, 5, 137, 120, 43, 12, 200, 113, 159, 214, 187, 32, 13, 212, 156, 192, 134, 100, 63, 98, 139, 243, 65, 247, 74, 233, 84, 208, 15, 59, 204, 76, 23, 195, 187, 81, 100, 249, 18, 120, 64, 206, 203, 63, 76, 1, 23, 78, 41, 38, 113, 39, 150, 77, 18, 188, 159, 99, 42, 35, 252, 211, 75, 124, 119, 94, 233, 123, 28, 151, 28, 12, 196, 10, 115, 214, 167, 100, 138, 52, 198, 135, 81, 206, 191, 8, 113, 105, 167, 90, 133, 98, 66, 71, 84, 195 } });
        }
    }
}
