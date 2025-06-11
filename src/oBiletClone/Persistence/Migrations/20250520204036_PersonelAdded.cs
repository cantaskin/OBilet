using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class PersonelAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buses_Personels_PersonelId",
                table: "Buses");

            migrationBuilder.DropIndex(
                name: "IX_Buses_PersonelId",
                table: "Buses");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("0232819f-19a8-4cb5-b0a2-814d1f0504ac"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("979f14aa-5f6e-4afd-abcc-120a1631f80d"));

            migrationBuilder.DropColumn(
                name: "PersonelId",
                table: "Buses");

            migrationBuilder.CreateTable(
                name: "BusPersonel",
                columns: table => new
                {
                    BusesId = table.Column<int>(type: "int", nullable: false),
                    PersonelListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusPersonel", x => new { x.BusesId, x.PersonelListId });
                    table.ForeignKey(
                        name: "FK_BusPersonel_Buses_BusesId",
                        column: x => x.BusesId,
                        principalTable: "Buses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BusPersonel_Personels_PersonelListId",
                        column: x => x.PersonelListId,
                        principalTable: "Personels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("72f14616-6596-475b-ba1b-4b46b2335a9c"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@admin.io", new byte[] { 132, 110, 57, 25, 18, 200, 112, 166, 81, 204, 54, 172, 129, 27, 44, 66, 140, 236, 53, 157, 134, 16, 123, 100, 242, 94, 241, 94, 132, 46, 32, 103, 55, 201, 41, 112, 145, 199, 75, 250, 88, 182, 125, 88, 24, 206, 67, 19, 16, 89, 100, 162, 111, 173, 156, 9, 22, 221, 71, 183, 121, 61, 70, 26 }, new byte[] { 168, 140, 251, 99, 46, 68, 179, 216, 122, 115, 107, 206, 234, 81, 185, 19, 117, 33, 214, 138, 27, 237, 26, 206, 210, 85, 217, 52, 72, 188, 131, 140, 155, 212, 119, 145, 136, 103, 71, 49, 121, 156, 182, 108, 128, 235, 135, 62, 81, 246, 64, 118, 164, 180, 99, 55, 218, 0, 78, 75, 54, 44, 140, 110, 148, 132, 108, 218, 194, 153, 95, 119, 200, 141, 173, 7, 162, 253, 130, 196, 105, 107, 58, 157, 28, 166, 13, 103, 246, 113, 233, 247, 170, 126, 236, 30, 153, 80, 62, 19, 207, 39, 18, 179, 134, 246, 171, 85, 103, 22, 56, 107, 175, 185, 158, 101, 117, 24, 47, 211, 84, 10, 158, 7, 17, 179, 88, 42 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("9efe7267-5824-4ae4-a3b2-0b1094d25737"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("72f14616-6596-475b-ba1b-4b46b2335a9c") });

            migrationBuilder.CreateIndex(
                name: "IX_BusPersonel_PersonelListId",
                table: "BusPersonel",
                column: "PersonelListId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BusPersonel");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("9efe7267-5824-4ae4-a3b2-0b1094d25737"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("72f14616-6596-475b-ba1b-4b46b2335a9c"));

            migrationBuilder.AddColumn<int>(
                name: "PersonelId",
                table: "Buses",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("979f14aa-5f6e-4afd-abcc-120a1631f80d"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@admin.io", new byte[] { 225, 144, 198, 97, 127, 168, 176, 144, 118, 100, 218, 163, 169, 51, 225, 14, 75, 130, 165, 72, 196, 126, 84, 42, 11, 54, 76, 119, 152, 198, 130, 195, 246, 20, 149, 222, 211, 123, 198, 247, 207, 194, 50, 6, 117, 204, 126, 51, 249, 111, 206, 149, 37, 235, 114, 122, 168, 132, 205, 164, 88, 49, 106, 47 }, new byte[] { 8, 199, 201, 208, 165, 220, 91, 238, 14, 142, 230, 51, 74, 175, 157, 33, 66, 39, 143, 76, 216, 34, 234, 92, 164, 83, 77, 133, 48, 125, 183, 161, 139, 237, 60, 152, 237, 252, 64, 137, 25, 130, 220, 36, 221, 27, 254, 204, 211, 156, 201, 66, 29, 217, 147, 23, 160, 98, 108, 158, 12, 35, 209, 55, 1, 159, 196, 43, 13, 159, 63, 130, 229, 52, 137, 59, 132, 161, 214, 68, 218, 1, 221, 203, 207, 67, 65, 224, 56, 124, 43, 54, 70, 26, 74, 66, 14, 250, 121, 147, 219, 236, 45, 26, 223, 25, 44, 95, 125, 183, 204, 78, 21, 187, 113, 104, 212, 52, 216, 75, 32, 137, 224, 31, 193, 236, 187, 189 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("0232819f-19a8-4cb5-b0a2-814d1f0504ac"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("979f14aa-5f6e-4afd-abcc-120a1631f80d") });

            migrationBuilder.CreateIndex(
                name: "IX_Buses_PersonelId",
                table: "Buses",
                column: "PersonelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Buses_Personels_PersonelId",
                table: "Buses",
                column: "PersonelId",
                principalTable: "Personels",
                principalColumn: "Id");
        }
    }
}
