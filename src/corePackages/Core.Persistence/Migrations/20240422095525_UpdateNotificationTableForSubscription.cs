using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNotificationTableForSubscription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SubscriptionId",
                table: "Notifications",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("19afb672-bf92-47b0-ac84-2997c4320245"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 241, 211, 36, 214, 156, 228, 108, 133, 58, 216, 133, 15, 249, 219, 18, 64, 200, 216, 172, 10, 84, 184, 20, 84, 173, 95, 119, 66, 82, 78, 195, 28, 98, 193, 242, 178, 165, 162, 170, 114, 191, 106, 232, 200, 90, 205, 204, 107, 214, 140, 172, 124, 101, 13, 38, 40, 35, 144, 131, 80, 179, 196, 39, 214 }, new byte[] { 109, 213, 142, 8, 39, 238, 222, 201, 35, 96, 204, 86, 120, 13, 207, 51, 69, 206, 87, 176, 73, 26, 193, 18, 174, 206, 175, 144, 188, 211, 50, 224, 203, 1, 76, 191, 146, 114, 130, 248, 68, 245, 251, 25, 135, 164, 191, 119, 191, 99, 236, 53, 47, 237, 33, 160, 137, 124, 64, 17, 48, 191, 212, 188, 197, 234, 35, 186, 153, 6, 145, 79, 49, 83, 73, 150, 162, 25, 176, 228, 126, 24, 73, 226, 70, 130, 140, 161, 195, 218, 177, 175, 135, 174, 98, 59, 49, 159, 59, 9, 228, 79, 173, 239, 241, 1, 196, 13, 155, 37, 244, 109, 163, 216, 168, 89, 51, 26, 130, 73, 80, 203, 21, 231, 233, 200, 166, 21 } });

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_SubscriptionId",
                table: "Notifications",
                column: "SubscriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_Subscriptions_SubscriptionId",
                table: "Notifications",
                column: "SubscriptionId",
                principalTable: "Subscriptions",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_Subscriptions_SubscriptionId",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_SubscriptionId",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "SubscriptionId",
                table: "Notifications");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("19afb672-bf92-47b0-ac84-2997c4320245"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 249, 92, 167, 103, 180, 147, 29, 150, 42, 186, 180, 169, 156, 62, 218, 123, 84, 211, 164, 170, 68, 113, 77, 66, 2, 100, 51, 107, 212, 121, 234, 136, 142, 214, 95, 7, 243, 44, 135, 16, 84, 216, 38, 199, 107, 82, 141, 188, 229, 203, 16, 144, 243, 251, 196, 207, 18, 46, 5, 209, 49, 243, 148, 120 }, new byte[] { 107, 73, 135, 8, 96, 183, 150, 136, 165, 85, 174, 71, 142, 113, 224, 223, 109, 215, 161, 42, 22, 206, 48, 244, 192, 57, 210, 151, 200, 158, 96, 30, 192, 34, 131, 184, 124, 212, 18, 167, 209, 35, 108, 124, 102, 117, 125, 74, 205, 97, 213, 210, 239, 82, 224, 139, 232, 118, 186, 44, 148, 220, 59, 226, 83, 49, 148, 38, 224, 136, 112, 66, 25, 98, 49, 13, 53, 213, 217, 23, 23, 177, 127, 146, 18, 119, 149, 113, 154, 10, 32, 68, 200, 81, 227, 31, 34, 175, 95, 243, 38, 83, 13, 212, 204, 70, 194, 63, 216, 193, 148, 58, 169, 18, 114, 194, 237, 65, 110, 29, 113, 6, 183, 219, 118, 4, 32, 225 } });
        }
    }
}
