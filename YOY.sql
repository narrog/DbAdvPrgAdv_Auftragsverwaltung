use DbAdvPrgAdv_Auftragsverwaltung;

--select * from Articles where PeriodStart < (select dateadd(day,-2,GETDATE())) and PeriodEnd > (select GETDATE());
--select *, PeriodStart, PeriodEnd from Articles where PeriodStart < GETDATE() and PeriodEnd > GETDATE();

--select count(*) from Articles where PeriodStart < GETDATE() and PeriodEnd > GETDATE();

--Artikel
WITH Step1 AS (
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
SELECT StartYear, StartQtr, ArticlesCount,
	FORMAT((ArticlesCount - LastYearArticles)/LastYearArticles,'P') AS PercentChange
FROM Step2;

-- Orders
WITH Step1 AS (
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
SELECT OrderYear, OrderQtr, TotalSales, 
	FORMAT((TotalSales - LastQuarterSales)/LastQuarterSales,'P') AS PercentChange
FROM Step2;

-- Gesamtumsatz
WITH Step1 AS (
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
SELECT OrderYear, OrderQtr, TotalSales, 
	FORMAT((TotalSales - LastQuarterSales)/LastQuarterSales,'P') AS PercentChange
FROM Step2;

-- Umsatz pro Kunde
WITH Step1 AS 
(
	SELECT YEAR(o.OrderDate) AS OrderYear, 
		MONTH(o.OrderDate)/4  + 1 AS OrderQtr,
		Count(o.PriceTotal) AS TotalSales,
		c.CustomerID as Customer
	FROM Orders o
	inner join Customers FOR SYSTEM_TIME ALL c on c.CustomerID = o.CustomerID
	GROUP By YEAR(OrderDate), MONTH(OrderDate)/4 + 1, c.CustomerID
),
Step2 AS 
(
	SELECT OrderYear, OrderQtr, Customer,
		TotalSales, LAG(TotalSales,4) OVER(ORDER BY OrderYear, OrderQtr) AS LastQuarterSales
	FROM Step1
)
SELECT OrderYear, OrderQtr, TotalSales, Customer,
	FORMAT((TotalSales - LastQuarterSales)/LastQuarterSales,'P') AS PercentChange
FROM Step2;


-- Anzahl Artikel pro Bestellung
WITH Step1 AS (
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
SELECT OrderYear, OrderQtr, ArtikelProBestellung,
	FORMAT((ArtikelProBestellung - LastQuarterCount)/LastQuarterCount, 'P') AS PercentChange
FROM Step2;