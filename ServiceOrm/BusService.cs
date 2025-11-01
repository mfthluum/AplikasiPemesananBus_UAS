// FILE: ServiceOrm/BusService.cs

using System;
using System.Collections.Generic;
using System.Linq;
using AplikasiPemesananBus_UAS.Data;
using AplikasiPemesananBus_UAS.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AplikasiPemesananBus_UAS.ServiceOrm
{
    public class BusService
    {
        private readonly AppDbContext _db;

        public BusService(AppDbContext db)
        {
            _db = db;
        }

        // CREATE
        public async Task InsertBus(BusModel bus)
        {
            await _db.Buses.AddAsync(bus);
            await _db.SaveChangesAsync();
        }

        // READ: Ambil semua data Bus
        public List<BusModel> GetSemuaBus()
        {
            // OrderByDescending diubah menjadi OrderBy (Ascending) untuk konsistensi di DGV
            return _db.Buses.OrderBy(b => b.NamaBus).ToList();
        }

        // READ: Ambil data untuk Dropdown (ComboBox)
        public List<object> GetDropdown()
        {
            var list = _db.Buses
                .OrderBy(b => b.NamaBus)
                .Select(b => new
                {
                    // ID (Value Member)
                    ID = b.ID,

                    // DisplayName (Display Member) - HANYA MENAMPILKAN NAMA BUS
                    DisplayName = b.NamaBus // <--- BARIS INI KINI HANYA MENGAMBIL PROPERTI NamaBus
                })
                .ToList<object>();

            return list;
        }

        // READ: Ambil Bus berdasarkan ID
        public BusModel? FindByID(int id)
        {
            return _db.Buses.FirstOrDefault(b => b.ID == id);
        }

        // UPDATE
        public async Task UpdateBus(BusModel bus)
        {
            _db.Buses.Update(bus);
            await _db.SaveChangesAsync();
        }

        // DELETE
        public async Task DeleteBus(int id)
        {
            var busToDelete = await _db.Buses.FindAsync(id);
            if (busToDelete != null)
            {
                _db.Buses.Remove(busToDelete);
                await _db.SaveChangesAsync();
            }
        }
    }
}