using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class AppUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2db5a6fb-ac71-483a-85f5-83b2e190a308");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c1e0c87c-c309-4cc6-ae1b-5904cd73b69a");

            migrationBuilder.RenameColumn(
                name: "Adress",
                table: "User",
                newName: "Address");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3073a562-8fd6-442c-8cc3-a26496beee6c", null, "Admin", "ADMIN" },
                    { "66623d83-6c9a-4f38-b0b5-a0f2fd47ff1e", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3073a562-8fd6-442c-8cc3-a26496beee6c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "66623d83-6c9a-4f38-b0b5-a0f2fd47ff1e");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "User",
                newName: "Adress");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2db5a6fb-ac71-483a-85f5-83b2e190a308", null, "User", "USER" },
                    { "c1e0c87c-c309-4cc6-ae1b-5904cd73b69a", null, "Admin", "ADMIN" }
                });
        }
    }
}
