using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAboutTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("fb922621-1b33-494e-8fb8-aba2197a7d4b"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("5ea19859-a3b1-4191-8429-8e840c8e83de"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9925603e-4b1b-4822-b83a-5e57eb6e55c7"));

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Abouts",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Abouts",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Abouts",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "Abouts",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Abouts",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Abouts",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Abouts",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "ModifiedBy", "ModifiedDate", "Name", "Status" },
                values: new object[] { new Guid("8b5b27e1-dc3c-4ae0-bde4-3f25605a50ed"), "Admin", new DateTime(2024, 2, 1, 15, 49, 58, 750, DateTimeKind.Local).AddTicks(798), null, null, null, "Admin", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedBy", "CreatedDate", "CultureType", "DeletedDate", "Email", "FirstName", "LastName", "ModifiedBy", "ModifiedDate", "PasswordHash", "PasswordSalt", "Status" },
                values: new object[] { new Guid("15a11e8e-b8a2-4dbf-bddb-d5f467df4f26"), 0, "Admin", new DateTime(2024, 2, 1, 15, 49, 58, 756, DateTimeKind.Local).AddTicks(4194), 0, null, "admin@admin.com", "Admin", "Admin", null, null, new byte[] { 228, 188, 159, 196, 49, 57, 111, 107, 27, 9, 253, 75, 187, 22, 35, 210, 45, 54, 219, 50, 183, 83, 209, 94, 40, 16, 76, 138, 162, 181, 149, 162, 79, 251, 221, 238, 139, 7, 123, 144, 111, 25, 210, 182, 77, 129, 73, 104, 104, 34, 44, 187, 114, 169, 15, 58, 154, 150, 11, 157, 5, 132, 193, 168 }, new byte[] { 130, 103, 179, 123, 154, 64, 80, 184, 224, 239, 224, 231, 132, 130, 17, 249, 163, 137, 163, 239, 98, 105, 198, 26, 106, 160, 233, 129, 32, 141, 45, 192, 155, 112, 215, 9, 44, 170, 140, 32, 233, 87, 19, 51, 234, 178, 3, 199, 243, 27, 39, 233, 85, 100, 96, 120, 164, 168, 113, 242, 120, 187, 129, 208, 174, 143, 45, 12, 197, 184, 108, 240, 183, 22, 250, 36, 198, 112, 131, 126, 239, 15, 141, 179, 89, 238, 193, 38, 120, 2, 84, 36, 210, 228, 128, 54, 166, 130, 75, 159, 174, 82, 4, 112, 45, 75, 130, 22, 41, 161, 215, 179, 100, 202, 152, 74, 223, 224, 185, 55, 208, 18, 118, 142, 225, 19, 166, 219 }, 1 });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "ModifiedBy", "ModifiedDate", "OperationClaimId", "Status", "UserId" },
                values: new object[] { new Guid("0ee1c58d-9f1b-409c-aea5-f0f3c2c4c7bd"), "Admin", new DateTime(2024, 2, 1, 15, 49, 58, 757, DateTimeKind.Local).AddTicks(747), null, null, null, new Guid("8b5b27e1-dc3c-4ae0-bde4-3f25605a50ed"), 1, new Guid("15a11e8e-b8a2-4dbf-bddb-d5f467df4f26") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("0ee1c58d-9f1b-409c-aea5-f0f3c2c4c7bd"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("8b5b27e1-dc3c-4ae0-bde4-3f25605a50ed"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("15a11e8e-b8a2-4dbf-bddb-d5f467df4f26"));

            migrationBuilder.AlterColumn<string>(
                name: "Url",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Abouts",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Abouts",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "ModifiedBy", "ModifiedDate", "Name", "Status" },
                values: new object[] { new Guid("5ea19859-a3b1-4191-8429-8e840c8e83de"), "Admin", new DateTime(2024, 2, 1, 15, 38, 35, 384, DateTimeKind.Local).AddTicks(6183), null, null, null, "Admin", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedBy", "CreatedDate", "CultureType", "DeletedDate", "Email", "FirstName", "LastName", "ModifiedBy", "ModifiedDate", "PasswordHash", "PasswordSalt", "Status" },
                values: new object[] { new Guid("9925603e-4b1b-4822-b83a-5e57eb6e55c7"), 0, "Admin", new DateTime(2024, 2, 1, 15, 38, 35, 389, DateTimeKind.Local).AddTicks(8402), 0, null, "admin@admin.com", "Admin", "Admin", null, null, new byte[] { 28, 108, 106, 88, 229, 224, 215, 197, 14, 67, 20, 208, 218, 93, 223, 149, 239, 219, 110, 90, 144, 138, 184, 114, 242, 66, 203, 30, 157, 7, 221, 202, 8, 11, 102, 66, 209, 246, 24, 43, 225, 56, 169, 48, 41, 250, 104, 164, 251, 3, 207, 139, 254, 32, 37, 239, 116, 192, 41, 51, 32, 66, 74, 216 }, new byte[] { 138, 160, 110, 69, 205, 0, 238, 110, 33, 90, 81, 67, 15, 48, 94, 181, 240, 236, 74, 189, 43, 30, 108, 75, 191, 21, 102, 60, 198, 180, 195, 41, 47, 7, 82, 41, 176, 221, 217, 220, 231, 67, 221, 159, 56, 14, 24, 4, 72, 147, 192, 248, 135, 92, 125, 71, 28, 160, 2, 26, 117, 139, 170, 209, 142, 125, 159, 174, 113, 229, 89, 223, 170, 117, 226, 125, 36, 14, 114, 71, 43, 128, 53, 134, 19, 62, 143, 115, 196, 250, 108, 239, 19, 94, 144, 4, 222, 220, 11, 64, 121, 85, 103, 51, 54, 157, 232, 139, 210, 12, 223, 39, 57, 121, 36, 49, 203, 18, 239, 173, 119, 47, 68, 27, 114, 231, 34, 245 }, 1 });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "ModifiedBy", "ModifiedDate", "OperationClaimId", "Status", "UserId" },
                values: new object[] { new Guid("fb922621-1b33-494e-8fb8-aba2197a7d4b"), "Admin", new DateTime(2024, 2, 1, 15, 38, 35, 390, DateTimeKind.Local).AddTicks(3967), null, null, null, new Guid("5ea19859-a3b1-4191-8429-8e840c8e83de"), 1, new Guid("9925603e-4b1b-4822-b83a-5e57eb6e55c7") });
        }
    }
}
