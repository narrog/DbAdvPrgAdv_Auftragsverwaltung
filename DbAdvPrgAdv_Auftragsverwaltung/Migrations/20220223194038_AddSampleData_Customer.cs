using Microsoft.EntityFrameworkCore.Migrations;

namespace DbAdvPrgAdv_Auftragsverwaltung.Migrations
{
    public partial class AddSampleData_Customer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityID", "CityName", "PLZ" },
                values: new object[] { 2, "Herisau", 9000 });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerID", "Adress", "CityID", "Email", "Name", "Password", "Vorname", "Website" },
                values: new object[] { 3, null, 2, null, "Buser", null, "Leonie", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "CustomerID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityID",
                keyValue: 2);
        }
    }
}
