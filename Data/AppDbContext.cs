// FILE: Data/AppDbContext.cs

using AplikasiPemesananBus_UAS.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using System.Security.Cryptography.X509Certificates;

namespace AplikasiPemesananBus_UAS.Data
{
    public class AppDbContext : DbContext
    {
        // DAFTARKAN SEMUA MODEL APLIKASI
        public DbSet<BusModel> Buses { get; set; }
        public DbSet<PenumpangModel> Penumpangs { get; set; }
        public DbSet<PemesananModel> Pemesanan { get; set; }

        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // MENGGUNAKAN CONNECTION STRING YANG DIKONFIRMASI
                optionsBuilder.UseNpgsql("Server=localhost;Port=5432;" +
                                         "Database=db_pemesanan_bus;" +
                                         "User Id=postgres;Password=ulum3952;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // KONFIGURASI RELASI ONE-TO-MANY (Pemesanan -> Bus & Penumpang)

            // Relasi Pemesanan ke Bus
            modelBuilder.Entity<PemesananModel>()
                .HasOne(p => p.BusModel)
                .WithMany(b => b.Pemesanan)
                .HasForeignKey(p => p.BusID)
                .OnDelete(DeleteBehavior.Restrict);

            // Relasi Pemesanan ke Penumpang
            modelBuilder.Entity<PemesananModel>()
                .HasOne(p => p.PenumpangModel)
                .WithMany(pn => pn.Pemesanan)
                .HasForeignKey(p => p.PenumpangID)
                .OnDelete(DeleteBehavior.Restrict);

            // Konfigurasi Primary Key generik 'ID'
            modelBuilder.Entity<BusModel>().HasKey(b => b.ID);
            modelBuilder.Entity<PenumpangModel>().HasKey(p => p.ID);
            modelBuilder.Entity<PemesananModel>().HasKey(p => p.ID);


            // Konfigurasi Index Unik
            modelBuilder.Entity<BusModel>()
                .HasIndex(b => b.NomorPlat)
                .IsUnique();

            modelBuilder.Entity<PenumpangModel>()
                .HasIndex(p => p.NomorHP)
                .IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}