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
        public DbSet<Artikel> Artikel { get; set; }
        public DbSet<Auftrag> Aufträge { get; set; }
        public DbSet<Gruppe> Gruppen { get; set; }
        public DbSet<Kunde> Kunden { get; set; }
        public DbSet<Ort> Orte { get; set; }
        public DbSet<Position> Positionen { get; set; }

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
                .HasKey(t => new { t.Auftrag_ID, t.Artikel_ID});
        }
    }
}
