// FILE: ServiceOrm/PenumpangService.cs

using System;
using System.Collections.Generic;
using System.Linq;
using AplikasiPemesananBus_UAS.Data;
using AplikasiPemesananBus_UAS.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AplikasiPemesananBus_UAS.ServiceOrm
{
    public class PenumpangService
    {
        private readonly AppDbContext _db;

        public PenumpangService(AppDbContext db)
        {
            _db = db;
        }

        // CREATE
        public async Task InsertPenumpang(PenumpangModel penumpang)
        {
            await _db.Penumpangs.AddAsync(penumpang);
            await _db.SaveChangesAsync();
        }

        // READ: Ambil semua data Penumpang
        public List<PenumpangModel> GetSemuaPenumpang()
        {
            return _db.Penumpangs.OrderByDescending(p => p.ID).ToList();
        }

        // READ: Ambil data untuk Dropdown (ComboBox)
        public List<object> GetDropdown()
        {
            var list = _db.Penumpangs
                .OrderBy(p => p.Nama)
                .Select(p => new
                {
                    // ID (Value Member)
                    ID = p.ID,

                    // DisplayName (Display Member) - HANYA MENAMPILKAN NAMA
                    DisplayName = p.Nama // <--- BARIS INI KINI HANYA MENGAMBIL PROPERTI NAMA
                })
                .ToList<object>();

            return list;
        }

        // READ: Ambil Penumpang berdasarkan ID
        public PenumpangModel? FindByID(int id)
        {
            return _db.Penumpangs.FirstOrDefault(p => p.ID == id);
        }

        // UPDATE
        public async Task UpdatePenumpang(PenumpangModel penumpang)
        {
            _db.Penumpangs.Update(penumpang);
            await _db.SaveChangesAsync();
        }

        // DELETE
        public async Task DeletePenumpang(int id)
        {
            var penumpangToDelete = await _db.Penumpangs.FindAsync(id);
            if (penumpangToDelete != null)
            {
                _db.Penumpangs.Remove(penumpangToDelete);
                await _db.SaveChangesAsync();
            }
        }
    }
}