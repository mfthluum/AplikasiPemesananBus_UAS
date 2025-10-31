// FILE: Forms/PemesananForm.cs (Koreksi Lengkap)

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AplikasiPemesananBus_UAS.Models;
using AplikasiPemesananBus_UAS.Services;
using System.Linq;
using System.Globalization; // Tambahkan ini untuk penanganan format desimal

namespace AplikasiPemesananBus_UAS.Forms
{
    public partial class PemesananForm : Form
    {
        private PenumpangService penumpangService = new PenumpangService();
        private BusService busService = new BusService();
        private PemesananService pemesananService = new PemesananService();

        // Menyimpan list Bus yang diambil dari DB
        private List<BusModel> listBus = new List<BusModel>();

        public PemesananForm()
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.PemesananForm_Load);

            // Hubungkan semua event (Sudah benar)
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            this.btnKeluar.Click += new System.EventHandler(this.btnKeluar_Click);
            this.cmbBus.SelectedIndexChanged += new System.EventHandler(this.cmbBus_SelectedIndexChanged);

            // KOREKSI: Gunakan event TextChanged untuk kalkulasi
            this.txtJumlahTiket.TextChanged += new System.EventHandler(this.KalkulasiTotalTarif);
            this.txtRetribusi.TextChanged += new System.EventHandler(this.KalkulasiTotalTarif);

            // Memastikan input retribusi hanya angka (opsional: tambahkan event KeyPress)
            txtTarif.ReadOnly = true;
            txtTotalTarif.ReadOnly = true;

