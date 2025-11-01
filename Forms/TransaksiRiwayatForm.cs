// FILE: Forms/TransaksiRiwayatForm.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AplikasiPemesananBus_UAS.Models;
using AplikasiPemesananBus_UAS.ServiceOrm;
using AplikasiPemesananBus_UAS.Data;
using System.Globalization;

namespace AplikasiPemesananBus_UAS.Forms
{
    public partial class TransaksiRiwayatForm : Form
    {
        private readonly PemesananService _pemesananService;

        public TransaksiRiwayatForm()
        {
            InitializeComponent();

            var context = new AppDbContext();
            _pemesananService = new PemesananService(context);

            // Pengaturan Event Handler (sesuai nama komponen Anda: btnTampilkan, btnKeluar)
            if (btnTampilkan != null)
                this.btnTampilkan.Click += new System.EventHandler(this.btnTampilkan_Click);
            if (btnKeluar != null)
                this.btnKeluar.Click += new System.EventHandler(this.btnKeluar_Click);

            this.Load += new System.EventHandler(this.TransaksiRiwayatForm_Load);
        }

        private void TransaksiRiwayatForm_Load(object? sender, EventArgs e)
        {
            // dtpDariTanggal dan dtpSampaiTanggal
            if (dtpDariTanggal != null && dtpSampaiTanggal != null)
            {
                dtpDariTanggal.Value = DateTime.Now.Date.AddDays(-30);
                dtpSampaiTanggal.Value = DateTime.Now.Date;
            }
            TampilkanLaporan();
        }

        private void TampilkanLaporan()
        {
            if (dtpDariTanggal == null || dtpSampaiTanggal == null || dgvLaporanTransaksi == null || lblTotalTransaksi == null)
            {
                MessageBox.Show("Komponen Form (DTP/DGV/Label) belum siap. Cek Designer.cs.", "Error Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DateTime tglMulaiLocal = dtpDariTanggal.Value.Date;
            DateTime tglAkhirLocal = dtpSampaiTanggal.Value.Date;

            if (tglMulaiLocal > tglAkhirLocal)
            {
                MessageBox.Show("Tanggal Mulai tidak boleh lebih besar dari Tanggal Akhir.", "Validasi Tanggal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // ** PERBAIKAN KRITIS UTC **
                DateTime tglMulaiUtc = tglMulaiLocal.ToUniversalTime();
                DateTime tglAkhirMaxLocal = tglAkhirLocal.AddDays(1).AddSeconds(-1);
                DateTime tglAkhirUtc = tglAkhirMaxLocal.ToUniversalTime();

                List<PemesananModel> laporan = _pemesananService.GetLaporanByTanggal(tglMulaiUtc, tglAkhirUtc);

                dgvLaporanTransaksi.DataSource = laporan;

                // Hitung dan Tampilkan Total (lblTotalTransaksi)
                decimal totalBayarSemua = laporan.Sum(p => p.TotalBayar);
                lblTotalTransaksi.Text = $"Total Penerimaan: Rp. {totalBayarSemua.ToString("N0", CultureInfo.GetCultureInfo("id-ID"))}";

                // Pengaturan Kolom DataGridView
                if (dgvLaporanTransaksi.Columns.Count > 0)
                {
                    // Sembunyikan semua kolom yang tidak perlu
                    foreach (DataGridViewColumn col in dgvLaporanTransaksi.Columns)
                    {
                        col.Visible = false;
                    }

                    // Tampilkan dan atur kolom yang dibutuhkan
                    if (dgvLaporanTransaksi.Columns.Contains("ID"))
                    {
                        dgvLaporanTransaksi.Columns["ID"].Visible = true;
                        dgvLaporanTransaksi.Columns["ID"].HeaderText = "PK ID";
                        dgvLaporanTransaksi.Columns["ID"].Width = 50;
                    }

                    if (dgvLaporanTransaksi.Columns.Contains("TanggalPemesanan"))
                    {
                        dgvLaporanTransaksi.Columns["TanggalPemesanan"].Visible = true;
                        dgvLaporanTransaksi.Columns["TanggalPemesanan"].HeaderText = "Tgl Transaksi";
                        dgvLaporanTransaksi.Columns["TanggalPemesanan"].DefaultCellStyle.Format = "dd MMMM yyyy";
                    }

                    if (dgvLaporanTransaksi.Columns.Contains("NamaPenumpang"))
                    {
                        dgvLaporanTransaksi.Columns["NamaPenumpang"].Visible = true;
                        dgvLaporanTransaksi.Columns["NamaPenumpang"].HeaderText = "Penumpang";
                    }

                    if (dgvLaporanTransaksi.Columns.Contains("NamaBus"))
                    {
                        dgvLaporanTransaksi.Columns["NamaBus"].Visible = true;
                        dgvLaporanTransaksi.Columns["NamaBus"].HeaderText = "Bus";
                    }

                    if (dgvLaporanTransaksi.Columns.Contains("JumlahTiket"))
                    {
                        dgvLaporanTransaksi.Columns["JumlahTiket"].Visible = true;
                        dgvLaporanTransaksi.Columns["JumlahTiket"].HeaderText = "Jml Tiket";
                        dgvLaporanTransaksi.Columns["JumlahTiket"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }

                    if (dgvLaporanTransaksi.Columns.Contains("TotalBayar"))
                    {
                        dgvLaporanTransaksi.Columns["TotalBayar"].Visible = true;
                        dgvLaporanTransaksi.Columns["TotalBayar"].HeaderText = "Total Bayar";
                        dgvLaporanTransaksi.Columns["TotalBayar"].DefaultCellStyle.Format = "N0";
                        dgvLaporanTransaksi.Columns["TotalBayar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }

                    // Sembunyikan Foreign Key dan Model Navigation
                    if (dgvLaporanTransaksi.Columns.Contains("PemesananID")) dgvLaporanTransaksi.Columns["PemesananID"].Visible = false;
                    if (dgvLaporanTransaksi.Columns.Contains("PenumpangID")) dgvLaporanTransaksi.Columns["PenumpangID"].Visible = false;
                    if (dgvLaporanTransaksi.Columns.Contains("BusID")) dgvLaporanTransaksi.Columns["BusID"].Visible = false;
                    if (dgvLaporanTransaksi.Columns.Contains("TarifDasar")) dgvLaporanTransaksi.Columns["TarifDasar"].Visible = false;
                    if (dgvLaporanTransaksi.Columns.Contains("Retribusi")) dgvLaporanTransaksi.Columns["Retribusi"].Visible = false;
                    if (dgvLaporanTransaksi.Columns.Contains("PenumpangModel")) dgvLaporanTransaksi.Columns["PenumpangModel"].Visible = false;
                    if (dgvLaporanTransaksi.Columns.Contains("BusModel")) dgvLaporanTransaksi.Columns["BusModel"].Visible = false;


                    dgvLaporanTransaksi.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
                }
            }
            catch (Exception ex)
            {
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