using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbAdvPrgAdv_Auftragsverwaltung.Migrations
{
    public partial class AddMoreSampleData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "ArticleID", "GroupID", "Name", "Price" },
                values: new object[,]
                {
                    { 4, 4, "HP EliteBook G8", 1600m },
                    { 5, 4, "MacBook Air 2020", 1000m },
                    { 6, 2, "Canon Pixma", 60m }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderID", "CustomerID", "OrderDate", "PriceTotal" },
                values: new object[,]
                {
                    { 4, 1, new DateTime(2022, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1600m },
                    { 5, 1, new DateTime(2022, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 60m }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "ArticleID", "OrderID", "Count", "Number" },
                values: new object[] { 4, 4, 1, 5 });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "ArticleID", "OrderID", "Count", "Number" },
                values: new object[] { 6, 5, 1, 6 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "ArticleID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumns: new[] { "ArticleID", "OrderID" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumns: new[] { "ArticleID", "OrderID" },
                keyValues: new object[] { 6, 5 });

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "ArticleID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "ArticleID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 5);
        }
    }
}
