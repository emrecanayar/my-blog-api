using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ContactUsInformationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Dictionaries",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "Dictionaries",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Dictionaries",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Dictionaries",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "ContactUsInformations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    AddressText = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    GithubLink = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LinkedInLink = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    TwitterLink = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    FacebookLink = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
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
                    table.PrimaryKey("PK_ContactUsInformations", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "ModifiedBy", "ModifiedDate", "Name", "Status" },
                values: new object[] { new Guid("026f2ef9-d6f9-48ca-9e98-c2edab84737b"), "Admin", new DateTime(2024, 2, 1, 17, 19, 42, 594, DateTimeKind.Local).AddTicks(3260), null, null, null, "Admin", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedBy", "CreatedDate", "CultureType", "DeletedDate", "Email", "FirstName", "LastName", "ModifiedBy", "ModifiedDate", "PasswordHash", "PasswordSalt", "Status" },
                values: new object[] { new Guid("610cb9b2-da6f-422d-bc47-682b3fb9f983"), 0, "Admin", new DateTime(2024, 2, 1, 17, 19, 42, 600, DateTimeKind.Local).AddTicks(3817), 0, null, "admin@admin.com", "Admin", "Admin", null, null, new byte[] { 181, 80, 239, 30, 90, 232, 181, 198, 120, 111, 46, 103, 30, 91, 127, 156, 13, 35, 22, 43, 79, 78, 199, 25, 90, 38, 36, 120, 22, 155, 35, 49, 104, 45, 20, 128, 26, 134, 218, 142, 59, 44, 202, 67, 247, 168, 59, 101, 72, 31, 169, 91, 224, 189, 117, 167, 158, 201, 166, 226, 167, 147, 248, 103 }, new byte[] { 48, 254, 86, 72, 7, 23, 240, 121, 67, 199, 120, 130, 40, 28, 214, 155, 49, 198, 95, 30, 89, 128, 117, 64, 159, 108, 94, 66, 1, 71, 48, 74, 21, 42, 35, 74, 235, 32, 178, 117, 118, 252, 246, 50, 63, 94, 186, 92, 46, 58, 2, 132, 77, 58, 216, 244, 69, 242, 52, 133, 211, 250, 49, 97, 67, 144, 47, 130, 55, 61, 212, 61, 56, 182, 240, 38, 248, 120, 85, 4, 98, 153, 95, 114, 93, 1, 223, 222, 32, 232, 197, 201, 49, 222, 17, 215, 171, 36, 63, 57, 169, 89, 2, 105, 73, 242, 81, 7, 43, 249, 54, 112, 62, 71, 191, 135, 248, 58, 17, 229, 171, 14, 174, 66, 146, 169, 165, 163 }, 1 });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "ModifiedBy", "ModifiedDate", "OperationClaimId", "Status", "UserId" },
                values: new object[] { new Guid("9c0663d3-84a6-48ae-a61a-8370a244df91"), "Admin", new DateTime(2024, 2, 1, 17, 19, 42, 600, DateTimeKind.Local).AddTicks(8989), null, null, null, new Guid("026f2ef9-d6f9-48ca-9e98-c2edab84737b"), 1, new Guid("610cb9b2-da6f-422d-bc47-682b3fb9f983") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactUsInformations");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("9c0663d3-84a6-48ae-a61a-8370a244df91"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("026f2ef9-d6f9-48ca-9e98-c2edab84737b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("610cb9b2-da6f-422d-bc47-682b3fb9f983"));

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Dictionaries",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "Dictionaries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "Dictionaries",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Dictionaries",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

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
    }
}
