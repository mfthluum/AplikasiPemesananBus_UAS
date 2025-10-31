// FILE: Forms/TransaksiRiwayatForm.cs (Code Final)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AplikasiPemesananBus_UAS.Models;
using AplikasiPemesananBus_UAS.Services;
using System.Globalization;

namespace AplikasiPemesananBus_UAS.Forms
{
    public partial class TransaksiRiwayatForm : Form
    {
        private PemesananService pemesananService = new PemesananService();

        public TransaksiRiwayatForm()
        {
            InitializeComponent();

            // Hubungkan event click secara manual untuk memastikan
            if (btnTampilkan != null)
                this.btnTampilkan.Click += new System.EventHandler(this.btnTampilkan_Click);
            if (btnKeluar != null)
                this.btnKeluar.Click += new System.EventHandler(this.btnKeluar_Click);

            // Tambahkan event Load jika belum ada di designer
            this.Load += new System.EventHandler(this.TransaksiRiwayatForm_Load);
        }

        private void TransaksiRiwayatForm_Load(object? sender, EventArgs e)
        {
            // Set default filter: 1 bulan terakhir
            if (dtpDariTanggal != null && dtpSampaiTanggal != null)
            {
                dtpDariTanggal.Value = DateTime.Now.AddDays(-30);
                dtpSampaiTanggal.Value = DateTime.Now;
            }
            TampilkanLaporan();
        }

        private void TampilkanLaporan()
        {
            // KRITIS: Null-Check ketat untuk mencegah NullReferenceException
            if (dtpDariTanggal == null || dtpSampaiTanggal == null || dgvLaporanTransaksi == null || lblTotalTransaksi == null)
            {
                MessageBox.Show("Komponen Form (DTP/DGV/Label) belum siap. Cek Designer.cs.", "Error Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime tglMulai = dtpDariTanggal.Value.Date;
            // Mencakup hingga detik terakhir hari yang dipilih
            DateTime tglAkhir = dtpSampaiTanggal.Value.Date.AddDays(1).AddSeconds(-1);

            if (tglMulai > tglAkhir)
            {
                MessageBox.Show("Tanggal Mulai tidak boleh lebih besar dari Tanggal Akhir.", "Validasi Tanggal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                List<PemesananModel> laporan = pemesananService.GetLaporanByTanggal(tglMulai, tglAkhir);

                dgvLaporanTransaksi.DataSource = laporan;

                // Hitung dan tampilkan total
                decimal totalBayarSemua = laporan.Sum(p => p.TotalBayar);
                lblTotalTransaksi.Text = $"Total Penerimaan: Rp. {totalBayarSemua.ToString("N0", CultureInfo.GetCultureInfo("id-ID"))}";

                // Pengaturan DGV
                if (dgvLaporanTransaksi.Columns.Count > 0)
                {
                    // Sembunyikan kolom ID dan kolom dasar yang tidak perlu
                    dgvLaporanTransaksi.Columns["PemesananID"].Visible = false;
                    dgvLaporanTransaksi.Columns["PenumpangID"].Visible = false;
                    dgvLaporanTransaksi.Columns["BusID"].Visible = false;
                    dgvLaporanTransaksi.Columns["TarifDasar"].Visible = false;
                    dgvLaporanTransaksi.Columns["Retribusi"].Visible = false;

                    // Format Tampilan
                    dgvLaporanTransaksi.Columns["TanggalPemesanan"].DefaultCellStyle.Format = "dd MMMM yyyy";
                    dgvLaporanTransaksi.Columns["TotalBayar"].DefaultCellStyle.Format = "N0";
                    dgvLaporanTransaksi.Columns["TotalBayar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                    dgvLaporanTransaksi.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                }
            }
            catch (Exception ex)
            {
                // Ini akan menangani error yang datang dari Service (koneksi/SQL)
                MessageBox.Show($"Error Form Laporan: {ex.Message}", "Kesalahan Aplikasi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTampilkan_Click(object? sender, EventArgs e)
        {
            TampilkanLaporan();
        }

        private void btnKeluar_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
    }
}