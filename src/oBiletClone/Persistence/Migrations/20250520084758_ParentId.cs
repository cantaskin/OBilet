using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ParentId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusServiceBusService");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("cb108fe3-6fc9-447b-963b-2317dda700bf"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6dde21b4-ff80-4e08-9158-66d605ec5e54"));

            migrationBuilder.AddColumn<int>(
                name: "BusServiceId",
                table: "BusServices",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "BusServices");

            migrationBuilder.CreateTable(
                name: "BusServiceBusService",
                columns: table => new
                {
                    ChildrenId = table.Column<int>(type: "int", nullable: false),
                    ParentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusServiceBusService", x => new { x.ChildrenId, x.ParentsId });
                    table.ForeignKey(
                        name: "FK_BusServiceBusService_BusServices_ChildrenId",
                        column: x => x.ChildrenId,
                        principalTable: "BusServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusServiceBusService_BusServices_ParentsId",
                        column: x => x.ParentsId,
                        principalTable: "BusServices",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("6dde21b4-ff80-4e08-9158-66d605ec5e54"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@admin.io", new byte[] { 214, 1, 68, 43, 98, 126, 202, 172, 216, 154, 30, 72, 96, 201, 74, 47, 2, 96, 191, 175, 64, 194, 69, 115, 73, 140, 214, 229, 140, 14, 230, 220, 161, 140, 174, 184, 216, 152, 115, 34, 219, 182, 231, 160, 238, 110, 168, 17, 177, 22, 221, 47, 175, 182, 140, 112, 207, 224, 125, 120, 202, 190, 45, 234 }, new byte[] { 97, 144, 165, 33, 210, 145, 139, 38, 97, 24, 128, 252, 24, 7, 1, 233, 141, 131, 91, 26, 230, 38, 127, 221, 178, 250, 37, 225, 220, 47, 42, 133, 101, 46, 33, 131, 55, 182, 204, 215, 10, 196, 123, 169, 102, 50, 107, 61, 183, 57, 52, 137, 110, 117, 142, 14, 83, 12, 190, 106, 52, 247, 101, 161, 23, 25, 53, 45, 171, 40, 6, 187, 55, 110, 191, 117, 89, 240, 139, 226, 101, 3, 124, 140, 48, 188, 237, 112, 20, 187, 121, 74, 123, 75, 120, 169, 138, 98, 93, 84, 28, 185, 216, 238, 156, 97, 76, 194, 36, 116, 203, 49, 35, 144, 117, 117, 69, 64, 17, 124, 61, 43, 245, 88, 82, 93, 78, 74 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("cb108fe3-6fc9-447b-963b-2317dda700bf"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("6dde21b4-ff80-4e08-9158-66d605ec5e54") });

            migrationBuilder.CreateIndex(
                name: "IX_BusServiceBusService_ParentsId",
                table: "BusServiceBusService",
                column: "ParentsId");
        }
    }
}
