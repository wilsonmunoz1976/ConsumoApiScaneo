using System.Data;

namespace ConsumoApiScaneo
{
    partial class FrmMostrarImg
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
            imgCofre = new PictureBox();
            openFileDialog1 = new OpenFileDialog();
            btnMostrarSala = new Button();
            lstCofresUrnas = new ListBox();
            txtUsuario = new TextBox();
            label2 = new Label();
            cboEstado = new ComboBox();
            label1 = new Label();
            cboBodega = new ComboBox();
            lblBodega = new Label();
            label3 = new Label();
            lblNombreFallecido = new Label();
            lblBodegaOrigen = new Label();
            label5 = new Label();
            lblID = new Label();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)imgCofre).BeginInit();
            SuspendLayout();
            // 
            // imgCofre
            // 
            imgCofre.Location = new Point(360, 169);
            imgCofre.Name = "imgCofre";
            imgCofre.Size = new Size(415, 288);
            imgCofre.SizeMode = PictureBoxSizeMode.StretchImage;
            imgCofre.TabIndex = 0;
            imgCofre.TabStop = false;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnMostrarSala
            // 
            btnMostrarSala.Location = new Point(325, 58);
            btnMostrarSala.Name = "btnMostrarSala";
            btnMostrarSala.Size = new Size(142, 35);
            btnMostrarSala.TabIndex = 5;
            btnMostrarSala.Text = "MostrarSala";
            btnMostrarSala.UseVisualStyleBackColor = true;
            btnMostrarSala.Click += btnMostrarSala_Click;
            // 
            // lstCofresUrnas
            // 
            lstCofresUrnas.FormattingEnabled = true;
            lstCofresUrnas.ItemHeight = 15;
            lstCofresUrnas.Location = new Point(53, 123);
            lstCofresUrnas.Name = "lstCofresUrnas";
            lstCofresUrnas.Size = new Size(282, 334);
            lstCofresUrnas.TabIndex = 6;
            lstCofresUrnas.Click += LstCofresUrnas_Click;
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(631, 9);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(100, 23);
            txtUsuario.TabIndex = 13;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(559, 12);
            label2.Name = "label2";
            label2.Size = new Size(50, 15);
            label2.TabIndex = 12;
            label2.Text = "Usuario:";
            // 
            // cboEstado
            // 
            cboEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEstado.FormattingEnabled = true;
            cboEstado.Location = new Point(376, 7);
            cboEstado.Name = "cboEstado";
            cboEstado.Size = new Size(121, 23);
            cboEstado.TabIndex = 11;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(325, 10);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 10;
            label1.Text = "Estado:";
            // 
            // cboBodega
            // 
            cboBodega.DropDownStyle = ComboBoxStyle.DropDownList;
            cboBodega.FormattingEnabled = true;
            cboBodega.Location = new Point(128, 12);
            cboBodega.Name = "cboBodega";
            cboBodega.Size = new Size(121, 23);
            cboBodega.TabIndex = 9;
            // 
            // lblBodega
            // 
            lblBodega.AutoSize = true;
            lblBodega.Location = new Point(56, 12);
            lblBodega.Name = "lblBodega";
            lblBodega.Size = new Size(50, 15);
            lblBodega.TabIndex = 8;
            lblBodega.Text = "Bodega:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(359, 145);
            label3.Name = "label3";
            label3.Size = new Size(121, 15);
            label3.TabIndex = 14;
            label3.Text = "Nombre de fallecido :";
            // 
            // lblNombreFallecido
            // 
            lblNombreFallecido.BackColor = SystemColors.ButtonHighlight;
            lblNombreFallecido.BorderStyle = BorderStyle.FixedSingle;
            lblNombreFallecido.Location = new Point(490, 141);
            lblNombreFallecido.Name = "lblNombreFallecido";
            lblNombreFallecido.Size = new Size(285, 23);
            lblNombreFallecido.TabIndex = 17;
            // 
            // lblBodegaOrigen
            // 
            lblBodegaOrigen.BackColor = SystemColors.ButtonHighlight;
            lblBodegaOrigen.BorderStyle = BorderStyle.FixedSingle;
            lblBodegaOrigen.Location = new Point(581, 115);
            lblBodegaOrigen.Name = "lblBodegaOrigen";
            lblBodegaOrigen.Size = new Size(98, 23);
            lblBodegaOrigen.TabIndex = 19;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(514, 119);
            label5.Name = "label5";
            label5.Size = new Size(53, 15);
            label5.TabIndex = 18;
            label5.Text = "Bodega :";
            // 
            // lblID
            // 
            lblID.BackColor = SystemColors.ButtonHighlight;
            lblID.BorderStyle = BorderStyle.FixedSingle;
            lblID.Location = new Point(392, 115);
            lblID.Name = "lblID";
            lblID.Size = new Size(88, 23);
            lblID.TabIndex = 21;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(360, 119);
            label6.Name = "label6";
            label6.Size = new Size(23, 15);
            label6.TabIndex = 20;
            label6.Text = "Id :";
            // 
            // FrmMostrarImg
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 547);
            Controls.Add(lblID);
            Controls.Add(label6);
            Controls.Add(lblBodegaOrigen);
            Controls.Add(label5);
            Controls.Add(lblNombreFallecido);
            Controls.Add(label3);
            Controls.Add(txtUsuario);
            Controls.Add(label2);
            Controls.Add(cboEstado);
            Controls.Add(label1);
            Controls.Add(cboBodega);
            Controls.Add(lblBodega);
            Controls.Add(lstCofresUrnas);
            Controls.Add(btnMostrarSala);
            Controls.Add(imgCofre);
            Name = "FrmMostrarImg";
            Text = "FrmMostrarImg";
            Load += FrmMostrarImg_Load;
            ((System.ComponentModel.ISupportInitialize)imgCofre).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }



        #endregion

        private PictureBox imgCofre;
        private OpenFileDialog openFileDialog1;
        private Button btnMostrarSala;
        private ListBox lstCofresUrnas;
        private TextBox txtUsuario;
        private Label label2;
        private ComboBox cboEstado;
        private Label label1;
        private ComboBox cboBodega;
        private Label lblBodega;
        private Label label3;
        private Label lblNombreFallecido;
        private Label lblBodegaOrigen;
        private Label label5;
        private Label lblID;
        private Label label6;
    }
}