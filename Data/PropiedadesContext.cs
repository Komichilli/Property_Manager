using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics.Metrics;
using System;
using PropiedadesWEB.Models;
using PropiedadWEB.Models;


namespace PropiedadesWEB.Data
{
    public class PropiedadesContext : DbContext
    {
        public DbSet<Propiedad> Propiedads { get; set; }
        public DbSet<Inquilino> Inquilinos { get; set; }
        public DbSet<Contrato> Contratos { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=(localdb)\\mssqllocaldb;Database=PropertyManagerDB;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contrato>()
                .HasOne(c => c.Propiedad)
                .WithMany(p => p.Contratos)
                .HasForeignKey(c => c.PropiedadId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Contrato>()
                .HasOne(c => c.Inquilino)
                .WithMany(i => i.Contratos)
                .HasForeignKey(c => c.InquilinoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Pago>()
                .HasOne(p => p.Contrato)
                .WithMany(c => c.Pagos)
                .HasForeignKey(p => p.ContratoId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Inquilino>()
                .HasOne(i => i.Propiedad)
                .WithMany(p => p.Inquilinos)
                .HasForeignKey(i => i.PropiedadId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }

}
