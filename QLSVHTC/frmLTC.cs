﻿using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSVHTC
{
    public partial class frmLTC : DevExpress.XtraEditors.XtraForm
    {
        int vitri = 0;
        string macn = "";

        public frmLTC()
        {
            InitializeComponent();
        }
        ///ed

        private void frmLTC_Load(object sender, EventArgs e)
        {
            loadGVcombobox();
            DS.EnforceConstraints = false;
            
            // TODO: This line of code loads data into the 'DS.MONHOC' table. You can move, or remove it, as needed.
            this.MONHOCTableAdapter.Fill(this.DS.MONHOC);
            this.MONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
            // TODO: This line of code loads data into the 'DS.GIANGVIEN' table. You can move, or remove it, as needed.
            this.GIANGVIENTableAdapter.Fill(this.DS.GIANGVIEN);
            this.GIANGVIENTableAdapter.Connection.ConnectionString = Program.connstr;
            // TODO: This line of code loads data into the 'dS.LOPTINCHI' table. You can move, or remove it, as needed.
            this.LOPTINCHITableAdapter.Fill(this.DS.LOPTINCHI);
            this.LOPTINCHITableAdapter.Connection.ConnectionString = Program.connstr;

            macn = ((DataRowView)bdsLTC[0])["MAKHOA"].ToString();
            cmbKhoa.DataSource = Program.bds_dspm;
            cmbKhoa.DisplayMember = "TENKHOA";
            cmbKhoa.ValueMember = "TENSERVER";
            cmbKhoa.SelectedIndex = Program.mChinhanh;
            if (Program.mGroup == "KHOA")
            {
                cmbKhoa.Enabled = false;
            }
            cmbTenMH.DataSource = bdsMH;
            cmbTenMH.DisplayMember = "TENMH";
            cmbTenMH.ValueMember = "MAMH";
            
            cmbTenGV.DataSource = bdsGV;
            cmbTenGV.DisplayMember = "TEN";
            cmbTenGV.ValueMember = "MAGV";
        }
        void loadGVcombobox()
        {
            DataTable dt = new DataTable();
            string cmd = "EXEC dbo.SP_GetDSGV";
            dt = Program.ExecSqlDataTable(cmd);
            BindingSource bdsgv = new BindingSource();
            bdsgv.DataSource = dt;
            cmbTenGV.DataSource = bdsgv;
            cmbTenGV.DisplayMember = "HOTEN";
            cmbTenGV.ValueMember = "MAGV";
        }
        private void hOCKYSpinEdit_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void cmbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbKhoa.SelectedValue.ToString() == "System.Data.DataRowView")
                return;
            Program.servername = cmbKhoa.SelectedValue.ToString();
            if (cmbKhoa.SelectedIndex != Program.mChinhanh)
            {
                Program.mlogin = Program.remotelogin;
                Program.password = Program.remotepassword;
            }
            else
            {
                Program.mlogin = Program.mloginDN;
                Program.password = Program.passwordDN;
            }
            if (Program.KetNoi() == 0)
            {
                MessageBox.Show("Lỗi kết nối về chi nhánh mới", "", MessageBoxButtons.OK);
            }
            else
            {
                //loadGVcombobox();
                this.LOPTINCHITableAdapter.Connection.ConnectionString = Program.connstr;
                this.LOPTINCHITableAdapter.Fill(this.DS.LOPTINCHI);
                this.GIANGVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                this.GIANGVIENTableAdapter.Fill(this.DS.GIANGVIEN);
                macn = ((DataRowView)bdsLTC[0])["MAKHOA"].ToString();
            }
        }
        private void cmbTenMH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTenMH.SelectedValue != null)
            {
                txbMaMH.Text = cmbTenMH.SelectedValue.ToString();
            }
        }

        private void cmbTenGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTenGV.SelectedValue != null)
            {
                txbMaGV.Text = cmbTenGV.SelectedValue.ToString();
            }
        }
        private void txbMaMH_EditValueChanged(object sender, EventArgs e)
        {
            //cmbTenMH.SelectedValue = txbMaMH.Text;
        }

        private void txbMaGV_EditValueChanged(object sender, EventArgs e)
        {
            //cmbTenGV.SelectedValue = txbMaGV.Text;
        }

        private void txbMaKhoa_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string maloptc = "";
            if (bdsGV.Count > 0)
            {
                MessageBox.Show("Không thể xóa lớp này vì đã có sinh viên", "", MessageBoxButtons.OK);
                return;
            }
            if (MessageBox.Show("Bạn có thật sự muốn xóa lớp này ?", "Xác nhận", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    maloptc = ((DataRowView)bdsLTC[bdsLTC.Position])["MALTC"].ToString();
                    bdsLTC.RemoveCurrent();
                    this.LOPTINCHITableAdapter.Connection.ConnectionString = Program.connstr;
                    this.LOPTINCHITableAdapter.Update(this.DS.LOPTINCHI);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa lớp : " + ex.Message, "", MessageBoxButtons.OK);
                    this.LOPTINCHITableAdapter.Fill(this.DS.LOPTINCHI);
                    bdsLTC.Position = bdsLTC.Find("MALTC", maloptc);
                    return;
                }
            }
            if (bdsLTC.Count == 0) btnXoa.Enabled = false;
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (SpinHocKy.Value == 0)
            {
                MessageBox.Show("Học kì không được thiếu!", "", MessageBoxButtons.OK);
                SpinHocKy.Focus();
                return;
            }
            if (SpinSVTT.Value == 0)
            {
                MessageBox.Show("Số sinh viên tối thiểu không được thiếu!", "", MessageBoxButtons.OK);
                SpinSVTT.Focus();
                return;
            }
            if (SpinNhom.Value == 0)
            {
                MessageBox.Show("Nhóm không được thiếu!", "", MessageBoxButtons.OK);
                SpinNhom.Focus();
                return;
            }
            if (txbMaKhoa.Text.Trim() == "")
            {
                MessageBox.Show("Mã khoa không được thiếu!", "", MessageBoxButtons.OK);
                txbMaKhoa.Focus();
                return;
            }
            if (txbMaMH.Text.Trim() == "")
            {
                MessageBox.Show("Mã môn học không được thiếu!", "", MessageBoxButtons.OK);
                txbMaKhoa.Focus();
                return;
            }
            if (txbMaGV.Text.Trim() == "")
            {
                MessageBox.Show("Mã giảng viên không được thiếu!", "", MessageBoxButtons.OK);
                txbMaKhoa.Focus();
                return;
            }
            if (txbNienKhoa.Text.Trim() == "")
            {
                MessageBox.Show("Niên khóa không được thiếu!", "", MessageBoxButtons.OK);
                txbMaKhoa.Focus();
                return;
            }
            try
            {
                bdsLTC.EndEdit();
                bdsLTC.ResetCurrentItem();
                this.LOPTINCHITableAdapter.Connection.ConnectionString = Program.connstr;
                this.LOPTINCHITableAdapter.Update(this.DS.LOPTINCHI);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi ghi lớp tín chỉ: " + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
            lOPTINCHIGridControl.Enabled = true;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
            btnGhi.Enabled = btnPhucHoi.Enabled = true;
        }

        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnLamMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.LOPTINCHITableAdapter.Fill(this.DS.LOPTINCHI);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Reload: " + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsLTC.Position;
            panelControl2.Enabled = true;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = btnPhucHoi.Enabled = false;
            btnGhi.Enabled = true;
            lOPTINCHIGridControl.Enabled = false;
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsLTC.Position;
            panelControl2.Enabled = true;
            bdsLTC.AddNew();
            txbMaKhoa.Text = macn;
            cmbTenGV.SelectedIndex = 0;
            cmbTenMH.SelectedIndex = 0;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = false;
            btnGhi.Enabled = btnPhucHoi.Enabled = true;
            lOPTINCHIGridControl.Enabled = false;
        }
    }
}
