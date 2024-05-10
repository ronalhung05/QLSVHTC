namespace QLSVHTC
{
    partial class frmInHP
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbLop = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.nmHocKy = new System.Windows.Forms.NumericUpDown();
            this.txbNienKhoa = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nmHocKy)).BeginInit();
            this.SuspendLayout();
            // 
            // btnThoat
            // 
            this.btnThoat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(264, 194);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(83, 41);
            this.btnThoat.TabIndex = 13;
            this.btnThoat.Text = "THOÁT";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnIn
            // 
            this.btnIn.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIn.Location = new System.Drawing.Point(154, 194);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(83, 41);
            this.btnIn.TabIndex = 14;
            this.btnIn.Text = "IN";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(97, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "HỌC KÌ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(97, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "NIÊN KHÓA";
            // 
            // cmbLop
            // 
            this.cmbLop.FormattingEnabled = true;
            this.cmbLop.Location = new System.Drawing.Point(170, 85);
            this.cmbLop.Name = "cmbLop";
            this.cmbLop.Size = new System.Drawing.Size(243, 21);
            this.cmbLop.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(97, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "MÃ LỚP";
            // 
            // nmHocKy
            // 
            this.nmHocKy.Location = new System.Drawing.Point(170, 142);
            this.nmHocKy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nmHocKy.Name = "nmHocKy";
            this.nmHocKy.Size = new System.Drawing.Size(243, 21);
            this.nmHocKy.TabIndex = 15;
            // 
            // txbNienKhoa
            // 
            this.txbNienKhoa.Location = new System.Drawing.Point(170, 115);
            this.txbNienKhoa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txbNienKhoa.Name = "txbNienKhoa";
            this.txbNienKhoa.Size = new System.Drawing.Size(243, 21);
            this.txbNienKhoa.TabIndex = 16;
            // 
            // frmInHP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 344);
            this.Controls.Add(this.txbNienKhoa);
            this.Controls.Add(this.nmHocKy);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbLop);
            this.Controls.Add(this.label1);
            this.Name = "frmInHP";
            this.Text = "frmInHP";
            this.Load += new System.EventHandler(this.frmInHP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nmHocKy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbLop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nmHocKy;
        private System.Windows.Forms.TextBox txbNienKhoa;
    }
}