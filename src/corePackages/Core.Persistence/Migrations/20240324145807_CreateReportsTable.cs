using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreateReportsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateReported = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_Reports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reports_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reports_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("19afb672-bf92-47b0-ac84-2997c4320245"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 134, 108, 206, 63, 75, 98, 9, 253, 229, 96, 90, 119, 165, 238, 106, 79, 27, 78, 85, 40, 212, 247, 128, 8, 105, 19, 34, 40, 199, 40, 156, 156, 218, 44, 107, 247, 126, 235, 141, 33, 38, 184, 16, 196, 3, 170, 217, 76, 71, 212, 219, 74, 240, 225, 44, 36, 240, 33, 187, 32, 94, 35, 158, 139 }, new byte[] { 139, 58, 167, 57, 229, 23, 118, 155, 253, 118, 84, 142, 209, 176, 161, 24, 160, 135, 32, 198, 195, 5, 221, 236, 164, 24, 244, 24, 70, 91, 33, 60, 50, 166, 40, 220, 104, 211, 193, 162, 155, 209, 76, 163, 213, 158, 196, 207, 223, 75, 141, 209, 6, 213, 235, 230, 56, 129, 144, 176, 138, 189, 238, 255, 83, 247, 89, 242, 132, 185, 53, 186, 53, 217, 247, 62, 10, 227, 25, 19, 127, 106, 165, 74, 242, 231, 32, 144, 138, 182, 224, 45, 133, 156, 46, 24, 93, 14, 224, 100, 144, 179, 4, 241, 13, 239, 245, 12, 237, 104, 201, 68, 10, 218, 82, 18, 83, 215, 107, 93, 69, 127, 84, 163, 79, 191, 254, 72 } });

            migrationBuilder.CreateIndex(
                name: "IX_Reports_CommentId",
                table: "Reports",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_UserId",
                table: "Reports",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("19afb672-bf92-47b0-ac84-2997c4320245"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 154, 143, 243, 144, 82, 153, 203, 137, 26, 176, 138, 99, 241, 9, 200, 153, 122, 28, 49, 163, 176, 152, 105, 138, 37, 235, 218, 213, 42, 116, 204, 149, 207, 172, 106, 119, 152, 104, 50, 157, 115, 130, 244, 169, 9, 61, 5, 125, 49, 56, 195, 41, 213, 45, 22, 117, 35, 193, 102, 59, 192, 183, 171, 140 }, new byte[] { 131, 155, 255, 14, 85, 181, 31, 10, 11, 244, 246, 244, 159, 20, 135, 20, 104, 76, 234, 4, 83, 234, 131, 80, 101, 121, 211, 25, 178, 206, 43, 161, 55, 43, 252, 67, 240, 56, 54, 100, 149, 223, 149, 73, 151, 126, 200, 9, 79, 169, 18, 153, 102, 117, 225, 200, 3, 101, 214, 67, 55, 4, 17, 21, 105, 86, 89, 141, 250, 37, 231, 154, 145, 206, 135, 146, 133, 100, 190, 226, 207, 131, 79, 64, 1, 52, 140, 94, 196, 133, 245, 228, 66, 186, 101, 241, 254, 77, 141, 82, 65, 70, 253, 54, 38, 201, 189, 194, 135, 119, 62, 175, 117, 169, 185, 176, 126, 176, 142, 134, 153, 150, 38, 135, 137, 64, 228, 175 } });
        }
    }
}
