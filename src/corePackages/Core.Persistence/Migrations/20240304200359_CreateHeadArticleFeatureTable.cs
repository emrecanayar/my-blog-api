using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreateHeadArticleFeatureTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HeadArticleFeatures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_HeadArticleFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HeadArticleFeatures_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HeadArticleFeatureUploadedFile",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HeadArticleFeatureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UploadedFileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeadArticleFeatureUploadedFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HeadArticleFeatureUploadedFile_HeadArticleFeatures_HeadArticleFeatureId",
                        column: x => x.HeadArticleFeatureId,
                        principalTable: "HeadArticleFeatures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HeadArticleFeatureUploadedFile_UploadedFiles_UploadedFileId",
                        column: x => x.UploadedFileId,
                        principalTable: "UploadedFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("19afb672-bf92-47b0-ac84-2997c4320245"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 216, 147, 20, 132, 74, 28, 140, 249, 213, 245, 42, 32, 71, 150, 142, 59, 88, 40, 77, 123, 202, 147, 183, 163, 63, 232, 114, 48, 132, 34, 13, 61, 166, 139, 2, 129, 196, 36, 168, 18, 77, 28, 111, 109, 80, 44, 164, 255, 204, 36, 71, 112, 147, 84, 246, 5, 149, 125, 191, 148, 144, 118, 44, 18 }, new byte[] { 225, 252, 135, 194, 186, 131, 51, 93, 39, 88, 102, 43, 60, 237, 163, 142, 72, 134, 162, 241, 188, 149, 125, 220, 81, 24, 8, 124, 45, 78, 2, 76, 10, 134, 188, 117, 92, 98, 32, 198, 150, 238, 110, 121, 20, 75, 80, 7, 125, 63, 13, 210, 25, 21, 38, 178, 16, 21, 10, 213, 195, 80, 113, 187, 51, 195, 177, 132, 141, 113, 90, 184, 24, 244, 29, 187, 60, 20, 12, 213, 210, 104, 144, 76, 23, 36, 73, 145, 233, 9, 57, 121, 150, 217, 245, 14, 130, 119, 201, 164, 250, 109, 161, 89, 237, 203, 215, 184, 145, 109, 120, 4, 37, 198, 81, 32, 1, 226, 250, 199, 53, 106, 128, 205, 193, 199, 86, 53 } });

            migrationBuilder.CreateIndex(
                name: "IX_HeadArticleFeatures_CategoryId",
                table: "HeadArticleFeatures",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_HeadArticleFeatureUploadedFile_HeadArticleFeatureId",
                table: "HeadArticleFeatureUploadedFile",
                column: "HeadArticleFeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_HeadArticleFeatureUploadedFile_UploadedFileId",
                table: "HeadArticleFeatureUploadedFile",
                column: "UploadedFileId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HeadArticleFeatureUploadedFile");

            migrationBuilder.DropTable(
                name: "HeadArticleFeatures");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("19afb672-bf92-47b0-ac84-2997c4320245"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 37, 190, 235, 225, 235, 221, 193, 190, 8, 216, 7, 202, 142, 177, 32, 213, 226, 77, 169, 223, 203, 82, 119, 105, 191, 84, 198, 84, 149, 131, 193, 10, 193, 100, 62, 245, 228, 48, 109, 206, 65, 91, 14, 82, 212, 3, 239, 16, 26, 222, 248, 188, 92, 180, 105, 56, 82, 134, 26, 185, 130, 140, 204, 184 }, new byte[] { 37, 95, 131, 38, 238, 152, 130, 99, 107, 9, 67, 161, 197, 115, 172, 153, 120, 213, 126, 83, 173, 243, 53, 1, 33, 147, 79, 247, 180, 113, 66, 167, 221, 246, 9, 179, 201, 222, 196, 118, 153, 251, 228, 102, 235, 84, 79, 203, 157, 143, 223, 107, 147, 137, 246, 174, 152, 220, 21, 186, 56, 92, 66, 94, 5, 35, 37, 108, 119, 80, 197, 131, 75, 5, 229, 120, 119, 8, 15, 207, 210, 47, 105, 119, 111, 202, 135, 103, 19, 209, 157, 114, 184, 129, 220, 111, 213, 10, 64, 98, 57, 114, 140, 190, 180, 113, 180, 71, 16, 159, 94, 79, 149, 46, 136, 8, 6, 198, 175, 65, 163, 155, 136, 108, 39, 20, 121, 220 } });
        }
    }
}
