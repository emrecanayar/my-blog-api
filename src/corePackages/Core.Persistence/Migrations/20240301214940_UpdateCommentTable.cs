using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCommentTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("e41b2335-290e-4c49-a88c-8366cf928375"),
                column: "CreatedDate",
                value: new DateTime(2024, 3, 2, 0, 35, 28, 701, DateTimeKind.Local).AddTicks(4028));

            migrationBuilder.UpdateData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("827de17a-7223-4246-bda9-7f6caaeec155"),
                column: "CreatedDate",
                value: new DateTime(2024, 3, 2, 0, 35, 28, 704, DateTimeKind.Local).AddTicks(4928));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("19afb672-bf92-47b0-ac84-2997c4320245"),
                columns: new[] { "CreatedDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2024, 3, 2, 0, 35, 28, 703, DateTimeKind.Local).AddTicks(6834), new byte[] { 28, 132, 218, 157, 95, 180, 241, 123, 243, 210, 251, 108, 128, 91, 54, 34, 5, 104, 176, 212, 20, 230, 106, 138, 65, 38, 91, 22, 167, 206, 234, 186, 85, 63, 144, 148, 119, 144, 9, 244, 248, 242, 201, 15, 57, 174, 15, 109, 213, 177, 159, 108, 170, 124, 208, 201, 44, 242, 250, 150, 147, 72, 242, 239 }, new byte[] { 225, 163, 85, 56, 95, 214, 204, 123, 9, 231, 16, 2, 207, 216, 136, 90, 230, 44, 249, 9, 114, 68, 58, 9, 20, 70, 26, 178, 135, 220, 6, 35, 143, 151, 252, 199, 6, 156, 90, 188, 86, 38, 95, 155, 166, 149, 82, 105, 54, 209, 105, 187, 91, 144, 92, 131, 93, 19, 79, 25, 126, 215, 172, 243, 193, 57, 75, 131, 133, 95, 147, 79, 119, 77, 214, 13, 182, 103, 37, 112, 101, 168, 4, 97, 207, 129, 128, 188, 44, 105, 55, 81, 182, 46, 126, 18, 130, 237, 23, 248, 14, 147, 12, 173, 192, 83, 28, 254, 110, 148, 15, 248, 25, 2, 246, 160, 14, 148, 106, 55, 3, 173, 78, 60, 60, 156, 177, 134 } });
        }
    }
}
