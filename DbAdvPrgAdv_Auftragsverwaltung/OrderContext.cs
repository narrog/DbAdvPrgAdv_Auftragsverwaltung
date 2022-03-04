using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DbAdvPrgAdv_Auftragsverwaltung.Model;
using Microsoft.EntityFrameworkCore;

namespace DbAdvPrgAdv_Auftragsverwaltung
{
    class OrderContext : DbContext
    {
        // DBs "erstellen"
        public DbSet<Article> Articles { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Position> Positions { get; set; }

        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Verbindung aufbauen
            optionsBuilder.UseSqlServer("Data Source=.; Database=DbAdvPrgAdv_Auftragsverwaltung; Trusted_Connection=True");
            optionsBuilder.UseLazyLoadingProxies();

            // Logs
            optionsBuilder.LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
        }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // PK zusammen bauen aus 2 FK
            modelBuilder.Entity<Position>()
                .HasKey(t => new { t.OrderID, t.ArticleID});

            modelBuilder.Entity<Customer>().ToTable("Customers", c => c.IsTemporal());
            modelBuilder.Entity<Article>().ToTable("Articles", a => a.IsTemporal());

            #region Beispieldaten
            modelBuilder.Entity<City>().HasData(new City() { CityID = 1, PLZ = 9000, CityName = "St. Gallen" });
            modelBuilder.Entity<City>().HasData(new City() { CityID = 2, PLZ = 9000, CityName = "Herisau" });
            modelBuilder.Entity<Customer>().HasData(new Customer() { CustomerID = 1, Vorname = "Hans", Name = "Muster", CityID = 1 });
            modelBuilder.Entity<Customer>().HasData(new Customer() { CustomerID = 2, Vorname = "Benjamin", Name = "Peter", CityID = 1 });
            modelBuilder.Entity<Customer>().HasData(new Customer() { CustomerID = 3, Vorname = "Leonie", Name = "Buser", CityID = 2 });

            modelBuilder.Entity<Group>().HasData(new Group() { GroupID = 1, Name = "Elektronik", ParentID = 0 });
            modelBuilder.Entity<Group>().HasData(new Group() { GroupID = 2, Name = "Drucker", ParentID = 1 });
            modelBuilder.Entity<Group>().HasData(new Group() { GroupID = 3, Name = "Autozubehör", ParentID = 0 });
            modelBuilder.Entity<Group>().HasData(new Group() { GroupID = 4, Name = "Laptop", ParentID = 1 });

            modelBuilder.Entity<Article>().HasData(new Article() { ArticleID = 1, Name = "HP LaserJet Pro M404", GroupID = 2, Price = 420.00 });
            modelBuilder.Entity<Article>().HasData(new Article() { ArticleID = 2, Name = "Lenovo ThinkPad L15", GroupID = 4, Price = 900.00 });
            modelBuilder.Entity<Article>().HasData(new Article() { ArticleID = 3, Name = "Chromstahl Felgen 19 Zoll", GroupID = 3, Price = 200.00 });
            modelBuilder.Entity<Article>().HasData(new Article() { ArticleID = 4, Name = "HP EliteBook G8", GroupID = 4, Price = 1600.00});
            modelBuilder.Entity<Article>().HasData(new Article() { ArticleID = 5, Name = "MacBook Air 2020", GroupID = 4, Price = 1000 });
            modelBuilder.Entity<Article>().HasData(new Article() { ArticleID = 6, Name = "Canon Pixma", GroupID = 2, Price = 60});

