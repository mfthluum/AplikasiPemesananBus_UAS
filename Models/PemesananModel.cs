using System;

namespace AplikasiPemesananBus_UAS.Models
{
    public class PemesananModel
    {
        public int PemesananID { get; set; }
        public int PenumpangID { get; set; }
        public int BusID { get; set; }
        public DateTime TanggalPemesanan { get; set; }
        public int JumlahTiket { get; set; }
        public decimal TarifDasar { get; set; }
        public decimal Retribusi { get; set; }
        public decimal TotalBayar { get; set; }

        // Properti untuk tampilan DataGridView (Hasil JOIN)
        public string NamaBus { get; set; }
        public string NamaPenumpang { get; set; }
    }
}