namespace AplikasiPemesananBus_UAS.Forms
{
    partial class InputBusForm
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
            btnSimpan = new Button();
            btnEdit = new Button();
            btnKeluar = new Button();
            dgvDataBus = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtNomorPlat = new TextBox();
            txtNamaBus = new TextBox();
            txtKapasitas = new TextBox();
            txtTarifDasar = new TextBox();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvDataBus).BeginInit();
            SuspendLayout();
            // 
            // btnSimpan
            // 
            btnSimpan.Location = new Point(196, 222);
            btnSimpan.Name = "btnSimpan";
            btnSimpan.Size = new Size(75, 23);
            btnSimpan.TabIndex = 1;
            btnSimpan.Text = "Simpan";
            btnSimpan.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(315, 222);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(75, 23);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnKeluar
            // 
            btnKeluar.Location = new Point(474, 222);
            btnKeluar.Name = "btnKeluar";
            btnKeluar.Size = new Size(75, 23);
            btnKeluar.TabIndex = 3;
            btnKeluar.Text = "Keluar";
            btnKeluar.UseVisualStyleBackColor = true;
            // 
            // dgvDataBus
            // 
            dgvDataBus.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDataBus.Location = new Point(196, 273);
            dgvDataBus.Name = "dgvDataBus";
            dgvDataBus.Size = new Size(353, 150);
            dgvDataBus.TabIndex = 4;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(156, 115);
            label1.Name = "label1";
            label1.Size = new Size(68, 15);
            label1.TabIndex = 5;
            label1.Text = "Nomor Plat";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(163, 177);
            label2.Name = "label2";
            label2.Size = new Size(61, 15);
            label2.TabIndex = 6;
            label2.Text = "Nama Bus";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(389, 169);
            label3.Name = "label3";
            label3.Size = new Size(61, 15);
            label3.TabIndex = 7;
            label3.Text = "Tarif Dasar";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(389, 115);
            label4.Name = "label4";
            label4.Size = new Size(56, 15);
            label4.TabIndex = 8;
            label4.Text = "Kapasitas";
            // 
            // txtNomorPlat
            // 
            txtNomorPlat.Location = new Point(254, 107);
            txtNomorPlat.Name = "txtNomorPlat";
            txtNomorPlat.Size = new Size(100, 23);
            txtNomorPlat.TabIndex = 9;
            // 
            // txtNamaBus
            // 
            txtNamaBus.Location = new Point(254, 169);
            txtNamaBus.Name = "txtNamaBus";
            txtNamaBus.Size = new Size(100, 23);
            txtNamaBus.TabIndex = 10;
            // 
            // txtKapasitas
            // 
            txtKapasitas.Location = new Point(471, 107);
            txtKapasitas.Name = "txtKapasitas";
            txtKapasitas.Size = new Size(100, 23);
            txtKapasitas.TabIndex = 11;
            // 
            // txtTarifDasar
            // 
            txtTarifDasar.Location = new Point(471, 161);
            txtTarifDasar.Name = "txtTarifDasar";
            txtTarifDasar.Size = new Size(100, 23);
            txtTarifDasar.TabIndex = 12;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(290, 47);
            label5.Name = "label5";
            label5.Size = new Size(184, 32);
            label5.TabIndex = 13;
            label5.Text = "Input Data Bus";
            // 
            // InputBusForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label5);
            Controls.Add(txtTarifDasar);
            Controls.Add(txtKapasitas);
            Controls.Add(txtNamaBus);
            Controls.Add(txtNomorPlat);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvDataBus);
            Controls.Add(btnKeluar);
            Controls.Add(btnEdit);
            Controls.Add(btnSimpan);
            Name = "InputBusForm";
            Text = "InputBus";
            Load += InputBusForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDataBus).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSimpan;
        private Button btnEdit;
        private Button btnKeluar;
        private DataGridView dgvDataBus;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtNomorPlat;
        private TextBox txtNamaBus;
        private TextBox txtKapasitas;
        private TextBox txtTarifDasar;
        private Label label5;
    }
}