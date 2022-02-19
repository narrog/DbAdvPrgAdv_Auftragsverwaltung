using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            modelBuilder.Entity<City>().HasData(new City() { CityID = 1, PLZ = 9000, CityName = "St. Gallen" });
            modelBuilder.Entity<Customer>().HasData(new Customer() {CustomerID = 1, Vorname = "Hans", Name = "Muster",CityID = 1});
            modelBuilder.Entity<Customer>().HasData(new Customer() {CustomerID = 2, Vorname = "Benjamin", Name = "Peter", CityID = 1});

            modelBuilder.Entity<Group>().HasData(new Group() { GroupID = 1, Name = "Elektronik", ParentID = 0 });
            modelBuilder.Entity<Group>().HasData(new Group() { GroupID = 2, Name = "Drucker", ParentID = 1 });

            modelBuilder.Entity<Article>().HasData(new Article() {ArticleID = 1, Bezeichnung = "HP LaserJet Pro M404", GroupID = 2, Price = 420.00});
        }
    }
}
