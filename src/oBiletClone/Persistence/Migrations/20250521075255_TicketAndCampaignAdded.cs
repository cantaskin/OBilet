using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class TicketAndCampaignAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seats_Users_UserId",
                table: "Seats");

            migrationBuilder.DropIndex(
                name: "IX_Seats_UserId",
                table: "Seats");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("9efe7267-5824-4ae4-a3b2-0b1094d25737"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("72f14616-6596-475b-ba1b-4b46b2335a9c"));

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Seats");

            migrationBuilder.AddColumn<decimal>(
                name: "BasePrice",
                table: "BusServices",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Campaigns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DiscountPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountFixedAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusServiceId = table.Column<int>(type: "int", nullable: false),
                    SeatId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CampaignId = table.Column<int>(type: "int", nullable: true),
                    IsCancelled = table.Column<bool>(type: "bit", nullable: false),
                    IsOnHold = table.Column<bool>(type: "bit", nullable: false),
                    HoldUntil = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_BusServices_BusServiceId",
                        column: x => x.BusServiceId,
                        principalTable: "BusServices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tickets_Seats_SeatId",
                        column: x => x.SeatId,
                        principalTable: "Seats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 54, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tickets.Admin", null },
                    { 55, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tickets.Read", null },
                    { 56, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tickets.Write", null },
                    { 57, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tickets.Create", null },
                    { 58, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tickets.Update", null },
                    { 59, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Tickets.Delete", null },
                    { 60, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Campaigns.Admin", null },
                    { 61, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Campaigns.Read", null },
                    { 62, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Campaigns.Write", null },
                    { 63, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Campaigns.Create", null },
                    { 64, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Campaigns.Update", null },
                    { 65, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Campaigns.Delete", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("5266cf0c-2e85-4873-9a46-8cee0b3de945"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@admin.io", new byte[] { 154, 173, 15, 126, 232, 134, 207, 235, 67, 107, 130, 19, 42, 186, 185, 231, 29, 191, 228, 39, 25, 250, 27, 166, 5, 163, 136, 236, 11, 142, 105, 249, 201, 220, 183, 10, 46, 117, 155, 180, 246, 190, 23, 62, 114, 128, 208, 36, 248, 235, 42, 195, 15, 46, 129, 222, 21, 254, 66, 116, 4, 46, 190, 11 }, new byte[] { 14, 50, 196, 166, 177, 22, 129, 224, 178, 167, 198, 42, 122, 53, 59, 43, 79, 198, 159, 189, 31, 75, 239, 236, 0, 110, 220, 65, 171, 64, 89, 155, 146, 0, 6, 148, 30, 157, 188, 34, 226, 185, 74, 243, 127, 192, 68, 65, 191, 151, 96, 237, 126, 201, 131, 240, 148, 246, 211, 0, 244, 123, 242, 130, 144, 19, 114, 205, 218, 35, 106, 199, 57, 65, 206, 174, 209, 210, 74, 89, 189, 237, 212, 245, 230, 249, 162, 203, 38, 53, 110, 102, 50, 79, 151, 93, 119, 254, 171, 71, 74, 112, 254, 240, 174, 103, 247, 82, 7, 34, 17, 119, 68, 92, 45, 112, 237, 69, 57, 43, 233, 11, 55, 2, 8, 27, 158, 144 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("eb3ac63e-214d-4d3c-a657-0b23db34e4a8"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("5266cf0c-2e85-4873-9a46-8cee0b3de945") });

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_BusServiceId",
                table: "Tickets",
                column: "BusServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_CampaignId",
                table: "Tickets",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_SeatId",
                table: "Tickets",
                column: "SeatId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UserId",
                table: "Tickets",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Campaigns");

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("eb3ac63e-214d-4d3c-a657-0b23db34e4a8"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("5266cf0c-2e85-4873-9a46-8cee0b3de945"));

            migrationBuilder.DropColumn(
                name: "BasePrice",
                table: "BusServices");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Seats",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("72f14616-6596-475b-ba1b-4b46b2335a9c"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@admin.io", new byte[] { 132, 110, 57, 25, 18, 200, 112, 166, 81, 204, 54, 172, 129, 27, 44, 66, 140, 236, 53, 157, 134, 16, 123, 100, 242, 94, 241, 94, 132, 46, 32, 103, 55, 201, 41, 112, 145, 199, 75, 250, 88, 182, 125, 88, 24, 206, 67, 19, 16, 89, 100, 162, 111, 173, 156, 9, 22, 221, 71, 183, 121, 61, 70, 26 }, new byte[] { 168, 140, 251, 99, 46, 68, 179, 216, 122, 115, 107, 206, 234, 81, 185, 19, 117, 33, 214, 138, 27, 237, 26, 206, 210, 85, 217, 52, 72, 188, 131, 140, 155, 212, 119, 145, 136, 103, 71, 49, 121, 156, 182, 108, 128, 235, 135, 62, 81, 246, 64, 118, 164, 180, 99, 55, 218, 0, 78, 75, 54, 44, 140, 110, 148, 132, 108, 218, 194, 153, 95, 119, 200, 141, 173, 7, 162, 253, 130, 196, 105, 107, 58, 157, 28, 166, 13, 103, 246, 113, 233, 247, 170, 126, 236, 30, 153, 80, 62, 19, 207, 39, 18, 179, 134, 246, 171, 85, 103, 22, 56, 107, 175, 185, 158, 101, 117, 24, 47, 211, 84, 10, 158, 7, 17, 179, 88, 42 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("9efe7267-5824-4ae4-a3b2-0b1094d25737"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("72f14616-6596-475b-ba1b-4b46b2335a9c") });

            migrationBuilder.CreateIndex(
                name: "IX_Seats_UserId",
                table: "Seats",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seats_Users_UserId",
                table: "Seats",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
