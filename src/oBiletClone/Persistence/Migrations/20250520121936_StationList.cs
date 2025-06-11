using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class StationList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BusServices_BusServices_ParentId",
                table: "BusServices");

            migrationBuilder.DropForeignKey(
                name: "FK_BusServices_Stations_FinishStationId",
                table: "BusServices");

            migrationBuilder.DropForeignKey(
                name: "FK_BusServices_Stations_StartStationId",
                table: "BusServices");

            migrationBuilder.DropForeignKey(
                name: "FK_BusServices_Stations_StationId",
                table: "BusServices");

            migrationBuilder.DropIndex(
                name: "IX_BusServices_FinishStationId",
                table: "BusServices");

            migrationBuilder.DropIndex(
                name: "IX_BusServices_ParentId",
                table: "BusServices");

            migrationBuilder.DropIndex(
                name: "IX_BusServices_StartStationId",
                table: "BusServices");

            migrationBuilder.DropIndex(
                name: "IX_BusServices_StationId",
                table: "BusServices");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("bd06e3f1-6fd1-421c-a15c-80c89f7a5b03"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("074bcea3-ebac-4257-8106-cb1939e29591"));

            migrationBuilder.DropColumn(
                name: "FinishStationId",
                table: "BusServices");

            migrationBuilder.DropColumn(
                name: "ParentId",
                table: "BusServices");

            migrationBuilder.DropColumn(
                name: "StartStationId",
                table: "BusServices");

            migrationBuilder.DropColumn(
                name: "StationId",
                table: "BusServices");

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
                values: new object[] { new Guid("d15316fe-c4a9-4ff5-bb66-85aa5f305095"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@admin.io", new byte[] { 113, 103, 114, 26, 124, 215, 204, 244, 228, 206, 167, 188, 177, 173, 187, 217, 147, 191, 60, 20, 87, 23, 98, 40, 124, 161, 15, 72, 9, 125, 135, 244, 244, 9, 193, 112, 3, 44, 73, 184, 18, 235, 106, 114, 219, 78, 143, 157, 60, 4, 169, 211, 133, 38, 153, 205, 58, 235, 164, 106, 216, 158, 101, 253 }, new byte[] { 61, 143, 142, 58, 66, 41, 249, 13, 255, 223, 168, 14, 129, 28, 236, 226, 80, 138, 224, 159, 148, 57, 25, 74, 135, 249, 243, 97, 149, 19, 107, 64, 165, 86, 201, 109, 63, 69, 171, 194, 47, 166, 211, 30, 118, 247, 131, 220, 47, 124, 64, 43, 141, 13, 30, 58, 244, 72, 80, 254, 126, 233, 162, 246, 62, 30, 207, 3, 123, 52, 52, 163, 127, 98, 129, 51, 155, 51, 94, 209, 148, 194, 216, 57, 33, 253, 79, 5, 80, 1, 202, 131, 125, 76, 187, 162, 49, 136, 241, 8, 121, 16, 129, 84, 198, 46, 254, 184, 207, 133, 217, 216, 165, 216, 167, 244, 36, 85, 16, 28, 60, 139, 203, 51, 116, 144, 146, 248 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("f8bee5d5-c15f-4f34-911f-a7e47a2794f7"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("d15316fe-c4a9-4ff5-bb66-85aa5f305095") });

            migrationBuilder.CreateIndex(
                name: "IX_BusServiceStation_StationsId",
                table: "BusServiceStation",
                column: "StationsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusServiceStation");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("f8bee5d5-c15f-4f34-911f-a7e47a2794f7"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d15316fe-c4a9-4ff5-bb66-85aa5f305095"));

            migrationBuilder.AddColumn<int>(
                name: "FinishStationId",
                table: "BusServices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ParentId",
                table: "BusServices",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StartStationId",
                table: "BusServices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StationId",
                table: "BusServices",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("074bcea3-ebac-4257-8106-cb1939e29591"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@admin.io", new byte[] { 230, 69, 247, 253, 12, 75, 8, 84, 237, 237, 249, 110, 22, 250, 103, 108, 66, 1, 186, 20, 209, 57, 115, 188, 76, 173, 236, 252, 14, 172, 220, 117, 102, 76, 98, 26, 218, 64, 3, 96, 210, 235, 144, 142, 92, 173, 92, 27, 198, 37, 73, 137, 108, 179, 158, 47, 247, 52, 96, 205, 250, 162, 69, 228 }, new byte[] { 235, 193, 149, 4, 77, 198, 127, 92, 88, 101, 3, 221, 23, 16, 11, 21, 55, 87, 235, 243, 44, 160, 221, 241, 205, 140, 21, 81, 20, 134, 198, 110, 181, 20, 25, 28, 110, 173, 254, 225, 203, 113, 203, 160, 103, 205, 23, 233, 223, 129, 130, 215, 239, 220, 168, 12, 52, 200, 53, 76, 199, 219, 96, 97, 245, 238, 47, 156, 124, 179, 177, 121, 6, 238, 215, 89, 118, 157, 100, 158, 20, 184, 27, 132, 217, 251, 36, 243, 63, 23, 186, 189, 161, 51, 14, 143, 250, 132, 226, 110, 138, 94, 101, 28, 195, 153, 42, 189, 121, 195, 97, 69, 79, 189, 103, 48, 79, 133, 158, 135, 106, 23, 168, 177, 78, 234, 179, 30 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("bd06e3f1-6fd1-421c-a15c-80c89f7a5b03"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("074bcea3-ebac-4257-8106-cb1939e29591") });

            migrationBuilder.CreateIndex(
                name: "IX_BusServices_FinishStationId",
                table: "BusServices",
                column: "FinishStationId");

            migrationBuilder.CreateIndex(
                name: "IX_BusServices_ParentId",
                table: "BusServices",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_BusServices_StartStationId",
                table: "BusServices",
                column: "StartStationId");

            migrationBuilder.CreateIndex(
                name: "IX_BusServices_StationId",
                table: "BusServices",
                column: "StationId");

            migrationBuilder.AddForeignKey(
                name: "FK_BusServices_BusServices_ParentId",
                table: "BusServices",
                column: "ParentId",
                principalTable: "BusServices",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BusServices_Stations_FinishStationId",
                table: "BusServices",
                column: "FinishStationId",
                principalTable: "Stations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BusServices_Stations_StartStationId",
                table: "BusServices",
                column: "StartStationId",
                principalTable: "Stations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BusServices_Stations_StationId",
                table: "BusServices",
                column: "StationId",
                principalTable: "Stations",
                principalColumn: "Id");
        }
    }
}
