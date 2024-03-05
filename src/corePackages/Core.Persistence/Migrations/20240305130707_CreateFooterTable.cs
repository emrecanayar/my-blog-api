using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Core.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class CreateFooterTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Footers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(750)", maxLength: 750, nullable: false),
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
                    table.PrimaryKey("PK_Footers", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("19afb672-bf92-47b0-ac84-2997c4320245"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 158, 216, 166, 197, 218, 155, 166, 78, 178, 149, 83, 247, 72, 101, 37, 157, 48, 134, 207, 200, 68, 28, 84, 182, 40, 175, 35, 217, 214, 0, 88, 214, 38, 117, 44, 245, 48, 220, 88, 238, 240, 12, 29, 111, 152, 80, 2, 179, 133, 249, 195, 201, 11, 142, 84, 209, 159, 16, 22, 27, 15, 236, 150, 84 }, new byte[] { 215, 72, 105, 89, 244, 1, 171, 193, 50, 221, 174, 183, 132, 214, 35, 109, 216, 61, 88, 39, 89, 54, 197, 236, 99, 124, 204, 106, 225, 38, 61, 86, 2, 18, 55, 173, 60, 198, 230, 25, 84, 75, 40, 245, 127, 141, 222, 159, 102, 36, 68, 29, 242, 78, 165, 53, 54, 216, 153, 172, 3, 230, 16, 217, 42, 222, 21, 121, 148, 113, 116, 162, 17, 188, 13, 204, 128, 176, 174, 3, 223, 30, 65, 207, 234, 72, 52, 146, 145, 127, 82, 46, 184, 68, 150, 103, 6, 246, 36, 25, 122, 8, 98, 248, 159, 203, 37, 103, 44, 206, 160, 115, 60, 96, 134, 43, 13, 139, 225, 212, 76, 185, 113, 152, 39, 79, 211, 203 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Footers");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("19afb672-bf92-47b0-ac84-2997c4320245"),
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 114, 94, 111, 21, 230, 252, 220, 58, 175, 244, 130, 162, 230, 116, 16, 174, 238, 12, 44, 231, 222, 95, 141, 156, 199, 174, 51, 104, 205, 115, 100, 84, 150, 51, 232, 240, 206, 125, 234, 65, 29, 0, 240, 121, 181, 114, 57, 189, 159, 61, 42, 241, 69, 174, 162, 3, 110, 194, 111, 253, 3, 101, 129, 28 }, new byte[] { 21, 89, 131, 24, 99, 176, 140, 163, 50, 190, 69, 77, 156, 90, 172, 229, 96, 49, 204, 82, 210, 114, 240, 9, 50, 79, 178, 105, 231, 219, 57, 80, 107, 35, 72, 158, 138, 66, 227, 121, 195, 72, 241, 40, 70, 27, 186, 58, 54, 64, 183, 116, 157, 139, 118, 141, 238, 131, 120, 116, 36, 79, 51, 139, 145, 195, 244, 229, 207, 67, 59, 201, 125, 18, 121, 77, 234, 109, 10, 167, 130, 173, 87, 118, 5, 19, 4, 217, 92, 97, 38, 225, 100, 42, 134, 250, 156, 203, 106, 15, 249, 129, 48, 133, 239, 69, 58, 249, 209, 191, 230, 104, 190, 116, 164, 3, 66, 89, 170, 58, 57, 48, 249, 246, 231, 127, 95, 102 } });
        }
    }
}
