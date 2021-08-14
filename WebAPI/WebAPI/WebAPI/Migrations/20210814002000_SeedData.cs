using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class SeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "candidates",
                columns: new[] { "Id", "Code", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "DT", "Donald", "Trump" },
                    { 2, "HC", "Hillary", "Clinton" },
                    { 3, "JB", "Joe", "Biden" },
                    { 4, "JFK", "John F.", "Kennedy" },
                    { 5, "JR", "Jack", "Randall" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "candidates",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "candidates",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "candidates",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "candidates",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "candidates",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
