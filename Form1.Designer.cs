namespace AUT
{
    partial class Game
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
            this.StatusLogin = new System.Windows.Forms.Label();
            this.panelAuth = new System.Windows.Forms.Panel();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.btnReg = new System.Windows.Forms.Button();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.btConnect = new System.Windows.Forms.Button();
            this.panelAuth.SuspendLayout();
            this.SuspendLayout();
            // 
            // StatusLogin
            // 
            this.StatusLogin.AutoSize = true;
            this.StatusLogin.Location = new System.Drawing.Point(164, 12);
            this.StatusLogin.Name = "StatusLogin";
            this.StatusLogin.Size = new System.Drawing.Size(0, 13);
            this.StatusLogin.TabIndex = 3;
            // 
            // panelAuth
            // 
            this.panelAuth.Controls.Add(this.tbPassword);
            this.panelAuth.Controls.Add(this.StatusLogin);
            this.panelAuth.Controls.Add(this.btnReg);
            this.panelAuth.Controls.Add(this.tbLogin);
            this.panelAuth.Controls.Add(this.btConnect);
            this.panelAuth.Location = new System.Drawing.Point(12, 12);
            this.panelAuth.Name = "panelAuth";
            this.panelAuth.Size = new System.Drawing.Size(256, 143);
            this.panelAuth.TabIndex = 5;
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(67, 34);
            this.tbPassword.Margin = new System.Windows.Forms.Padding(2);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(82, 20);
            this.tbPassword.TabIndex = 1;
            // 
            // btnReg
            // 
            this.btnReg.Location = new System.Drawing.Point(67, 86);
            this.btnReg.Name = "btnReg";
            this.btnReg.Size = new System.Drawing.Size(82, 23);
            this.btnReg.TabIndex = 4;
            this.btnReg.Text = "Регистрация";
            this.btnReg.UseVisualStyleBackColor = true;
            this.btnReg.Click += new System.EventHandler(this.btnReg_Click);
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(67, 12);
            this.tbLogin.Margin = new System.Windows.Forms.Padding(2);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(82, 20);
            this.tbLogin.TabIndex = 0;
            this.tbLogin.TextChanged += new System.EventHandler(this.tbLogin_TextChanged);
            // 
            // btConnect
            // 
            this.btConnect.Location = new System.Drawing.Point(67, 58);
            this.btConnect.Margin = new System.Windows.Forms.Padding(2);
            this.btConnect.Name = "btConnect";
            this.btConnect.Size = new System.Drawing.Size(82, 23);
            this.btConnect.TabIndex = 2;
            this.btConnect.Text = "Авторизация";
            this.btConnect.UseVisualStyleBackColor = true;
            this.btConnect.Click += new System.EventHandler(this.btConnect_Click);
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 170);
            this.Controls.Add(this.panelAuth);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Game";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelAuth.ResumeLayout(false);
            this.panelAuth.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label StatusLogin;
        private System.Windows.Forms.Panel panelAuth;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Button btnReg;
        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.Button btConnect;
    }
}

