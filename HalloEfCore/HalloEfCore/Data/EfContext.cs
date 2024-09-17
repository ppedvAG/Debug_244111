using HalloEfCore.Model;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace HalloEfCore.Data
{
    internal class EfContext : DbContext
    {
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Bestellitem> Bestellitems { get; set; }
        public DbSet<Bestellung> Bestellungen { get; set; }
        public DbSet<Kunde> Kunden { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conString = "Server=(localdb)\\mssqllocaldb;Database=PizzaDb;Trusted_Connection=true;";

            optionsBuilder.UseSqlServer(conString).LogTo(msg => Debug.WriteLine(msg)).EnableSensitiveDataLogging(true);
        }
    }
}
