using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CategoryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    IsPopular = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "ModifiedBy", "ModifiedDate", "Name", "Status" },
                values: new object[] { new Guid("34af4715-4eda-4655-af0c-c7fbc76a61c0"), "Admin", new DateTime(2024, 2, 5, 19, 54, 17, 585, DateTimeKind.Local).AddTicks(3635), null, null, null, "Admin", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedBy", "CreatedDate", "CultureType", "DeletedDate", "Email", "FirstName", "LastName", "ModifiedBy", "ModifiedDate", "PasswordHash", "PasswordSalt", "Status" },
                values: new object[] { new Guid("3fb04f40-bc49-4acd-888f-60320b13bdd6"), 0, "Admin", new DateTime(2024, 2, 5, 19, 54, 17, 593, DateTimeKind.Local).AddTicks(6838), 0, null, "admin@admin.com", "Admin", "Admin", null, null, new byte[] { 46, 207, 191, 112, 252, 5, 31, 7, 195, 27, 137, 186, 130, 64, 181, 205, 190, 144, 96, 180, 110, 43, 142, 66, 64, 98, 237, 33, 16, 234, 195, 211, 80, 184, 9, 209, 9, 191, 161, 104, 114, 41, 40, 229, 85, 80, 106, 220, 135, 91, 16, 198, 133, 165, 223, 83, 151, 4, 61, 93, 139, 130, 215, 95 }, new byte[] { 37, 146, 201, 241, 136, 235, 51, 210, 92, 107, 238, 115, 100, 97, 185, 242, 255, 235, 27, 170, 52, 85, 133, 157, 37, 187, 17, 151, 174, 235, 95, 10, 42, 82, 249, 209, 68, 206, 100, 81, 173, 14, 207, 113, 99, 139, 250, 97, 55, 146, 86, 239, 25, 224, 152, 179, 180, 244, 180, 158, 14, 121, 124, 116, 134, 217, 71, 65, 237, 226, 92, 112, 162, 199, 13, 186, 57, 208, 172, 59, 240, 61, 63, 176, 13, 56, 205, 98, 142, 201, 29, 196, 1, 239, 118, 79, 197, 166, 216, 130, 193, 43, 56, 130, 73, 182, 241, 179, 193, 164, 157, 195, 71, 220, 143, 149, 233, 228, 99, 234, 191, 177, 224, 204, 20, 2, 181, 80 }, 1 });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "ModifiedBy", "ModifiedDate", "OperationClaimId", "Status", "UserId" },
                values: new object[] { new Guid("bad8d623-6947-4e33-a6c0-c9b04225396f"), "Admin", new DateTime(2024, 2, 5, 19, 54, 17, 594, DateTimeKind.Local).AddTicks(5062), null, null, null, new Guid("34af4715-4eda-4655-af0c-c7fbc76a61c0"), 1, new Guid("3fb04f40-bc49-4acd-888f-60320b13bdd6") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("bad8d623-6947-4e33-a6c0-c9b04225396f"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("34af4715-4eda-4655-af0c-c7fbc76a61c0"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3fb04f40-bc49-4acd-888f-60320b13bdd6"));

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
    }
}
