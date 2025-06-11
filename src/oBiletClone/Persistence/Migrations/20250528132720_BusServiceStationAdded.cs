using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class BusServiceStationAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusServiceStation");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("e13ec629-14e8-4f42-bc25-c4c6a910ed94"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("4e68f7c7-1da5-4d82-a2f0-ce095d8ede7c"));

            migrationBuilder.CreateTable(
                name: "BusServiceStations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusServiceId = table.Column<int>(type: "int", nullable: false),
                    StationId = table.Column<int>(type: "int", nullable: false),
                    Column = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusServiceStations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BusServiceStations_BusServices_BusServiceId",
                        column: x => x.BusServiceId,
                        principalTable: "BusServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusServiceStations_Stations_StationId",
                        column: x => x.StationId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("485833c9-7a29-4def-8728-de180f79d4b1"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@admin.io", new byte[] { 139, 162, 255, 169, 167, 102, 90, 190, 246, 103, 17, 121, 252, 72, 157, 191, 245, 237, 178, 211, 122, 213, 26, 17, 116, 175, 180, 217, 229, 154, 127, 174, 65, 142, 167, 24, 220, 78, 241, 89, 77, 224, 202, 24, 147, 59, 168, 234, 225, 218, 31, 167, 118, 230, 35, 70, 141, 44, 149, 140, 173, 216, 210, 194 }, new byte[] { 223, 230, 106, 152, 220, 212, 69, 79, 49, 195, 223, 157, 229, 31, 251, 217, 208, 12, 26, 82, 50, 167, 202, 203, 20, 68, 182, 194, 52, 187, 106, 186, 18, 206, 131, 10, 160, 196, 106, 123, 28, 124, 63, 110, 153, 116, 49, 249, 133, 163, 248, 102, 156, 227, 212, 137, 190, 106, 223, 134, 55, 73, 137, 111, 53, 34, 109, 244, 143, 72, 75, 208, 251, 53, 183, 244, 16, 173, 158, 188, 1, 32, 103, 238, 160, 82, 229, 225, 39, 16, 224, 155, 135, 113, 35, 137, 151, 131, 78, 19, 140, 216, 179, 203, 15, 86, 99, 79, 73, 249, 246, 154, 73, 17, 56, 77, 203, 133, 243, 20, 25, 96, 243, 85, 153, 174, 87, 61 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("4cefd587-e3cc-4263-8f6e-d6bd0f0b7dd1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("485833c9-7a29-4def-8728-de180f79d4b1") });

            migrationBuilder.CreateIndex(
                name: "IX_BusServiceStations_BusServiceId",
                table: "BusServiceStations",
                column: "BusServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_BusServiceStations_StationId",
                table: "BusServiceStations",
                column: "StationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusServiceStations");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("4cefd587-e3cc-4263-8f6e-d6bd0f0b7dd1"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("485833c9-7a29-4def-8728-de180f79d4b1"));

            migrationBuilder.CreateTable(
                name: "BusServiceStation",
                columns: table => new
                {
                    BusServicesId = table.Column<int>(type: "int", nullable: false),
                    StationsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusServiceStation", x => new { x.BusServicesId, x.StationsId });
                    table.ForeignKey(
                        name: "FK_BusServiceStation_BusServices_BusServicesId",
                        column: x => x.BusServicesId,
                        principalTable: "BusServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusServiceStation_Stations_StationsId",
                        column: x => x.StationsId,
                        principalTable: "Stations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("4e68f7c7-1da5-4d82-a2f0-ce095d8ede7c"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@admin.io", new byte[] { 236, 177, 167, 156, 204, 128, 98, 249, 216, 22, 187, 203, 132, 235, 6, 127, 108, 240, 134, 16, 192, 197, 2, 40, 23, 155, 66, 209, 222, 231, 193, 219, 192, 10, 106, 71, 45, 107, 219, 228, 67, 214, 201, 40, 115, 38, 107, 27, 166, 88, 54, 123, 62, 131, 231, 62, 82, 201, 196, 228, 1, 25, 95, 193 }, new byte[] { 221, 174, 89, 65, 125, 215, 104, 130, 19, 191, 0, 216, 102, 69, 228, 221, 16, 192, 142, 60, 204, 168, 234, 44, 238, 138, 134, 98, 42, 108, 214, 54, 114, 174, 222, 88, 241, 179, 128, 112, 252, 253, 74, 181, 12, 202, 148, 81, 75, 218, 253, 199, 104, 26, 2, 145, 18, 182, 185, 59, 49, 53, 139, 237, 240, 184, 211, 242, 205, 157, 131, 93, 204, 238, 146, 104, 155, 186, 150, 114, 109, 72, 173, 212, 212, 168, 164, 106, 117, 227, 106, 15, 157, 85, 166, 207, 194, 119, 227, 89, 196, 9, 166, 53, 169, 158, 113, 214, 164, 107, 202, 58, 114, 92, 192, 33, 16, 110, 66, 108, 240, 174, 98, 95, 59, 106, 129, 181 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("e13ec629-14e8-4f42-bc25-c4c6a910ed94"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("4e68f7c7-1da5-4d82-a2f0-ce095d8ede7c") });

            migrationBuilder.CreateIndex(
                name: "IX_BusServiceStation_StationsId",
                table: "BusServiceStation",
                column: "StationsId");
        }
    }
}
