using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ContactTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Message = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
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
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "ModifiedBy", "ModifiedDate", "Name", "Status" },
                values: new object[] { new Guid("a0ced15a-bd9c-4cd2-98da-bedf11f59844"), "Admin", new DateTime(2024, 2, 1, 20, 42, 16, 834, DateTimeKind.Local).AddTicks(2833), null, null, null, "Admin", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedBy", "CreatedDate", "CultureType", "DeletedDate", "Email", "FirstName", "LastName", "ModifiedBy", "ModifiedDate", "PasswordHash", "PasswordSalt", "Status" },
                values: new object[] { new Guid("37bec1e4-2be8-418b-9d3c-31290172fa3f"), 0, "Admin", new DateTime(2024, 2, 1, 20, 42, 16, 842, DateTimeKind.Local).AddTicks(620), 0, null, "admin@admin.com", "Admin", "Admin", null, null, new byte[] { 158, 92, 9, 104, 26, 195, 138, 188, 98, 197, 40, 16, 50, 247, 244, 180, 140, 45, 126, 168, 52, 158, 41, 116, 5, 19, 181, 113, 199, 97, 234, 94, 193, 219, 114, 217, 30, 150, 37, 145, 165, 242, 231, 220, 100, 186, 156, 207, 87, 185, 26, 79, 20, 132, 71, 183, 137, 228, 167, 61, 112, 224, 167, 18 }, new byte[] { 86, 20, 235, 140, 44, 59, 196, 235, 92, 46, 186, 205, 38, 12, 194, 138, 236, 170, 192, 158, 9, 118, 230, 2, 153, 18, 15, 30, 47, 44, 179, 5, 187, 144, 54, 215, 251, 49, 1, 170, 153, 177, 216, 91, 223, 129, 249, 77, 29, 14, 79, 104, 134, 44, 2, 175, 112, 176, 252, 239, 203, 178, 173, 44, 241, 70, 202, 8, 7, 6, 133, 28, 107, 218, 242, 64, 68, 90, 139, 174, 199, 169, 128, 161, 27, 20, 25, 57, 147, 135, 38, 191, 120, 101, 171, 6, 218, 146, 77, 186, 67, 75, 171, 71, 13, 208, 123, 189, 133, 15, 108, 209, 108, 27, 225, 248, 206, 70, 2, 143, 155, 27, 209, 143, 5, 144, 110, 104 }, 1 });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "ModifiedBy", "ModifiedDate", "OperationClaimId", "Status", "UserId" },
                values: new object[] { new Guid("5edc1008-e516-4114-9fb0-faef77f2df02"), "Admin", new DateTime(2024, 2, 1, 20, 42, 16, 842, DateTimeKind.Local).AddTicks(7007), null, null, null, new Guid("a0ced15a-bd9c-4cd2-98da-bedf11f59844"), 1, new Guid("37bec1e4-2be8-418b-9d3c-31290172fa3f") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("5edc1008-e516-4114-9fb0-faef77f2df02"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("a0ced15a-bd9c-4cd2-98da-bedf11f59844"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("37bec1e4-2be8-418b-9d3c-31290172fa3f"));

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
    }
}
