// FILE: Models/PemesananModel.cs

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AplikasiPemesananBus_UAS.Models
{
    public class PemesananModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; } // Primary Key EF Core (PK)

        // Foreign Keys (FK)
        public int PenumpangID { get; set; }
        public int BusID { get; set; }

        // Kolom data Pemesanan
        public DateTime TanggalPemesanan { get; set; }
        public int JumlahTiket { get; set; }
        public decimal TotalBayar { get; set; }

        // Kolom Tambahan (untuk histori harga)
        public decimal TarifDasar { get; set; }
        public decimal Retribusi { get; set; }

        // Kolom ID Internal (Jika diperlukan untuk kompatibilitas code lama/dosen)
        // Ini tidak digunakan oleh EF Core sebagai PK/FK
        public int PemesananID { get; set; }

        // Navigation Properties (untuk JOIN)
        [ForeignKey("BusID")]
        public BusModel? BusModel { get; set; }

        [ForeignKey("PenumpangID")]
        public PenumpangModel? PenumpangModel { get; set; }

        // Non-mapped Properties (untuk tampilan di DataGridView)
        [NotMapped]
        public string NamaBus { get; set; } = string.Empty;

        [NotMapped]
        public string NamaPenumpang { get; set; } = string.Empty;
    }
}