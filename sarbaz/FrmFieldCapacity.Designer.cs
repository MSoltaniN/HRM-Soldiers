namespace sarbaz
{
    partial class FrmFieldCapacity
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.GVFeildCapacity = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.cboxGrade = new System.Windows.Forms.ComboBox();
            this.button8 = new System.Windows.Forms.Button();
            this.btnChangeGrade = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GVFeildCapacity)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnClose.ForeColor = System.Drawing.SystemColors.Window;
            this.btnClose.Location = new System.Drawing.Point(504, 284);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(65, 28);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "انصراف";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnApply
            // 
            this.btnApply.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnApply.ForeColor = System.Drawing.SystemColors.Window;
            this.btnApply.Location = new System.Drawing.Point(504, 246);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(65, 24);
            this.btnApply.TabIndex = 5;
            this.btnApply.Text = "ثبت";
            this.btnApply.UseVisualStyleBackColor = false;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // GVFeildCapacity
            // 
            this.GVFeildCapacity.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.GVFeildCapacity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GVFeildCapacity.Location = new System.Drawing.Point(108, 65);
            this.GVFeildCapacity.Name = "GVFeildCapacity";
            this.GVFeildCapacity.Size = new System.Drawing.Size(390, 247);
            this.GVFeildCapacity.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(81, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "مدرک";
            // 
            // cboxGrade
            // 
            this.cboxGrade.FormattingEnabled = true;
            this.cboxGrade.Location = new System.Drawing.Point(134, 16);
            this.cboxGrade.Name = "cboxGrade";
            this.cboxGrade.Size = new System.Drawing.Size(121, 21);
            this.cboxGrade.TabIndex = 1;
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button8.ForeColor = System.Drawing.SystemColors.Window;
            this.button8.Location = new System.Drawing.Point(52, 273);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(50, 27);
            this.button8.TabIndex = 3;
            this.button8.Text = "تغییرات";
            this.button8.UseVisualStyleBackColor = false;
            // 
            // btnChangeGrade
            // 
            this.btnChangeGrade.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnChangeGrade.ForeColor = System.Drawing.SystemColors.Window;
            this.btnChangeGrade.Location = new System.Drawing.Point(261, 14);
            this.btnChangeGrade.Name = "btnChangeGrade";
            this.btnChangeGrade.Size = new System.Drawing.Size(54, 23);
            this.btnChangeGrade.TabIndex = 2;
            this.btnChangeGrade.Text = "تغییرات";
            this.btnChangeGrade.UseVisualStyleBackColor = false;
            // 
            // FrmFieldCapacity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Navy;
            this.ClientSize = new System.Drawing.Size(581, 324);
            this.ControlBox = false;
            this.Controls.Add(this.button8);
            this.Controls.Add(this.btnChangeGrade);
            this.Controls.Add(this.cboxGrade);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GVFeildCapacity);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnApply);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FrmFieldCapacity";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "فرم ثبت ظرفیت رشته";
            this.Load += new System.EventHandler(this.FrmFieldCapacity_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GVFeildCapacity)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.DataGridView GVFeildCapacity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboxGrade;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button btnChangeGrade;
    }
}