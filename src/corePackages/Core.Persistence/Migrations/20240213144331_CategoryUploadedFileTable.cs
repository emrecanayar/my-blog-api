using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CategoryUploadedFileTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("59a91c09-75e9-442b-9c80-9082fd98cda6"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("a88ce11e-6617-4737-99d7-d09d169fa46c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("87f78a24-8cca-4c87-befe-a06430b03c29"));

            migrationBuilder.CreateTable(
                name: "CategoryUploadedFiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 250, nullable: false),
                    UploadedFileId = table.Column<Guid>(type: "uniqueidentifier", maxLength: 250, nullable: false),
                    OldPath = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    NewPath = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
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
                    table.PrimaryKey("PK_CategoryUploadedFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryUploadedFiles_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryUploadedFiles_UploadedFiles_UploadedFileId",
                        column: x => x.UploadedFileId,
                        principalTable: "UploadedFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "ModifiedBy", "ModifiedDate", "Name", "Status" },
                values: new object[] { new Guid("53d61cc4-d55e-4ec3-8f9b-74fc17b4eecf"), "Admin", new DateTime(2024, 2, 13, 17, 43, 28, 190, DateTimeKind.Local).AddTicks(7867), null, null, null, "Admin", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedBy", "CreatedDate", "CultureType", "DeletedDate", "Email", "FirstName", "LastName", "ModifiedBy", "ModifiedDate", "PasswordHash", "PasswordSalt", "Status" },
                values: new object[] { new Guid("751482fa-5642-4dc8-9db0-9714b5e14c43"), 0, "Admin", new DateTime(2024, 2, 13, 17, 43, 28, 203, DateTimeKind.Local).AddTicks(3585), 0, null, "admin@admin.com", "Admin", "Admin", null, null, new byte[] { 222, 235, 191, 112, 161, 223, 198, 37, 92, 225, 41, 38, 84, 50, 127, 233, 49, 251, 45, 203, 170, 60, 109, 47, 7, 109, 242, 40, 151, 51, 89, 47, 76, 159, 144, 51, 66, 6, 34, 130, 53, 61, 83, 220, 151, 118, 121, 68, 65, 193, 135, 151, 27, 50, 26, 54, 17, 97, 91, 205, 230, 38, 158, 112 }, new byte[] { 6, 0, 170, 230, 221, 106, 44, 69, 254, 181, 107, 135, 54, 208, 186, 120, 200, 228, 92, 98, 218, 159, 133, 55, 25, 136, 12, 203, 102, 101, 98, 152, 63, 52, 248, 35, 22, 219, 86, 35, 5, 206, 140, 95, 73, 165, 127, 182, 235, 73, 64, 217, 135, 190, 19, 75, 143, 179, 1, 166, 198, 77, 78, 46, 167, 229, 139, 214, 51, 120, 249, 131, 200, 33, 47, 222, 235, 10, 122, 221, 73, 219, 108, 201, 238, 230, 193, 125, 131, 255, 49, 160, 119, 135, 164, 115, 103, 188, 157, 7, 154, 93, 148, 167, 12, 53, 166, 31, 162, 79, 236, 92, 112, 18, 244, 113, 79, 232, 134, 162, 95, 87, 240, 45, 37, 67, 172, 185 }, 1 });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "ModifiedBy", "ModifiedDate", "OperationClaimId", "Status", "UserId" },
                values: new object[] { new Guid("deaf24d2-1aeb-4cbb-815f-e0c07f707bc2"), "Admin", new DateTime(2024, 2, 13, 17, 43, 28, 203, DateTimeKind.Local).AddTicks(8832), null, null, null, new Guid("53d61cc4-d55e-4ec3-8f9b-74fc17b4eecf"), 1, new Guid("751482fa-5642-4dc8-9db0-9714b5e14c43") });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryUploadedFiles_CategoryId",
                table: "CategoryUploadedFiles",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryUploadedFiles_UploadedFileId",
                table: "CategoryUploadedFiles",
                column: "UploadedFileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryUploadedFiles");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("deaf24d2-1aeb-4cbb-815f-e0c07f707bc2"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("53d61cc4-d55e-4ec3-8f9b-74fc17b4eecf"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("751482fa-5642-4dc8-9db0-9714b5e14c43"));

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "ModifiedBy", "ModifiedDate", "Name", "Status" },
                values: new object[] { new Guid("a88ce11e-6617-4737-99d7-d09d169fa46c"), "Admin", new DateTime(2024, 2, 5, 20, 6, 22, 882, DateTimeKind.Local).AddTicks(1638), null, null, null, "Admin", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedBy", "CreatedDate", "CultureType", "DeletedDate", "Email", "FirstName", "LastName", "ModifiedBy", "ModifiedDate", "PasswordHash", "PasswordSalt", "Status" },
                values: new object[] { new Guid("87f78a24-8cca-4c87-befe-a06430b03c29"), 0, "Admin", new DateTime(2024, 2, 5, 20, 6, 22, 896, DateTimeKind.Local).AddTicks(7337), 0, null, "admin@admin.com", "Admin", "Admin", null, null, new byte[] { 93, 2, 208, 83, 66, 232, 24, 98, 206, 66, 177, 35, 104, 147, 92, 143, 37, 11, 47, 56, 125, 246, 141, 241, 101, 132, 244, 168, 153, 0, 142, 55, 107, 194, 12, 130, 24, 87, 18, 4, 113, 107, 58, 99, 213, 206, 26, 86, 99, 188, 87, 145, 72, 194, 116, 32, 224, 113, 188, 248, 62, 239, 36, 122 }, new byte[] { 126, 211, 169, 206, 164, 21, 199, 233, 212, 102, 104, 44, 242, 110, 79, 142, 190, 137, 44, 242, 10, 137, 79, 48, 88, 28, 213, 211, 161, 83, 184, 56, 160, 233, 88, 9, 219, 8, 146, 97, 23, 129, 234, 11, 180, 77, 53, 42, 244, 86, 130, 36, 3, 85, 153, 213, 177, 110, 81, 117, 56, 73, 82, 201, 101, 78, 171, 249, 108, 135, 4, 155, 190, 5, 209, 79, 169, 75, 175, 101, 17, 67, 62, 18, 50, 58, 246, 158, 90, 59, 81, 94, 129, 45, 100, 81, 196, 234, 102, 236, 171, 205, 138, 196, 126, 188, 163, 193, 251, 2, 27, 172, 216, 50, 33, 203, 134, 198, 142, 137, 213, 164, 164, 213, 109, 242, 87, 76 }, 1 });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "ModifiedBy", "ModifiedDate", "OperationClaimId", "Status", "UserId" },
                values: new object[] { new Guid("59a91c09-75e9-442b-9c80-9082fd98cda6"), "Admin", new DateTime(2024, 2, 5, 20, 6, 22, 897, DateTimeKind.Local).AddTicks(9572), null, null, null, new Guid("a88ce11e-6617-4737-99d7-d09d169fa46c"), 1, new Guid("87f78a24-8cca-4c87-befe-a06430b03c29") });
        }
    }
}
