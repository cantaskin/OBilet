using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class DurationInMinutes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("e666df3d-efb6-4c69-8cea-0b02dbfb31b2"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("55cea79c-70b7-4ca6-9ea3-c63be08c9701"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartTime",
                table: "BusServices",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FinishTime",
                table: "BusServices",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<decimal>(
                name: "BasePrice",
                table: "BusServices",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<bool>(
                name: "IsSellable",
                table: "BusServices",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 66, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "BusServiceStations.Admin", null },
                    { 67, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "BusServiceStations.Read", null },
                    { 68, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "BusServiceStations.Write", null },
                    { 69, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "BusServiceStations.Create", null },
                    { 70, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "BusServiceStations.Update", null },
                    { 71, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "BusServiceStations.Delete", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("972df63b-f857-49ca-8b4a-f59d36302bf8"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@admin.io", new byte[] { 172, 207, 247, 37, 184, 8, 166, 22, 219, 9, 41, 185, 4, 6, 98, 44, 231, 50, 58, 210, 86, 91, 250, 17, 100, 120, 222, 179, 109, 77, 93, 167, 113, 136, 43, 44, 109, 88, 53, 97, 105, 42, 171, 205, 250, 63, 209, 39, 167, 14, 80, 55, 45, 129, 70, 63, 68, 139, 38, 157, 127, 231, 83, 162 }, new byte[] { 168, 11, 228, 199, 174, 230, 120, 228, 30, 76, 141, 69, 245, 71, 58, 252, 105, 135, 197, 127, 82, 52, 71, 82, 86, 246, 174, 241, 30, 188, 15, 23, 251, 80, 124, 195, 187, 158, 111, 53, 78, 225, 32, 106, 61, 152, 141, 5, 58, 80, 195, 183, 153, 194, 130, 186, 106, 145, 174, 87, 4, 121, 100, 68, 154, 170, 198, 165, 64, 209, 68, 197, 94, 93, 64, 159, 12, 236, 11, 202, 142, 195, 62, 83, 20, 80, 84, 36, 40, 227, 144, 49, 29, 161, 216, 154, 248, 50, 132, 142, 29, 3, 125, 166, 243, 51, 167, 57, 239, 28, 220, 183, 15, 246, 33, 175, 173, 201, 217, 195, 94, 159, 67, 112, 233, 196, 230, 43 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("5bbf6b1f-ce54-4b3d-a3d5-0b71cf2b6d4a"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("972df63b-f857-49ca-8b4a-f59d36302bf8") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("5bbf6b1f-ce54-4b3d-a3d5-0b71cf2b6d4a"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("972df63b-f857-49ca-8b4a-f59d36302bf8"));

            migrationBuilder.DropColumn(
                name: "IsSellable",
                table: "BusServices");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartTime",
                table: "BusServices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FinishTime",
                table: "BusServices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "BasePrice",
                table: "BusServices",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("55cea79c-70b7-4ca6-9ea3-c63be08c9701"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@admin.io", new byte[] { 146, 109, 122, 79, 235, 111, 116, 79, 159, 95, 57, 165, 219, 49, 210, 192, 221, 149, 112, 2, 220, 163, 232, 226, 242, 34, 59, 119, 1, 215, 11, 15, 90, 113, 170, 212, 98, 6, 3, 135, 246, 34, 210, 205, 238, 30, 42, 23, 224, 26, 52, 233, 31, 161, 181, 213, 176, 122, 97, 28, 7, 94, 38, 158 }, new byte[] { 207, 183, 209, 153, 103, 215, 37, 142, 219, 225, 27, 24, 132, 116, 194, 245, 159, 105, 255, 164, 249, 206, 234, 0, 75, 163, 77, 181, 118, 135, 71, 118, 133, 43, 4, 180, 251, 18, 194, 128, 216, 72, 205, 72, 181, 120, 41, 9, 6, 98, 169, 98, 70, 143, 239, 246, 25, 210, 251, 228, 51, 152, 122, 253, 182, 121, 53, 184, 163, 209, 68, 3, 42, 234, 160, 169, 50, 194, 198, 44, 203, 102, 224, 79, 72, 248, 30, 39, 116, 171, 33, 57, 49, 192, 226, 69, 237, 87, 154, 174, 137, 82, 64, 211, 20, 235, 86, 56, 131, 133, 86, 155, 45, 112, 48, 84, 151, 215, 17, 154, 229, 65, 5, 191, 251, 203, 207, 99 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("e666df3d-efb6-4c69-8cea-0b02dbfb31b2"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("55cea79c-70b7-4ca6-9ea3-c63be08c9701") });
        }
    }
}
