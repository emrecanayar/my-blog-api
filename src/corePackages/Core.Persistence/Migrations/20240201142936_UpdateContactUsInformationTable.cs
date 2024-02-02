using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateContactUsInformationTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "FacebookLink",
                table: "ContactUsInformations");

            migrationBuilder.AlterColumn<string>(
                name: "TwitterLink",
                table: "ContactUsInformations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "LinkedInLink",
                table: "ContactUsInformations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "GithubLink",
                table: "ContactUsInformations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AddColumn<string>(
                name: "WhatsAppLink",
                table: "ContactUsInformations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "ModifiedBy", "ModifiedDate", "Name", "Status" },
                values: new object[] { new Guid("5cb5668c-aff7-48fe-a897-04c381bfb0b9"), "Admin", new DateTime(2024, 2, 1, 17, 29, 34, 834, DateTimeKind.Local).AddTicks(9200), null, null, null, "Admin", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedBy", "CreatedDate", "CultureType", "DeletedDate", "Email", "FirstName", "LastName", "ModifiedBy", "ModifiedDate", "PasswordHash", "PasswordSalt", "Status" },
                values: new object[] { new Guid("cb3cdeab-8d2c-4b8e-89f0-df87e77c76e2"), 0, "Admin", new DateTime(2024, 2, 1, 17, 29, 34, 841, DateTimeKind.Local).AddTicks(8967), 0, null, "admin@admin.com", "Admin", "Admin", null, null, new byte[] { 89, 200, 243, 48, 180, 172, 25, 127, 28, 202, 7, 199, 37, 13, 121, 203, 2, 187, 16, 120, 152, 177, 24, 98, 127, 37, 118, 155, 184, 198, 60, 216, 112, 163, 130, 133, 209, 42, 13, 123, 149, 158, 120, 11, 25, 243, 246, 88, 92, 16, 72, 191, 254, 208, 74, 19, 63, 8, 135, 142, 171, 235, 72, 71 }, new byte[] { 217, 251, 52, 109, 30, 112, 115, 216, 169, 244, 84, 7, 75, 248, 149, 42, 45, 0, 43, 84, 172, 145, 148, 253, 210, 235, 113, 230, 167, 95, 175, 252, 249, 38, 210, 117, 90, 220, 249, 79, 50, 33, 178, 80, 244, 93, 102, 171, 30, 161, 246, 245, 163, 229, 82, 48, 85, 17, 240, 230, 205, 22, 225, 57, 169, 110, 214, 1, 197, 35, 6, 157, 45, 209, 221, 0, 108, 142, 11, 70, 49, 203, 232, 39, 77, 120, 64, 82, 169, 146, 170, 236, 16, 102, 71, 11, 206, 129, 82, 187, 162, 2, 164, 226, 23, 61, 85, 248, 67, 115, 91, 37, 6, 200, 218, 49, 246, 96, 87, 206, 6, 231, 190, 99, 181, 9, 56, 49 }, 1 });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "ModifiedBy", "ModifiedDate", "OperationClaimId", "Status", "UserId" },
                values: new object[] { new Guid("63fd854c-7714-4cbc-848a-17bdafc77f3a"), "Admin", new DateTime(2024, 2, 1, 17, 29, 34, 842, DateTimeKind.Local).AddTicks(6652), null, null, null, new Guid("5cb5668c-aff7-48fe-a897-04c381bfb0b9"), 1, new Guid("cb3cdeab-8d2c-4b8e-89f0-df87e77c76e2") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("63fd854c-7714-4cbc-848a-17bdafc77f3a"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("5cb5668c-aff7-48fe-a897-04c381bfb0b9"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("cb3cdeab-8d2c-4b8e-89f0-df87e77c76e2"));

            migrationBuilder.DropColumn(
                name: "WhatsAppLink",
                table: "ContactUsInformations");

            migrationBuilder.AlterColumn<string>(
                name: "TwitterLink",
                table: "ContactUsInformations",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "LinkedInLink",
                table: "ContactUsInformations",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "GithubLink",
                table: "ContactUsInformations",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "FacebookLink",
                table: "ContactUsInformations",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

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
    }
}
