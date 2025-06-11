using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ParentAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusServices_BusServices_BusServiceId",
                table: "BusServices");

            migrationBuilder.DropIndex(
                name: "IX_BusServices_BusServiceId",
                table: "BusServices");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("055bf683-0297-49e5-a710-3e7547720b20"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("bd1b9fa9-951a-4a61-a270-5ba4c0b2ad32"));

            migrationBuilder.DropColumn(
                name: "BusServiceId",
                table: "BusServices");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("074bcea3-ebac-4257-8106-cb1939e29591"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@admin.io", new byte[] { 230, 69, 247, 253, 12, 75, 8, 84, 237, 237, 249, 110, 22, 250, 103, 108, 66, 1, 186, 20, 209, 57, 115, 188, 76, 173, 236, 252, 14, 172, 220, 117, 102, 76, 98, 26, 218, 64, 3, 96, 210, 235, 144, 142, 92, 173, 92, 27, 198, 37, 73, 137, 108, 179, 158, 47, 247, 52, 96, 205, 250, 162, 69, 228 }, new byte[] { 235, 193, 149, 4, 77, 198, 127, 92, 88, 101, 3, 221, 23, 16, 11, 21, 55, 87, 235, 243, 44, 160, 221, 241, 205, 140, 21, 81, 20, 134, 198, 110, 181, 20, 25, 28, 110, 173, 254, 225, 203, 113, 203, 160, 103, 205, 23, 233, 223, 129, 130, 215, 239, 220, 168, 12, 52, 200, 53, 76, 199, 219, 96, 97, 245, 238, 47, 156, 124, 179, 177, 121, 6, 238, 215, 89, 118, 157, 100, 158, 20, 184, 27, 132, 217, 251, 36, 243, 63, 23, 186, 189, 161, 51, 14, 143, 250, 132, 226, 110, 138, 94, 101, 28, 195, 153, 42, 189, 121, 195, 97, 69, 79, 189, 103, 48, 79, 133, 158, 135, 106, 23, 168, 177, 78, 234, 179, 30 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("bd06e3f1-6fd1-421c-a15c-80c89f7a5b03"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("074bcea3-ebac-4257-8106-cb1939e29591") });

            migrationBuilder.CreateIndex(
                name: "IX_BusServices_ParentId",
                table: "BusServices",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_BusServices_BusServices_ParentId",
                table: "BusServices",
                column: "ParentId",
                principalTable: "BusServices",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusServices_BusServices_ParentId",
                table: "BusServices");

            migrationBuilder.DropIndex(
                name: "IX_BusServices_ParentId",
                table: "BusServices");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("bd06e3f1-6fd1-421c-a15c-80c89f7a5b03"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("074bcea3-ebac-4257-8106-cb1939e29591"));

            migrationBuilder.AddColumn<int>(
                name: "BusServiceId",
                table: "BusServices",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("bd1b9fa9-951a-4a61-a270-5ba4c0b2ad32"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@admin.io", new byte[] { 209, 152, 71, 197, 201, 8, 175, 86, 166, 189, 191, 104, 198, 144, 207, 30, 73, 198, 87, 5, 60, 47, 135, 110, 153, 183, 22, 250, 197, 235, 63, 121, 41, 86, 247, 31, 57, 52, 149, 208, 200, 59, 185, 80, 92, 0, 122, 214, 213, 58, 168, 61, 187, 98, 62, 6, 18, 160, 137, 135, 195, 221, 129, 146 }, new byte[] { 122, 201, 67, 64, 132, 63, 14, 238, 193, 184, 215, 146, 34, 14, 167, 22, 90, 236, 32, 80, 13, 182, 148, 123, 130, 128, 70, 56, 213, 12, 147, 30, 80, 140, 27, 222, 165, 224, 23, 231, 239, 21, 80, 61, 75, 153, 81, 84, 40, 182, 62, 80, 221, 156, 157, 149, 145, 108, 97, 208, 61, 253, 84, 186, 73, 203, 100, 1, 94, 47, 68, 93, 116, 11, 13, 80, 216, 121, 58, 69, 153, 141, 110, 60, 119, 77, 129, 161, 198, 121, 226, 76, 61, 184, 218, 210, 242, 238, 186, 65, 101, 121, 189, 113, 133, 233, 233, 64, 102, 29, 68, 198, 95, 168, 193, 229, 144, 89, 27, 17, 242, 172, 129, 162, 164, 73, 197, 45 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("055bf683-0297-49e5-a710-3e7547720b20"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("bd1b9fa9-951a-4a61-a270-5ba4c0b2ad32") });

            migrationBuilder.CreateIndex(
                name: "IX_BusServices_BusServiceId",
                table: "BusServices",
                column: "BusServiceId");

            migrationBuilder.AddForeignKey(
                name: "FK_BusServices_BusServices_BusServiceId",
                table: "BusServices",
                column: "BusServiceId",
                principalTable: "BusServices",
                principalColumn: "Id");
        }
    }
}
