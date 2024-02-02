using DesafioAutoGlass.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace DesafioAutoGlass.Infrastructure.Data
{
    public class SqlDbContext: DbContext
    {

        public SqlDbContext()
        {

        }
        public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionBuilder)
        {
            optionBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TesteTecnicoAutoGlass;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Supplier>()
                .HasData(
                    new Supplier { Id = 1, Description = "João Auto Peças", CNPJ = "25669302000188" }
                );

            modelBuilder.Entity<Product>()
                .HasData(
                    new Product { Id = 1, Description = "Parachoque Gol G4", Status = true, ManufacturingDate = DateTime.UtcNow.AddYears(-1), SupplierId = 1 }
                );

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SqlDbContext).Assembly);
            
        }

    }
}
