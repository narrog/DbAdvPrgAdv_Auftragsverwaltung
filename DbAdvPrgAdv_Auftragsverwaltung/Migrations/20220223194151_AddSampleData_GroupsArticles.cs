using Microsoft.EntityFrameworkCore.Migrations;

namespace DbAdvPrgAdv_Auftragsverwaltung.Migrations
{
    public partial class AddSampleData_GroupsArticles : Migration
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
                values: new object[] { 3, "Autozubehör", 0 });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "ArticleID", "GroupID", "Name", "Price" },
                values: new object[] { 3, 3, "Chromstahl Felgen 19 Zoll", 200m });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "GroupID", "Name", "ParentID" },
                values: new object[] { 4, "Laptop", 1 });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "GroupID", "Name", "ParentID" },
                values: new object[] { 2, "Drucker", 1 });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "ArticleID", "GroupID", "Name", "Price" },
                values: new object[] { 1, 2, "HP LaserJet Pro M404", 420m });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "ArticleID", "GroupID", "Name", "Price" },
                values: new object[] { 2, 4, "Lenovo ThinkPad L15", 900m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "ArticleID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "ArticleID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "ArticleID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "GroupID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "GroupID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "GroupID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "GroupID",
                keyValue: 1);
        }
    }
}
