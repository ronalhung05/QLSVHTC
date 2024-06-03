namespace QLSVHTC
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.ribbonPage4 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageCategory1 = new DevExpress.XtraBars.Ribbon.RibbonPageCategory();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.btnLopHoc = new DevExpress.XtraBars.BarButtonItem();
            this.btnSinhVien = new DevExpress.XtraBars.BarButtonItem();
            this.btnMonHoc = new DevExpress.XtraBars.BarButtonItem();
            this.btnLopTinChi = new DevExpress.XtraBars.BarButtonItem();
            this.btnChamDiem = new DevExpress.XtraBars.BarButtonItem();
            this.btnDangKyLTC = new DevExpress.XtraBars.BarButtonItem();
            this.btnHocPhi = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnBangDiemMonHoc = new DevExpress.XtraBars.BarButtonItem();
            this.btnDanhSachLopTC = new DevExpress.XtraBars.BarButtonItem();
            this.btnSinhVienDangKyLopTC = new DevExpress.XtraBars.BarButtonItem();
            this.btnPhieuDiem = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.btnInHocPhi = new DevExpress.XtraBars.BarButtonItem();
            this.btnBangDiemTongKet = new DevExpress.XtraBars.BarButtonItem();
            this.btnTaoTaiKhoan = new DevExpress.XtraBars.BarButtonItem();
            this.btnDangXuat = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage5 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage7 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.MAGV = new System.Windows.Forms.ToolStripStatusLabel();
            this.HOTEN = new System.Windows.Forms.ToolStripStatusLabel();
            this.NHOM = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // ribbonPage4
            // 
            this.ribbonPage4.Name = "ribbonPage4";
            this.ribbonPage4.Text = "ribbonPage4";
            // 
            // ribbonPageCategory1
            // 
            this.ribbonPageCategory1.Name = "ribbonPageCategory1";
            this.ribbonPageCategory1.Text = "ribbonPageCategory1";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "ribbonPage2";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "ribbonPageGroup2";
            // 
            // ribbonPage3
            // 
            this.ribbonPage3.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3});
            this.ribbonPage3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ribbonPage3.ImageOptions.Image")));
            this.ribbonPage3.Name = "ribbonPage3";
            this.ribbonPage3.Text = "Quản Trị";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.btnLopHoc);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnSinhVien);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnMonHoc);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnLopTinChi);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnChamDiem);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnDangKyLTC);
            this.ribbonPageGroup3.ItemLinks.Add(this.btnHocPhi);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "Quản Trị";
            // 
            // btnLopHoc
            // 
            this.btnLopHoc.Caption = "Lớp Học";
            this.btnLopHoc.Id = 3;
            this.btnLopHoc.ImageOptions.SvgImage = global::QLSVHTC.Properties.Resources.school;
            this.btnLopHoc.Name = "btnLopHoc";
            this.btnLopHoc.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLH_ItemClick);
            // 
            // btnSinhVien
            // 
            this.btnSinhVien.Caption = "Sinh Viên";
            this.btnSinhVien.Id = 4;
            this.btnSinhVien.ImageOptions.SvgImage = global::QLSVHTC.Properties.Resources.graduating_student;
            this.btnSinhVien.Name = "btnSinhVien";
            this.btnSinhVien.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnSinhVien.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSV_ItemClick);
            // 
            // btnMonHoc
            // 
            this.btnMonHoc.Caption = "Môn Học";
            this.btnMonHoc.Id = 5;
            this.btnMonHoc.ImageOptions.SvgImage = global::QLSVHTC.Properties.Resources.books;
            this.btnMonHoc.Name = "btnMonHoc";
            this.btnMonHoc.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnMonHoc_ItemClick);
            // 
            // btnLopTinChi
            // 
            this.btnLopTinChi.Caption = "LTC";
            this.btnLopTinChi.Id = 6;
            this.btnLopTinChi.ImageOptions.SvgImage = global::QLSVHTC.Properties.Resources.training;
            this.btnLopTinChi.Name = "btnLopTinChi";
            this.btnLopTinChi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLTC_ItemClick);
            // 
            // btnChamDiem
            // 
            this.btnChamDiem.Caption = "Điểm";
            this.btnChamDiem.Id = 9;
            this.btnChamDiem.ImageOptions.SvgImage = global::QLSVHTC.Properties.Resources.score;
            this.btnChamDiem.Name = "btnChamDiem";
            this.btnChamDiem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnChamDiem_ItemClick);
            // 
            // btnDangKyLTC
            // 
            this.btnDangKyLTC.Caption = "Đăng Ký";
            this.btnDangKyLTC.Id = 7;
            this.btnDangKyLTC.ImageOptions.SvgImage = global::QLSVHTC.Properties.Resources.memo;
            this.btnDangKyLTC.Name = "btnDangKyLTC";
            this.btnDangKyLTC.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDangKyLTC_ItemClick);
            // 
            // btnHocPhi
            // 
            this.btnHocPhi.Caption = "Học Phí";
            this.btnHocPhi.Id = 10;
            this.btnHocPhi.ImageOptions.SvgImage = global::QLSVHTC.Properties.Resources.charge;
            this.btnHocPhi.Name = "btnHocPhi";
            this.btnHocPhi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.BtnHocPhi_ItemClick);
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(35, 37, 35, 37);
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.btnLopHoc,
            this.btnSinhVien,
            this.btnMonHoc,
            this.btnLopTinChi,
            this.btnDangKyLTC,
            this.btnChamDiem,
            this.btnHocPhi,
            this.btnBangDiemMonHoc,
            this.btnDanhSachLopTC,
            this.btnSinhVienDangKyLopTC,
            this.btnPhieuDiem,
            this.barButtonItem1,
            this.btnInHocPhi,
            this.btnBangDiemTongKet,
            this.btnTaoTaiKhoan,
            this.btnDangXuat});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ribbonControl1.MaxItemId = 20;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.OptionsMenuMinWidth = 385;
            this.ribbonControl1.PageCategories.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageCategory[] {
            this.ribbonPageCategory1});
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage3,
            this.ribbonPage5,
            this.ribbonPage7});
            this.ribbonControl1.Size = new System.Drawing.Size(989, 201);
            this.ribbonControl1.Click += new System.EventHandler(this.ribbonControl1_Click);
            // 
            // btnBangDiemMonHoc
            // 
            this.btnBangDiemMonHoc.Caption = "Bảng điểm môn học";
            this.btnBangDiemMonHoc.Id = 11;
            this.btnBangDiemMonHoc.ImageOptions.SvgImage = global::QLSVHTC.Properties.Resources.grades;
            this.btnBangDiemMonHoc.Name = "btnBangDiemMonHoc";
            this.btnBangDiemMonHoc.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBDMH_ItemClick);
            // 
            // btnDanhSachLopTC
            // 
            this.btnDanhSachLopTC.Caption = "Danh sách lớp tín chỉ";
            this.btnDanhSachLopTC.Id = 12;
            this.btnDanhSachLopTC.ImageOptions.SvgImage = global::QLSVHTC.Properties.Resources.data_analysis;
            this.btnDanhSachLopTC.Name = "btnDanhSachLopTC";
            this.btnDanhSachLopTC.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDSLTC_ItemClick);
            // 
            // btnSinhVienDangKyLopTC
            // 
            this.btnSinhVienDangKyLopTC.Caption = "Danh sách sinh viên";
            this.btnSinhVienDangKyLopTC.Id = 13;
            this.btnSinhVienDangKyLopTC.ImageOptions.SvgImage = global::QLSVHTC.Properties.Resources.immigration;
            this.btnSinhVienDangKyLopTC.Name = "btnSinhVienDangKyLopTC";
            this.btnSinhVienDangKyLopTC.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSVDKLTC_ItemClick);
            // 
            // btnPhieuDiem
            // 
            this.btnPhieuDiem.Caption = "Phiếu điểm";
            this.btnPhieuDiem.Id = 14;
            this.btnPhieuDiem.ImageOptions.SvgImage = global::QLSVHTC.Properties.Resources.report_card__1_;
            this.btnPhieuDiem.Name = "btnPhieuDiem";
            this.btnPhieuDiem.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDiemSV_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "HocPhi";
            this.barButtonItem1.Id = 15;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // btnInHocPhi
            // 
            this.btnInHocPhi.Caption = "Danh sách đóng học phí của lớp";
            this.btnInHocPhi.Id = 16;
            this.btnInHocPhi.ImageOptions.SvgImage = global::QLSVHTC.Properties.Resources.accounting;
            this.btnInHocPhi.Name = "btnInHocPhi";
            this.btnInHocPhi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnInHocPhi_ItemClick);
            // 
            // btnBangDiemTongKet
            // 
            this.btnBangDiemTongKet.Caption = "Bảng điểm tổng kết";
            this.btnBangDiemTongKet.Id = 17;
            this.btnBangDiemTongKet.ImageOptions.SvgImage = global::QLSVHTC.Properties.Resources.reporting;
            this.btnBangDiemTongKet.Name = "btnBangDiemTongKet";
            this.btnBangDiemTongKet.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnBangDiemTongKet_ItemClick);
            // 
            // btnTaoTaiKhoan
            // 
            this.btnTaoTaiKhoan.Caption = "Tạo tài khoản";
            this.btnTaoTaiKhoan.Id = 18;
            this.btnTaoTaiKhoan.ImageOptions.SvgImage = global::QLSVHTC.Properties.Resources.add_friend;
            this.btnTaoTaiKhoan.Name = "btnTaoTaiKhoan";
            this.btnTaoTaiKhoan.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTaoTaiKhoan_ItemClick);
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Caption = "Đăng xuất";
            this.btnDangXuat.Id = 19;
            this.btnDangXuat.ImageOptions.SvgImage = global::QLSVHTC.Properties.Resources.delete;
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDangXuat_ItemClick_1);
            // 
            // ribbonPage5
            // 
            this.ribbonPage5.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup5});
            this.ribbonPage5.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("ribbonPage5.ImageOptions.Image")));
            this.ribbonPage5.Name = "ribbonPage5";
            this.ribbonPage5.Text = "Báo Cáo";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.ItemLinks.Add(this.btnBangDiemMonHoc);
            this.ribbonPageGroup5.ItemLinks.Add(this.btnDanhSachLopTC);
            this.ribbonPageGroup5.ItemLinks.Add(this.btnSinhVienDangKyLopTC);
            this.ribbonPageGroup5.ItemLinks.Add(this.btnPhieuDiem);
            this.ribbonPageGroup5.ItemLinks.Add(this.btnInHocPhi);
            this.ribbonPageGroup5.ItemLinks.Add(this.btnBangDiemTongKet);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            this.ribbonPageGroup5.Text = "Báo Cáo";
            // 
            // ribbonPage7
            // 
            this.ribbonPage7.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup4});
            this.ribbonPage7.ImageOptions.Image = global::QLSVHTC.Properties.Resources.engineering;
            this.ribbonPage7.Name = "ribbonPage7";
            this.ribbonPage7.Text = "Cấu hình";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.btnTaoTaiKhoan);
            this.ribbonPageGroup4.ItemLinks.Add(this.btnDangXuat);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.Text = "Hệ thống";
            // 
            // ribbonPageGroup6
            // 
            this.ribbonPageGroup6.Name = "ribbonPageGroup6";
            // 
            // MAGV
            // 
            this.MAGV.Name = "MAGV";
            this.MAGV.Size = new System.Drawing.Size(51, 20);
            this.MAGV.Text = "MAGV";
            // 
            // HOTEN
            // 
            this.HOTEN.Name = "HOTEN";
            this.HOTEN.Size = new System.Drawing.Size(57, 20);
            this.HOTEN.Text = "HOTEN";
            // 
            // NHOM
            // 
            this.NHOM.Name = "NHOM";
            this.NHOM.Size = new System.Drawing.Size(55, 20);
            this.NHOM.Text = "NHOM";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MAGV,
            this.HOTEN,
            this.NHOM});
            this.statusStrip1.Location = new System.Drawing.Point(0, 623);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(989, 26);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Quản Trị";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 649);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ribbonControl1);
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.Ribbon = this.ribbonControl1;
            this.Text = "Trang chủ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage4;
        private System.Windows.Forms.StatusStrip statusStrip1;
        public System.Windows.Forms.ToolStripStatusLabel MAGV;
        public System.Windows.Forms.ToolStripStatusLabel HOTEN;
        public System.Windows.Forms.ToolStripStatusLabel NHOM;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPageCategory ribbonPageCategory1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.BarButtonItem btnLopHoc;
        private DevExpress.XtraBars.BarButtonItem btnSinhVien;
        private DevExpress.XtraBars.BarButtonItem btnMonHoc;
        private DevExpress.XtraBars.BarButtonItem btnLopTinChi;
        private DevExpress.XtraBars.BarButtonItem btnDangKyLTC;
        private DevExpress.XtraBars.BarButtonItem btnChamDiem;
        private DevExpress.XtraBars.BarButtonItem btnHocPhi;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage5;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.BarButtonItem btnBangDiemMonHoc;
        private DevExpress.XtraBars.BarButtonItem btnDanhSachLopTC;
        private DevExpress.XtraBars.BarButtonItem btnSinhVienDangKyLopTC;
        private DevExpress.XtraBars.BarButtonItem btnPhieuDiem;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem btnInHocPhi;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
        private DevExpress.XtraBars.BarButtonItem btnBangDiemTongKet;
        private DevExpress.XtraBars.BarButtonItem btnTaoTaiKhoan;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage7;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.BarButtonItem btnDangXuat;
    }
}