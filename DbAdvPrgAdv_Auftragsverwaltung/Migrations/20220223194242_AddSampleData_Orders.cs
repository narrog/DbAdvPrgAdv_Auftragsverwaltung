using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DbAdvPrgAdv_Auftragsverwaltung.Migrations
{
    public partial class AddSampleData_Orders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderID", "CustomerID", "OrderDate", "PriceTotal" },
                values: new object[] { 1, 1, new DateTime(2021, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 420m });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderID", "CustomerID", "OrderDate", "PriceTotal" },
                values: new object[] { 2, 1, new DateTime(2022, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 840m });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderID", "CustomerID", "OrderDate", "PriceTotal" },
                values: new object[] { 3, 2, new DateTime(2022, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 1320m });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "ArticleID", "OrderID", "Count", "Number" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 1, 2, 2, 2 },
                    { 1, 3, 1, 3 },
                    { 2, 3, 1, 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumns: new[] { "ArticleID", "OrderID" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumns: new[] { "ArticleID", "OrderID" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumns: new[] { "ArticleID", "OrderID" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumns: new[] { "ArticleID", "OrderID" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 3);
        }
    }
}
