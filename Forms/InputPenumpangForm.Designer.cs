namespace AplikasiPemesananBus_UAS.Forms
{
    partial class InputPenumpangForm
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
            btnSimpan = new Button();
            btnHapus = new Button();
            btnEdit = new Button();
            btnKeluar = new Button();
            txtNama = new TextBox();
            txtNomorHp = new TextBox();
            txtEmail = new TextBox();
            dgvDataPenumpang = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvDataPenumpang).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(285, 52);
            label1.Name = "label1";
            label1.Size = new Size(280, 32);
            label1.TabIndex = 0;
            label1.Text = "Input Data Penumpang";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(299, 118);
            label2.Name = "label2";
            label2.Size = new Size(87, 15);
            label2.TabIndex = 1;
            label2.Text = "Nama Lengkap";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(299, 175);
            label3.Name = "label3";
            label3.Size = new Size(64, 15);
            label3.TabIndex = 2;
            label3.Text = "Nomor Hp";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(299, 233);
            label4.Name = "label4";
            label4.Size = new Size(36, 15);
            label4.TabIndex = 3;
            label4.Text = "Email";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(150, 301);
            label5.Name = "label5";
            label5.Size = new Size(0, 15);
            label5.TabIndex = 4;
            // 
            // btnSimpan
            // 
            btnSimpan.Location = new Point(216, 289);
            btnSimpan.Name = "btnSimpan";
            btnSimpan.Size = new Size(75, 23);
            btnSimpan.TabIndex = 5;
            btnSimpan.Text = "Simpan";
            btnSimpan.UseVisualStyleBackColor = true;
            // 
            // btnHapus
            // 
            btnHapus.Location = new Point(320, 289);
            btnHapus.Name = "btnHapus";
            btnHapus.Size = new Size(75, 23);
            btnHapus.TabIndex = 6;
            btnHapus.Text = "Hapus";
            btnHapus.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(419, 289);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(75, 23);
            btnEdit.TabIndex = 7;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnKeluar
            // 
            btnKeluar.Location = new Point(531, 289);
            btnKeluar.Name = "btnKeluar";
            btnKeluar.Size = new Size(75, 23);
            btnKeluar.TabIndex = 8;
            btnKeluar.Text = "Keluar";
            btnKeluar.UseVisualStyleBackColor = true;
            // 
            // txtNama
            // 
            txtNama.Location = new Point(394, 110);
            txtNama.Name = "txtNama";
            txtNama.Size = new Size(100, 23);
            txtNama.TabIndex = 9;
            // 
            // txtNomorHp
            // 
            txtNomorHp.Location = new Point(394, 167);
            txtNomorHp.Name = "txtNomorHp";
            txtNomorHp.Size = new Size(100, 23);
            txtNomorHp.TabIndex = 10;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(394, 225);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(100, 23);
            txtEmail.TabIndex = 11;
            // 
            // dgvDataPenumpang
            // 
            dgvDataPenumpang.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDataPenumpang.Location = new Point(216, 326);
            dgvDataPenumpang.Name = "dgvDataPenumpang";
            dgvDataPenumpang.Size = new Size(390, 112);
            dgvDataPenumpang.TabIndex = 12;
            // 
            // InputPenumpangForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvDataPenumpang);
            Controls.Add(txtEmail);
            Controls.Add(txtNomorHp);
            Controls.Add(txtNama);
            Controls.Add(btnKeluar);
            Controls.Add(btnEdit);
            Controls.Add(btnHapus);
            Controls.Add(btnSimpan);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "InputPenumpangForm";
            Text = "InputPenumpangForm";
            Load += InputPenumpangForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDataPenumpang).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button btnSimpan;
        private Button btnHapus;
        private Button btnEdit;
        private Button btnKeluar;
        private TextBox txtNama;
        private TextBox txtNomorHp;
        private TextBox txtEmail;
        private DataGridView dgvDataPenumpang;
    }
}