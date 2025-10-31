using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace AplikasiPemesananBus_UAS // PENTING: NAMESPACE UTAMA
{
    partial class HomeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            masterDataToolStripMenuItem = new ToolStripMenuItem();
            inputDataBusToolStripMenuItem = new ToolStripMenuItem();
            inputDataPenumpangToolStripMenuItem = new ToolStripMenuItem();
            transaksiToolStripMenuItem = new ToolStripMenuItem();
            pemesananTiketToolStripMenuItem = new ToolStripMenuItem();
            laporanToolStripMenuItem = new ToolStripMenuItem();
            riwayatTransaksiToolStripMenuItem = new ToolStripMenuItem();
            keluarToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { masterDataToolStripMenuItem, transaksiToolStripMenuItem, laporanToolStripMenuItem, keluarToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // masterDataToolStripMenuItem
            // 
            masterDataToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { inputDataBusToolStripMenuItem, inputDataPenumpangToolStripMenuItem });
            masterDataToolStripMenuItem.Name = "masterDataToolStripMenuItem";
            masterDataToolStripMenuItem.Size = new Size(82, 20);
            masterDataToolStripMenuItem.Text = "Master Data";
            // 
            // inputDataBusToolStripMenuItem
            // 
            inputDataBusToolStripMenuItem.Name = "inputDataBusToolStripMenuItem";
            inputDataBusToolStripMenuItem.Size = new Size(197, 22);
            inputDataBusToolStripMenuItem.Text = " Input Data Bus";
            inputDataBusToolStripMenuItem.Click += inputDataBusToolStripMenuItem_Click;
            // 
            // inputDataPenumpangToolStripMenuItem
            // 
            inputDataPenumpangToolStripMenuItem.Name = "inputDataPenumpangToolStripMenuItem";
            inputDataPenumpangToolStripMenuItem.Size = new Size(197, 22);
            inputDataPenumpangToolStripMenuItem.Text = "Input Data Penumpang";
            inputDataPenumpangToolStripMenuItem.Click += inputDataPenumpangToolStripMenuItem_Click;
            // 
            // transaksiToolStripMenuItem
            // 
            transaksiToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { pemesananTiketToolStripMenuItem });
            transaksiToolStripMenuItem.Name = "transaksiToolStripMenuItem";
            transaksiToolStripMenuItem.Size = new Size(66, 20);
            transaksiToolStripMenuItem.Text = "Transaksi";
            // 
            // pemesananTiketToolStripMenuItem
            // 
            pemesananTiketToolStripMenuItem.Name = "pemesananTiketToolStripMenuItem";
            pemesananTiketToolStripMenuItem.Size = new Size(163, 22);
            pemesananTiketToolStripMenuItem.Text = "Pemesanan Tiket";
            pemesananTiketToolStripMenuItem.Click += pemesananTiketToolStripMenuItem_Click;
            // 
            // laporanToolStripMenuItem
            // 
            laporanToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { riwayatTransaksiToolStripMenuItem });
            laporanToolStripMenuItem.Name = "laporanToolStripMenuItem";
            laporanToolStripMenuItem.Size = new Size(62, 20);
            laporanToolStripMenuItem.Text = "Laporan";
            // 
            // riwayatTransaksiToolStripMenuItem
            // 
            riwayatTransaksiToolStripMenuItem.Name = "riwayatTransaksiToolStripMenuItem";
            riwayatTransaksiToolStripMenuItem.Size = new Size(165, 22);
            riwayatTransaksiToolStripMenuItem.Text = "Riwayat Transaksi";
            riwayatTransaksiToolStripMenuItem.Click += riwayatTransaksiToolStripMenuItem_Click;
            // 
            // keluarToolStripMenuItem
            // 
            keluarToolStripMenuItem.Name = "keluarToolStripMenuItem";
            keluarToolStripMenuItem.Size = new Size(52, 20);
            keluarToolStripMenuItem.Text = "Keluar";
            keluarToolStripMenuItem.Click += keluarToolStripMenuItem_Click;
            // 
            // HomeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
            // PENTING: SETEL KE TRUE KARENA KITA AKAN PAKAI MDI PARENT
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "HomeForm";
            Text = "Form1";
            Load += HomeForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem masterDataToolStripMenuItem;
        private ToolStripMenuItem transaksiToolStripMenuItem;
        private ToolStripMenuItem laporanToolStripMenuItem;
        private ToolStripMenuItem keluarToolStripMenuItem;
        private ToolStripMenuItem inputDataBusToolStripMenuItem;
        private ToolStripMenuItem inputDataPenumpangToolStripMenuItem;
        private ToolStripMenuItem pemesananTiketToolStripMenuItem;
        private ToolStripMenuItem riwayatTransaksiToolStripMenuItem;
    }
}