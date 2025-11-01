// FILE: Forms/PemesananForm.cs (REVISI FINAL)

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AplikasiPemesananBus_UAS.Models;
using AplikasiPemesananBus_UAS.ServiceOrm;
using AplikasiPemesananBus_UAS.Data;
using System.Linq;
using System.Globalization;
using System.Threading.Tasks;

namespace AplikasiPemesananBus_UAS.Forms
{
    public partial class PemesananForm : Form
    {
        // Deklarasi Service ORM
        private readonly PenumpangService _penumpangService;
        private readonly BusService _busService;
        private readonly PemesananService _pemesananService;

        // List model untuk DataBinding
        // private List<BusModel> _listBus = new List<BusModel>(); // Tidak perlu jika menggunakan GetDropdown
        // private List<PenumpangModel> _listPenumpang = new List<PenumpangModel>(); // Tidak perlu jika menggunakan GetDropdown

        // Asumsi properti lain yang mungkin Anda miliki, misalnya:
        // private int IDPemesananDipilih = 0; 

        public PemesananForm()
        {
            InitializeComponent();

            // INISIALISASI SERVICE EF CORE
            var context = new AppDbContext();
            _penumpangService = new PenumpangService(context);
            _busService = new BusService(context);
            _pemesananService = new PemesananService(context);

            this.Load += new System.EventHandler(this.PemesananForm_Load);

            // Event Handler Sesuai Code Lama Anda
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            this.btnKeluar.Click += new System.EventHandler(this.btnKeluar_Click);
            this.cmbBus.SelectedIndexChanged += new System.EventHandler(this.cmbBus_SelectedIndexChanged);
            this.txtJumlahTiket.TextChanged += new System.EventHandler(this.KalkulasiTotalTarif);
            this.txtRetribusi.TextChanged += new System.EventHandler(this.KalkulasiTotalTarif); // Asumsi ini ada

            txtTarif.ReadOnly = true;
            txtTotalTarif.ReadOnly = true;

            ClearForm();
        }

        private void ClearForm()
        {
            cmbPenumpang.SelectedIndex = -1;
            cmbBus.SelectedIndex = -1;
            txtJumlahTiket.Text = "1";
            txtRetribusi.Text = "0";
            txtTarif.Text = "0";
            txtTotalTarif.Text = "0";

            // IDPemesananDipilih = 0; 
        }

        // PENTING: Dibuat synchronous (tanpa async/await) untuk mengatasi Error CS1061 di Load
        private void LoadComboBoxData()
        {
            try
            {
                // Asumsi GetDropdown adalah synchronous (List<T>)
                cmbPenumpang.DataSource = _penumpangService.GetDropdown();
                cmbPenumpang.DisplayMember = "DisplayName";
                cmbPenumpang.ValueMember = "ID";

                // Asumsi GetDropdown adalah synchronous (List<T>)
                cmbBus.DataSource = _busService.GetDropdown();
                cmbBus.DisplayMember = "DisplayName";
                cmbBus.ValueMember = "ID";

                if (cmbPenumpang.Items.Count == 0 || cmbBus.Items.Count == 0)
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
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal memuat data ComboBox: {ex.Message}", "Error Data", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSubmit.Enabled = false;
            }
        }

