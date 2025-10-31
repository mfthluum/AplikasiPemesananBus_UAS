// FILE: Forms/InputPenumpangForm.cs (Koreksi Lengkap)

using System;
using System.Windows.Forms;
using AplikasiPemesananBus_UAS.Models;
using AplikasiPemesananBus_UAS.Services;

namespace AplikasiPemesananBus_UAS.Forms
{
    public partial class InputPenumpangForm : Form
    {
        private PenumpangService service = new PenumpangService();
        private int selectedPenumpangId = 0;

        public InputPenumpangForm()
        {
            InitializeComponent();

            // Panggil LoadData saat form pertama kali dimuat
            this.Load += (s, e) => LoadData();

            // Hubungkan semua event (Sudah benar)
            this.btnSimpan.Click += new System.EventHandler(this.btnSimpan_Click);
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            this.btnKeluar.Click += new System.EventHandler(this.btnKeluar_Click);

            // ASUMSI: DataGridView Anda bernama dgvDataPenumpang
            this.dgvDataPenumpang.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDataPenumpang_CellClick);
        }

        private void LoadData()
        {
            // Panggil Service (Memastikan menggunakan GetSemuaPenumpang() yang sudah dikoreksi)
            dgvDataPenumpang.DataSource = service.GetSemuaPenumpang();

            // Pengaturan DataGridView
            if (dgvDataPenumpang.Columns.Contains("PenumpangID"))
            {
                dgvDataPenumpang.Columns["PenumpangID"].Visible = false;
            }
            if (dgvDataPenumpang.Columns.Contains("NomorHP"))
            {
                dgvDataPenumpang.Columns["NomorHP"].HeaderText = "Nomor HP";
            }
            if (dgvDataPenumpang.Columns.Contains("Nama"))
            {
                dgvDataPenumpang.Columns["Nama"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            ClearForm();
            btnEdit.Enabled = false; // Nonaktifkan Edit/Hapus saat awal load
            btnHapus.Enabled = false;
        }

        private void ClearForm()
        {
            txtNama.Clear();
            txtNomorHp.Clear();
            txtEmail.Clear();
            selectedPenumpangId = 0;
            btnSimpan.Enabled = true;
            btnEdit.Enabled = false;
            btnHapus.Enabled = false;
        }

        // PERBAIKAN: Menambahkan '?' pada object sender
        private void dgvDataPenumpang_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dgvDataPenumpang.Rows.Count - 1) // Tambah cek agar tidak klik baris kosong
            {
                DataGridViewRow row = this.dgvDataPenumpang.Rows[e.RowIndex];

                // Pengecekan DBNull untuk Email
                object emailValue = row.Cells["Email"].Value;
                string emailText = (emailValue == null || emailValue == DBNull.Value) ? string.Empty : emailValue.ToString();

                selectedPenumpangId = (int)row.Cells["PenumpangID"].Value;
                txtNama.Text = row.Cells["Nama"].Value.ToString();
                txtNomorHp.Text = row.Cells["NomorHP"].Value.ToString();
                txtEmail.Text = emailText; // Gunakan hasil pengecekan DBNull

                btnSimpan.Enabled = false; // Nonaktifkan simpan
                btnEdit.Enabled = true;   // Aktifkan edit
                btnHapus.Enabled = true;  // Aktifkan hapus
            }
        }

        private void btnSimpan_Click(object? sender, EventArgs e)
        {
            // KOREKSI VALIDASI: Nama dan Nomor HP WAJIB diisi
            if (string.IsNullOrWhiteSpace(txtNama.Text) || string.IsNullOrWhiteSpace(txtNomorHp.Text))
            {
                MessageBox.Show("Nama dan Nomor HP wajib diisi.", "Validasi Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Mengganti string kosong menjadi null jika kolom di DB mengizinkan NULL
            string email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text;

            var newPenumpang = new PenumpangModel
            {
                Nama = txtNama.Text,
                NomorHP = txtNomorHp.Text,
                Email = email
            };

            if (service.SimpanPenumpang(newPenumpang))
            {
                MessageBox.Show("Data Penumpang berhasil disimpan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            else
            {
                MessageBox.Show("Gagal menyimpan data penumpang. Cek koneksi atau kemungkinan Nomor HP sudah terdaftar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object? sender, EventArgs e)
        {
            if (selectedPenumpangId == 0) return;

            // KOREKSI VALIDASI: Nama dan Nomor HP WAJIB diisi
            if (string.IsNullOrWhiteSpace(txtNama.Text) || string.IsNullOrWhiteSpace(txtNomorHp.Text))
            {
                MessageBox.Show("Nama dan Nomor HP wajib diisi.", "Validasi Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Mengganti string kosong menjadi null
            string email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text;

            var updatedPenumpang = new PenumpangModel
            {
                PenumpangID = selectedPenumpangId,
                Nama = txtNama.Text,
                NomorHP = txtNomorHp.Text,
                Email = email
            };

            if (service.UpdatePenumpang(updatedPenumpang))
            {
                MessageBox.Show("Data Penumpang berhasil diubah!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            else
            {
                MessageBox.Show("Gagal mengubah data penumpang. Cek koneksi atau kemungkinan Nomor HP sudah terdaftar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHapus_Click(object? sender, EventArgs e)
        {
            if (selectedPenumpangId == 0) return;

            DialogResult result = MessageBox.Show($"Yakin ingin menghapus data penumpang '{txtNama.Text}'?",
                                                "Konfirmasi Hapus",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (service.HapusPenumpang(selectedPenumpangId))
                {
                    MessageBox.Show("Data Penumpang berhasil dihapus!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                else
                {
                    // Penumpang mungkin memiliki Pemesanan yang terkait
                    MessageBox.Show("Gagal menghapus data. Penumpang mungkin memiliki riwayat pemesanan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnKeluar_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void InputPenumpangForm_Load(object sender, EventArgs e)
        {
            // Tidak perlu ada kode di sini, semua logic sudah di constructor dan LoadData
        }
    }
}