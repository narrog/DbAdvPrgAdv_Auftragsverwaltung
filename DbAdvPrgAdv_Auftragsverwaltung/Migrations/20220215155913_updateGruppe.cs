using Microsoft.EntityFrameworkCore.Migrations;

namespace DbAdvPrgAdv_Auftragsverwaltung.Migrations
{
    public partial class updateGruppe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentID",
                table: "Gruppen",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentID",
                table: "Gruppen");
        }
    }
}
