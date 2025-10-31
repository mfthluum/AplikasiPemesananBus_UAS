namespace AplikasiPemesananBus_UAS.Forms
{
    partial class PemesananForm
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
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtRetribusi = new TextBox();
            txtTotalTarif = new TextBox();
            txtTarif = new TextBox();
            cmbPenumpang = new ComboBox();
            cmbBus = new ComboBox();
            label7 = new Label();
            txtJumlahTiket = new TextBox();
            btnSubmit = new Button();
            btnKeluar = new Button();
            dgvDataTransaksi = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvDataTransaksi).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(323, 42);
            label1.Name = "label1";
            label1.Size = new Size(206, 32);
            label1.TabIndex = 1;
            label1.Text = "Pemesanan Tiket";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(238, 110);
            label2.Name = "label2";
            label2.Size = new Size(72, 15);
            label2.TabIndex = 2;
            label2.Text = "Penumpang";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(238, 146);
            label3.Name = "label3";
            label3.Size = new Size(26, 15);
            label3.TabIndex = 3;
            label3.Text = "Bus";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(238, 188);
            label4.Name = "label4";
            label4.Size = new Size(29, 15);
            label4.TabIndex = 4;
            label4.Text = "Tarif";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(238, 262);
            label5.Name = "label5";
            label5.Size = new Size(53, 15);
            label5.TabIndex = 5;
            label5.Text = "Retribusi";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(238, 299);
            label6.Name = "label6";
            label6.Size = new Size(57, 15);
            label6.TabIndex = 6;
            label6.Text = "Total Tarif";
            // 
            // txtRetribusi
            // 
            txtRetribusi.Location = new Point(357, 254);
            txtRetribusi.Name = "txtRetribusi";
            txtRetribusi.Size = new Size(121, 23);
            txtRetribusi.TabIndex = 7;
            // 
            // txtTotalTarif
            // 
            txtTotalTarif.Location = new Point(357, 291);
            txtTotalTarif.Name = "txtTotalTarif";
            txtTotalTarif.Size = new Size(121, 23);
            txtTotalTarif.TabIndex = 8;
            // 
            // txtTarif
            // 
            txtTarif.Location = new Point(357, 180);
            txtTarif.Name = "txtTarif";
            txtTarif.Size = new Size(121, 23);
            txtTarif.TabIndex = 9;
            // 
            // cmbPenumpang
            // 
            cmbPenumpang.FormattingEnabled = true;
            cmbPenumpang.Location = new Point(357, 106);
            cmbPenumpang.Name = "cmbPenumpang";
            cmbPenumpang.Size = new Size(121, 23);
            cmbPenumpang.TabIndex = 10;
            // 
            // cmbBus
            // 
            cmbBus.FormattingEnabled = true;
            cmbBus.Location = new Point(357, 143);
            cmbBus.Name = "cmbBus";
            cmbBus.Size = new Size(121, 23);
            cmbBus.TabIndex = 11;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(238, 220);
            label7.Name = "label7";
            label7.Size = new Size(73, 15);
            label7.TabIndex = 12;
            label7.Text = "Jumlah Tiket";
            // 
            // txtJumlahTiket
            // 
            txtJumlahTiket.Location = new Point(357, 212);
            txtJumlahTiket.Name = "txtJumlahTiket";
            txtJumlahTiket.Size = new Size(121, 23);
            txtJumlahTiket.TabIndex = 13;
            // 
            // btnSubmit
            // 
            btnSubmit.Location = new Point(243, 341);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(75, 23);
            btnSubmit.TabIndex = 14;
            btnSubmit.Text = "Submit";
            btnSubmit.UseVisualStyleBackColor = true;
            // 
            // btnKeluar
            // 
            btnKeluar.Location = new Point(357, 341);
            btnKeluar.Name = "btnKeluar";
            btnKeluar.Size = new Size(75, 23);
            btnKeluar.TabIndex = 15;
            btnKeluar.Text = "Keluar";
            btnKeluar.UseVisualStyleBackColor = true;
            // 
            // dgvDataTransaksi
            // 
            dgvDataTransaksi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDataTransaksi.Location = new Point(519, 98);
            dgvDataTransaksi.Name = "dgvDataTransaksi";
            dgvDataTransaksi.Size = new Size(240, 216);
            dgvDataTransaksi.TabIndex = 16;
            // 
            // PemesananForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvDataTransaksi);
            Controls.Add(btnKeluar);
            Controls.Add(btnSubmit);
            Controls.Add(txtJumlahTiket);
            Controls.Add(label7);
            Controls.Add(cmbBus);
            Controls.Add(cmbPenumpang);
            Controls.Add(txtTarif);
            Controls.Add(txtTotalTarif);
            Controls.Add(txtRetribusi);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "PemesananForm";
            Text = "PemesananForm";
            Load += PemesananForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDataTransaksi).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txtRetribusi;
        private TextBox txtTotalTarif;
        private TextBox txtTarif;
        private ComboBox cmbPenumpang;
        private ComboBox cmbBus;
        private Label label7;
        private TextBox txtJumlahTiket;
        private Button btnSubmit;
        private Button btnKeluar;
        private DataGridView dgvDataTransaksi;
    }
}