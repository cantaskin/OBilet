using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class BusServiceStationsBusServiceRootId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("35dec4a8-3a15-40a7-916a-6fbaae3ead43"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f1bfcdc0-df14-48d2-a515-77d1783a7667"));

            migrationBuilder.AddColumn<int>(
                name: "BusServiceRootId",
                table: "BusServiceStations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("87d7e3e9-f339-478a-b163-6aa672ea1b94"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@admin.io", new byte[] { 222, 170, 253, 21, 54, 145, 1, 41, 108, 46, 238, 189, 233, 52, 188, 151, 51, 13, 226, 61, 1, 28, 200, 183, 85, 25, 148, 18, 173, 150, 69, 78, 74, 38, 189, 222, 43, 202, 8, 176, 190, 175, 105, 252, 141, 37, 156, 148, 219, 86, 148, 244, 11, 235, 198, 81, 2, 17, 68, 81, 40, 218, 248, 238 }, new byte[] { 116, 94, 59, 255, 60, 53, 3, 199, 206, 41, 67, 182, 86, 204, 50, 198, 45, 223, 239, 229, 151, 56, 66, 216, 87, 14, 216, 173, 146, 99, 162, 249, 111, 97, 180, 104, 166, 75, 53, 236, 16, 195, 27, 118, 139, 140, 83, 77, 115, 10, 52, 249, 59, 146, 2, 229, 191, 96, 3, 55, 49, 80, 233, 174, 23, 94, 163, 67, 209, 154, 169, 225, 113, 70, 30, 2, 220, 169, 217, 174, 88, 13, 210, 197, 220, 187, 112, 145, 132, 67, 73, 57, 171, 237, 250, 125, 81, 160, 187, 23, 102, 215, 122, 161, 20, 25, 41, 73, 157, 152, 165, 210, 246, 118, 72, 132, 238, 233, 175, 91, 177, 234, 227, 74, 254, 77, 110, 15 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("187370cc-46f7-44e3-a2ff-8ca9668a7c39"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("87d7e3e9-f339-478a-b163-6aa672ea1b94") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("187370cc-46f7-44e3-a2ff-8ca9668a7c39"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("87d7e3e9-f339-478a-b163-6aa672ea1b94"));

            migrationBuilder.DropColumn(
                name: "BusServiceRootId",
                table: "BusServiceStations");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("f1bfcdc0-df14-48d2-a515-77d1783a7667"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@admin.io", new byte[] { 71, 151, 127, 181, 117, 234, 251, 167, 191, 50, 10, 214, 5, 78, 4, 72, 218, 119, 254, 6, 134, 171, 254, 118, 223, 141, 183, 171, 12, 167, 119, 169, 79, 166, 127, 241, 137, 5, 74, 111, 48, 169, 17, 207, 8, 217, 5, 120, 9, 101, 36, 114, 133, 224, 131, 201, 54, 250, 209, 155, 122, 1, 187, 34 }, new byte[] { 230, 37, 240, 54, 54, 11, 183, 182, 140, 62, 181, 0, 38, 136, 198, 137, 136, 213, 176, 237, 232, 124, 33, 32, 168, 171, 60, 253, 144, 184, 188, 225, 237, 113, 6, 84, 141, 0, 175, 151, 142, 72, 82, 235, 232, 78, 72, 121, 149, 199, 10, 107, 226, 121, 71, 249, 43, 192, 31, 235, 29, 126, 168, 109, 175, 59, 234, 79, 198, 171, 224, 72, 38, 108, 160, 31, 188, 25, 160, 128, 113, 74, 238, 86, 86, 117, 233, 39, 35, 57, 196, 197, 84, 50, 154, 58, 8, 49, 182, 185, 141, 130, 226, 115, 214, 70, 144, 203, 209, 135, 226, 85, 72, 75, 77, 113, 170, 156, 206, 114, 242, 34, 64, 241, 1, 36, 159, 203 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("35dec4a8-3a15-40a7-916a-6fbaae3ead43"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("f1bfcdc0-df14-48d2-a515-77d1783a7667") });
        }
    }
}
