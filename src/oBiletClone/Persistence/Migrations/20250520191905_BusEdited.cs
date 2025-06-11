using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class BusEdited : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("42b62e62-9508-4539-a647-c9083a964863"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d05e8c70-3ad0-4038-86cb-ac4f444d2064"));

            migrationBuilder.RenameColumn(
                name: "NeighborSeatId",
                table: "Seats",
                newName: "TopSeatId");

            migrationBuilder.RenameColumn(
                name: "BusInsideSeatId",
                table: "Seats",
                newName: "LocalSeatId");

            migrationBuilder.AddColumn<int>(
                name: "BottomSeatId",
                table: "Seats",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LeftSeatId",
                table: "Seats",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RightSeatId",
                table: "Seats",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("98d0acda-cb7c-4729-a703-21984c50a185"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@admin.io", new byte[] { 244, 167, 41, 55, 44, 61, 122, 126, 77, 144, 15, 9, 10, 145, 61, 227, 28, 248, 3, 186, 194, 76, 249, 191, 246, 161, 227, 203, 130, 14, 219, 50, 6, 171, 44, 188, 52, 152, 118, 154, 104, 115, 226, 70, 134, 185, 138, 46, 175, 80, 7, 166, 5, 134, 184, 165, 144, 112, 127, 153, 79, 103, 58, 157 }, new byte[] { 115, 209, 57, 140, 25, 241, 48, 92, 25, 22, 204, 81, 44, 239, 104, 167, 12, 53, 130, 41, 124, 176, 60, 213, 241, 106, 217, 48, 169, 158, 175, 232, 50, 230, 83, 116, 103, 135, 77, 68, 50, 92, 226, 54, 50, 160, 241, 97, 237, 191, 83, 2, 19, 116, 85, 41, 137, 84, 185, 60, 139, 43, 131, 255, 228, 239, 49, 1, 202, 227, 38, 38, 61, 0, 98, 17, 161, 78, 73, 59, 114, 41, 178, 197, 197, 175, 9, 65, 22, 208, 219, 209, 230, 174, 92, 134, 199, 219, 69, 21, 150, 41, 169, 216, 196, 10, 44, 29, 24, 67, 121, 58, 39, 135, 180, 27, 55, 171, 178, 0, 40, 208, 93, 202, 23, 113, 57, 129 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("04e29ca1-3af2-4107-97ed-88d2cea3f2b4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("98d0acda-cb7c-4729-a703-21984c50a185") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("04e29ca1-3af2-4107-97ed-88d2cea3f2b4"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("98d0acda-cb7c-4729-a703-21984c50a185"));

            migrationBuilder.DropColumn(
                name: "BottomSeatId",
                table: "Seats");

            migrationBuilder.DropColumn(
                name: "LeftSeatId",
                table: "Seats");

            migrationBuilder.DropColumn(
                name: "RightSeatId",
                table: "Seats");

            migrationBuilder.RenameColumn(
                name: "TopSeatId",
                table: "Seats",
                newName: "NeighborSeatId");

            migrationBuilder.RenameColumn(
                name: "LocalSeatId",
                table: "Seats",
                newName: "BusInsideSeatId");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("d05e8c70-3ad0-4038-86cb-ac4f444d2064"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@admin.io", new byte[] { 209, 10, 145, 31, 45, 106, 148, 112, 226, 192, 148, 219, 176, 57, 193, 125, 168, 0, 188, 178, 5, 30, 163, 168, 201, 80, 113, 20, 11, 108, 136, 90, 195, 75, 77, 250, 174, 235, 32, 177, 206, 205, 85, 101, 255, 49, 188, 78, 248, 13, 131, 228, 153, 200, 5, 146, 101, 8, 16, 246, 41, 179, 199, 9 }, new byte[] { 29, 59, 103, 30, 48, 115, 141, 219, 116, 134, 51, 89, 37, 19, 217, 188, 180, 230, 125, 248, 129, 101, 141, 93, 231, 83, 76, 121, 179, 157, 119, 241, 150, 11, 229, 128, 84, 163, 29, 113, 84, 182, 162, 93, 250, 247, 113, 208, 98, 45, 213, 99, 118, 146, 193, 149, 86, 153, 238, 238, 31, 162, 53, 57, 160, 107, 232, 212, 96, 22, 223, 98, 156, 211, 170, 16, 203, 190, 133, 23, 55, 250, 69, 16, 166, 28, 68, 195, 228, 52, 190, 104, 220, 62, 235, 130, 241, 248, 238, 200, 106, 124, 234, 41, 64, 61, 36, 141, 68, 122, 224, 204, 11, 192, 38, 78, 216, 23, 209, 176, 159, 226, 43, 175, 245, 236, 233, 189 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("42b62e62-9508-4539-a647-c9083a964863"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("d05e8c70-3ad0-4038-86cb-ac4f444d2064") });
        }
    }
}