            ClearForm(); // Panggil ClearForm di awal
        }

        private void ClearForm()
        {
            // Atur ulang semua komponen input
            cmbPenumpang.SelectedIndex = -1;
            cmbBus.SelectedIndex = -1;
            txtJumlahTiket.Text = "1"; // Default 1 tiket
            txtRetribusi.Text = "0";
            txtTarif.Text = "0";
            txtTotalTarif.Text = "0";
        }

        private void LoadComboBoxData()
        {
            // 1. Ambil Data Bus
            listBus = busService.GetSemuaBus();

            // 2. Binding Penumpang
            var listPenumpang = penumpangService.GetSemuaPenumpang();
            cmbPenumpang.DataSource = listPenumpang;
            cmbPenumpang.DisplayMember = "Nama";
            cmbPenumpang.ValueMember = "PenumpangID";

            // 3. Binding Bus
            cmbBus.DataSource = listBus;
            cmbBus.DisplayMember = "NamaBus";
            cmbBus.ValueMember = "BusID";

            // KOREKSI: Tambahkan pengecekan data
            if (listPenumpang.Count == 0 || listBus.Count == 0)
            {
                MessageBox.Show("Data Bus atau Penumpang Kosong. Mohon input data master terlebih dahulu.", "Data Master Kosong", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnSubmit.Enabled = false;
            }
            else
            {
                btnSubmit.Enabled = true;
            }

            cmbPenumpang.SelectedIndex = -1;
            cmbBus.SelectedIndex = -1;
        }

        private void LoadDataTransaksi()
        {
            dgvDataTransaksi.DataSource = pemesananService.GetSemuaPemesanan();

            // Pengaturan DataGridView Transaksi
            if (dgvDataTransaksi.Columns.Contains("PemesananID"))
            {
                dgvDataTransaksi.Columns["PemesananID"].Visible = false;
            }
            if (dgvDataTransaksi.Columns.Contains("BusID"))
            {
                dgvDataTransaksi.Columns["BusID"].Visible = false;
            }
            if (dgvDataTransaksi.Columns.Contains("PenumpangID"))
            {
                dgvDataTransaksi.Columns["PenumpangID"].Visible = false;
            }
            // Tampilkan Nama Bus dan Nama Penumpang (dari JOIN di Service)
            dgvDataTransaksi.Columns["NamaBus"].HeaderText = "Nama Bus";
            dgvDataTransaksi.Columns["NamaPenumpang"].HeaderText = "Penumpang";
            dgvDataTransaksi.Columns["TotalBayar"].DefaultCellStyle.Format = "N0";
        }

        private void PemesananForm_Load(object? sender, EventArgs e)
        {
            LoadComboBoxData();
            LoadDataTransaksi();
        }

        private void cmbBus_SelectedIndexChanged(object? sender, EventArgs e)
        {
            // KOREKSI: Gunakan SelectedItem dan pengecekan null yang lebih aman
            if (cmbBus.SelectedItem is BusModel selectedBus)
            {
                // Tampilkan tarif dasar, gunakan format N0 untuk menghilangkan desimal
                txtTarif.Text = selectedBus.TarifBase.ToString("N0", CultureInfo.InvariantCulture);
                KalkulasiTotalTarif(null, null);
            }
            else
            {
                txtTarif.Text = "0";
                KalkulasiTotalTarif(null, null);
            }
        }

        // KOREKSI: Fungsi KalkulasiTotalTarif yang lebih robust
        private void KalkulasiTotalTarif(object? sender, EventArgs? e)
        {
            // Menggunakan fungsi TryParse dengan CultureInfo yang aman
            decimal.TryParse(txtTarif.Text.Replace(".", ""), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal tarifDasar);
            decimal.TryParse(txtRetribusi.Text.Replace(".", ""), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal retribusi);

            // Pastikan Jumlah Tiket adalah integer yang valid dan > 0
            if (!int.TryParse(txtJumlahTiket.Text, out int jumlahTiket) || jumlahTiket <= 0)
            {
                jumlahTiket = 0;
            }

            decimal totalBayar = (tarifDasar * jumlahTiket) + retribusi;

            // Tampilkan hasil total bayar dengan format N0
            txtTotalTarif.Text = totalBayar.ToString("N0", CultureInfo.InvariantCulture);
        }

        private void btnSubmit_Click(object? sender, EventArgs e)
        {
            // Validasi umum
            if (cmbPenumpang.SelectedValue == null || cmbBus.SelectedValue == null ||
                !int.TryParse(txtJumlahTiket.Text, out int jumlahTiket) || jumlahTiket <= 0)
            {
                MessageBox.Show("Mohon lengkapi data Penumpang, Bus, dan Jumlah Tiket (minimal 1).", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validasi dan Parsing nilai dari TextBox (sudah dilakukan di Kalkulasi, tinggal TryParse lagi)
            decimal.TryParse(txtTarif.Text.Replace(".", ""), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal tarifDasar);
            decimal.TryParse(txtRetribusi.Text.Replace(".", ""), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal retribusi);
            decimal.TryParse(txtTotalTarif.Text.Replace(".", ""), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal totalBayar);

            // Cek ketersediaan tiket (Logika opsional jika Anda memiliki pengecekan Kapasitas)
            // ... (Cek Kapasitas di sini jika diperlukan) ...

            var newPemesanan = new PemesananModel
            {
                // KOREKSI: Gunakan (int?)SelectedValue?.Value ?? 0 untuk penanganan null yang lebih aman
                PenumpangID = (int)cmbPenumpang.SelectedValue!,
                BusID = (int)cmbBus.SelectedValue!,
                TanggalPemesanan = DateTime.Now.Date,
                JumlahTiket = jumlahTiket,
                TarifDasar = tarifDasar,
                Retribusi = retribusi,
                TotalBayar = totalBayar
            };

            if (pemesananService.SimpanPemesanan(newPemesanan))
            {
                MessageBox.Show("Transaksi Pemesanan Tiket berhasil disimpan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearForm(); // Bersihkan Form
                LoadDataTransaksi();
            }
            else
            {
                MessageBox.Show("Gagal menyimpan transaksi. Cek koneksi atau foreign key (Bus/Penumpang) yang hilang.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKeluar_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
    }
}