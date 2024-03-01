using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreateFeatureTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("fcc8c9a2-f214-429b-8b0d-91ae5a4a8969"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("b2aef235-58da-4dda-97bc-68f6aec2c096"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("c70cd0e4-a393-4139-b4c9-cb2b7bc3dd02"));

            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
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
                    table.PrimaryKey("PK_Features", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "ModifiedBy", "ModifiedDate", "Name", "Status" },
                values: new object[] { new Guid("dbcf0471-5852-47bd-b3ef-65ca7d440257"), "Admin", new DateTime(2024, 3, 1, 16, 3, 25, 747, DateTimeKind.Local).AddTicks(6932), null, null, null, "Admin", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedBy", "CreatedDate", "CultureType", "DeletedDate", "Email", "FirstName", "LastName", "ModifiedBy", "ModifiedDate", "PasswordHash", "PasswordSalt", "Status" },
                values: new object[] { new Guid("9ed31b90-87a7-43b1-bc71-bb83a905fbf9"), 0, "Admin", new DateTime(2024, 3, 1, 16, 3, 25, 749, DateTimeKind.Local).AddTicks(5843), 0, null, "admin@admin.com", "Admin", "Admin", null, null, new byte[] { 177, 199, 239, 65, 223, 188, 148, 143, 2, 77, 46, 213, 41, 234, 37, 253, 130, 57, 27, 195, 134, 175, 125, 139, 252, 78, 84, 175, 85, 72, 38, 22, 68, 174, 50, 64, 50, 154, 245, 128, 191, 101, 190, 194, 214, 27, 207, 63, 151, 16, 177, 34, 160, 26, 209, 253, 32, 192, 13, 145, 187, 188, 207, 30 }, new byte[] { 74, 93, 194, 98, 95, 61, 96, 22, 231, 3, 73, 234, 173, 76, 37, 224, 112, 177, 155, 6, 201, 85, 178, 121, 252, 253, 28, 55, 220, 194, 51, 84, 36, 98, 32, 73, 31, 26, 252, 93, 178, 194, 163, 43, 89, 228, 222, 45, 187, 36, 10, 163, 40, 46, 114, 77, 165, 48, 241, 56, 137, 17, 151, 153, 220, 99, 125, 107, 101, 40, 1, 36, 132, 109, 165, 185, 44, 6, 15, 161, 125, 100, 79, 57, 246, 68, 254, 132, 69, 203, 12, 250, 244, 220, 11, 157, 19, 195, 109, 98, 198, 211, 38, 197, 231, 64, 102, 72, 87, 194, 74, 77, 38, 61, 131, 12, 72, 242, 61, 169, 39, 240, 78, 56, 17, 184, 35, 109 }, 1 });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "ModifiedBy", "ModifiedDate", "OperationClaimId", "Status", "UserId" },
                values: new object[] { new Guid("1c5decf2-cf7d-4553-838b-53fa5eee4573"), "Admin", new DateTime(2024, 3, 1, 16, 3, 25, 750, DateTimeKind.Local).AddTicks(3782), null, null, null, new Guid("dbcf0471-5852-47bd-b3ef-65ca7d440257"), 1, new Guid("9ed31b90-87a7-43b1-bc71-bb83a905fbf9") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("1c5decf2-cf7d-4553-838b-53fa5eee4573"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("dbcf0471-5852-47bd-b3ef-65ca7d440257"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9ed31b90-87a7-43b1-bc71-bb83a905fbf9"));

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "ModifiedBy", "ModifiedDate", "Name", "Status" },
                values: new object[] { new Guid("b2aef235-58da-4dda-97bc-68f6aec2c096"), "Admin", new DateTime(2024, 2, 24, 21, 37, 6, 272, DateTimeKind.Local).AddTicks(1974), null, null, null, "Admin", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedBy", "CreatedDate", "CultureType", "DeletedDate", "Email", "FirstName", "LastName", "ModifiedBy", "ModifiedDate", "PasswordHash", "PasswordSalt", "Status" },
                values: new object[] { new Guid("c70cd0e4-a393-4139-b4c9-cb2b7bc3dd02"), 0, "Admin", new DateTime(2024, 2, 24, 21, 37, 6, 275, DateTimeKind.Local).AddTicks(8941), 0, null, "admin@admin.com", "Admin", "Admin", null, null, new byte[] { 31, 226, 135, 76, 159, 161, 246, 195, 159, 167, 113, 66, 28, 98, 156, 218, 133, 230, 156, 86, 153, 66, 210, 192, 113, 44, 251, 156, 147, 202, 135, 70, 92, 100, 165, 193, 233, 175, 100, 115, 76, 231, 143, 122, 229, 51, 54, 189, 15, 34, 99, 79, 139, 112, 171, 129, 85, 165, 217, 7, 27, 82, 84, 230 }, new byte[] { 12, 48, 31, 169, 141, 42, 112, 22, 211, 157, 166, 56, 216, 137, 137, 114, 241, 94, 238, 45, 170, 13, 71, 76, 50, 139, 28, 12, 18, 198, 6, 22, 104, 47, 192, 3, 122, 68, 74, 149, 165, 131, 208, 184, 183, 212, 12, 243, 248, 149, 182, 167, 9, 116, 163, 217, 54, 44, 131, 144, 63, 88, 62, 223, 212, 71, 253, 24, 14, 40, 109, 116, 1, 0, 78, 32, 234, 195, 128, 108, 32, 186, 236, 88, 153, 252, 115, 111, 90, 63, 139, 159, 107, 182, 233, 128, 115, 30, 55, 71, 26, 113, 31, 182, 245, 240, 183, 220, 179, 111, 126, 248, 65, 28, 143, 46, 141, 79, 75, 85, 90, 206, 203, 50, 244, 193, 251, 105 }, 1 });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "ModifiedBy", "ModifiedDate", "OperationClaimId", "Status", "UserId" },
                values: new object[] { new Guid("fcc8c9a2-f214-429b-8b0d-91ae5a4a8969"), "Admin", new DateTime(2024, 2, 24, 21, 37, 6, 277, DateTimeKind.Local).AddTicks(791), null, null, null, new Guid("b2aef235-58da-4dda-97bc-68f6aec2c096"), 1, new Guid("c70cd0e4-a393-4139-b4c9-cb2b7bc3dd02") });
        }
    }
}
