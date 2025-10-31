namespace AplikasiPemesananBus_UAS.Forms
{
    partial class TransaksiRiwayatForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            dtpDariTanggal = new DateTimePicker();
            btnTampilkan = new Button();
            dgvLaporanTransaksi = new DataGridView();
            lblTotalTransaksi = new Label();
            btnKeluar = new Button();
            dtpSampaiTanggal = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)dgvLaporanTransaksi).BeginInit();
            SuspendLayout();
            // 
            // dtpSampaiTanggal
            // 
            dtpSampaiTanggal.Location = new Point(351, 117);
            dtpSampaiTanggal.Name = "dtpSampaiTanggal";
            dtpSampaiTanggal.Size = new Size(200, 23);
            dtpSampaiTanggal.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(351, 31);
            label1.Name = "label1";
            label1.Size = new Size(219, 32);
            label1.TabIndex = 0;
            label1.Text = "Laporan Transaksi";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(236, 83);
            label2.Name = "label2";
            label2.Size = new Size(72, 15);
            label2.TabIndex = 1;
            label2.Text = "Dari Tanggal";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(236, 125);
            label3.Name = "label3";
            label3.Size = new Size(90, 15);
            label3.TabIndex = 2;
            label3.Text = "Sampai Tanggal";
            // 
            // dtpDariTanggal
            // 
            dtpDariTanggal.Location = new Point(351, 75);
            dtpDariTanggal.Name = "dtpDariTanggal";
            dtpDariTanggal.Size = new Size(200, 23);
            dtpDariTanggal.TabIndex = 3;
            // 
            // btnTampilkan
            // 
            btnTampilkan.Location = new Point(333, 174);
            btnTampilkan.Name = "btnTampilkan";
            btnTampilkan.Size = new Size(75, 23);
            btnTampilkan.TabIndex = 5;
            btnTampilkan.Text = "Tampilkan";
            btnTampilkan.UseVisualStyleBackColor = true;
            // 
            // dgvLaporanTransaksi
            // 
            dgvLaporanTransaksi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLaporanTransaksi.Location = new Point(218, 219);
            dgvLaporanTransaksi.Name = "dgvLaporanTransaksi";
            dgvLaporanTransaksi.Size = new Size(322, 150);
            dgvLaporanTransaksi.TabIndex = 6;
            // 
            // lblTotalTransaksi
            // 
            lblTotalTransaksi.AutoSize = true;
            lblTotalTransaksi.Location = new Point(218, 384);
            lblTotalTransaksi.Name = "lblTotalTransaksi";
            lblTotalTransaksi.Size = new Size(32, 15);
            lblTotalTransaksi.TabIndex = 7;
            lblTotalTransaksi.Text = "Total";
            // 
            // btnKeluar
            // 
            btnKeluar.Location = new Point(333, 415);
            btnKeluar.Name = "btnKeluar";
            btnKeluar.Size = new Size(75, 23);
            btnKeluar.TabIndex = 8;
            btnKeluar.Text = "Keluar";
            btnKeluar.UseVisualStyleBackColor = true;
            // 
            // TransaksiRiwayatForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnKeluar);
            Controls.Add(lblTotalTransaksi);
            Controls.Add(dgvLaporanTransaksi);
            Controls.Add(btnTampilkan);
            Controls.Add(dtpSampaiTanggal);
            Controls.Add(dtpDariTanggal);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "TransaksiRiwayatForm";
            Text = "TransaksiRiwayatForm";
            Load += TransaksiRiwayatForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvLaporanTransaksi).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private DateTimePicker dtpDariTanggal;
        private DateTimePicker dtpSampaiTanggal;
        private Button btnTampilkan;
        private DataGridView dgvLaporanTransaksi;
        private Label lblTotalTransaksi;
        private Button btnKeluar;
    }
}