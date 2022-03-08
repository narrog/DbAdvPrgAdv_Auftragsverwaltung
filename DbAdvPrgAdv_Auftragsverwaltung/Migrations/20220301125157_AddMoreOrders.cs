using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbAdvPrgAdv_Auftragsverwaltung.Migrations
{
    public partial class AddMoreOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderID", "CustomerID", "OrderDate", "PriceTotal" },
                values: new object[,]
                {
                    { 6, 1, new DateTime(2021, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 420m },
                    { 7, 1, new DateTime(2021, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 420m },
                    { 8, 1, new DateTime(2021, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 420m },
                    { 9, 1, new DateTime(2020, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 420m },
                    { 10, 1, new DateTime(2020, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 420m },
                    { 11, 1, new DateTime(2020, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 420m },
                    { 12, 1, new DateTime(2019, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 420m },
                    { 13, 1, new DateTime(2019, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 420m },
                    { 14, 1, new DateTime(2019, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 420m },
                    { 15, 1, new DateTime(2019, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 420m },
                    { 16, 1, new DateTime(2018, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 420m },
                    { 17, 1, new DateTime(2018, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 420m },
                    { 18, 1, new DateTime(2018, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 420m },
                    { 19, 1, new DateTime(2018, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 420m },
                    { 20, 1, new DateTime(2020, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 420m }
                });

            migrationBuilder.InsertData(
                table: "Positions",
                columns: new[] { "ArticleID", "OrderID", "Count", "Number" },
                values: new object[,]
                {
                    { 1, 6, 1, 7 },
                    { 1, 7, 1, 8 },
                    { 1, 8, 1, 9 },
                    { 1, 9, 1, 10 },
                    { 1, 10, 1, 11 },
                    { 1, 11, 1, 12 },
                    { 1, 12, 1, 13 },
                    { 1, 13, 1, 14 },
                    { 1, 14, 1, 15 },
                    { 1, 15, 1, 16 },
                    { 1, 16, 1, 17 },
                    { 1, 17, 1, 18 },
                    { 1, 18, 1, 19 },
                    { 1, 19, 1, 20 },
                    { 1, 20, 1, 21 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumns: new[] { "ArticleID", "OrderID" },
                keyValues: new object[] { 1, 6 });

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumns: new[] { "ArticleID", "OrderID" },
                keyValues: new object[] { 1, 7 });

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumns: new[] { "ArticleID", "OrderID" },
                keyValues: new object[] { 1, 8 });

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumns: new[] { "ArticleID", "OrderID" },
                keyValues: new object[] { 1, 9 });

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumns: new[] { "ArticleID", "OrderID" },
                keyValues: new object[] { 1, 10 });

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumns: new[] { "ArticleID", "OrderID" },
                keyValues: new object[] { 1, 11 });

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumns: new[] { "ArticleID", "OrderID" },
                keyValues: new object[] { 1, 12 });

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumns: new[] { "ArticleID", "OrderID" },
                keyValues: new object[] { 1, 13 });

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumns: new[] { "ArticleID", "OrderID" },
                keyValues: new object[] { 1, 14 });

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumns: new[] { "ArticleID", "OrderID" },
                keyValues: new object[] { 1, 15 });

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumns: new[] { "ArticleID", "OrderID" },
                keyValues: new object[] { 1, 16 });

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumns: new[] { "ArticleID", "OrderID" },
                keyValues: new object[] { 1, 17 });

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumns: new[] { "ArticleID", "OrderID" },
                keyValues: new object[] { 1, 18 });

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumns: new[] { "ArticleID", "OrderID" },
                keyValues: new object[] { 1, 19 });

            migrationBuilder.DeleteData(
                table: "Positions",
                keyColumns: new[] { "ArticleID", "OrderID" },
                keyValues: new object[] { 1, 20 });

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 20);
        }
    }
}
