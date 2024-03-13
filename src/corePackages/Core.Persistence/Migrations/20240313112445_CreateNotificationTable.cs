using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreateNotificationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 250, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    IsRead = table.Column<bool>(type: "bit", maxLength: 250, nullable: false),
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
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("19afb672-bf92-47b0-ac84-2997c4320245"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 60, 59, 17, 68, 235, 166, 173, 97, 126, 116, 148, 120, 228, 145, 247, 220, 229, 198, 112, 59, 78, 26, 157, 145, 238, 86, 15, 90, 10, 209, 212, 174, 10, 102, 192, 95, 251, 67, 121, 124, 197, 197, 28, 98, 102, 40, 223, 223, 86, 34, 81, 217, 113, 107, 74, 84, 209, 13, 224, 228, 90, 185, 68, 142 }, new byte[] { 152, 235, 104, 55, 87, 66, 154, 235, 5, 189, 116, 61, 101, 35, 165, 219, 165, 50, 148, 94, 221, 160, 232, 142, 109, 77, 38, 219, 50, 236, 137, 84, 132, 119, 150, 62, 96, 207, 193, 13, 116, 182, 142, 96, 213, 229, 110, 77, 209, 229, 20, 254, 85, 184, 79, 204, 104, 51, 236, 209, 45, 158, 124, 254, 30, 69, 36, 214, 218, 0, 155, 153, 147, 165, 22, 210, 40, 228, 51, 251, 207, 199, 198, 110, 81, 175, 79, 17, 8, 146, 53, 11, 12, 95, 201, 75, 186, 210, 39, 123, 10, 36, 36, 143, 131, 97, 12, 37, 211, 3, 245, 160, 159, 113, 117, 252, 253, 228, 241, 128, 202, 172, 143, 146, 153, 173, 70, 79 } });

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("19afb672-bf92-47b0-ac84-2997c4320245"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 247, 180, 176, 159, 121, 229, 219, 89, 14, 66, 155, 179, 172, 215, 208, 254, 92, 38, 185, 177, 70, 5, 137, 223, 63, 114, 227, 160, 110, 225, 20, 232, 189, 108, 204, 183, 68, 50, 43, 37, 94, 98, 60, 134, 194, 41, 185, 36, 230, 22, 200, 177, 87, 34, 223, 6, 138, 216, 51, 206, 38, 46, 20, 35 }, new byte[] { 37, 35, 20, 197, 101, 191, 11, 43, 127, 57, 177, 127, 231, 37, 198, 87, 165, 17, 175, 238, 23, 50, 219, 198, 0, 220, 202, 53, 103, 25, 25, 165, 232, 220, 233, 111, 17, 152, 25, 19, 195, 184, 49, 76, 233, 102, 193, 67, 226, 24, 21, 241, 135, 161, 8, 123, 38, 203, 200, 242, 88, 21, 39, 135, 142, 148, 254, 152, 41, 39, 148, 74, 188, 188, 229, 238, 149, 183, 138, 51, 8, 227, 81, 243, 76, 121, 87, 68, 112, 166, 244, 22, 180, 110, 159, 131, 105, 62, 13, 183, 157, 12, 126, 23, 51, 225, 59, 95, 179, 138, 223, 101, 243, 9, 114, 176, 175, 44, 251, 95, 249, 19, 222, 69, 207, 205, 214, 56 } });
        }
    }
}
