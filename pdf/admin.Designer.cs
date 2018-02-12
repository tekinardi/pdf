namespace pdf
{
    partial class Admin
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtSifre = new System.Windows.Forms.TextBox();
            this.txtdomain = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.lblmsj = new System.Windows.Forms.Label();
            this.btnYeniBaslat = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Şifre :";
            // 
            // txtSifre
            // 
            this.txtSifre.Location = new System.Drawing.Point(84, 19);
            this.txtSifre.Name = "txtSifre";
            this.txtSifre.Size = new System.Drawing.Size(135, 20);
            this.txtSifre.TabIndex = 1;
            this.txtSifre.UseSystemPasswordChar = true;
            // 
            // txtdomain
            // 
            this.txtdomain.Location = new System.Drawing.Point(84, 50);
            this.txtdomain.Name = "txtdomain";
            this.txtdomain.Size = new System.Drawing.Size(135, 20);
            this.txtdomain.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Kullanıcı Adı :";
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Location = new System.Drawing.Point(225, 52);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(87, 23);
            this.btnGuncelle.TabIndex = 4;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // lblmsj
            // 
            this.lblmsj.AutoSize = true;
            this.lblmsj.Location = new System.Drawing.Point(106, 83);
            this.lblmsj.Name = "lblmsj";
            this.lblmsj.Size = new System.Drawing.Size(0, 13);
            this.lblmsj.TabIndex = 5;
            // 
            // btnYeniBaslat
            // 
            this.btnYeniBaslat.Location = new System.Drawing.Point(225, 78);
            this.btnYeniBaslat.Name = "btnYeniBaslat";
            this.btnYeniBaslat.Size = new System.Drawing.Size(87, 23);
            this.btnYeniBaslat.TabIndex = 6;
            this.btnYeniBaslat.Text = "Yeniden Başlat";
            this.btnYeniBaslat.UseVisualStyleBackColor = true;
            this.btnYeniBaslat.Visible = false;
            this.btnYeniBaslat.Click += new System.EventHandler(this.btnYeniBaslat_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.Location = new System.Drawing.Point(304, -2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(23, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 105);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnYeniBaslat);
            this.Controls.Add(this.lblmsj);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.txtdomain);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSifre);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "Admin";
            this.Text = "Admin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSifre;
        private System.Windows.Forms.TextBox txtdomain;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Label lblmsj;
        private System.Windows.Forms.Button btnYeniBaslat;
        private System.Windows.Forms.Button button1;
    }
}