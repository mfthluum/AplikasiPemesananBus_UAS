// FILE: ServiceOrm/PemesananService.cs (Revisi Akhir)

using AplikasiPemesananBus_UAS.Data;
using AplikasiPemesananBus_UAS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AplikasiPemesananBus_UAS.ServiceOrm
{
    public class PemesananService
    {
        private readonly AppDbContext _db;

        public PemesananService(AppDbContext db)
        {
            _db = db;
        }

        // CREATE: Menyimpan data pemesanan baru (tetap async)
        public async Task<int> InsertPemesanan(PemesananModel pemesanan)
        {
            // PENTING: Memastikan tanggal disimpan sebagai UTC
            if (pemesanan.TanggalPemesanan.Kind != DateTimeKind.Utc)
            {
                pemesanan.TanggalPemesanan = pemesanan.TanggalPemesanan.ToUniversalTime();
            }

            try
            {
                _db.Pemesanan.Add(pemesanan);
                return await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saat menyimpan pemesanan: {ex.Message}");
                throw;
            }
        }

        // READ ALL (Untuk PemesananForm DGV): Mengambil semua data
        public List<PemesananModel> GetSemuaPemesanan()
        {
            return _db.Pemesanan
                .Include(p => p.BusModel)
                .Include(p => p.PenumpangModel)
                .OrderByDescending(p => p.TanggalPemesanan)
                .Select(p => new PemesananModel
                {
                    ID = p.ID,
                    PemesananID = p.PemesananID,
                    BusID = p.BusID,
                    PenumpangID = p.PenumpangID,

                    // Konversi kembali ke waktu Lokal untuk TAMPILAN
                    TanggalPemesanan = p.TanggalPemesanan.ToLocalTime(),

                    JumlahTiket = p.JumlahTiket,
                    TotalBayar = p.TotalBayar,
                    TarifDasar = p.TarifDasar,
                    Retribusi = p.Retribusi,

                    // Kolom dari JOIN
                    NamaBus = p.BusModel.NamaBus,
                    NamaPenumpang = p.PenumpangModel.Nama // Asumsi properti nama Penumpang adalah 'Nama'
                })
                .ToList();
        }

        // READ: Ambil Laporan Berdasarkan Rentang Tanggal (Untuk TransaksiRiwayatForm)
        public List<PemesananModel> GetLaporanByTanggal(DateTime tglMulaiUtc, DateTime tglAkhirUtc)
        {
            // tglMulaiUtc: Sudah disetel ke 00:00:00 UTC dari Form
            // tglAkhirUtc: Sudah disetel ke 23:59:59 UTC dari Form

            return _db.Pemesanan
                .Include(p => p.BusModel)
                .Include(p => p.PenumpangModel)

                // FILTER FINAL KRITIS: Bandingkan langsung TanggalPemesanan (UTC) dengan rentang UTC
                // Ini seharusnya mengatasi masalah filter yang over-inclusive.
                .Where(p => p.TanggalPemesanan >= tglMulaiUtc && p.TanggalPemesanan <= tglAkhirUtc)

                .OrderByDescending(p => p.TanggalPemesanan)
                .Select(p => new PemesananModel
                {
                    ID = p.ID,
                    PemesananID = p.PemesananID,
                    BusID = p.BusID,
                    PenumpangID = p.PenumpangID,

                    // Konversi kembali ke waktu Lokal untuk TAMPILAN di DGV Laporan
                    TanggalPemesanan = p.TanggalPemesanan.ToLocalTime(),

                    JumlahTiket = p.JumlahTiket,
                    TotalBayar = p.TotalBayar,
                    TarifDasar = p.TarifDasar,
                    Retribusi = p.Retribusi,

                    NamaBus = p.BusModel.NamaBus,
                    NamaPenumpang = p.PenumpangModel.Nama
                })
                .ToList();
        }
    }
}