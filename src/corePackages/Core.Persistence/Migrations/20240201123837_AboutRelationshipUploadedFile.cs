using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AboutRelationshipUploadedFile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("ee95d17f-6b1f-4830-9247-bedaa33b498d"));

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("c2d4b115-5d3f-4df1-838d-a9f16437b28d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4ebe2893-6613-4791-a2af-464bf5494191"));

            migrationBuilder.AddColumn<Guid>(
                name: "UploadedFileId",
                table: "Abouts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

            migrationBuilder.CreateIndex(
                name: "IX_Abouts_UploadedFileId",
                table: "Abouts",
                column: "UploadedFileId");

            migrationBuilder.AddForeignKey(
                name: "FK_Abouts_UploadedFiles_UploadedFileId",
                table: "Abouts",
                column: "UploadedFileId",
                principalTable: "UploadedFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Abouts_UploadedFiles_UploadedFileId",
                table: "Abouts");

            migrationBuilder.DropIndex(
                name: "IX_Abouts_UploadedFileId",
                table: "Abouts");

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

            migrationBuilder.DropColumn(
                name: "UploadedFileId",
                table: "Abouts");

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "ModifiedBy", "ModifiedDate", "Name", "Status" },
                values: new object[] { new Guid("c2d4b115-5d3f-4df1-838d-a9f16437b28d"), "Admin", new DateTime(2024, 2, 1, 13, 39, 0, 746, DateTimeKind.Local).AddTicks(5574), null, null, null, "Admin", 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedBy", "CreatedDate", "CultureType", "DeletedDate", "Email", "FirstName", "LastName", "ModifiedBy", "ModifiedDate", "PasswordHash", "PasswordSalt", "Status" },
                values: new object[] { new Guid("4ebe2893-6613-4791-a2af-464bf5494191"), 0, "Admin", new DateTime(2024, 2, 1, 13, 39, 0, 749, DateTimeKind.Local).AddTicks(3722), 0, null, "admin@admin.com", "Admin", "Admin", null, null, new byte[] { 130, 110, 243, 106, 42, 69, 67, 45, 69, 20, 55, 213, 9, 171, 82, 253, 105, 146, 18, 14, 135, 37, 129, 59, 167, 129, 13, 187, 66, 80, 24, 99, 234, 153, 233, 158, 234, 1, 248, 86, 101, 239, 138, 191, 194, 79, 30, 126, 71, 156, 96, 107, 164, 85, 187, 97, 88, 119, 175, 247, 61, 193, 80, 137 }, new byte[] { 169, 96, 42, 2, 67, 209, 138, 25, 194, 129, 180, 162, 178, 94, 167, 216, 193, 15, 115, 89, 36, 93, 62, 233, 186, 26, 19, 177, 124, 54, 31, 233, 231, 119, 69, 58, 1, 135, 216, 140, 237, 231, 66, 217, 244, 223, 61, 158, 0, 11, 238, 221, 65, 246, 186, 80, 192, 123, 160, 6, 200, 201, 134, 76, 237, 114, 98, 213, 212, 140, 100, 175, 74, 171, 83, 251, 29, 129, 111, 38, 22, 76, 93, 114, 17, 227, 140, 105, 239, 195, 219, 144, 13, 207, 30, 153, 194, 228, 70, 14, 148, 47, 180, 215, 173, 240, 226, 74, 98, 243, 229, 3, 56, 3, 56, 16, 164, 218, 177, 197, 86, 166, 34, 211, 36, 250, 235, 19 }, 1 });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DeletedDate", "ModifiedBy", "ModifiedDate", "OperationClaimId", "Status", "UserId" },
                values: new object[] { new Guid("ee95d17f-6b1f-4830-9247-bedaa33b498d"), "Admin", new DateTime(2024, 2, 1, 13, 39, 0, 749, DateTimeKind.Local).AddTicks(9514), null, null, null, new Guid("c2d4b115-5d3f-4df1-838d-a9f16437b28d"), 1, new Guid("4ebe2893-6613-4791-a2af-464bf5494191") });
        }
    }
}
