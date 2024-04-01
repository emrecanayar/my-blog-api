using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ArticleVoteConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArticleVotes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ArticleId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 250, nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 250, nullable: false),
                    Vote = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
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
                    table.PrimaryKey("PK_ArticleVotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticleVotes_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ArticleVotes_Users_UserId",
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
                values: new object[] { new byte[] { 53, 64, 195, 30, 182, 101, 115, 18, 109, 72, 224, 249, 211, 188, 132, 49, 124, 214, 199, 33, 79, 75, 220, 63, 44, 80, 17, 132, 183, 182, 164, 200, 212, 248, 1, 23, 243, 226, 5, 247, 235, 167, 236, 185, 239, 228, 195, 28, 100, 98, 236, 90, 152, 126, 131, 167, 190, 165, 95, 117, 159, 130, 127, 14 }, new byte[] { 186, 215, 103, 104, 6, 213, 183, 15, 70, 249, 113, 108, 86, 231, 247, 224, 70, 34, 124, 179, 116, 205, 223, 66, 145, 81, 58, 54, 111, 252, 156, 39, 186, 5, 137, 120, 43, 12, 200, 113, 159, 214, 187, 32, 13, 212, 156, 192, 134, 100, 63, 98, 139, 243, 65, 247, 74, 233, 84, 208, 15, 59, 204, 76, 23, 195, 187, 81, 100, 249, 18, 120, 64, 206, 203, 63, 76, 1, 23, 78, 41, 38, 113, 39, 150, 77, 18, 188, 159, 99, 42, 35, 252, 211, 75, 124, 119, 94, 233, 123, 28, 151, 28, 12, 196, 10, 115, 214, 167, 100, 138, 52, 198, 135, 81, 206, 191, 8, 113, 105, 167, 90, 133, 98, 66, 71, 84, 195 } });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleVotes_ArticleId",
                table: "ArticleVotes",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleVotes_UserId",
                table: "ArticleVotes",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleVotes");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("19afb672-bf92-47b0-ac84-2997c4320245"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 134, 108, 206, 63, 75, 98, 9, 253, 229, 96, 90, 119, 165, 238, 106, 79, 27, 78, 85, 40, 212, 247, 128, 8, 105, 19, 34, 40, 199, 40, 156, 156, 218, 44, 107, 247, 126, 235, 141, 33, 38, 184, 16, 196, 3, 170, 217, 76, 71, 212, 219, 74, 240, 225, 44, 36, 240, 33, 187, 32, 94, 35, 158, 139 }, new byte[] { 139, 58, 167, 57, 229, 23, 118, 155, 253, 118, 84, 142, 209, 176, 161, 24, 160, 135, 32, 198, 195, 5, 221, 236, 164, 24, 244, 24, 70, 91, 33, 60, 50, 166, 40, 220, 104, 211, 193, 162, 155, 209, 76, 163, 213, 158, 196, 207, 223, 75, 141, 209, 6, 213, 235, 230, 56, 129, 144, 176, 138, 189, 238, 255, 83, 247, 89, 242, 132, 185, 53, 186, 53, 217, 247, 62, 10, 227, 25, 19, 127, 106, 165, 74, 242, 231, 32, 144, 138, 182, 224, 45, 133, 156, 46, 24, 93, 14, 224, 100, 144, 179, 4, 241, 13, 239, 245, 12, 237, 104, 201, 68, 10, 218, 82, 18, 83, 215, 107, 93, 69, 127, 84, 163, 79, 191, 254, 72 } });
        }
    }
}
