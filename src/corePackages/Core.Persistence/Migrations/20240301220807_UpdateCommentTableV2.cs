using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCommentTableV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Comments",
                type: "uniqueidentifier",
                maxLength: 250,
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("e41b2335-290e-4c49-a88c-8366cf928375"),
                column: "CreatedDate",
                value: new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("827de17a-7223-4246-bda9-7f6caaeec155"),
                column: "CreatedDate",
                value: new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("19afb672-bf92-47b0-ac84-2997c4320245"),
                columns: new[] { "CreatedDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new byte[] { 105, 148, 66, 190, 52, 99, 65, 184, 83, 100, 85, 107, 5, 97, 121, 104, 158, 3, 200, 84, 41, 155, 0, 50, 54, 214, 203, 145, 67, 128, 87, 106, 160, 193, 189, 16, 33, 198, 49, 42, 185, 108, 243, 7, 209, 89, 172, 248, 226, 12, 204, 242, 3, 70, 252, 133, 23, 58, 95, 139, 47, 237, 232, 120 }, new byte[] { 200, 7, 108, 87, 250, 88, 243, 237, 134, 14, 155, 248, 114, 202, 139, 169, 159, 89, 64, 241, 49, 41, 72, 83, 79, 27, 79, 138, 114, 217, 174, 62, 41, 188, 50, 38, 63, 159, 3, 55, 32, 14, 95, 47, 46, 183, 122, 129, 194, 249, 46, 9, 254, 142, 105, 182, 230, 145, 26, 117, 155, 92, 254, 100, 22, 0, 209, 81, 140, 178, 57, 1, 43, 152, 93, 0, 243, 188, 185, 164, 175, 228, 0, 239, 90, 86, 92, 60, 55, 207, 92, 126, 116, 184, 139, 227, 179, 160, 40, 104, 84, 22, 180, 250, 244, 237, 166, 1, 197, 183, 97, 164, 31, 78, 204, 59, 23, 152, 51, 22, 7, 251, 0, 174, 78, 238, 219, 149 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Comments",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldMaxLength: 250,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("e41b2335-290e-4c49-a88c-8366cf928375"),
                column: "CreatedDate",
                value: new DateTime(2024, 3, 2, 0, 49, 37, 69, DateTimeKind.Local).AddTicks(3384));

            migrationBuilder.UpdateData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("827de17a-7223-4246-bda9-7f6caaeec155"),
                column: "CreatedDate",
                value: new DateTime(2024, 3, 2, 0, 49, 37, 72, DateTimeKind.Local).AddTicks(5556));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("19afb672-bf92-47b0-ac84-2997c4320245"),
                columns: new[] { "CreatedDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2024, 3, 2, 0, 49, 37, 71, DateTimeKind.Local).AddTicks(7877), new byte[] { 184, 116, 171, 120, 80, 148, 250, 134, 15, 66, 157, 122, 77, 174, 89, 25, 75, 94, 10, 11, 94, 25, 107, 138, 182, 214, 34, 191, 100, 159, 108, 198, 51, 76, 28, 122, 30, 210, 125, 76, 73, 143, 199, 227, 65, 160, 57, 211, 163, 178, 248, 86, 56, 251, 7, 232, 2, 91, 181, 215, 74, 156, 142, 199 }, new byte[] { 70, 27, 212, 199, 220, 9, 61, 109, 208, 50, 77, 84, 247, 202, 166, 68, 179, 61, 188, 214, 6, 205, 73, 65, 112, 95, 236, 56, 206, 29, 247, 123, 193, 9, 253, 184, 178, 191, 144, 153, 174, 107, 240, 99, 244, 191, 246, 69, 165, 80, 141, 218, 28, 246, 182, 12, 234, 144, 33, 120, 124, 219, 244, 57, 113, 46, 69, 182, 172, 187, 27, 160, 240, 189, 151, 203, 232, 192, 125, 237, 16, 123, 67, 64, 108, 102, 138, 60, 99, 24, 141, 185, 237, 59, 242, 89, 22, 28, 206, 136, 7, 109, 242, 56, 22, 241, 63, 239, 251, 159, 79, 227, 18, 108, 236, 242, 121, 2, 239, 55, 73, 61, 223, 175, 76, 147, 240, 250 } });
        }
    }
}
