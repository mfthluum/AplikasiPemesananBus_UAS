// FILE: Models/BusModel.cs

using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AplikasiPemesananBus_UAS.Models
{
    public class BusModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; } // Primary Key EF Core (PK)

        // Kolom data Bus
        public string NamaBus { get; set; } = string.Empty;
        public string NomorPlat { get; set; } = string.Empty;
        public int Kapasitas { get; set; }
        public decimal TarifBase { get; set; }

        // Navigation Property (Relasi One-to-Many ke Pemesanan)
        public ICollection<PemesananModel> Pemesanan { get; set; } = new List<PemesananModel>();
    }
}