using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreateUserUploadedFilesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserUploadedFiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UploadedFileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.PrimaryKey("PK_UserUploadedFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserUploadedFiles_UploadedFiles_UploadedFileId",
                        column: x => x.UploadedFileId,
                        principalTable: "UploadedFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserUploadedFiles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("19afb672-bf92-47b0-ac84-2997c4320245"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 142, 223, 232, 9, 21, 157, 168, 26, 166, 20, 165, 227, 37, 193, 29, 208, 218, 249, 51, 81, 172, 16, 66, 105, 179, 171, 16, 102, 66, 137, 168, 104, 16, 175, 67, 179, 94, 39, 235, 184, 51, 14, 189, 134, 176, 112, 191, 250, 201, 160, 125, 125, 196, 29, 197, 156, 34, 227, 193, 232, 137, 6, 122, 79 }, new byte[] { 219, 245, 163, 150, 64, 212, 237, 237, 235, 218, 13, 201, 193, 180, 85, 186, 16, 101, 44, 98, 3, 18, 21, 185, 4, 38, 119, 60, 43, 141, 129, 219, 39, 184, 136, 180, 123, 205, 107, 223, 158, 2, 50, 144, 167, 5, 181, 182, 166, 42, 152, 239, 188, 97, 10, 190, 96, 135, 199, 113, 60, 104, 207, 67, 164, 87, 205, 76, 125, 18, 244, 160, 200, 197, 71, 253, 225, 183, 54, 162, 11, 244, 152, 57, 126, 122, 250, 238, 117, 69, 65, 214, 7, 172, 201, 166, 33, 54, 153, 119, 168, 3, 151, 120, 244, 234, 35, 97, 195, 121, 94, 75, 83, 21, 5, 70, 102, 179, 87, 53, 207, 223, 116, 252, 94, 18, 251, 195 } });

            migrationBuilder.CreateIndex(
                name: "IX_UserUploadedFiles_UploadedFileId",
                table: "UserUploadedFiles",
                column: "UploadedFileId");

            migrationBuilder.CreateIndex(
                name: "IX_UserUploadedFiles_UserId",
                table: "UserUploadedFiles",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserUploadedFiles");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("19afb672-bf92-47b0-ac84-2997c4320245"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 106, 138, 200, 84, 19, 38, 139, 133, 144, 51, 204, 95, 106, 215, 240, 185, 164, 68, 121, 134, 225, 1, 252, 190, 185, 134, 8, 83, 34, 160, 229, 103, 36, 11, 122, 60, 185, 218, 75, 156, 13, 205, 242, 213, 163, 125, 161, 81, 161, 39, 203, 7, 216, 49, 27, 227, 103, 206, 206, 99, 211, 9, 124, 203 }, new byte[] { 6, 73, 209, 199, 191, 141, 243, 34, 239, 53, 243, 127, 76, 28, 171, 33, 102, 253, 25, 241, 181, 133, 45, 14, 45, 28, 218, 79, 184, 137, 7, 159, 21, 28, 34, 152, 252, 120, 177, 162, 66, 105, 140, 26, 196, 241, 241, 52, 32, 194, 182, 132, 192, 100, 173, 3, 23, 41, 183, 140, 57, 109, 215, 170, 198, 78, 146, 6, 97, 24, 152, 117, 4, 65, 5, 167, 102, 140, 3, 148, 55, 62, 188, 77, 192, 135, 86, 36, 133, 21, 120, 175, 150, 69, 43, 54, 128, 12, 27, 43, 198, 119, 183, 12, 139, 197, 210, 250, 133, 201, 116, 38, 81, 63, 207, 186, 112, 183, 190, 3, 204, 70, 41, 107, 87, 150, 19, 73 } });
        }
    }
}
