using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Npgsql;
using AplikasiPemesananBus_UAS.Models;

namespace AplikasiPemesananBus_UAS.Services
{
    public class PemesananService
    {
        private PemesananModel MapReaderToModel(NpgsqlDataReader reader)
        {
            return new PemesananModel
            {
                PemesananID = reader.GetInt32(reader.GetOrdinal("PemesananID")),
                PenumpangID = reader.GetInt32(reader.GetOrdinal("PenumpangID")),
                BusID = reader.GetInt32(reader.GetOrdinal("BusID")),
                TanggalPemesanan = reader.GetDateTime(reader.GetOrdinal("TanggalPemesanan")),
                JumlahTiket = reader.GetInt32(reader.GetOrdinal("JumlahTiket")),
                TarifDasar = reader.GetDecimal(reader.GetOrdinal("TarifDasar")),
                Retribusi = reader.GetDecimal(reader.GetOrdinal("Retribusi")),
                TotalBayar = reader.GetDecimal(reader.GetOrdinal("TotalBayar")),
                NamaBus = reader.GetString(reader.GetOrdinal("NamaBus")),
                NamaPenumpang = reader.GetString(reader.GetOrdinal("NamaPenumpang"))
            };
        }

        public bool SimpanPemesanan(PemesananModel model)
        {
            string query = @"
                INSERT INTO ""pemesanan"" (""PenumpangID"", ""BusID"", ""TanggalPemesanan"", ""JumlahTiket"", ""TarifDasar"", ""Retribusi"", ""TotalBayar"")
                VALUES (@PenumpangID, @BusID, @TanggalPemesanan, @JumlahTiket, @TarifDasar, @Retribusi, @TotalBayar)";

            try
            {
                using (var conn = new NpgsqlConnection(DbKoneksi.GetConnectionString()))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@PenumpangID", model.PenumpangID);
                        cmd.Parameters.AddWithValue("@BusID", model.BusID);
                        cmd.Parameters.AddWithValue("@TanggalPemesanan", model.TanggalPemesanan);
                        cmd.Parameters.AddWithValue("@JumlahTiket", model.JumlahTiket);
                        cmd.Parameters.AddWithValue("@TarifDasar", model.TarifDasar);
                        cmd.Parameters.AddWithValue("@Retribusi", model.Retribusi);
                        cmd.Parameters.AddWithValue("@TotalBayar", model.TotalBayar);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Simpan Pemesanan: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public List<PemesananModel> GetSemuaPemesanan()
        {
            List<PemesananModel> listPemesanan = new List<PemesananModel>();
            string query = @"
                SELECT p.*, b.""NamaBus"", n.""Nama"" AS NamaPenumpang
                FROM ""pemesanan"" p 
                JOIN ""bus"" b ON p.""BusID"" = b.""BusID"" 
                JOIN ""penumpang"" n ON p.""PenumpangID"" = n.""PenumpangID""
                ORDER BY p.""TanggalPemesanan"" DESC";

            try
            {
                using (var conn = new NpgsqlConnection(DbKoneksi.GetConnectionString()))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listPemesanan.Add(MapReaderToModel(reader));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Get Semua Pemesanan: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return listPemesanan;
        }

        // KODE UNTUK LAPORAN
        public List<PemesananModel> GetLaporanByTanggal(DateTime tglMulai, DateTime tglAkhir)
        {
            List<PemesananModel> listLaporan = new List<PemesananModel>();

            string query = @"
                SELECT p.*, b.""NamaBus"", n.""Nama"" AS NamaPenumpang
                FROM ""pemesanan"" p 
                JOIN ""bus"" b ON p.""BusID"" = b.""BusID"" 
                JOIN ""penumpang"" n ON p.""PenumpangID"" = n.""PenumpangID""
                WHERE p.""TanggalPemesanan"" >= @TglMulai AND p.""TanggalPemesanan"" <= @TglAkhir
                ORDER BY p.""TanggalPemesanan"" ASC";

            try
            {
                using (var conn = new NpgsqlConnection(DbKoneksi.GetConnectionString()))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TglMulai", NpgsqlTypes.NpgsqlDbType.Timestamp, tglMulai);
                        cmd.Parameters.AddWithValue("@TglAkhir", NpgsqlTypes.NpgsqlDbType.Timestamp, tglAkhir);

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                listLaporan.Add(MapReaderToModel(reader));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error Laporan: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return listLaporan;
        }
    }
}