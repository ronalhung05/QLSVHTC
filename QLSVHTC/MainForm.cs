using System;
using System.Windows.Forms;

namespace QLSVHTC
{
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public MainForm()
        {
            InitializeComponent();
        }
        String group = "";
        private void MainForm_Load(object sender, EventArgs e)
        {
            this.MAGV.Text = "MA: " + Program.username;
            this.HOTEN.Text = "| HO TEN: " + Program.mHoten;
            this.NHOM.Text = "| NHOM: " + Program.mGroup;
            this.group = Program.mGroup;

            switch (this.group)
            {
                case "PGV":
                    btnInHocPhi.Enabled = false;
                    btnHocPhi.Enabled = false;
                    break;

                case "KHOA":
                    btnInHocPhi.Enabled = false;
                    btnHocPhi.Enabled = false;
                    btnDangKyLTC.Enabled = false;
                    btnTaoTaiKhoan.Enabled = false;
                    break;

                case "PKT":
                    // Cau hinh
                    btnLopHoc.Enabled = false;
                    btnSinhVien.Enabled = false;
                    btnMonHoc.Enabled = false;
                    btnLopTinChi.Enabled = false;
                    btnChamDiem.Enabled = false;
                    btnDangKyLTC.Enabled = false;
                    //Bao cao
                    btnBangDiemMonHoc.Enabled = false;
                    btnDanhSachLopTC.Enabled = false;
                    btnSinhVienDangKyLopTC.Enabled = false;
                    btnPhieuDiem.Enabled = false;
                    btnBangDiemTongKet.Enabled = false;

                    btnTaoTaiKhoan.Enabled = false;
                    break;
                case "SV":
                    btnLopHoc.Enabled = false;
                    btnSinhVien.Enabled = false;
                    btnMonHoc.Enabled = false;
                    btnLopTinChi.Enabled = false;
                    btnChamDiem.Enabled = false;
                    btnInHocPhi.Enabled = false;
                    btnHocPhi.Enabled = false;
                    //Bao cao
                    btnBangDiemMonHoc.Enabled = false;
                    btnDanhSachLopTC.Enabled = false;
                    btnSinhVienDangKyLopTC.Enabled = false;
                    btnBangDiemTongKet.Enabled = false;

                    btnTaoTaiKhoan.Enabled = false;
                    break;

            }
        }
        private Form CheckExists(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == ftype)
                    return f;
            }
            return null;
        }


        private void btnLH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            Form frm = this.CheckExists(typeof(frmLopHoc));
            if (frm != null) { frm.Activate(); }
            else
            {
                frmLopHoc f = new frmLopHoc();
                f.MdiParent = this;
                f.Show();
            }
        }


        private void btnMonHoc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            Form frm = this.CheckExists(typeof(frmMonHoc));
            if (frm != null) { frm.Activate(); }
            else
            {
                frmMonHoc f = new frmMonHoc();
                f.MdiParent = this;
                f.Show();
            }


        }

        private void btnSV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            Form frm = this.CheckExists(typeof(frmSinhVien));
            if (frm != null) { frm.Activate(); }
            else
            {
                frmSinhVien f = new frmSinhVien();
                f.MdiParent = this;
                f.Show();
            }


        }

        private void btnLTC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            Form frm = this.CheckExists(typeof(frmLTC));
            if (frm != null) { frm.Activate(); }
            else
            {
                frmLTC f = new frmLTC();
                f.MdiParent = this;
                f.Show();
            }

        }

        private void btnDangKyLTC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            Form frm = this.CheckExists(typeof(frmDangKy));
            if (frm != null) { frm.Activate(); }
            else
            {
                frmDangKy f = new frmDangKy();
                f.MdiParent = this;
                f.Show();
            }

        }

        private void btnChamDiem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            Form frm = this.CheckExists(typeof(frmDiem));
            if (frm != null) { frm.Activate(); }
            else
            {
                frmDiem f = new frmDiem();
                f.MdiParent = this;
                f.Show();
            }


        }

        private void BtnHocPhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            Form frm = this.CheckExists(typeof(frmHocPhi));
            if (frm != null) { frm.Activate(); }
            else
            {
                frmHocPhi f = new frmHocPhi();
                f.MdiParent = this;
                f.Show();
            }

        }

        private void btnBDMH_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            Form frm = this.CheckExists(typeof(frptBDMH));
            if (frm != null) { frm.Activate(); }
            else
            {
                frptBDMH f = new frptBDMH();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void btnDSLTC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frptDSLTC));
            if (frm != null) { frm.Activate(); }
            else
            {
                frptDSLTC f = new frptDSLTC();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnSVDKLTC_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frptSVDKLTC));
            if (frm != null) { frm.Activate(); }
            else
            {
                frptSVDKLTC f = new frptSVDKLTC();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnDiemSV_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frptDiemSV));
            if (frm != null) { frm.Activate(); }
            else
            {
                frptDiemSV f = new frptDiemSV();
                f.MdiParent = this;
                f.Show();
            }
        }



        private void btnTaoTaiKhoan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frmTaoTaiKhoan));
            if (frm != null) { frm.Activate(); }
            else
            {
                frmTaoTaiKhoan f = new frmTaoTaiKhoan();
                f.MdiParent = this;
                f.Show();
            }
        }

        private void btnInHocPhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            Form frm = this.CheckExists(typeof(frptInHP));
            if (frm != null) { frm.Activate(); }
            else
            {
                frptInHP f = new frptInHP();
                f.MdiParent = this;
                f.Show();
            }


        }

        private void btnDangXuat_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (Form f in this.MdiChildren)
            {
                f.Close();
            }
            Form frmDangNhap = new frmDangNhap();

            this.Close();
        }

        private void btnBangDiemTongKet_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form frm = this.CheckExists(typeof(frpt_InBangDiemTK));
            if (frm != null) { frm.Activate(); }
            else
            {
                frpt_InBangDiemTK f = new frpt_InBangDiemTK();
                f.MdiParent = this;
                f.Show();
            }
        }

    }
}