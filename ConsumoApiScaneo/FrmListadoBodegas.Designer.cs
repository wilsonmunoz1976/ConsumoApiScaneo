namespace ConsumoApiScaneo
{
    partial class FrmListadoBodegas
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnConsultar = new Button();
            dataGridView1 = new DataGridView();
            dataGridView2 = new DataGridView();
            lblBodega = new Label();
            cboBodega = new ComboBox();
            label1 = new Label();
            cboEstado = new ComboBox();
            label2 = new Label();
            txtUsuario = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // btnConsultar
            // 
            btnConsultar.Location = new Point(176, 133);
            btnConsultar.Name = "btnConsultar";
            btnConsultar.Size = new Size(75, 23);
            btnConsultar.TabIndex = 2;
            btnConsultar.Text = "Consultar";
            btnConsultar.UseVisualStyleBackColor = true;
            btnConsultar.Click += btnConsultar_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(43, 174);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(463, 71);
            dataGridView1.TabIndex = 8;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(41, 264);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowTemplate.Height = 25;
            dataGridView2.Size = new Size(672, 119);
            dataGridView2.TabIndex = 9;
            // 
            // lblBodega
            // 
            lblBodega.AutoSize = true;
            lblBodega.Location = new Point(95, 10);
            lblBodega.Name = "lblBodega";
            lblBodega.Size = new Size(50, 15);
            lblBodega.TabIndex = 0;
            lblBodega.Text = "Bodega:";
            // 
            // cboBodega
            // 
            cboBodega.DropDownStyle = ComboBoxStyle.DropDownList;
            cboBodega.FormattingEnabled = true;
            cboBodega.Location = new Point(167, 10);
            cboBodega.Name = "cboBodega";
            cboBodega.Size = new Size(121, 23);
            cboBodega.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(95, 45);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 4;
            label1.Text = "Estado:";
            // 
            // cboEstado
            // 
            cboEstado.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEstado.FormattingEnabled = true;
            cboEstado.Location = new Point(166, 44);
            cboEstado.Name = "cboEstado";
            cboEstado.Size = new Size(121, 23);
            cboEstado.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(95, 80);
            label2.Name = "label2";
            label2.Size = new Size(50, 15);
            label2.TabIndex = 6;
            label2.Text = "Usuario:";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(167, 77);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(100, 23);
            txtUsuario.TabIndex = 7;
            // 
            // FrmListadoBodegas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView2);
            Controls.Add(dataGridView1);
            Controls.Add(txtUsuario);
            Controls.Add(label2);
            Controls.Add(cboEstado);
            Controls.Add(label1);
            Controls.Add(cboBodega);
            Controls.Add(btnConsultar);
            Controls.Add(lblBodega);
            Name = "FrmListadoBodegas";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnConsultar;
        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private Label lblBodega;
        private ComboBox cboBodega;
        private Label label1;
        private ComboBox cboEstado;
        private Label label2;
        private TextBox txtUsuario;
    }
}