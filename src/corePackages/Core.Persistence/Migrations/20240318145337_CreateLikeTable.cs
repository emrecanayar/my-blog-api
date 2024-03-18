using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreateLikeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ParentCommentId",
                table: "Comments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsLiked = table.Column<bool>(type: "bit", nullable: false),
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
                    table.PrimaryKey("PK_Likes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Likes_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Likes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("19afb672-bf92-47b0-ac84-2997c4320245"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 154, 143, 243, 144, 82, 153, 203, 137, 26, 176, 138, 99, 241, 9, 200, 153, 122, 28, 49, 163, 176, 152, 105, 138, 37, 235, 218, 213, 42, 116, 204, 149, 207, 172, 106, 119, 152, 104, 50, 157, 115, 130, 244, 169, 9, 61, 5, 125, 49, 56, 195, 41, 213, 45, 22, 117, 35, 193, 102, 59, 192, 183, 171, 140 }, new byte[] { 131, 155, 255, 14, 85, 181, 31, 10, 11, 244, 246, 244, 159, 20, 135, 20, 104, 76, 234, 4, 83, 234, 131, 80, 101, 121, 211, 25, 178, 206, 43, 161, 55, 43, 252, 67, 240, 56, 54, 100, 149, 223, 149, 73, 151, 126, 200, 9, 79, 169, 18, 153, 102, 117, 225, 200, 3, 101, 214, 67, 55, 4, 17, 21, 105, 86, 89, 141, 250, 37, 231, 154, 145, 206, 135, 146, 133, 100, 190, 226, 207, 131, 79, 64, 1, 52, 140, 94, 196, 133, 245, 228, 66, 186, 101, 241, 254, 77, 141, 82, 65, 70, 253, 54, 38, 201, 189, 194, 135, 119, 62, 175, 117, 169, 185, 176, 126, 176, 142, 134, 153, 150, 38, 135, 137, 64, 228, 175 } });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ParentCommentId",
                table: "Comments",
                column: "ParentCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_CommentId",
                table: "Likes",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_UserId",
                table: "Likes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_ParentCommentId",
                table: "Comments",
                column: "ParentCommentId",
                principalTable: "Comments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_ParentCommentId",
                table: "Comments");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ParentCommentId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ParentCommentId",
                table: "Comments");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("19afb672-bf92-47b0-ac84-2997c4320245"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 228, 32, 168, 155, 25, 197, 69, 129, 213, 54, 194, 113, 253, 200, 44, 218, 206, 53, 17, 217, 229, 85, 224, 128, 94, 34, 212, 55, 204, 24, 151, 242, 138, 227, 85, 4, 235, 235, 230, 190, 15, 56, 157, 240, 120, 22, 104, 170, 129, 49, 186, 125, 18, 10, 249, 169, 180, 235, 216, 147, 201, 141, 130, 83 }, new byte[] { 166, 145, 199, 201, 252, 233, 243, 227, 206, 12, 101, 172, 37, 226, 212, 113, 185, 230, 216, 202, 27, 192, 123, 0, 210, 158, 200, 219, 22, 67, 16, 137, 120, 130, 70, 112, 235, 4, 109, 80, 83, 200, 58, 139, 12, 116, 102, 13, 120, 114, 67, 107, 244, 103, 212, 139, 146, 113, 171, 156, 107, 34, 87, 192, 167, 49, 11, 111, 250, 233, 64, 182, 151, 95, 185, 163, 15, 159, 200, 133, 115, 129, 187, 216, 160, 0, 7, 167, 87, 14, 237, 176, 39, 194, 222, 208, 152, 42, 180, 211, 185, 187, 64, 218, 68, 201, 237, 228, 81, 94, 193, 235, 71, 60, 142, 220, 62, 189, 118, 10, 239, 31, 140, 124, 46, 96, 104, 250 } });
        }
    }
}
