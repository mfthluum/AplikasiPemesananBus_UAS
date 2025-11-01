// FILE: Forms/InputPenumpangForm.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AplikasiPemesananBus_UAS.Models;
using AplikasiPemesananBus_UAS.ServiceOrm; // PENTING: Menggunakan Service ORM
using AplikasiPemesananBus_UAS.Data;
using System.Globalization;

namespace AplikasiPemesananBus_UAS.Forms
{
    public partial class InputPenumpangForm : Form
    {
        // Variabel untuk menyimpan ID yang sedang diedit
        private int IDPenumpangDipilih = 0;

        // Ganti deklarasi Service
        private readonly PenumpangService _penumpangService;

        public InputPenumpangForm()
        {
            InitializeComponent();

            // Inisialisasi Service menggunakan AppDbContext
            var context = new AppDbContext();
            _penumpangService = new PenumpangService(context);

            this.Load += new System.EventHandler(this.InputPenumpangForm_Load);
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            this.btnKeluar.Click += new System.EventHandler(this.btnKeluar_Click);
            this.dgvDataPenumpang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDataPenumpang_CellClick);

            // Set default
            ClearForm();
            btnEdit.Enabled = false;
            btnHapus.Enabled = false;
        }

        private void ClearForm()
        {
            IDPenumpangDipilih = 0;
            txtNama.Text = string.Empty;
            txtNomorHp.Text = string.Empty;
            txtEmail.Text = string.Empty;
            btnSimpan.Text = "Simpan";
            btnEdit.Enabled = false;
            btnHapus.Enabled = false;
            txtNama.Focus();
        }

        private void LoadDataPenumpang()
        {
            dgvDataPenumpang.DataSource = _penumpangService.GetSemuaPenumpang();

            // Format DataGridView
            if (dgvDataPenumpang.Columns.Count > 0)
            {
                // Kolom ID Generik (Primary Key EF Core)
                if (dgvDataPenumpang.Columns.Contains("ID"))
                {
                    dgvDataPenumpang.Columns["ID"].Visible = true;
                    dgvDataPenumpang.Columns["ID"].HeaderText = "PK ID";
                    dgvDataPenumpang.Columns["ID"].Width = 50;
                }

                // Sembunyikan kolom navigasi
                if (dgvDataPenumpang.Columns.Contains("Pemesanan")) dgvDataPenumpang.Columns["Pemesanan"].Visible = false;
            }
            ClearForm();
        }

        private void InputPenumpangForm_Load(object? sender, EventArgs e)
        {
            LoadDataPenumpang();
        }

        private void dgvDataPenumpang_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvDataPenumpang.Rows.Count > 0)
            {
                // Ambil ID Generik (Primary Key) dari DGV
                if (dgvDataPenumpang.Rows[e.RowIndex].Cells["ID"].Value is int penumpangID)
                {
                    IDPenumpangDipilih = penumpangID;
                    btnSimpan.Text = "Baru";
                    btnEdit.Enabled = true;
                    btnHapus.Enabled = true;

                    txtNama.Text = dgvDataPenumpang.Rows[e.RowIndex].Cells["Nama"].Value.ToString();
                    txtNomorHp.Text = dgvDataPenumpang.Rows[e.RowIndex].Cells["NomorHP"].Value.ToString();
                    txtEmail.Text = dgvDataPenumpang.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                }
            }
        }

        private async void btnSimpan_Click(object? sender, EventArgs e)
        {
            if (IDPenumpangDipilih != 0)
            {
                ClearForm();
                return;
            }

            if (!ValidasiInput()) return;

            var newPenumpang = CreatePenumpangModel();

            try
            {
                // Panggil method asinkron
                await _penumpangService.InsertPenumpang(newPenumpang);
                MessageBox.Show("Data Penumpang berhasil disimpan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataPenumpang();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal menyimpan data. Pastikan Nomor HP unik. Error: {ex.Message}", "Error DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnEdit_Click(object? sender, EventArgs e)
        {
            if (IDPenumpangDipilih == 0) return;

            if (!ValidasiInput()) return;

            var updatedPenumpang = CreatePenumpangModel();
            updatedPenumpang.ID = IDPenumpangDipilih;

            try
            {
                // Panggil method asinkron
                await _penumpangService.UpdatePenumpang(updatedPenumpang);
                MessageBox.Show("Data Penumpang berhasil diubah!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataPenumpang();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Gagal mengubah data. Pastikan Nomor HP unik. Error: {ex.Message}", "Error DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnHapus_Click(object? sender, EventArgs e)
        {
            if (IDPenumpangDipilih == 0) return;

            if (MessageBox.Show("Apakah Anda yakin ingin menghapus data Penumpang ini?", "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                try
                {
                    // Panggil method asinkron
                    await _penumpangService.DeletePenumpang(IDPenumpangDipilih);
                    MessageBox.Show("Data Penumpang berhasil dihapus!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDataPenumpang();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Gagal menghapus data. Penumpang ini mungkin sudah digunakan dalam transaksi. Error: {ex.Message}", "Error DB", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidasiInput()
        {
            if (string.IsNullOrWhiteSpace(txtNama.Text) || string.IsNullOrWhiteSpace(txtNomorHp.Text))
            {
                MessageBox.Show("Nama dan Nomor HP harus diisi.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private PenumpangModel CreatePenumpangModel()
        {
            return new PenumpangModel
            {
                Nama = txtNama.Text,
                NomorHP = txtNomorHp.Text,
                Email = txtEmail.Text
            };
        }

        private void btnKeluar_Click(object? sender, EventArgs e)
        {
            this.Close();
        }
    }
}