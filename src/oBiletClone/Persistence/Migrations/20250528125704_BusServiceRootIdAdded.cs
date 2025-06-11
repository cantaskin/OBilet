using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class BusServiceRootIdAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("eb3ac63e-214d-4d3c-a657-0b23db34e4a8"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5266cf0c-2e85-4873-9a46-8cee0b3de945"));

            migrationBuilder.AddColumn<int>(
                name: "FromStationId",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ToStationId",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RootId",
                table: "BusServices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("4e68f7c7-1da5-4d82-a2f0-ce095d8ede7c"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@admin.io", new byte[] { 236, 177, 167, 156, 204, 128, 98, 249, 216, 22, 187, 203, 132, 235, 6, 127, 108, 240, 134, 16, 192, 197, 2, 40, 23, 155, 66, 209, 222, 231, 193, 219, 192, 10, 106, 71, 45, 107, 219, 228, 67, 214, 201, 40, 115, 38, 107, 27, 166, 88, 54, 123, 62, 131, 231, 62, 82, 201, 196, 228, 1, 25, 95, 193 }, new byte[] { 221, 174, 89, 65, 125, 215, 104, 130, 19, 191, 0, 216, 102, 69, 228, 221, 16, 192, 142, 60, 204, 168, 234, 44, 238, 138, 134, 98, 42, 108, 214, 54, 114, 174, 222, 88, 241, 179, 128, 112, 252, 253, 74, 181, 12, 202, 148, 81, 75, 218, 253, 199, 104, 26, 2, 145, 18, 182, 185, 59, 49, 53, 139, 237, 240, 184, 211, 242, 205, 157, 131, 93, 204, 238, 146, 104, 155, 186, 150, 114, 109, 72, 173, 212, 212, 168, 164, 106, 117, 227, 106, 15, 157, 85, 166, 207, 194, 119, 227, 89, 196, 9, 166, 53, 169, 158, 113, 214, 164, 107, 202, 58, 114, 92, 192, 33, 16, 110, 66, 108, 240, 174, 98, 95, 59, 106, 129, 181 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("e13ec629-14e8-4f42-bc25-c4c6a910ed94"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("4e68f7c7-1da5-4d82-a2f0-ce095d8ede7c") });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_FromStationId",
                table: "Tickets",
                column: "FromStationId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ToStationId",
                table: "Tickets",
                column: "ToStationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Stations_FromStationId",
                table: "Tickets",
                column: "FromStationId",
                principalTable: "Stations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Stations_ToStationId",
                table: "Tickets",
                column: "ToStationId",
                principalTable: "Stations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Stations_FromStationId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Stations_ToStationId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_FromStationId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_ToStationId",
                table: "Tickets");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("e13ec629-14e8-4f42-bc25-c4c6a910ed94"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4e68f7c7-1da5-4d82-a2f0-ce095d8ede7c"));

            migrationBuilder.DropColumn(
                name: "FromStationId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "ToStationId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "RootId",
                table: "BusServices");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("5266cf0c-2e85-4873-9a46-8cee0b3de945"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@admin.io", new byte[] { 154, 173, 15, 126, 232, 134, 207, 235, 67, 107, 130, 19, 42, 186, 185, 231, 29, 191, 228, 39, 25, 250, 27, 166, 5, 163, 136, 236, 11, 142, 105, 249, 201, 220, 183, 10, 46, 117, 155, 180, 246, 190, 23, 62, 114, 128, 208, 36, 248, 235, 42, 195, 15, 46, 129, 222, 21, 254, 66, 116, 4, 46, 190, 11 }, new byte[] { 14, 50, 196, 166, 177, 22, 129, 224, 178, 167, 198, 42, 122, 53, 59, 43, 79, 198, 159, 189, 31, 75, 239, 236, 0, 110, 220, 65, 171, 64, 89, 155, 146, 0, 6, 148, 30, 157, 188, 34, 226, 185, 74, 243, 127, 192, 68, 65, 191, 151, 96, 237, 126, 201, 131, 240, 148, 246, 211, 0, 244, 123, 242, 130, 144, 19, 114, 205, 218, 35, 106, 199, 57, 65, 206, 174, 209, 210, 74, 89, 189, 237, 212, 245, 230, 249, 162, 203, 38, 53, 110, 102, 50, 79, 151, 93, 119, 254, 171, 71, 74, 112, 254, 240, 174, 103, 247, 82, 7, 34, 17, 119, 68, 92, 45, 112, 237, 69, 57, 43, 233, 11, 55, 2, 8, 27, 158, 144 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("eb3ac63e-214d-4d3c-a657-0b23db34e4a8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("5266cf0c-2e85-4873-9a46-8cee0b3de945") });
        }
    }
}
