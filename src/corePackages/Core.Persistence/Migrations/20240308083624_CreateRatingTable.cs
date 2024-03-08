using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreateRatingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ratings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("19afb672-bf92-47b0-ac84-2997c4320245"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 247, 180, 176, 159, 121, 229, 219, 89, 14, 66, 155, 179, 172, 215, 208, 254, 92, 38, 185, 177, 70, 5, 137, 223, 63, 114, 227, 160, 110, 225, 20, 232, 189, 108, 204, 183, 68, 50, 43, 37, 94, 98, 60, 134, 194, 41, 185, 36, 230, 22, 200, 177, 87, 34, 223, 6, 138, 216, 51, 206, 38, 46, 20, 35 }, new byte[] { 37, 35, 20, 197, 101, 191, 11, 43, 127, 57, 177, 127, 231, 37, 198, 87, 165, 17, 175, 238, 23, 50, 219, 198, 0, 220, 202, 53, 103, 25, 25, 165, 232, 220, 233, 111, 17, 152, 25, 19, 195, 184, 49, 76, 233, 102, 193, 67, 226, 24, 21, 241, 135, 161, 8, 123, 38, 203, 200, 242, 88, 21, 39, 135, 142, 148, 254, 152, 41, 39, 148, 74, 188, 188, 229, 238, 149, 183, 138, 51, 8, 227, 81, 243, 76, 121, 87, 68, 112, 166, 244, 22, 180, 110, 159, 131, 105, 62, 13, 183, 157, 12, 126, 23, 51, 225, 59, 95, 179, 138, 223, 101, 243, 9, 114, 176, 175, 44, 251, 95, 249, 19, 222, 69, 207, 205, 214, 56 } });

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_ArticleId",
                table: "Ratings",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_UserId",
                table: "Ratings",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("19afb672-bf92-47b0-ac84-2997c4320245"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 142, 223, 232, 9, 21, 157, 168, 26, 166, 20, 165, 227, 37, 193, 29, 208, 218, 249, 51, 81, 172, 16, 66, 105, 179, 171, 16, 102, 66, 137, 168, 104, 16, 175, 67, 179, 94, 39, 235, 184, 51, 14, 189, 134, 176, 112, 191, 250, 201, 160, 125, 125, 196, 29, 197, 156, 34, 227, 193, 232, 137, 6, 122, 79 }, new byte[] { 219, 245, 163, 150, 64, 212, 237, 237, 235, 218, 13, 201, 193, 180, 85, 186, 16, 101, 44, 98, 3, 18, 21, 185, 4, 38, 119, 60, 43, 141, 129, 219, 39, 184, 136, 180, 123, 205, 107, 223, 158, 2, 50, 144, 167, 5, 181, 182, 166, 42, 152, 239, 188, 97, 10, 190, 96, 135, 199, 113, 60, 104, 207, 67, 164, 87, 205, 76, 125, 18, 244, 160, 200, 197, 71, 253, 225, 183, 54, 162, 11, 244, 152, 57, 126, 122, 250, 238, 117, 69, 65, 214, 7, 172, 201, 166, 33, 54, 153, 119, 168, 3, 151, 120, 244, 234, 35, 97, 195, 121, 94, 75, 83, 21, 5, 70, 102, 179, 87, 53, 207, 223, 116, 252, 94, 18, 251, 195 } });
        }
    }
}
