using System;

namespace AplikasiPemesananBus_UAS.Services
{
    public class DbKoneksi
    {
        public static string GetConnectionString()
        {
            // PASTIKAN PASSWORD INI SAMA DENGAN PASSWORD POSTGRES ANDA
            return "Server=localhost;Port=5432;Database=db_pemesanan_bus;User Id=postgres;Password=ulum3952;";
        }
    }
}