using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class BusEntityUpgraded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("04e29ca1-3af2-4107-97ed-88d2cea3f2b4"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("98d0acda-cb7c-4729-a703-21984c50a185"));

            migrationBuilder.AddColumn<int>(
                name: "Column",
                table: "Buses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DoorGapRowIndex",
                table: "Buses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DoorGapSize",
                table: "Buses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Row",
                table: "Buses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("979f14aa-5f6e-4afd-abcc-120a1631f80d"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@admin.io", new byte[] { 225, 144, 198, 97, 127, 168, 176, 144, 118, 100, 218, 163, 169, 51, 225, 14, 75, 130, 165, 72, 196, 126, 84, 42, 11, 54, 76, 119, 152, 198, 130, 195, 246, 20, 149, 222, 211, 123, 198, 247, 207, 194, 50, 6, 117, 204, 126, 51, 249, 111, 206, 149, 37, 235, 114, 122, 168, 132, 205, 164, 88, 49, 106, 47 }, new byte[] { 8, 199, 201, 208, 165, 220, 91, 238, 14, 142, 230, 51, 74, 175, 157, 33, 66, 39, 143, 76, 216, 34, 234, 92, 164, 83, 77, 133, 48, 125, 183, 161, 139, 237, 60, 152, 237, 252, 64, 137, 25, 130, 220, 36, 221, 27, 254, 204, 211, 156, 201, 66, 29, 217, 147, 23, 160, 98, 108, 158, 12, 35, 209, 55, 1, 159, 196, 43, 13, 159, 63, 130, 229, 52, 137, 59, 132, 161, 214, 68, 218, 1, 221, 203, 207, 67, 65, 224, 56, 124, 43, 54, 70, 26, 74, 66, 14, 250, 121, 147, 219, 236, 45, 26, 223, 25, 44, 95, 125, 183, 204, 78, 21, 187, 113, 104, 212, 52, 216, 75, 32, 137, 224, 31, 193, 236, 187, 189 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("0232819f-19a8-4cb5-b0a2-814d1f0504ac"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("979f14aa-5f6e-4afd-abcc-120a1631f80d") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("0232819f-19a8-4cb5-b0a2-814d1f0504ac"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("979f14aa-5f6e-4afd-abcc-120a1631f80d"));

            migrationBuilder.DropColumn(
                name: "Column",
                table: "Buses");

            migrationBuilder.DropColumn(
                name: "DoorGapRowIndex",
                table: "Buses");

            migrationBuilder.DropColumn(
                name: "DoorGapSize",
                table: "Buses");

            migrationBuilder.DropColumn(
                name: "Row",
                table: "Buses");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("98d0acda-cb7c-4729-a703-21984c50a185"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@admin.io", new byte[] { 244, 167, 41, 55, 44, 61, 122, 126, 77, 144, 15, 9, 10, 145, 61, 227, 28, 248, 3, 186, 194, 76, 249, 191, 246, 161, 227, 203, 130, 14, 219, 50, 6, 171, 44, 188, 52, 152, 118, 154, 104, 115, 226, 70, 134, 185, 138, 46, 175, 80, 7, 166, 5, 134, 184, 165, 144, 112, 127, 153, 79, 103, 58, 157 }, new byte[] { 115, 209, 57, 140, 25, 241, 48, 92, 25, 22, 204, 81, 44, 239, 104, 167, 12, 53, 130, 41, 124, 176, 60, 213, 241, 106, 217, 48, 169, 158, 175, 232, 50, 230, 83, 116, 103, 135, 77, 68, 50, 92, 226, 54, 50, 160, 241, 97, 237, 191, 83, 2, 19, 116, 85, 41, 137, 84, 185, 60, 139, 43, 131, 255, 228, 239, 49, 1, 202, 227, 38, 38, 61, 0, 98, 17, 161, 78, 73, 59, 114, 41, 178, 197, 197, 175, 9, 65, 22, 208, 219, 209, 230, 174, 92, 134, 199, 219, 69, 21, 150, 41, 169, 216, 196, 10, 44, 29, 24, 67, 121, 58, 39, 135, 180, 27, 55, 171, 178, 0, 40, 208, 93, 202, 23, 113, 57, 129 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("04e29ca1-3af2-4107-97ed-88d2cea3f2b4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("98d0acda-cb7c-4729-a703-21984c50a185") });
        }
    }
}
