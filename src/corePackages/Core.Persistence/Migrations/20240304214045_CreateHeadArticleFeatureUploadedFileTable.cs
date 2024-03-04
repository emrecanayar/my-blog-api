using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreateHeadArticleFeatureUploadedFileTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HeadArticleFeatureUploadedFile_HeadArticleFeatures_HeadArticleFeatureId",
                table: "HeadArticleFeatureUploadedFile");

            migrationBuilder.DropForeignKey(
                name: "FK_HeadArticleFeatureUploadedFile_UploadedFiles_UploadedFileId",
                table: "HeadArticleFeatureUploadedFile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HeadArticleFeatureUploadedFile",
                table: "HeadArticleFeatureUploadedFile");

            migrationBuilder.RenameTable(
                name: "HeadArticleFeatureUploadedFile",
                newName: "HeadArticleFeatureUploadedFiles");

            migrationBuilder.RenameIndex(
                name: "IX_HeadArticleFeatureUploadedFile_UploadedFileId",
                table: "HeadArticleFeatureUploadedFiles",
                newName: "IX_HeadArticleFeatureUploadedFiles_UploadedFileId");

            migrationBuilder.RenameIndex(
                name: "IX_HeadArticleFeatureUploadedFile_HeadArticleFeatureId",
                table: "HeadArticleFeatureUploadedFiles",
                newName: "IX_HeadArticleFeatureUploadedFiles_HeadArticleFeatureId");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "HeadArticleFeatureUploadedFiles",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "HeadArticleFeatureUploadedFiles",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "HeadArticleFeatureUploadedFiles",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "HeadArticleFeatureUploadedFiles",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "NewPath",
                table: "HeadArticleFeatureUploadedFiles",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OldPath",
                table: "HeadArticleFeatureUploadedFiles",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HeadArticleFeatureUploadedFiles",
                table: "HeadArticleFeatureUploadedFiles",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("19afb672-bf92-47b0-ac84-2997c4320245"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 114, 94, 111, 21, 230, 252, 220, 58, 175, 244, 130, 162, 230, 116, 16, 174, 238, 12, 44, 231, 222, 95, 141, 156, 199, 174, 51, 104, 205, 115, 100, 84, 150, 51, 232, 240, 206, 125, 234, 65, 29, 0, 240, 121, 181, 114, 57, 189, 159, 61, 42, 241, 69, 174, 162, 3, 110, 194, 111, 253, 3, 101, 129, 28 }, new byte[] { 21, 89, 131, 24, 99, 176, 140, 163, 50, 190, 69, 77, 156, 90, 172, 229, 96, 49, 204, 82, 210, 114, 240, 9, 50, 79, 178, 105, 231, 219, 57, 80, 107, 35, 72, 158, 138, 66, 227, 121, 195, 72, 241, 40, 70, 27, 186, 58, 54, 64, 183, 116, 157, 139, 118, 141, 238, 131, 120, 116, 36, 79, 51, 139, 145, 195, 244, 229, 207, 67, 59, 201, 125, 18, 121, 77, 234, 109, 10, 167, 130, 173, 87, 118, 5, 19, 4, 217, 92, 97, 38, 225, 100, 42, 134, 250, 156, 203, 106, 15, 249, 129, 48, 133, 239, 69, 58, 249, 209, 191, 230, 104, 190, 116, 164, 3, 66, 89, 170, 58, 57, 48, 249, 246, 231, 127, 95, 102 } });

            migrationBuilder.AddForeignKey(
                name: "FK_HeadArticleFeatureUploadedFiles_HeadArticleFeatures_HeadArticleFeatureId",
                table: "HeadArticleFeatureUploadedFiles",
                column: "HeadArticleFeatureId",
                principalTable: "HeadArticleFeatures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HeadArticleFeatureUploadedFiles_UploadedFiles_UploadedFileId",
                table: "HeadArticleFeatureUploadedFiles",
                column: "UploadedFileId",
                principalTable: "UploadedFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HeadArticleFeatureUploadedFiles_HeadArticleFeatures_HeadArticleFeatureId",
                table: "HeadArticleFeatureUploadedFiles");

            migrationBuilder.DropForeignKey(
                name: "FK_HeadArticleFeatureUploadedFiles_UploadedFiles_UploadedFileId",
                table: "HeadArticleFeatureUploadedFiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HeadArticleFeatureUploadedFiles",
                table: "HeadArticleFeatureUploadedFiles");

            migrationBuilder.DropColumn(
                name: "NewPath",
                table: "HeadArticleFeatureUploadedFiles");

            migrationBuilder.DropColumn(
                name: "OldPath",
                table: "HeadArticleFeatureUploadedFiles");

            migrationBuilder.RenameTable(
                name: "HeadArticleFeatureUploadedFiles",
                newName: "HeadArticleFeatureUploadedFile");

            migrationBuilder.RenameIndex(
                name: "IX_HeadArticleFeatureUploadedFiles_UploadedFileId",
                table: "HeadArticleFeatureUploadedFile",
                newName: "IX_HeadArticleFeatureUploadedFile_UploadedFileId");

            migrationBuilder.RenameIndex(
                name: "IX_HeadArticleFeatureUploadedFiles_HeadArticleFeatureId",
                table: "HeadArticleFeatureUploadedFile",
                newName: "IX_HeadArticleFeatureUploadedFile_HeadArticleFeatureId");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "HeadArticleFeatureUploadedFile",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedBy",
                table: "HeadArticleFeatureUploadedFile",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                table: "HeadArticleFeatureUploadedFile",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "HeadArticleFeatureUploadedFile",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddPrimaryKey(
                name: "PK_HeadArticleFeatureUploadedFile",
                table: "HeadArticleFeatureUploadedFile",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("19afb672-bf92-47b0-ac84-2997c4320245"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 216, 147, 20, 132, 74, 28, 140, 249, 213, 245, 42, 32, 71, 150, 142, 59, 88, 40, 77, 123, 202, 147, 183, 163, 63, 232, 114, 48, 132, 34, 13, 61, 166, 139, 2, 129, 196, 36, 168, 18, 77, 28, 111, 109, 80, 44, 164, 255, 204, 36, 71, 112, 147, 84, 246, 5, 149, 125, 191, 148, 144, 118, 44, 18 }, new byte[] { 225, 252, 135, 194, 186, 131, 51, 93, 39, 88, 102, 43, 60, 237, 163, 142, 72, 134, 162, 241, 188, 149, 125, 220, 81, 24, 8, 124, 45, 78, 2, 76, 10, 134, 188, 117, 92, 98, 32, 198, 150, 238, 110, 121, 20, 75, 80, 7, 125, 63, 13, 210, 25, 21, 38, 178, 16, 21, 10, 213, 195, 80, 113, 187, 51, 195, 177, 132, 141, 113, 90, 184, 24, 244, 29, 187, 60, 20, 12, 213, 210, 104, 144, 76, 23, 36, 73, 145, 233, 9, 57, 121, 150, 217, 245, 14, 130, 119, 201, 164, 250, 109, 161, 89, 237, 203, 215, 184, 145, 109, 120, 4, 37, 198, 81, 32, 1, 226, 250, 199, 53, 106, 128, 205, 193, 199, 86, 53 } });

            migrationBuilder.AddForeignKey(
                name: "FK_HeadArticleFeatureUploadedFile_HeadArticleFeatures_HeadArticleFeatureId",
                table: "HeadArticleFeatureUploadedFile",
                column: "HeadArticleFeatureId",
                principalTable: "HeadArticleFeatures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HeadArticleFeatureUploadedFile_UploadedFiles_UploadedFileId",
                table: "HeadArticleFeatureUploadedFile",
                column: "UploadedFileId",
                principalTable: "UploadedFiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
