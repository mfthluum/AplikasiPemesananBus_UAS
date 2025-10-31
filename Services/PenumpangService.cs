using AplikasiPemesananBus_UAS.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AplikasiPemesananBus_UAS.Services
{
    public class PenumpangService
    {
        // ---------------------- READ ----------------------
        public List<PenumpangModel> GetSemuaPenumpang()
        {
            List<PenumpangModel> listPenumpang = new List<PenumpangModel>();
            string query = "SELECT * FROM \"penumpang\""; // FIX: Menggunakan quotes dan huruf kecil

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
                            listPenumpang.Add(new PenumpangModel
                            {
                                PenumpangID = reader.GetInt32(0),
                                Nama = reader.GetString(1),
                                NomorHP = reader.GetString(2),
                                Email = reader.IsDBNull(3) ? null : reader.GetString(3)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Penumpang Service Error (GetSemuaPenumpang): " + ex.Message, "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return listPenumpang;
        }

        // ---------------------- CREATE ----------------------
        public bool SimpanPenumpang(PenumpangModel penumpang)
        {
            string query = "INSERT INTO \"penumpang\"(\"Nama\", \"NomorHP\", \"Email\") VALUES(@Nama, @NomorHP, @Email)";
            try
            {
                using (var conn = new NpgsqlConnection(DbKoneksi.GetConnectionString()))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Nama", penumpang.Nama);
                        cmd.Parameters.AddWithValue("@NomorHP", (object)penumpang.NomorHP ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Email", (object)penumpang.Email ?? DBNull.Value);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Penumpang Service Error (SimpanPenumpang): " + ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // ---------------------- UPDATE ----------------------
        public bool UpdatePenumpang(PenumpangModel penumpang)
        {
            string query = "UPDATE \"penumpang\" SET \"Nama\"=@Nama, \"NomorHP\"=@NomorHP, \"Email\"=@Email WHERE \"PenumpangID\"=@PenumpangID";
            try
            {
                using (var conn = new NpgsqlConnection(DbKoneksi.GetConnectionString()))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Nama", penumpang.Nama);
                        cmd.Parameters.AddWithValue("@NomorHP", (object)penumpang.NomorHP ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Email", (object)penumpang.Email ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@PenumpangID", penumpang.PenumpangID);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Penumpang Service Error (UpdatePenumpang): " + ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // ---------------------- DELETE ----------------------
        public bool HapusPenumpang(int penumpangId)
        {
            string query = "DELETE FROM \"penumpang\" WHERE \"PenumpangID\"=@PenumpangID";
            try
            {
                using (var conn = new NpgsqlConnection(DbKoneksi.GetConnectionString()))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@PenumpangID", penumpangId);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Penumpang Service Error (HapusPenumpang): " + ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}