using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class Portfolio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "92f78877-27d9-489b-a6b9-d8ddc114a99d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b73c84f-ce83-46d5-abaf-1914d8e86a17");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "483e69b2-76f0-4de9-9177-c8ef2c0327c7", null, "Admin", "ADMIN" },
                    { "7645d941-2261-48ee-906a-1c39badfff57", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "483e69b2-76f0-4de9-9177-c8ef2c0327c7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7645d941-2261-48ee-906a-1c39badfff57");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "92f78877-27d9-489b-a6b9-d8ddc114a99d", null, "Admin", "ADMIN" },
                    { "9b73c84f-ce83-46d5-abaf-1914d8e86a17", null, "User", "USER" }
                });
        }
    }
}
