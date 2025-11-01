// FILE: Forms/InputBusForm.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AplikasiPemesananBus_UAS.Models;
using AplikasiPemesananBus_UAS.ServiceOrm;
using AplikasiPemesananBus_UAS.Data;
using System.Globalization;
using System.Threading.Tasks;

namespace AplikasiPemesananBus_UAS.Forms
{
    public partial class InputBusForm : Form
    {
        private int IDBusDipilih = 0;
        private readonly BusService _busService;

        public InputBusForm()
        {
            InitializeComponent();

            // Inisialisasi Service menggunakan AppDbContext
            var context = new AppDbContext();
            _busService = new BusService(context);

            // --- Event Handlers (Pastikan Sesuai dengan Designer.cs) ---
            this.Load += new System.EventHandler(this.InputBusForm_Load);

            // Menggunakan event click yang sudah didefinisikan di Designer
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
        
            this.btnKeluar.Click += new System.EventHandler(this.btnKeluar_Click);

            this.dgvDataBus.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDataBus_CellClick);

            ClearForm();
            btnEdit.Enabled = false;
           
        }

        private void ClearForm()
        {
            IDBusDipilih = 0;
            txtNamaBus.Text = string.Empty;
            txtNomorPlat.Text = string.Empty;
            txtKapasitas.Text = "0";
            txtTarifDasar.Text = "0";
            btnSimpan.Text = "Simpan";
            btnEdit.Enabled = false;
          
            txtNamaBus.Focus();
        }

        private void LoadDataBus()
        {
            dgvDataBus.DataSource = _busService.GetSemuaBus();

            if (dgvDataBus.Columns.Count > 0)
            {
                if (dgvDataBus.Columns.Contains("ID"))
                {
                    dgvDataBus.Columns["ID"].Visible = true;
                    dgvDataBus.Columns["ID"].HeaderText = "PK ID";
                    dgvDataBus.Columns["ID"].Width = 50;
                }

                if (dgvDataBus.Columns.Contains("Pemesanan")) dgvDataBus.Columns["Pemesanan"].Visible = false;

                if (dgvDataBus.Columns.Contains("TarifBase"))
                {
                    dgvDataBus.Columns["TarifBase"].HeaderText = "Tarif Dasar";
                    dgvDataBus.Columns["TarifBase"].DefaultCellStyle.Format = "N0";
                    dgvDataBus.Columns["TarifBase"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                dgvDataBus.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            ClearForm();
        }

        private void InputBusForm_Load(object? sender, EventArgs e)
        {
            LoadDataBus();
        }

        private void dgvDataBus_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvDataBus.Rows.Count > 0)
            {
                if (dgvDataBus.Rows[e.RowIndex].Cells["ID"].Value is int busID)
                {
                    IDBusDipilih = busID;
                    btnSimpan.Text = "Baru";
                    btnEdit.Enabled = true;
                  

                    txtNamaBus.Text = dgvDataBus.Rows[e.RowIndex].Cells["NamaBus"].Value.ToString();
                    txtNomorPlat.Text = dgvDataBus.Rows[e.RowIndex].Cells["NomorPlat"].Value.ToString();

                    if (dgvDataBus.Rows[e.RowIndex].Cells["Kapasitas"].Value is int kapasitas)
                    {
                        txtKapasitas.Text = kapasitas.ToString();
                    }

                    if (dgvDataBus.Rows[e.RowIndex].Cells["TarifBase"].Value is decimal tarif)
                    {
                        // Format ke string N0 lalu hapus separator ribuan default ('-') jika ada
                        string tarifText = tarif.ToString("N0", CultureInfo.InvariantCulture).Replace(CultureInfo.CurrentCulture.NumberFormat.NumberGroupSeparator, "");
                        txtTarifDasar.Text = tarifText;
                    }
                }
            }
        }

        private async void btnSimpan_Click(object? sender, EventArgs e)
        {
            if (IDBusDipilih != 0)
            {
                ClearForm();
                return;
            }

            if (!ValidasiInput()) return;

            var newBus = CreateBusModel();

            try
            {
                await _busService.InsertBus(newBus);
                MessageBox.Show("Data Bus berhasil disimpan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataBus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal menyimpan data. Pastikan Nomor Plat Bus unik. Error: {ex.Message}", "Error DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnEdit_Click(object? sender, EventArgs e)
        {
            if (IDBusDipilih == 0) return;

            if (!ValidasiInput()) return;

            var updatedBus = CreateBusModel();
            updatedBus.ID = IDBusDipilih;

            try
            {
                await _busService.UpdateBus(updatedBus);
                MessageBox.Show("Data Bus berhasil diubah!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataBus();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal mengubah data. Pastikan Nomor Plat Bus unik. Error: {ex.Message}", "Error DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnHapus_Click(object? sender, EventArgs e)
        {
            if (IDBusDipilih == 0) return;

            if (MessageBox.Show("Apakah Anda yakin ingin menghapus data Bus ini?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    await _busService.DeleteBus(IDBusDipilih);
                    MessageBox.Show("Data Bus berhasil dihapus!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataBus();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Gagal menghapus data. Bus ini mungkin sudah digunakan dalam transaksi. Error: {ex.Message}", "Error DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidasiInput()
        {
            if (string.IsNullOrWhiteSpace(txtNamaBus.Text) || string.IsNullOrWhiteSpace(txtNomorPlat.Text))
            {
                MessageBox.Show("Nama Bus dan Nomor Plat harus diisi.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (!int.TryParse(txtKapasitas.Text, out int kapasitas) || kapasitas <= 0)
            {
                MessageBox.Show("Kapasitas harus berupa angka positif.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            decimal.TryParse(txtTarifDasar.Text.Replace(".", ""), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal tarifDasar);
            if (tarifDasar <= 0)
            {
                MessageBox.Show("Tarif Dasar harus lebih besar dari Rp. 0.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private BusModel CreateBusModel()
        {
            int.TryParse(txtKapasitas.Text, out int kapasitas);
            decimal.TryParse(txtTarifDasar.Text.Replace(".", ""), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal tarifDasar);

            return new BusModel
            {
                NamaBus = txtNamaBus.Text,
                NomorPlat = txtNomorPlat.Text,
                Kapasitas = kapasitas,
                TarifBase = tarifDasar
            };
        }

        private void btnKeluar_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
    }
}