            // Bestellungen
            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 1, OrderDate = new DateTime(2021, 12, 31), CustomerID = 1, PriceTotal = 420.00 });
            modelBuilder.Entity<Position>().HasData(new Position() { Number = 1, ArticleID = 1, Count = 1, OrderID = 1 });

            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 2, OrderDate = new DateTime(2022, 01, 03), CustomerID = 1, PriceTotal = 840.00 });
            modelBuilder.Entity<Position>().HasData(new Position() { Number = 2, ArticleID = 1, Count = 2, OrderID = 2 });

            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 3, OrderDate = new DateTime(2022, 01, 03), CustomerID = 2, PriceTotal = 1320.00 });
            modelBuilder.Entity<Position>().HasData(new Position() { Number = 3, ArticleID = 1, Count = 1, OrderID = 3 });
            modelBuilder.Entity<Position>().HasData(new Position() { Number = 4, ArticleID = 2, Count = 1, OrderID = 3 });
            
            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 4, OrderDate = new DateTime(2022, 01, 10), CustomerID = 1, PriceTotal = 1600 });
            modelBuilder.Entity<Position>().HasData(new Position() { Number = 5, ArticleID = 4, Count = 1, OrderID = 4 });

            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 5, OrderDate = new DateTime(2022, 01, 20), CustomerID = 1, PriceTotal = 60 });
            modelBuilder.Entity<Position>().HasData(new Position() { Number = 6, ArticleID = 6, Count = 1, OrderID = 5 });

            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 6, OrderDate = new DateTime(2021, 09, 30), CustomerID = 1, PriceTotal = 420.00 });
            modelBuilder.Entity<Position>().HasData(new Position() { Number = 7, ArticleID = 1, Count = 1, OrderID = 6 });

            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 7, OrderDate = new DateTime(2021, 06, 30), CustomerID = 1, PriceTotal = 420.00 });
            modelBuilder.Entity<Position>().HasData(new Position() { Number = 8, ArticleID = 1, Count = 1, OrderID = 7 });

            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 8, OrderDate = new DateTime(2021, 03, 31), CustomerID = 1, PriceTotal = 420.00 });
            modelBuilder.Entity<Position>().HasData(new Position() { Number = 9, ArticleID = 1, Count = 1, OrderID = 8 });

            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 9, OrderDate = new DateTime(2020, 12, 31), CustomerID = 1, PriceTotal = 420.00 });
            modelBuilder.Entity<Position>().HasData(new Position() { Number = 10, ArticleID = 1, Count = 1, OrderID = 9 });

            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 10, OrderDate = new DateTime(2020, 06, 30), CustomerID = 1, PriceTotal = 420.00 });
            modelBuilder.Entity<Position>().HasData(new Position() { Number = 11, ArticleID = 1, Count = 1, OrderID = 10 });

            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 11, OrderDate = new DateTime(2020, 03, 31), CustomerID = 1, PriceTotal = 420.00 });
            modelBuilder.Entity<Position>().HasData(new Position() { Number = 12, ArticleID = 1, Count = 1, OrderID = 11 });

            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 12, OrderDate = new DateTime(2019, 12, 31), CustomerID = 1, PriceTotal = 420.00 });
            modelBuilder.Entity<Position>().HasData(new Position() { Number = 13, ArticleID = 1, Count = 1, OrderID = 12 });

            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 13, OrderDate = new DateTime(2019, 09, 30), CustomerID = 1, PriceTotal = 420.00 });
            modelBuilder.Entity<Position>().HasData(new Position() { Number = 14, ArticleID = 1, Count = 1, OrderID = 13 });

            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 14, OrderDate = new DateTime(2019, 06, 30), CustomerID = 1, PriceTotal = 420.00 });
            modelBuilder.Entity<Position>().HasData(new Position() { Number = 15, ArticleID = 1, Count = 1, OrderID = 14 });

            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 15, OrderDate = new DateTime(2019, 03, 31), CustomerID = 1, PriceTotal = 420.00 });
            modelBuilder.Entity<Position>().HasData(new Position() { Number = 16, ArticleID = 1, Count = 1, OrderID = 15 });

            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 16, OrderDate = new DateTime(2018, 12, 31), CustomerID = 1, PriceTotal = 420.00 });
            modelBuilder.Entity<Position>().HasData(new Position() { Number = 17, ArticleID = 1, Count = 1, OrderID = 16 });

            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 17, OrderDate = new DateTime(2018, 09, 30), CustomerID = 1, PriceTotal = 420.00 });
            modelBuilder.Entity<Position>().HasData(new Position() { Number = 18, ArticleID = 1, Count = 1, OrderID = 17 });

            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 18, OrderDate = new DateTime(2018, 06, 30), CustomerID = 1, PriceTotal = 420.00 });
            modelBuilder.Entity<Position>().HasData(new Position() { Number = 19, ArticleID = 1, Count = 1, OrderID = 18 });

            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 19, OrderDate = new DateTime(2018, 03, 31), CustomerID = 1, PriceTotal = 420.00 });
            modelBuilder.Entity<Position>().HasData(new Position() { Number = 20, ArticleID = 1, Count = 1, OrderID = 19 });

            modelBuilder.Entity<Order>().HasData(new Order() { OrderID = 20, OrderDate = new DateTime(2020, 09, 30), CustomerID = 1, PriceTotal = 420.00 });
            modelBuilder.Entity<Position>().HasData(new Position() { Number = 21, ArticleID = 1, Count = 1, OrderID = 20 });

            #endregion

        }

        public List<Yoy> Test()
        {
            var list = new List<Yoy>();
            using(var context = new OrderContext())
            {
                using (var command = context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText =
                        @";WITH Step1 AS (
	                        SELECT CONCAT(YEAR(OrderDate),' Q',MONTH(OrderDate)/4  + 1) AS OrderQrt, 
		                        Count(PriceTotal) AS TotalSales
	                        FROM Orders
	                        GROUP By OrderDate
                        ),
                        Step2 AS (
	                        SELECT OrderQrt, 
		                        TotalSales, LAG(TotalSales,4) OVER(ORDER BY OrderQrt) AS LastQuarterSales
	                        FROM Step1
                        )
                        SELECT TOP 12 OrderQrt AS Quartal, TotalSales, 
	                        FORMAT((TotalSales - LastQuarterSales)/LastQuarterSales,'P') AS Yoy
                        FROM Step2 ORDER BY OrderQrt desc;";
                    context.Database.OpenConnection();
                    using (var result = command.ExecuteReader())
                    {
                        while (result.Read())
                        {
                            list.Add(new Yoy(result["Quartal"].ToString(), result["TotalSales"].ToString(), result["Yoy"].ToString()));
                        }
                    }
                }
            }
            return list;
        }

        // CTE für TreeView
        public List<Group> GroupTree() =>
            Groups.FromSqlRaw(
                    @";with cte as (
	                    SELECT GroupID, Name, ParentID, cast('none' as nvarchar(max)) AS Parent 
                        FROM Groups 
                        WHERE ParentID = 0
	                    UNION ALL
	                    SELECT a.GroupID, a.Name, a.ParentID, (b.Name) AS Parent 
                        FROM Groups a
	                    INNER JOIN cte b 
                            ON a.ParentID = b.GroupID
                    )
                    SELECT * FROM cte;")
                .AsNoTrackingWithIdentityResolution()
                .ToList();

        // Anzahl Bestellungen
        public List<Order> OrderYOY() =>
                Orders.FromSqlRaw(
                @";WITH Step1 AS (
	                SELECT YEAR(OrderDate) AS OrderYear, 
		                MONTH(OrderDate)/4  + 1 AS OrderQtr,
		                Count(PriceTotal) AS TotalSales
	                FROM Orders
	                GROUP By YEAR(OrderDate), MONTH(OrderDate)/4 + 1
                ),
                Step2 AS (
	                SELECT OrderYear, OrderQtr, 
		                TotalSales, LAG(TotalSales,4) OVER(ORDER BY OrderYear, OrderQtr) AS LastQuarterSales
	                FROM Step1
                )
                SELECT TOP 12 OrderYear AS Year, OrderQtr AS Quartal, TotalSales AS Kategorie, 
	                FORMAT((TotalSales - LastQuarterSales)/LastQuarterSales,'P') AS Yoy
                FROM Step2;")
            .AsNoTrackingWithIdentityResolution()
            .ToList();

        // Anzahl Artikel Pro Bestellung
        public List<Order> ArticlesPerOrderYOY() =>
            Orders.FromSqlRaw(
                @";WITH Step1 AS (
	                SELECT YEAR(o.OrderDate) AS OrderYear, 
		                MONTH(o.OrderDate)/4  + 1 AS OrderQtr,
		                count (o.OrderID) as AnzahlBestellungen,
		                sum(p.Count) AS AnzahlArtikel,
		                cast(sum(p.Count)as numeric (10,2)) / (count (o.OrderID) ) as ArtikelProBestellung
	                FROM Orders o
	                inner join Positions p on o.OrderID = p.OrderID
	                GROUP By YEAR(OrderDate), MONTH(OrderDate)/4 + 1
                ),
                Step2 AS (
	                SELECT OrderYear, OrderQtr, ArtikelProBestellung,
		                LAG(AnzahlArtikel,4) OVER(ORDER BY OrderYear, OrderQtr) AS LastQuarterCount
	                FROM Step1
                )
                SELECT TOP 12 OrderYear, OrderQtr, ArtikelProBestellung,
	                FORMAT((ArtikelProBestellung - LastQuarterCount)/LastQuarterCount, 'P') AS PercentChange
                FROM Step2;")
            .AsNoTrackingWithIdentityResolution()
            .ToList();

        // Umsatz pro Kunde
        public List<Order> SalesPerCustomerYOY() =>
            Orders.FromSqlRaw(
                    @";WITH Step1 AS (
	                    SELECT YEAR(o.OrderDate) AS OrderYear, 
		                    MONTH(o.OrderDate)/4  + 1 AS OrderQtr,
		                    Count(o.PriceTotal) AS TotalSales,
		                    c.CustomerID as Customer
	                    FROM Orders o
	                    inner join Customers FOR SYSTEM_TIME ALL c on c.CustomerID = o.CustomerID
	                    GROUP By YEAR(OrderDate), MONTH(OrderDate)/4 + 1, c.CustomerID
                    ),
                    Step2 AS (
	                    SELECT OrderYear, OrderQtr, Customer,
		                    TotalSales, LAG(TotalSales,4) OVER(ORDER BY OrderYear, OrderQtr) AS LastQuarterSales
	                    FROM Step1
                    )
                    SELECT TOP 12 OrderYear, OrderQtr, TotalSales, Customer,
	                    FORMAT((TotalSales - LastQuarterSales)/LastQuarterSales,'P') AS PercentChange
                    FROM Step2;")
                .AsNoTrackingWithIdentityResolution()
                .ToList();

        // Gesamtumsatz
        public List<Order> SalesTotalYOY() =>
            Orders.FromSqlRaw(
                    @";WITH Step1 AS (
	                    SELECT YEAR(OrderDate) AS OrderYear, 
		                    MONTH(OrderDate)/4  + 1 AS OrderQtr,
		                    sum(PriceTotal) AS TotalSales
	                    FROM Orders
	                    GROUP By YEAR(OrderDate), MONTH(OrderDate)/4 + 1
                    ),
                    Step2 AS (
	                    SELECT OrderYear, OrderQtr, 
		                    TotalSales, LAG(TotalSales,4) OVER(ORDER BY OrderYear, OrderQtr) AS LastQuarterSales
	                    FROM Step1
                    )
                    SELECT TOP 12 OrderYear, OrderQtr, TotalSales, 
	                    FORMAT((TotalSales - LastQuarterSales)/LastQuarterSales,'P') AS PercentChange
                    FROM Step2;")
                .AsNoTrackingWithIdentityResolution()
                .ToList();

        // Anzahl Artikel
        public List<Article> ArticlesYOY() =>
            Articles.FromSqlRaw(
                    @";WITH Step1 AS (
	                    SELECT YEAR(PeriodStart) AS StartYear, 
		                    MONTH(PeriodStart)/4  + 1 AS StartQtr,
		                    COUNT(*) AS ArticlesCount
	                    FROM Articles
	                    FOR SYSTEM_TIME ALL
	                    GROUP By YEAR(PeriodStart), MONTH(PeriodStart)/4 + 1),
                    Step2 AS (
	                    SELECT StartYear, StartQtr, 
		                    ArticlesCount, LAG(ArticlesCount,4) OVER(ORDER BY StartYear, StartQtr)  AS LastYearArticles
	                    FROM Step1)
                    SELECT TOP 12 StartYear, StartQtr, ArticlesCount,
	                    FORMAT((ArticlesCount - LastYearArticles)/LastYearArticles,'P') AS PercentChange
                    FROM Step2;")
                .AsNoTrackingWithIdentityResolution()
                .ToList();
    }
}
