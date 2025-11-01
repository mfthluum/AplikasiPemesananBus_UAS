// FILE: Forms/InputBusForm.Designer.cs (Dihasilkan oleh Visual Studio Designer)

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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtNamaBus = new TextBox();
            txtNomorPlat = new TextBox();
            txtKapasitas = new TextBox();
            txtTarifDasar = new TextBox();
            btnSimpan = new Button();
            btnEdit = new Button();
            btnHapus = new Button();
            btnKeluar = new Button();
            dgvDataBus = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvDataBus).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.Location = new Point(198, 9);
            label1.Name = "label1";
            label1.Size = new Size(144, 25);
            label1.TabIndex = 0;
            label1.Text = "Input Data Bus";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(34, 53);
            label2.Name = "label2";
            label2.Size = new Size(64, 15);
            label2.TabIndex = 1;
            label2.Text = "Nama Bus:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(34, 84);
            label3.Name = "label3";
            label3.Size = new Size(71, 15);
            label3.TabIndex = 2;
            label3.Text = "Nomor Plat:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(34, 115);
            label4.Name = "label4";
            label4.Size = new Size(59, 15);
            label4.TabIndex = 3;
            label4.Text = "Kapasitas:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(34, 146);
            label5.Name = "label5";
            label5.Size = new Size(64, 15);
            label5.TabIndex = 4;
            label5.Text = "Tarif Dasar:";
            // 
            // txtNamaBus
            // 
            txtNamaBus.Location = new Point(135, 50);
            txtNamaBus.Name = "txtNamaBus";
            txtNamaBus.Size = new Size(150, 23);
            txtNamaBus.TabIndex = 5;
            // 
            // txtNomorPlat
            // 
            txtNomorPlat.Location = new Point(135, 81);
            txtNomorPlat.Name = "txtNomorPlat";
            txtNomorPlat.Size = new Size(150, 23);
            txtNomorPlat.TabIndex = 6;
            // 
            // txtKapasitas
            // 
            txtKapasitas.Location = new Point(135, 112);
            txtKapasitas.Name = "txtKapasitas";
            txtKapasitas.Size = new Size(150, 23);
            txtKapasitas.TabIndex = 7;
            // 
            // txtTarifDasar
            // 
            txtTarifDasar.Location = new Point(135, 143);
            txtTarifDasar.Name = "txtTarifDasar";
            txtTarifDasar.Size = new Size(150, 23);
            txtTarifDasar.TabIndex = 8;
            // 
            // btnSimpan
            // 
            btnSimpan.Location = new Point(135, 185);
            btnSimpan.Name = "btnSimpan";
            btnSimpan.Size = new Size(75, 23);
            btnSimpan.TabIndex = 9;
            btnSimpan.Text = "Simpan";
            btnSimpan.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(216, 185);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(75, 23);
            btnEdit.TabIndex = 10;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnHapus
            // 
            btnHapus.Location = new Point(297, 185);
            btnHapus.Name = "btnHapus";
            btnHapus.Size = new Size(75, 23);
            btnHapus.TabIndex = 11;
            btnHapus.Text = "Hapus";
            btnHapus.UseVisualStyleBackColor = true;
            // 
            // btnKeluar
            // 
            btnKeluar.Location = new Point(378, 185);
            btnKeluar.Name = "btnKeluar";
            btnKeluar.Size = new Size(75, 23);
            btnKeluar.TabIndex = 12;
            btnKeluar.Text = "Keluar";
            btnKeluar.UseVisualStyleBackColor = true;
            // 
            // dgvDataBus
            // 
            dgvDataBus.AllowUserToAddRows = false;
            dgvDataBus.AllowUserToDeleteRows = false;
            dgvDataBus.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDataBus.Location = new Point(55, 230);
            dgvDataBus.Name = "dgvDataBus";
            dgvDataBus.ReadOnly = true;
            dgvDataBus.Size = new Size(441, 186);
            dgvDataBus.TabIndex = 13;
            // 
            // InputBusForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(558, 428);
            Controls.Add(dgvDataBus);
            Controls.Add(btnKeluar);
            Controls.Add(btnHapus);
            Controls.Add(btnEdit);
            Controls.Add(btnSimpan);
            Controls.Add(txtTarifDasar);
            Controls.Add(txtKapasitas);
            Controls.Add(txtNomorPlat);
            Controls.Add(txtNamaBus);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "InputBusForm";
            Text = "Input Bus";
            ((System.ComponentModel.ISupportInitialize)dgvDataBus).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNamaBus;
        private System.Windows.Forms.TextBox txtNomorPlat;
        private System.Windows.Forms.TextBox txtKapasitas;
        private System.Windows.Forms.TextBox txtTarifDasar;

        // Deklarasi tombol sebagai public member (penting!)
        public System.Windows.Forms.Button btnSimpan;
        public System.Windows.Forms.Button btnEdit;
        public System.Windows.Forms.Button btnHapus;
        public System.Windows.Forms.Button btnKeluar;

        private System.Windows.Forms.DataGridView dgvDataBus;
    }
}