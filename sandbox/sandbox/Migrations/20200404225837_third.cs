using Microsoft.EntityFrameworkCore.Migrations;

namespace sandbox.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cats",
                columns: new[] { "ID", "Age", "Gender", "Name", "Type" },
                values: new object[,]
                {
                    { 1, 100, "Male", "Garfield", "Fat cat" },
                    { 2, 20, "Female", "Josie", "Fat Cat" },
                    { 3, 1, "Male", "Rochi", "MochiPochi" }
                });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "ID", "Age", "Gender", "Name", "Type" },
                values: new object[,]
                {
                    { 1, 1, "Male", "Mochi", "GoldenPoodle" },
                    { 2, 16, "Male", "Kudo", "Morkie" },
                    { 3, 1, "Male", "Gochi", "MochiPochi" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cats",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Dogs",
                keyColumn: "ID",
                keyValue: 3);
        }
    }
}
