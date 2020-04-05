using Microsoft.EntityFrameworkCore.Migrations;

namespace sandbox.Migrations
{
    public partial class fourth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shelter",
                columns: table => new
                {
                    DogsID = table.Column<int>(nullable: false),
                    CatsID = table.Column<int>(nullable: false),
                    type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shelter", x => new { x.DogsID, x.CatsID });
                    table.ForeignKey(
                        name: "FK_Shelter_Cats_CatsID",
                        column: x => x.CatsID,
                        principalTable: "Cats",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Shelter_Dogs_DogsID",
                        column: x => x.DogsID,
                        principalTable: "Dogs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Shelter_CatsID",
                table: "Shelter",
                column: "CatsID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shelter");
        }
    }
}
