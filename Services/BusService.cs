using AplikasiPemesananBus_UAS.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AplikasiPemesananBus_UAS.Services
{
    public class BusService
    {
        // ---------------------- READ ----------------------
        public List<BusModel> GetSemuaBus()
        {
            List<BusModel> listBus = new List<BusModel>();
            string query = "SELECT * FROM \"bus\""; // FIX: Menggunakan quotes dan huruf kecil

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
                            listBus.Add(new BusModel
                            {
                                BusID = reader.GetInt32(0),
                                NamaBus = reader.GetString(1),
                                NomorPlat = reader.GetString(2),
                                Kapasitas = reader.GetInt32(3),
                                TarifBase = reader.GetDecimal(4)
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bus Service Error (GetSemuaBus): " + ex.Message, "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return listBus;
        }

        // ---------------------- CREATE ----------------------
        public bool SimpanBus(BusModel bus)
        {
            string query = "INSERT INTO \"bus\"(\"NamaBus\", \"NomorPlat\", \"Kapasitas\", \"TarifBase\") " +
                           "VALUES(@NamaBus, @NomorPlat, @Kapasitas, @TarifBase)";
            try
            {
                using (var conn = new NpgsqlConnection(DbKoneksi.GetConnectionString()))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@NamaBus", bus.NamaBus);
                        cmd.Parameters.AddWithValue("@NomorPlat", bus.NomorPlat);
                        cmd.Parameters.AddWithValue("@Kapasitas", bus.Kapasitas);
                        cmd.Parameters.AddWithValue("@TarifBase", bus.TarifBase);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bus Service Error (SimpanBus): " + ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // ---------------------- UPDATE ----------------------
        public bool UpdateBus(BusModel bus)
        {
            string query = "UPDATE \"bus\" SET \"NamaBus\"=@NamaBus, \"NomorPlat\"=@NomorPlat, " +
                           "\"Kapasitas\"=@Kapasitas, \"TarifBase\"=@TarifBase " +
                           "WHERE \"BusID\"=@BusID";
            try
            {
                using (var conn = new NpgsqlConnection(DbKoneksi.GetConnectionString()))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@NamaBus", bus.NamaBus);
                        cmd.Parameters.AddWithValue("@NomorPlat", bus.NomorPlat);
                        cmd.Parameters.AddWithValue("@Kapasitas", bus.Kapasitas);
                        cmd.Parameters.AddWithValue("@TarifBase", bus.TarifBase);
                        cmd.Parameters.AddWithValue("@BusID", bus.BusID);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bus Service Error (UpdateBus): " + ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // ---------------------- DELETE ----------------------
        public bool HapusBus(int busId)
        {
            string query = "DELETE FROM \"bus\" WHERE \"BusID\"=@BusID";
            try
            {
                using (var conn = new NpgsqlConnection(DbKoneksi.GetConnectionString()))
                {
                    conn.Open();
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@BusID", busId);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bus Service Error (HapusBus): " + ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}