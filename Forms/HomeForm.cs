using System;
using System.Windows.Forms;
using AplikasiPemesananBus_UAS.Forms; // Ini tetap diperlukan untuk mengakses form lain

// NAMESPACE HARUS SAMA DENGAN DESIGNER.CS ANDA
namespace AplikasiPemesananBus_UAS
{
    public partial class HomeForm : Form
    {
        // 1. DEKLARASI INSTANCE (Tingkat Class)
        private Forms.InputBusForm? inputBusFormInstance;
        private Forms.InputPenumpangForm? inputPenumpangFormInstance;
        private Forms.PemesananForm? pemesananFormInstance;
        private Forms.TransaksiRiwayatForm? riwayatFormInstance;

        public HomeForm()
        {
            InitializeComponent();
            // Opsional: Untuk memastikan HomeForm tidak bertindak sebagai MDI Parent
            this.IsMdiContainer = false;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        // --- MASTER DATA ---

        private void inputDataBusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (inputBusFormInstance == null || inputBusFormInstance.IsDisposed)
            {
                inputBusFormInstance = new Forms.InputBusForm();
                inputBusFormInstance.FormClosed += (s, args) => inputBusFormInstance = null;
                // BARIS MDI PARENT DIHAPUS, FORM AKAN MUNCUL MANDIRI
                inputBusFormInstance.Show();
            }
            else
            {
                inputBusFormInstance.BringToFront();
                inputBusFormInstance.Activate();
            }
        }

        private void inputDataPenumpangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (inputPenumpangFormInstance == null || inputPenumpangFormInstance.IsDisposed)
            {
                inputPenumpangFormInstance = new Forms.InputPenumpangForm();
                inputPenumpangFormInstance.FormClosed += (s, args) => inputPenumpangFormInstance = null;
                // BARIS MDI PARENT DIHAPUS
                inputPenumpangFormInstance.Show();
            }
            else
            {
                inputPenumpangFormInstance.BringToFront();
                inputPenumpangFormInstance.Activate();
            }
        }

        // --- TRANSAKSI ---

        private void pemesananTiketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pemesananFormInstance == null || pemesananFormInstance.IsDisposed)
            {
                pemesananFormInstance = new Forms.PemesananForm();
                pemesananFormInstance.FormClosed += (s, args) => pemesananFormInstance = null;
                // BARIS MDI PARENT DIHAPUS
                pemesananFormInstance.Show();
            }
            else
            {
                pemesananFormInstance.BringToFront();
                pemesananFormInstance.Activate();
            }
        }

        // --- LAPORAN ---

        private void riwayatTransaksiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (riwayatFormInstance == null || riwayatFormInstance.IsDisposed)
            {
                riwayatFormInstance = new Forms.TransaksiRiwayatForm();
                riwayatFormInstance.FormClosed += (s, args) => riwayatFormInstance = null;
                // BARIS MDI PARENT DIHAPUS
                riwayatFormInstance.Show();
            }
            else
            {
                riwayatFormInstance.BringToFront();
                riwayatFormInstance.Activate();
            }
        }

        // --- KELUAR ---
        private void keluarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void HomeForm_Load(object sender, EventArgs e)
        {
            // Event ini dipanggil saat form utama dimuat
        }
    }
}