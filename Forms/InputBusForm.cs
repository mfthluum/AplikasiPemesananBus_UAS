// FILE: Forms/InputBusForm.cs

using System;
using System.Windows.Forms;
using AplikasiPemesananBus_UAS.Models;
using AplikasiPemesananBus_UAS.Services;
using System.Globalization; // Tambahkan ini untuk penanganan format desimal

namespace AplikasiPemesananBus_UAS.Forms
{
    public partial class InputBusForm : Form
    {
        private BusService service = new BusService();
        private int selectedBusId = 0;

        public InputBusForm()
        {
            InitializeComponent();

            // Panggil LoadData saat form pertama kali dimuat
            this.Load += (s, e) => LoadData();

            // Event Handlers sudah benar
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            this.btnKeluar.Click += new System.EventHandler(this.btnKeluar_Click);
            this.dgvDataBus.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDataBus_CellClick);
        }

        // KOREKSI: Panggil LoadData secara terpisah dari event Load form
        private void InputBusForm_Load(object sender, EventArgs e)
        {
            // Tidak perlu memanggil LoadData di sini lagi karena sudah dipanggil di constructor
        }

        private void LoadData()
        {
            // Panggil Service yang sudah dikoreksi
            dgvDataBus.DataSource = service.GetSemuaBus();

            // Pengaturan DataGridView agar terlihat rapi dan data ID tersembunyi
            if (dgvDataBus.Columns.Contains("BusID"))
            {
                dgvDataBus.Columns["BusID"].Visible = false;
            }
            // Format TarifBase sebagai mata uang
            if (dgvDataBus.Columns.Contains("TarifBase"))
            {
                dgvDataBus.Columns["TarifBase"].DefaultCellStyle.Format = "N2";
                dgvDataBus.Columns["TarifBase"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            ClearForm();
        }

        private void ClearForm()
        {
            txtNamaBus.Clear();
            txtNomorPlat.Clear();
            txtKapasitas.Clear();
            txtTarifDasar.Clear();
            selectedBusId = 0;
            btnSimpan.Enabled = true; // Jika mode simpan
            btnEdit.Enabled = false;  // Nonaktifkan edit saat clear
        }

        private void dgvDataBus_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvDataBus.Rows[e.RowIndex];

                // Pastikan nama kolom sesuai dengan nama properti di BusModel (yang Anda kirim)
                selectedBusId = (int)row.Cells["BusID"].Value;
                txtNamaBus.Text = row.Cells["NamaBus"].Value.ToString();
                txtNomorPlat.Text = row.Cells["NomorPlat"].Value.ToString();
                txtKapasitas.Text = row.Cells["Kapasitas"].Value.ToString();

                // KOREKSI: Ambil TarifBase sebagai Decimal/string, lalu format kembali (optional)
                // Kita asumsikan TarifBase di model adalah decimal
                if (row.Cells["TarifBase"].Value != null)
                {
                    // Gunakan ToString("N0") untuk menampilkan angka tanpa desimal (misal: 150000)
                    txtTarifDasar.Text = ((decimal)row.Cells["TarifBase"].Value).ToString("N0", CultureInfo.InvariantCulture);
                }

                btnSimpan.Enabled = false; // Nonaktifkan simpan saat memilih data
                btnEdit.Enabled = true;   // Aktifkan edit
            }
        }

        private void btnSimpan_Click(object? sender, EventArgs e)
        {
            // KOREKSI: Gunakan NumberStyles.Any dan CultureInfo.InvariantCulture agar bisa menerima input "150.000" atau "150000"
            if (string.IsNullOrWhiteSpace(txtNamaBus.Text) ||
                string.IsNullOrWhiteSpace(txtNomorPlat.Text) ||
                !int.TryParse(txtKapasitas.Text, out int kapasitas) ||
                !decimal.TryParse(txtTarifDasar.Text.Replace(".", ","), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal tarifDasar))
            {
                MessageBox.Show("Mohon isi semua data (Nama Bus, Nomor Plat, Kapasitas (angka), dan Tarif Dasar (angka)) dengan benar.", "Validasi Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (kapasitas <= 0 || tarifDasar <= 0)
            {
                MessageBox.Show("Kapasitas dan Tarif Dasar harus lebih besar dari nol.", "Validasi Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            var newBus = new BusModel
            {
                NamaBus = txtNamaBus.Text,
                NomorPlat = txtNomorPlat.Text,
                Kapasitas = kapasitas,
                TarifBase = tarifDasar
            };

            if (service.SimpanBus(newBus))
            {
                MessageBox.Show("Data Bus berhasil disimpan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            else
            {
                // Tampilkan pesan error jika SimpanBus mengembalikan false (biasanya karena NomorPlat duplikat)
                MessageBox.Show("Gagal menyimpan data bus. Kemungkinan Nomor Plat sudah terdaftar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object? sender, EventArgs e)
        {
            if (selectedBusId == 0) return;

            // KOREKSI: Tambahkan validasi yang sama seperti Simpan
            if (string.IsNullOrWhiteSpace(txtNamaBus.Text) ||
                string.IsNullOrWhiteSpace(txtNomorPlat.Text) ||
                !int.TryParse(txtKapasitas.Text, out int kapasitas) ||
                !decimal.TryParse(txtTarifDasar.Text.Replace(".", ","), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal tarifDasar))
            {
                MessageBox.Show("Mohon isi semua data dengan format yang benar.", "Validasi Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (kapasitas <= 0 || tarifDasar <= 0)
            {
                MessageBox.Show("Kapasitas dan Tarif Dasar harus lebih besar dari nol.", "Validasi Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var updatedBus = new BusModel
            {
                BusID = selectedBusId,
                NamaBus = txtNamaBus.Text,
                NomorPlat = txtNomorPlat.Text,
                Kapasitas = kapasitas,
                TarifBase = tarifDasar
            };

            if (service.UpdateBus(updatedBus))
            {
                MessageBox.Show("Data Bus berhasil diubah!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            else
            {
                // Tampilkan pesan error jika UpdateBus mengembalikan false
                MessageBox.Show("Gagal mengubah data bus. Cek koneksi atau Nomor Plat mungkin duplikat.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKeluar_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSimpan_Click_1(object sender, EventArgs e)
        {

        }
    }
}