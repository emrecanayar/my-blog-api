using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNotificationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ArticleId",
                table: "Notifications",
                type: "uniqueidentifier",
                maxLength: 250,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("19afb672-bf92-47b0-ac84-2997c4320245"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 139, 191, 177, 28, 57, 211, 143, 129, 197, 145, 121, 212, 8, 78, 25, 194, 230, 106, 251, 142, 135, 245, 52, 110, 202, 68, 189, 48, 43, 156, 103, 81, 104, 45, 206, 227, 251, 128, 34, 250, 23, 72, 99, 31, 135, 120, 186, 233, 173, 87, 15, 161, 249, 190, 144, 170, 40, 213, 180, 73, 247, 183, 249, 237 }, new byte[] { 69, 249, 87, 109, 189, 251, 85, 103, 215, 243, 170, 96, 246, 4, 148, 126, 110, 11, 130, 93, 6, 30, 193, 28, 182, 109, 179, 227, 78, 247, 89, 73, 130, 180, 179, 33, 17, 197, 41, 38, 112, 46, 203, 245, 189, 52, 230, 68, 39, 164, 24, 96, 99, 40, 93, 74, 76, 255, 13, 44, 254, 194, 178, 35, 124, 249, 1, 173, 101, 96, 143, 23, 82, 252, 182, 67, 61, 9, 36, 227, 5, 183, 196, 177, 52, 1, 123, 155, 254, 123, 44, 105, 210, 170, 24, 195, 131, 255, 87, 134, 99, 127, 168, 36, 32, 109, 160, 240, 240, 251, 129, 195, 66, 215, 8, 104, 32, 163, 240, 167, 247, 48, 214, 202, 133, 216, 11, 54 } });

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_ArticleId",
                table: "Notifications",
                column: "ArticleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Articles_ArticleId",
                table: "Notifications",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Articles_ArticleId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_ArticleId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "ArticleId",
                table: "Notifications");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("19afb672-bf92-47b0-ac84-2997c4320245"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 143, 186, 58, 1, 174, 44, 70, 188, 134, 196, 61, 214, 56, 153, 33, 214, 108, 112, 90, 146, 81, 243, 1, 193, 131, 108, 64, 69, 192, 137, 12, 130, 33, 188, 87, 234, 247, 223, 189, 66, 204, 240, 118, 145, 108, 25, 222, 13, 95, 68, 170, 158, 94, 130, 205, 176, 114, 231, 116, 255, 199, 8, 37, 196 }, new byte[] { 203, 120, 89, 162, 13, 111, 106, 148, 168, 155, 56, 7, 247, 211, 43, 77, 213, 147, 59, 175, 205, 104, 168, 192, 32, 32, 35, 22, 64, 61, 135, 203, 50, 107, 66, 27, 163, 143, 153, 91, 11, 149, 113, 93, 90, 8, 131, 0, 65, 220, 224, 0, 47, 43, 92, 175, 157, 236, 96, 70, 133, 37, 16, 42, 66, 220, 163, 147, 240, 186, 8, 86, 183, 175, 147, 253, 235, 135, 173, 146, 233, 117, 226, 95, 28, 1, 106, 112, 112, 35, 75, 102, 64, 233, 151, 176, 202, 146, 175, 236, 191, 179, 223, 66, 176, 124, 172, 135, 134, 95, 32, 72, 64, 234, 193, 209, 209, 17, 79, 231, 68, 124, 159, 20, 117, 158, 173, 142 } });
        }
    }
}
