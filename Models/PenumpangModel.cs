// FILE: Models/PenumpangModel.cs

using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AplikasiPemesananBus_UAS.Models
{
    public class PenumpangModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; } // Primary Key EF Core (PK)

        // Kolom data Penumpang
        public string Nama { get; set; } = string.Empty;
        public string NomorHP { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        // Navigation Property (Relasi One-to-Many ke Pemesanan)
        public ICollection<PemesananModel> Pemesanan { get; set; } = new List<PemesananModel>();
    }
}