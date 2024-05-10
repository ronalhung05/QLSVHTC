namespace QLSVHTC
{
    partial class frptDSLTC
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
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnIn = new System.Windows.Forms.Button();
            this.cmbHocKi = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbNienKhoa = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbKhoa = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(267, 200);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(83, 41);
            this.btnThoat.TabIndex = 13;
            this.btnThoat.Text = "THOÁT";
            this.btnThoat.UseVisualStyleBackColor = true;
            // 
            // btnIn
            // 
            this.btnIn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIn.Location = new System.Drawing.Point(157, 200);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(83, 41);
            this.btnIn.TabIndex = 14;
            this.btnIn.Text = "IN";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // cmbHocKi
            // 
            this.cmbHocKi.FormattingEnabled = true;
            this.cmbHocKi.Location = new System.Drawing.Point(174, 149);
            this.cmbHocKi.Name = "cmbHocKi";
            this.cmbHocKi.Size = new System.Drawing.Size(243, 21);
            this.cmbHocKi.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(101, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "HỌC KÌ";
            // 
            // cmbNienKhoa
            // 
            this.cmbNienKhoa.FormattingEnabled = true;
            this.cmbNienKhoa.Location = new System.Drawing.Point(174, 122);
            this.cmbNienKhoa.Name = "cmbNienKhoa";
            this.cmbNienKhoa.Size = new System.Drawing.Size(243, 21);
            this.cmbNienKhoa.TabIndex = 11;
            this.cmbNienKhoa.SelectedIndexChanged += new System.EventHandler(this.cmbNienKhoa_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(101, 125);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "NIÊN KHÓA";
            // 
            // cmbKhoa
            // 
            this.cmbKhoa.FormattingEnabled = true;
            this.cmbKhoa.Location = new System.Drawing.Point(174, 95);
            this.cmbKhoa.Name = "cmbKhoa";
            this.cmbKhoa.Size = new System.Drawing.Size(243, 21);
            this.cmbKhoa.TabIndex = 12;
            this.cmbKhoa.SelectedIndexChanged += new System.EventHandler(this.cmbKhoa_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(101, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "KHOA";
            // 
            // frptDSLTC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 349);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.cmbHocKi);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbNienKhoa);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbKhoa);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frptDSLTC";
            this.Text = "frmDSLTC";
            this.Load += new System.EventHandler(this.frmDSLTC_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.ComboBox cmbHocKi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbNienKhoa;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbKhoa;
        private System.Windows.Forms.Label label1;
    }
}