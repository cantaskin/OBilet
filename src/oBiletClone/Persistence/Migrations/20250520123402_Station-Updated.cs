using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class StationUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("f8bee5d5-c15f-4f34-911f-a7e47a2794f7"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d15316fe-c4a9-4ff5-bb66-85aa5f305095"));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Stations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("d05e8c70-3ad0-4038-86cb-ac4f444d2064"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@admin.io", new byte[] { 209, 10, 145, 31, 45, 106, 148, 112, 226, 192, 148, 219, 176, 57, 193, 125, 168, 0, 188, 178, 5, 30, 163, 168, 201, 80, 113, 20, 11, 108, 136, 90, 195, 75, 77, 250, 174, 235, 32, 177, 206, 205, 85, 101, 255, 49, 188, 78, 248, 13, 131, 228, 153, 200, 5, 146, 101, 8, 16, 246, 41, 179, 199, 9 }, new byte[] { 29, 59, 103, 30, 48, 115, 141, 219, 116, 134, 51, 89, 37, 19, 217, 188, 180, 230, 125, 248, 129, 101, 141, 93, 231, 83, 76, 121, 179, 157, 119, 241, 150, 11, 229, 128, 84, 163, 29, 113, 84, 182, 162, 93, 250, 247, 113, 208, 98, 45, 213, 99, 118, 146, 193, 149, 86, 153, 238, 238, 31, 162, 53, 57, 160, 107, 232, 212, 96, 22, 223, 98, 156, 211, 170, 16, 203, 190, 133, 23, 55, 250, 69, 16, 166, 28, 68, 195, 228, 52, 190, 104, 220, 62, 235, 130, 241, 248, 238, 200, 106, 124, 234, 41, 64, 61, 36, 141, 68, 122, 224, 204, 11, 192, 38, 78, 216, 23, 209, 176, 159, 226, 43, 175, 245, 236, 233, 189 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("42b62e62-9508-4539-a647-c9083a964863"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("d05e8c70-3ad0-4038-86cb-ac4f444d2064") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("42b62e62-9508-4539-a647-c9083a964863"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d05e8c70-3ad0-4038-86cb-ac4f444d2064"));

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Stations");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("d15316fe-c4a9-4ff5-bb66-85aa5f305095"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@admin.io", new byte[] { 113, 103, 114, 26, 124, 215, 204, 244, 228, 206, 167, 188, 177, 173, 187, 217, 147, 191, 60, 20, 87, 23, 98, 40, 124, 161, 15, 72, 9, 125, 135, 244, 244, 9, 193, 112, 3, 44, 73, 184, 18, 235, 106, 114, 219, 78, 143, 157, 60, 4, 169, 211, 133, 38, 153, 205, 58, 235, 164, 106, 216, 158, 101, 253 }, new byte[] { 61, 143, 142, 58, 66, 41, 249, 13, 255, 223, 168, 14, 129, 28, 236, 226, 80, 138, 224, 159, 148, 57, 25, 74, 135, 249, 243, 97, 149, 19, 107, 64, 165, 86, 201, 109, 63, 69, 171, 194, 47, 166, 211, 30, 118, 247, 131, 220, 47, 124, 64, 43, 141, 13, 30, 58, 244, 72, 80, 254, 126, 233, 162, 246, 62, 30, 207, 3, 123, 52, 52, 163, 127, 98, 129, 51, 155, 51, 94, 209, 148, 194, 216, 57, 33, 253, 79, 5, 80, 1, 202, 131, 125, 76, 187, 162, 49, 136, 241, 8, 121, 16, 129, 84, 198, 46, 254, 184, 207, 133, 217, 216, 165, 216, 167, 244, 36, 85, 16, 28, 60, 139, 203, 51, 116, 144, 146, 248 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("f8bee5d5-c15f-4f34-911f-a7e47a2794f7"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("d15316fe-c4a9-4ff5-bb66-85aa5f305095") });
        }
    }
}
