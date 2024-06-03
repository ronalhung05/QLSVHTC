namespace QLSVHTC
{
    partial class frptInHP
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
            this.nmHocKy = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.cbLop = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txbNienKhoa = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.nmHocKy)).BeginInit();
            this.SuspendLayout();
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.Color.Salmon;
            this.btnThoat.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(312, 272);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(96, 42);
            this.btnThoat.TabIndex = 13;
            this.btnThoat.Text = "THOÁT";
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnIn
            // 
            this.btnIn.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnIn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIn.Location = new System.Drawing.Point(206, 272);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(100, 42);
            this.btnIn.TabIndex = 14;
            this.btnIn.Text = "IN";
            this.btnIn.UseVisualStyleBackColor = false;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // nmHocKy
            // 
            this.nmHocKy.Location = new System.Drawing.Point(205, 221);
            this.nmHocKy.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.nmHocKy.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nmHocKy.Name = "nmHocKy";
            this.nmHocKy.Size = new System.Drawing.Size(325, 23);
            this.nmHocKy.TabIndex = 11;
            this.nmHocKy.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(69, 221);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 24);
            this.label3.TabIndex = 7;
            this.label3.Text = "HỌC KỲ";
            // 
            // cbLop
            // 
            this.cbLop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLop.FormattingEnabled = true;
            this.cbLop.Location = new System.Drawing.Point(205, 144);
            this.cbLop.Name = "cbLop";
            this.cbLop.Size = new System.Drawing.Size(325, 24);
            this.cbLop.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(69, 182);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 24);
            this.label2.TabIndex = 8;
            this.label2.Text = "NIÊN KHÓA";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(69, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 24);
            this.label1.TabIndex = 9;
            this.label1.Text = "MÃ LỚP";
            // 
            // txbNienKhoa
            // 
            this.txbNienKhoa.Location = new System.Drawing.Point(205, 186);
            this.txbNienKhoa.Name = "txbNienKhoa";
            this.txbNienKhoa.Size = new System.Drawing.Size(325, 23);
            this.txbNienKhoa.TabIndex = 12;
            // 
            // frptInHP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 459);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.txbNienKhoa);
            this.Controls.Add(this.nmHocKy);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbLop);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "frptInHP";
            this.Text = "In học phí";
            this.Load += new System.EventHandler(this.frptInHP_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nmHocKy)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.NumericUpDown nmHocKy;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbLop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbNienKhoa;
    }
}