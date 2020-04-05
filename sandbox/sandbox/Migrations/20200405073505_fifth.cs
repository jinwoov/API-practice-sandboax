using Microsoft.EntityFrameworkCore.Migrations;

namespace sandbox.Migrations
{
    public partial class fifth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Shelter",
                columns: new[] { "DogsID", "CatsID", "type" },
                values: new object[] { 1, 1, 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Shelter",
                keyColumns: new[] { "DogsID", "CatsID" },
                keyValues: new object[] { 1, 1 });
        }
    }
}
