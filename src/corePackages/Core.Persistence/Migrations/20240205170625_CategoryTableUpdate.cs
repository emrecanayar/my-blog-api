using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CategoryTableUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<Guid>(
                name: "UploadedFileId",
                table: "Categories",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

            migrationBuilder.CreateIndex(
                name: "IX_Categories_UploadedFileId",
                table: "Categories",
                column: "UploadedFileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_UploadedFiles_UploadedFileId",
                table: "Categories",
                column: "UploadedFileId",
                principalTable: "UploadedFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_UploadedFiles_UploadedFileId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_UploadedFileId",
                table: "Categories");

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

            migrationBuilder.DropColumn(
                name: "UploadedFileId",
                table: "Categories");

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
    }
}
