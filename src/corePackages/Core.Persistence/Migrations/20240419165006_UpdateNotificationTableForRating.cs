using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNotificationTableForRating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "RatingId",
                table: "Notifications",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("19afb672-bf92-47b0-ac84-2997c4320245"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 201, 251, 55, 12, 250, 32, 236, 95, 3, 232, 82, 47, 195, 6, 41, 6, 153, 250, 166, 236, 106, 90, 168, 77, 248, 54, 230, 231, 11, 202, 194, 133, 140, 59, 180, 190, 35, 244, 167, 243, 255, 52, 139, 109, 25, 52, 196, 54, 181, 218, 123, 54, 176, 176, 18, 42, 179, 239, 216, 240, 137, 185, 160, 20 }, new byte[] { 74, 14, 80, 35, 206, 55, 133, 173, 235, 193, 172, 40, 254, 83, 155, 190, 71, 106, 138, 235, 204, 21, 254, 95, 252, 100, 175, 156, 145, 228, 219, 99, 11, 224, 129, 19, 162, 74, 200, 124, 65, 189, 96, 57, 33, 243, 194, 254, 125, 31, 251, 254, 145, 42, 136, 196, 39, 178, 63, 249, 20, 146, 90, 67, 13, 19, 157, 86, 91, 86, 137, 119, 199, 30, 242, 32, 3, 52, 194, 171, 77, 17, 222, 30, 61, 68, 120, 56, 130, 176, 148, 152, 62, 31, 38, 124, 207, 44, 186, 59, 244, 31, 111, 158, 54, 61, 119, 131, 226, 116, 67, 34, 45, 90, 0, 81, 203, 12, 72, 10, 233, 108, 215, 243, 128, 15, 9, 219 } });

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_RatingId",
                table: "Notifications",
                column: "RatingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Ratings_RatingId",
                table: "Notifications",
                column: "RatingId",
                principalTable: "Ratings",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Ratings_RatingId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_RatingId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "RatingId",
                table: "Notifications");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("19afb672-bf92-47b0-ac84-2997c4320245"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 21, 19, 23, 123, 89, 80, 151, 119, 46, 2, 59, 220, 16, 113, 139, 198, 43, 69, 51, 249, 45, 79, 213, 203, 95, 125, 169, 28, 176, 246, 134, 142, 221, 145, 150, 202, 4, 82, 150, 194, 88, 181, 249, 183, 31, 185, 72, 131, 87, 124, 176, 13, 68, 16, 105, 218, 129, 195, 154, 251, 210, 194, 65, 202 }, new byte[] { 191, 48, 255, 142, 182, 154, 116, 66, 188, 193, 36, 88, 245, 177, 243, 139, 217, 1, 172, 151, 142, 31, 73, 2, 8, 188, 100, 212, 107, 114, 195, 255, 141, 94, 236, 1, 204, 72, 58, 92, 217, 157, 99, 185, 176, 10, 171, 147, 165, 248, 76, 99, 186, 142, 96, 234, 93, 194, 147, 156, 215, 165, 81, 172, 60, 34, 239, 93, 175, 185, 180, 255, 67, 236, 95, 73, 30, 139, 204, 127, 92, 57, 52, 133, 69, 199, 97, 156, 120, 219, 55, 106, 86, 214, 52, 92, 221, 190, 35, 160, 117, 79, 169, 4, 197, 185, 147, 187, 109, 252, 45, 180, 223, 47, 44, 52, 105, 109, 148, 167, 64, 92, 204, 118, 133, 202, 8, 20 } });
        }
    }
}
