using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class BusServiceStationsBusServiceRootIdAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("187370cc-46f7-44e3-a2ff-8ca9668a7c39"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("87d7e3e9-f339-478a-b163-6aa672ea1b94"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("55cea79c-70b7-4ca6-9ea3-c63be08c9701"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@admin.io", new byte[] { 146, 109, 122, 79, 235, 111, 116, 79, 159, 95, 57, 165, 219, 49, 210, 192, 221, 149, 112, 2, 220, 163, 232, 226, 242, 34, 59, 119, 1, 215, 11, 15, 90, 113, 170, 212, 98, 6, 3, 135, 246, 34, 210, 205, 238, 30, 42, 23, 224, 26, 52, 233, 31, 161, 181, 213, 176, 122, 97, 28, 7, 94, 38, 158 }, new byte[] { 207, 183, 209, 153, 103, 215, 37, 142, 219, 225, 27, 24, 132, 116, 194, 245, 159, 105, 255, 164, 249, 206, 234, 0, 75, 163, 77, 181, 118, 135, 71, 118, 133, 43, 4, 180, 251, 18, 194, 128, 216, 72, 205, 72, 181, 120, 41, 9, 6, 98, 169, 98, 70, 143, 239, 246, 25, 210, 251, 228, 51, 152, 122, 253, 182, 121, 53, 184, 163, 209, 68, 3, 42, 234, 160, 169, 50, 194, 198, 44, 203, 102, 224, 79, 72, 248, 30, 39, 116, 171, 33, 57, 49, 192, 226, 69, 237, 87, 154, 174, 137, 82, 64, 211, 20, 235, 86, 56, 131, 133, 86, 155, 45, 112, 48, 84, 151, 215, 17, 154, 229, 65, 5, 191, 251, 203, 207, 99 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("e666df3d-efb6-4c69-8cea-0b02dbfb31b2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("55cea79c-70b7-4ca6-9ea3-c63be08c9701") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("e666df3d-efb6-4c69-8cea-0b02dbfb31b2"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("55cea79c-70b7-4ca6-9ea3-c63be08c9701"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("87d7e3e9-f339-478a-b163-6aa672ea1b94"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@admin.io", new byte[] { 222, 170, 253, 21, 54, 145, 1, 41, 108, 46, 238, 189, 233, 52, 188, 151, 51, 13, 226, 61, 1, 28, 200, 183, 85, 25, 148, 18, 173, 150, 69, 78, 74, 38, 189, 222, 43, 202, 8, 176, 190, 175, 105, 252, 141, 37, 156, 148, 219, 86, 148, 244, 11, 235, 198, 81, 2, 17, 68, 81, 40, 218, 248, 238 }, new byte[] { 116, 94, 59, 255, 60, 53, 3, 199, 206, 41, 67, 182, 86, 204, 50, 198, 45, 223, 239, 229, 151, 56, 66, 216, 87, 14, 216, 173, 146, 99, 162, 249, 111, 97, 180, 104, 166, 75, 53, 236, 16, 195, 27, 118, 139, 140, 83, 77, 115, 10, 52, 249, 59, 146, 2, 229, 191, 96, 3, 55, 49, 80, 233, 174, 23, 94, 163, 67, 209, 154, 169, 225, 113, 70, 30, 2, 220, 169, 217, 174, 88, 13, 210, 197, 220, 187, 112, 145, 132, 67, 73, 57, 171, 237, 250, 125, 81, 160, 187, 23, 102, 215, 122, 161, 20, 25, 41, 73, 157, 152, 165, 210, 246, 118, 72, 132, 238, 233, 175, 91, 177, 234, 227, 74, 254, 77, 110, 15 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("187370cc-46f7-44e3-a2ff-8ca9668a7c39"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("87d7e3e9-f339-478a-b163-6aa672ea1b94") });
        }
    }
}