        private void LoadDataTransaksi()
        {
            // PENTING: Menggunakan GetSemuaPemesanan() yang sudah diperbarui di Service (synchronous)
            dgvDataTransaksi.DataSource = _pemesananService.GetSemuaPemesanan();

            // KOREKSI PENGATURAN KOLOM DGV (code Anda)
            if (dgvDataTransaksi.Columns.Count > 0)
            {
                // Sembunyikan kolom yang tidak perlu
                foreach (DataGridViewColumn col in dgvDataTransaksi.Columns)
                {
                    col.Visible = false;
                }

                // Tampilkan dan Atur Kolom (sesuai code Anda)
                if (dgvDataTransaksi.Columns.Contains("ID"))
                {
                    dgvDataTransaksi.Columns["ID"].Visible = true;
                    dgvDataTransaksi.Columns["ID"].HeaderText = "PK ID";
                    dgvDataTransaksi.Columns["ID"].Width = 50;
                }

                if (dgvDataTransaksi.Columns.Contains("NamaBus")) dgvDataTransaksi.Columns["NamaBus"].Visible = true;
                if (dgvDataTransaksi.Columns.Contains("NamaBus")) dgvDataTransaksi.Columns["NamaBus"].HeaderText = "Nama Bus";

                if (dgvDataTransaksi.Columns.Contains("NamaPenumpang")) dgvDataTransaksi.Columns["NamaPenumpang"].Visible = true;
                if (dgvDataTransaksi.Columns.Contains("NamaPenumpang")) dgvDataTransaksi.Columns["NamaPenumpang"].HeaderText = "Penumpang";

                if (dgvDataTransaksi.Columns.Contains("TanggalPemesanan")) dgvDataTransaksi.Columns["TanggalPemesanan"].Visible = true;
                if (dgvDataTransaksi.Columns.Contains("TanggalPemesanan")) dgvDataTransaksi.Columns["TanggalPemesanan"].HeaderText = "Tanggal";

                if (dgvDataTransaksi.Columns.Contains("JumlahTiket")) dgvDataTransaksi.Columns["JumlahTiket"].Visible = true;
                if (dgvDataTransaksi.Columns.Contains("JumlahTiket")) dgvDataTransaksi.Columns["JumlahTiket"].HeaderText = "Jml Tiket";

                if (dgvDataTransaksi.Columns.Contains("TotalBayar"))
                {
                    dgvDataTransaksi.Columns["TotalBayar"].Visible = true;
                    dgvDataTransaksi.Columns["TotalBayar"].HeaderText = "Total Bayar";
                    dgvDataTransaksi.Columns["TotalBayar"].DefaultCellStyle.Format = "N0";
                    dgvDataTransaksi.Columns["TotalBayar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                dgvDataTransaksi.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
        }

        private void PemesananForm_Load(object? sender, EventArgs e)
        {
            LoadComboBoxData();
            LoadDataTransaksi();
        }

        private void cmbBus_SelectedIndexChanged(object? sender, EventArgs e)
        {
            // Pastikan SelectedValue adalah int (ID Generik)
            if (cmbBus.SelectedValue != null && cmbBus.SelectedValue is int busID)
            {
                try
                {
                    // Panggilan FindByID (Asumsi synchronous)
                    var selectedBus = _busService.FindByID(busID);

                    if (selectedBus != null)
                    {
                        // PENTING: Menggunakan TarifBase
                        txtTarif.Text = selectedBus.TarifBase.ToString("N0", CultureInfo.InvariantCulture);
                        KalkulasiTotalTarif(null, null);
                    }
                    else
                    {
                        txtTarif.Text = "0";
                        KalkulasiTotalTarif(null, null);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error mencari data Bus: {ex.Message}", "Error DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTarif.Text = "0";
                }
            }
            else
            {
                txtTarif.Text = "0";
                KalkulasiTotalTarif(null, null);
            }
        }

        private void KalkulasiTotalTarif(object? sender, EventArgs? e)
        {
            decimal.TryParse(txtTarif.Text.Replace(".", ""), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal tarifDasar);
            decimal.TryParse(txtRetribusi.Text.Replace(".", ""), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal retribusi);

            if (!int.TryParse(txtJumlahTiket.Text, out int jumlahTiket) || jumlahTiket <= 0)
            {
                jumlahTiket = 0;
            }

            decimal totalBayar = (tarifDasar * jumlahTiket) + retribusi;

            txtTotalTarif.Text = totalBayar.ToString("N0", CultureInfo.InvariantCulture);
        }

        private async void btnSubmit_Click(object? sender, EventArgs e)
        {
            if (cmbPenumpang.SelectedValue == null || cmbBus.SelectedValue == null ||
             !int.TryParse(txtJumlahTiket.Text, out int jumlahTiket) || jumlahTiket <= 0)
            {
                MessageBox.Show("Mohon lengkapi data Penumpang, Bus, dan Jumlah Tiket (minimal 1).", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal.TryParse(txtTotalTarif.Text.Replace(".", ""), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal totalBayar);

            int selectedBusID = (int)cmbBus.SelectedValue!;
            int selectedPenumpangID = (int)cmbPenumpang.SelectedValue!;

            var selectedBus = _busService.FindByID(selectedBusID);

            if (selectedBus == null)
            {
                MessageBox.Show("Data Bus tidak ditemukan saat menyimpan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            decimal.TryParse(txtRetribusi.Text.Replace(".", ""), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal retribusiValue);


            var newPemesanan = new PemesananModel
            {
                PenumpangID = selectedPenumpangID,
                BusID = selectedBusID,

                // FIX TIME ZONE CRITICAL: Mengubah DateTime.Now (Local) ke UTC
                TanggalPemesanan = DateTime.Now.ToUniversalTime(), // <--- PERBAIKAN UTAMA

                JumlahTiket = jumlahTiket,
                TotalBayar = totalBayar,

                // PENTING: Menggunakan TarifBase
                TarifDasar = selectedBus.TarifBase,
                Retribusi = retribusiValue
            };

            try
            {
                await _pemesananService.InsertPemesanan(newPemesanan);
                MessageBox.Show("Transaksi Pemesanan Tiket berhasil disimpan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearForm();
                LoadDataTransaksi();
            }
            catch (Exception ex)
            {
                string innerExceptionMessage = (ex.InnerException != null) ? ex.InnerException.Message : "Tidak ada detail inner exception.";

                MessageBox.Show($"Gagal menyimpan transaksi. Error: {ex.Message}\nDetail: {innerExceptionMessage}", "Error DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnKeluar_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
    }
}