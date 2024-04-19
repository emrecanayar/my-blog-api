using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNotificationTableForLike : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LikeId",
                table: "Notifications",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("19afb672-bf92-47b0-ac84-2997c4320245"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 249, 92, 167, 103, 180, 147, 29, 150, 42, 186, 180, 169, 156, 62, 218, 123, 84, 211, 164, 170, 68, 113, 77, 66, 2, 100, 51, 107, 212, 121, 234, 136, 142, 214, 95, 7, 243, 44, 135, 16, 84, 216, 38, 199, 107, 82, 141, 188, 229, 203, 16, 144, 243, 251, 196, 207, 18, 46, 5, 209, 49, 243, 148, 120 }, new byte[] { 107, 73, 135, 8, 96, 183, 150, 136, 165, 85, 174, 71, 142, 113, 224, 223, 109, 215, 161, 42, 22, 206, 48, 244, 192, 57, 210, 151, 200, 158, 96, 30, 192, 34, 131, 184, 124, 212, 18, 167, 209, 35, 108, 124, 102, 117, 125, 74, 205, 97, 213, 210, 239, 82, 224, 139, 232, 118, 186, 44, 148, 220, 59, 226, 83, 49, 148, 38, 224, 136, 112, 66, 25, 98, 49, 13, 53, 213, 217, 23, 23, 177, 127, 146, 18, 119, 149, 113, 154, 10, 32, 68, 200, 81, 227, 31, 34, 175, 95, 243, 38, 83, 13, 212, 204, 70, 194, 63, 216, 193, 148, 58, 169, 18, 114, 194, 237, 65, 110, 29, 113, 6, 183, 219, 118, 4, 32, 225 } });

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_LikeId",
                table: "Notifications",
                column: "LikeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Likes_LikeId",
                table: "Notifications",
                column: "LikeId",
                principalTable: "Likes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Likes_LikeId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_LikeId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "LikeId",
                table: "Notifications");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("19afb672-bf92-47b0-ac84-2997c4320245"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 201, 251, 55, 12, 250, 32, 236, 95, 3, 232, 82, 47, 195, 6, 41, 6, 153, 250, 166, 236, 106, 90, 168, 77, 248, 54, 230, 231, 11, 202, 194, 133, 140, 59, 180, 190, 35, 244, 167, 243, 255, 52, 139, 109, 25, 52, 196, 54, 181, 218, 123, 54, 176, 176, 18, 42, 179, 239, 216, 240, 137, 185, 160, 20 }, new byte[] { 74, 14, 80, 35, 206, 55, 133, 173, 235, 193, 172, 40, 254, 83, 155, 190, 71, 106, 138, 235, 204, 21, 254, 95, 252, 100, 175, 156, 145, 228, 219, 99, 11, 224, 129, 19, 162, 74, 200, 124, 65, 189, 96, 57, 33, 243, 194, 254, 125, 31, 251, 254, 145, 42, 136, 196, 39, 178, 63, 249, 20, 146, 90, 67, 13, 19, 157, 86, 91, 86, 137, 119, 199, 30, 242, 32, 3, 52, 194, 171, 77, 17, 222, 30, 61, 68, 120, 56, 130, 176, 148, 152, 62, 31, 38, 124, 207, 44, 186, 59, 244, 31, 111, 158, 54, 61, 119, 131, 226, 116, 67, 34, 45, 90, 0, 81, 203, 12, 72, 10, 233, 108, 215, 243, 128, 15, 9, 219 } });
        }
    }
}
