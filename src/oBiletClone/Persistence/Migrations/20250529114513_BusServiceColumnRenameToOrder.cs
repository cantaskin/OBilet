using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class BusServiceColumnRenameToOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("4cefd587-e3cc-4263-8f6e-d6bd0f0b7dd1"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("485833c9-7a29-4def-8728-de180f79d4b1"));

            migrationBuilder.RenameColumn(
                name: "Column",
                table: "BusServiceStations",
                newName: "Order");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("f1bfcdc0-df14-48d2-a515-77d1783a7667"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@admin.io", new byte[] { 71, 151, 127, 181, 117, 234, 251, 167, 191, 50, 10, 214, 5, 78, 4, 72, 218, 119, 254, 6, 134, 171, 254, 118, 223, 141, 183, 171, 12, 167, 119, 169, 79, 166, 127, 241, 137, 5, 74, 111, 48, 169, 17, 207, 8, 217, 5, 120, 9, 101, 36, 114, 133, 224, 131, 201, 54, 250, 209, 155, 122, 1, 187, 34 }, new byte[] { 230, 37, 240, 54, 54, 11, 183, 182, 140, 62, 181, 0, 38, 136, 198, 137, 136, 213, 176, 237, 232, 124, 33, 32, 168, 171, 60, 253, 144, 184, 188, 225, 237, 113, 6, 84, 141, 0, 175, 151, 142, 72, 82, 235, 232, 78, 72, 121, 149, 199, 10, 107, 226, 121, 71, 249, 43, 192, 31, 235, 29, 126, 168, 109, 175, 59, 234, 79, 198, 171, 224, 72, 38, 108, 160, 31, 188, 25, 160, 128, 113, 74, 238, 86, 86, 117, 233, 39, 35, 57, 196, 197, 84, 50, 154, 58, 8, 49, 182, 185, 141, 130, 226, 115, 214, 70, 144, 203, 209, 135, 226, 85, 72, 75, 77, 113, 170, 156, 206, 114, 242, 34, 64, 241, 1, 36, 159, 203 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("35dec4a8-3a15-40a7-916a-6fbaae3ead43"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("f1bfcdc0-df14-48d2-a515-77d1783a7667") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("35dec4a8-3a15-40a7-916a-6fbaae3ead43"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f1bfcdc0-df14-48d2-a515-77d1783a7667"));

            migrationBuilder.RenameColumn(
                name: "Order",
                table: "BusServiceStations",
                newName: "Column");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("485833c9-7a29-4def-8728-de180f79d4b1"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@admin.io", new byte[] { 139, 162, 255, 169, 167, 102, 90, 190, 246, 103, 17, 121, 252, 72, 157, 191, 245, 237, 178, 211, 122, 213, 26, 17, 116, 175, 180, 217, 229, 154, 127, 174, 65, 142, 167, 24, 220, 78, 241, 89, 77, 224, 202, 24, 147, 59, 168, 234, 225, 218, 31, 167, 118, 230, 35, 70, 141, 44, 149, 140, 173, 216, 210, 194 }, new byte[] { 223, 230, 106, 152, 220, 212, 69, 79, 49, 195, 223, 157, 229, 31, 251, 217, 208, 12, 26, 82, 50, 167, 202, 203, 20, 68, 182, 194, 52, 187, 106, 186, 18, 206, 131, 10, 160, 196, 106, 123, 28, 124, 63, 110, 153, 116, 49, 249, 133, 163, 248, 102, 156, 227, 212, 137, 190, 106, 223, 134, 55, 73, 137, 111, 53, 34, 109, 244, 143, 72, 75, 208, 251, 53, 183, 244, 16, 173, 158, 188, 1, 32, 103, 238, 160, 82, 229, 225, 39, 16, 224, 155, 135, 113, 35, 137, 151, 131, 78, 19, 140, 216, 179, 203, 15, 86, 99, 79, 73, 249, 246, 154, 73, 17, 56, 77, 203, 133, 243, 20, 25, 96, 243, 85, 153, 174, 87, 61 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("4cefd587-e3cc-4263-8f6e-d6bd0f0b7dd1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("485833c9-7a29-4def-8728-de180f79d4b1") });
        }
    }
}
