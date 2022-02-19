using Microsoft.EntityFrameworkCore.Migrations;

namespace DbAdvPrgAdv_Auftragsverwaltung.Migrations
{
    public partial class AddSampleData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "GroupID", "Name", "ParentID" },
                values: new object[] { 1, "Elektronik", 0 });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "GroupID", "Name", "ParentID" },
                values: new object[] { 2, "Drucker", 1 });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "ArticleID", "Bezeichnung", "GroupID", "Price" },
                values: new object[] { 1, "HP LaserJet Pro M404", 2, 420m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "ArticleID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "GroupID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "GroupID",
                keyValue: 2);
        }
    }
}
