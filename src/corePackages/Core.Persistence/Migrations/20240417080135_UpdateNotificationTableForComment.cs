using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNotificationTableForComment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CommentId",
                table: "Notifications",
                type: "uniqueidentifier",
                maxLength: 250,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("19afb672-bf92-47b0-ac84-2997c4320245"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 21, 19, 23, 123, 89, 80, 151, 119, 46, 2, 59, 220, 16, 113, 139, 198, 43, 69, 51, 249, 45, 79, 213, 203, 95, 125, 169, 28, 176, 246, 134, 142, 221, 145, 150, 202, 4, 82, 150, 194, 88, 181, 249, 183, 31, 185, 72, 131, 87, 124, 176, 13, 68, 16, 105, 218, 129, 195, 154, 251, 210, 194, 65, 202 }, new byte[] { 191, 48, 255, 142, 182, 154, 116, 66, 188, 193, 36, 88, 245, 177, 243, 139, 217, 1, 172, 151, 142, 31, 73, 2, 8, 188, 100, 212, 107, 114, 195, 255, 141, 94, 236, 1, 204, 72, 58, 92, 217, 157, 99, 185, 176, 10, 171, 147, 165, 248, 76, 99, 186, 142, 96, 234, 93, 194, 147, 156, 215, 165, 81, 172, 60, 34, 239, 93, 175, 185, 180, 255, 67, 236, 95, 73, 30, 139, 204, 127, 92, 57, 52, 133, 69, 199, 97, 156, 120, 219, 55, 106, 86, 214, 52, 92, 221, 190, 35, 160, 117, 79, 169, 4, 197, 185, 147, 187, 109, 252, 45, 180, 223, 47, 44, 52, 105, 109, 148, 167, 64, 92, 204, 118, 133, 202, 8, 20 } });

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_CommentId",
                table: "Notifications",
                column: "CommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Comments_CommentId",
                table: "Notifications",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Comments_CommentId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_CommentId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "Notifications");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("19afb672-bf92-47b0-ac84-2997c4320245"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 139, 191, 177, 28, 57, 211, 143, 129, 197, 145, 121, 212, 8, 78, 25, 194, 230, 106, 251, 142, 135, 245, 52, 110, 202, 68, 189, 48, 43, 156, 103, 81, 104, 45, 206, 227, 251, 128, 34, 250, 23, 72, 99, 31, 135, 120, 186, 233, 173, 87, 15, 161, 249, 190, 144, 170, 40, 213, 180, 73, 247, 183, 249, 237 }, new byte[] { 69, 249, 87, 109, 189, 251, 85, 103, 215, 243, 170, 96, 246, 4, 148, 126, 110, 11, 130, 93, 6, 30, 193, 28, 182, 109, 179, 227, 78, 247, 89, 73, 130, 180, 179, 33, 17, 197, 41, 38, 112, 46, 203, 245, 189, 52, 230, 68, 39, 164, 24, 96, 99, 40, 93, 74, 76, 255, 13, 44, 254, 194, 178, 35, 124, 249, 1, 173, 101, 96, 143, 23, 82, 252, 182, 67, 61, 9, 36, 227, 5, 183, 196, 177, 52, 1, 123, 155, 254, 123, 44, 105, 210, 170, 24, 195, 131, 255, 87, 134, 99, 127, 168, 36, 32, 109, 160, 240, 240, 251, 129, 195, 66, 215, 8, 104, 32, 163, 240, 167, 247, 48, 214, 202, 133, 216, 11, 54 } });
        }
    }
}
