using System;

namespace AplikasiPemesananBus_UAS.Models
{
    public class BusModel
    {
        public int BusID { get; set; }
        public string NamaBus { get; set; }
        public string NomorPlat { get; set; }
        public int Kapasitas { get; set; }
        public decimal TarifBase { get; set; }
    }
}