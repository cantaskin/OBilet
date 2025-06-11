using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class BusServiceParentsAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                keyValue: new Guid("274212f9-1379-4f4e-a429-073872b3b617"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e94c130c-30fd-4254-8e0d-7252828a42ec"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "ParentId",
                table: "BusServices",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("e94c130c-30fd-4254-8e0d-7252828a42ec"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@admin.io", new byte[] { 177, 26, 168, 15, 189, 86, 16, 198, 191, 201, 147, 246, 115, 155, 65, 237, 105, 154, 203, 122, 45, 70, 241, 150, 208, 207, 173, 170, 215, 88, 243, 65, 36, 208, 218, 239, 61, 108, 189, 255, 213, 121, 154, 75, 67, 241, 100, 109, 61, 82, 232, 141, 186, 130, 52, 227, 171, 180, 250, 201, 235, 87, 172, 155 }, new byte[] { 5, 3, 180, 82, 95, 89, 20, 237, 87, 67, 4, 4, 196, 202, 126, 137, 45, 79, 230, 218, 131, 83, 64, 105, 115, 210, 199, 11, 187, 247, 16, 111, 35, 168, 34, 207, 154, 227, 52, 62, 216, 17, 62, 26, 244, 96, 182, 65, 21, 53, 182, 127, 112, 129, 166, 4, 111, 80, 143, 147, 173, 206, 152, 4, 53, 191, 60, 73, 170, 212, 7, 88, 130, 136, 124, 87, 189, 204, 179, 150, 176, 147, 111, 60, 153, 7, 177, 191, 245, 227, 91, 117, 183, 252, 154, 208, 20, 235, 246, 179, 254, 121, 30, 100, 166, 145, 230, 107, 90, 57, 148, 190, 173, 77, 131, 66, 91, 168, 72, 5, 98, 162, 67, 78, 43, 175, 41, 69 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("274212f9-1379-4f4e-a429-073872b3b617"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("e94c130c-30fd-4254-8e0d-7252828a42ec") });

            migrationBuilder.CreateIndex(
                name: "IX_BusServices_ParentId",
                table: "BusServices",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_BusServices_BusServices_ParentId",
                table: "BusServices",
                column: "ParentId",
                principalTable: "BusServices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
