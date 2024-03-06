using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreateSubscriptionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 250, nullable: true),
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
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscriptions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("19afb672-bf92-47b0-ac84-2997c4320245"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 106, 138, 200, 84, 19, 38, 139, 133, 144, 51, 204, 95, 106, 215, 240, 185, 164, 68, 121, 134, 225, 1, 252, 190, 185, 134, 8, 83, 34, 160, 229, 103, 36, 11, 122, 60, 185, 218, 75, 156, 13, 205, 242, 213, 163, 125, 161, 81, 161, 39, 203, 7, 216, 49, 27, 227, 103, 206, 206, 99, 211, 9, 124, 203 }, new byte[] { 6, 73, 209, 199, 191, 141, 243, 34, 239, 53, 243, 127, 76, 28, 171, 33, 102, 253, 25, 241, 181, 133, 45, 14, 45, 28, 218, 79, 184, 137, 7, 159, 21, 28, 34, 152, 252, 120, 177, 162, 66, 105, 140, 26, 196, 241, 241, 52, 32, 194, 182, 132, 192, 100, 173, 3, 23, 41, 183, 140, 57, 109, 215, 170, 198, 78, 146, 6, 97, 24, 152, 117, 4, 65, 5, 167, 102, 140, 3, 148, 55, 62, 188, 77, 192, 135, 86, 36, 133, 21, 120, 175, 150, 69, 43, 54, 128, 12, 27, 43, 198, 119, 183, 12, 139, 197, 210, 250, 133, 201, 116, 38, 81, 63, 207, 186, 112, 183, 190, 3, 204, 70, 41, 107, 87, 150, 19, 73 } });

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_UserId",
                table: "Subscriptions",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("19afb672-bf92-47b0-ac84-2997c4320245"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 158, 216, 166, 197, 218, 155, 166, 78, 178, 149, 83, 247, 72, 101, 37, 157, 48, 134, 207, 200, 68, 28, 84, 182, 40, 175, 35, 217, 214, 0, 88, 214, 38, 117, 44, 245, 48, 220, 88, 238, 240, 12, 29, 111, 152, 80, 2, 179, 133, 249, 195, 201, 11, 142, 84, 209, 159, 16, 22, 27, 15, 236, 150, 84 }, new byte[] { 215, 72, 105, 89, 244, 1, 171, 193, 50, 221, 174, 183, 132, 214, 35, 109, 216, 61, 88, 39, 89, 54, 197, 236, 99, 124, 204, 106, 225, 38, 61, 86, 2, 18, 55, 173, 60, 198, 230, 25, 84, 75, 40, 245, 127, 141, 222, 159, 102, 36, 68, 29, 242, 78, 165, 53, 54, 216, 153, 172, 3, 230, 16, 217, 42, 222, 21, 121, 148, 113, 116, 162, 17, 188, 13, 204, 128, 176, 174, 3, 223, 30, 65, 207, 234, 72, 52, 146, 145, 127, 82, 46, 184, 68, 150, 103, 6, 246, 36, 25, 122, 8, 98, 248, 159, 203, 37, 103, 44, 206, 160, 115, 60, 96, 134, 43, 13, 139, 225, 212, 76, 185, 113, 152, 39, 79, 211, 203 } });
        }
    }
}
