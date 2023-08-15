namespace ConsumoApiScaneo
{
    partial class FrmLogin
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
            label2 = new Label();
            label3 = new Label();
            txtUsuario = new TextBox();
            txtPassword = new TextBox();
            cmdLogin = new Button();
            dataGridView1 = new DataGridView();
            dataGridView2 = new DataGridView();
            dataGridView3 = new DataGridView();
            txtToken = new TextBox();
            cmdVerCofresUrnas = new Button();
            btnEntrega = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(84, 33);
            label2.Name = "label2";
            label2.Size = new Size(50, 15);
            label2.TabIndex = 2;
            label2.Text = "Usuario:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(84, 71);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 3;
            label3.Text = "Pasword:";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(168, 30);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(135, 23);
            txtUsuario.TabIndex = 4;
            txtUsuario.Text = "wmunoz";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(168, 68);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(135, 23);
            txtPassword.TabIndex = 5;
            txtPassword.Text = "12345";
            // 
            // cmdLogin
            // 
            cmdLogin.Location = new Point(168, 117);
            cmdLogin.Name = "cmdLogin";
            cmdLogin.Size = new Size(151, 23);
            cmdLogin.TabIndex = 6;
            cmdLogin.Text = "Login";
            cmdLogin.UseVisualStyleBackColor = true;
            cmdLogin.Click += cmdLogin_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(426, 11);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(325, 83);
            dataGridView1.TabIndex = 7;
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(425, 112);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowTemplate.Height = 25;
            dataGridView2.Size = new Size(324, 92);
            dataGridView2.TabIndex = 8;
            // 
            // dataGridView3
            // 
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView3.Location = new Point(20, 230);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.RowTemplate.Height = 25;
            dataGridView3.Size = new Size(729, 195);
            dataGridView3.TabIndex = 9;
            // 
            // txtToken
            // 
            txtToken.Location = new Point(20, 434);
            txtToken.Name = "txtToken";
            txtToken.Size = new Size(725, 23);
            txtToken.TabIndex = 10;
            // 
            // cmdVerCofresUrnas
            // 
            cmdVerCofresUrnas.Enabled = false;
            cmdVerCofresUrnas.Location = new Point(20, 163);
            cmdVerCofresUrnas.Name = "cmdVerCofresUrnas";
            cmdVerCofresUrnas.Size = new Size(119, 28);
            cmdVerCofresUrnas.TabIndex = 11;
            cmdVerCofresUrnas.Text = "Ver Cofres Urnas";
            cmdVerCofresUrnas.UseVisualStyleBackColor = true;
            cmdVerCofresUrnas.Click += cmdVerCofresUrnas_Click;
            // 
            // btnEntrega
            // 
            btnEntrega.Enabled = false;
            btnEntrega.Location = new Point(145, 163);
            btnEntrega.Name = "btnEntrega";
            btnEntrega.Size = new Size(119, 28);
            btnEntrega.TabIndex = 12;
            btnEntrega.Text = "Ver Cofres Urnas";
            btnEntrega.UseVisualStyleBackColor = true;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(792, 467);
            Controls.Add(btnEntrega);
            Controls.Add(cmdVerCofresUrnas);
            Controls.Add(txtToken);
            Controls.Add(dataGridView3);
            Controls.Add(dataGridView2);
            Controls.Add(dataGridView1);
            Controls.Add(cmdLogin);
            Controls.Add(txtPassword);
            Controls.Add(txtUsuario);
            Controls.Add(label3);
            Controls.Add(label2);
            Name = "FrmLogin";
            Text = "FrmLogin";
            Load += FrmLogin_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private Label label3;
        private TextBox txtUsuario;
        private TextBox txtPassword;
        private Button cmdLogin;
        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private DataGridView dataGridView3;
        private TextBox txtToken;
        private Button cmdVerCofresUrnas;
        private Button btnEntrega;
    }
}