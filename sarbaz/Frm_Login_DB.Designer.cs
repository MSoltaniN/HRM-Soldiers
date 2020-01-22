namespace sarbaz
{
    partial class Frm_Login_DB
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
            this.btn_Connect = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_ServerName = new System.Windows.Forms.TextBox();
            this.txt_UserName = new System.Windows.Forms.TextBox();
            this.txt_Pass = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_Connect
            // 
            this.btn_Connect.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btn_Connect.ForeColor = System.Drawing.SystemColors.Window;
            this.btn_Connect.Location = new System.Drawing.Point(212, 195);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(75, 23);
            this.btn_Connect.TabIndex = 0;
            this.btn_Connect.Text = "اتصال";
            this.btn_Connect.UseVisualStyleBackColor = false;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btn_Close.ForeColor = System.Drawing.SystemColors.Window;
            this.btn_Close.Location = new System.Drawing.Point(212, 224);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(75, 23);
            this.btn_Close.TabIndex = 1;
            this.btn_Close.Text = "انصراف";
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Location = new System.Drawing.Point(58, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "نام سرور";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label2.Location = new System.Drawing.Point(58, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "نام کاربری";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label3.Location = new System.Drawing.Point(58, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "کلمه عبور";
            // 
            // txt_ServerName
            // 
            this.txt_ServerName.Location = new System.Drawing.Point(125, 48);
            this.txt_ServerName.Name = "txt_ServerName";
            this.txt_ServerName.Size = new System.Drawing.Size(100, 21);
            this.txt_ServerName.TabIndex = 5;
            // 
            // txt_UserName
            // 
            this.txt_UserName.Location = new System.Drawing.Point(125, 91);
            this.txt_UserName.Name = "txt_UserName";
            this.txt_UserName.Size = new System.Drawing.Size(100, 21);
            this.txt_UserName.TabIndex = 6;
            // 
            // txt_Pass
            // 
            this.txt_Pass.Location = new System.Drawing.Point(125, 134);
            this.txt_Pass.Name = "txt_Pass";
            this.txt_Pass.Size = new System.Drawing.Size(100, 21);
            this.txt_Pass.TabIndex = 7;
            // 
            // Frm_Login_DB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.ClientSize = new System.Drawing.Size(313, 267);
            this.ControlBox = false;
            this.Controls.Add(this.txt_Pass);
            this.Controls.Add(this.txt_UserName);
            this.Controls.Add(this.txt_ServerName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Close);
            this.Controls.Add(this.btn_Connect);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Frm_Login_DB";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Frm_Login_DB";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Frm_Login_DB_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Connect;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_ServerName;
        private System.Windows.Forms.TextBox txt_UserName;
        private System.Windows.Forms.TextBox txt_Pass;
    }
}