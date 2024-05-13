﻿using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSVHTC
{
    public partial class frmDangKy : DevExpress.XtraEditors.XtraForm
    {
        private BindingSource bdsSinhVien = new BindingSource();
        private BindingSource bdsLopTinchi = new BindingSource();
        private BindingSource bdsDSLTC_HUY = new BindingSource();
        public frmDangKy()
        {
            InitializeComponent();
        }

        private void btnTimMSSV_Click(object sender, EventArgs e)
        {
            if (txbMaSV.Text.Trim() == "")
            {
                MessageBox.Show("Mã sinh viên không được thiếu!", "", MessageBoxButtons.OK);
                txbMaSV.Focus();
                return;
            }
            if (txbMaSV.Text != Program.username)
            {
                MessageBox.Show("Bạn không phải là tài khoản sinh viên này!", "", MessageBoxButtons.OK);
                txbMaSV.Focus();
                return;
            }
            txbMSVDK.Text = txbMaSV.Text;
            string cmd = "EXEC dbo.SP_getInfoSVDKI '" + txbMaSV.Text + "'";
            string cmd1 = "EXEC [SP_LIST_SVHUYDANGKY] '" + txbMaSV.Text + "'";
            DataTable tableSV = Program.ExecSqlDataTable(cmd);
            DataTable tableDSLTC_HUY = Program.ExecSqlDataTable(cmd1);

            this.bdsSinhVien.DataSource = tableSV;
            this.bdsDSLTC_HUY.DataSource = tableDSLTC_HUY;
            this.gridSV.DataSource = this.bdsSinhVien;
            this.gridHuyLTC.DataSource = this.bdsDSLTC_HUY;
        }
        void loadcmbNienkhoa()
        {
            DataTable dt = new DataTable();
            string cmd = "EXEC dbo.GetAllNienKhoa";
            dt = Program.ExecSqlDataTable(cmd);

            BindingSource bdsNienKhoa = new BindingSource();
            bdsNienKhoa.DataSource = dt;
            cmbNienKhoa.DataSource = bdsNienKhoa;
            cmbNienKhoa.DisplayMember = "NIENKHOA";
            cmbNienKhoa.ValueMember = "NIENKHOA";
        }
        void loadcmbHocKi(string nienkhoa)
        {
            DataTable dt = new DataTable();
            string cmd = "EXEC dbo.GetAllHocKy '" + nienkhoa + "'";
            dt = Program.ExecSqlDataTable(cmd);

            BindingSource bdsHocKi = new BindingSource();
            bdsHocKi.DataSource = dt;
            cmbHocKy.DataSource = bdsHocKi;
            cmbHocKy.DisplayMember = "HOCKY";
            cmbHocKy.ValueMember = "HOCKY";
        }
        private void frmDangKy_Load(object sender, EventArgs e)
        {
            loadcmbNienkhoa();
            cmbNienKhoa.SelectedIndex = 0;  
            txbMaSV.Text = Program.username;
        }

        private void cmbNienKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadcmbHocKi(cmbNienKhoa.Text);
            //cmbHocKy.SelectedIndex = 0;

        }

        private void btnTimNKHK_Click(object sender, EventArgs e)
        {
            string cmd = "EXEC [dbo].[SP_InDanhSachLopTinChi] '" + cmbNienKhoa.Text + "', '" + cmbHocKy.Text + "'";
            DataTable tableLopTC = Program.ExecSqlDataTable(cmd);
            this.bdsLopTinchi.DataSource = tableLopTC;
            this.gridLTC.DataSource = this.bdsLopTinchi;
        }
        private void btnDangKi_Click(object sender, EventArgs e)
        {
            if (txbMSVDK.Text.Trim() == "")
            {
                MessageBox.Show("Mã sinh viên không được thiếu!", "", MessageBoxButtons.OK);
                txbMSVDK.Focus();
                return;
            }
            if (txbMLTCDK.Text.Trim() == "")
            {
                MessageBox.Show("Mã lớp tín chỉ không được thiếu!", "", MessageBoxButtons.OK);
                txbMLTCDK.Focus();
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn đăng kí lớp học này ?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                SqlConnection conn = new SqlConnection(Program.connstr);
                // bắt đầu transaction
                SqlTransaction tran;

                conn.Open();
                tran = conn.BeginTransaction();

                try
                {
                    SqlCommand cmd = new SqlCommand("[SP_XULY_LTC]", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;
                    cmd.Transaction = tran;

                    cmd.Parameters.Add(new SqlParameter("@MASV", txbMaSV.Text));
                    cmd.Parameters.Add(new SqlParameter("@MALTC", txbMLTCDK.Text));
                    cmd.Parameters.Add(new SqlParameter("@Type", 1));

                    cmd.ExecuteNonQuery();
                    tran.Commit();
                    XtraMessageBox.Show("Thao tác đăng kí thành công!", "", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("Lỗi trong quá trình đăng kí: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                    string cmd1 = "EXEC dbo.SP_LIST_SVHUYDANGKY '" + txbMaSV.Text + "'";
                    DataTable tableDSLTC_HUY = Program.ExecSqlDataTable(cmd1);
                    this.bdsDSLTC_HUY.DataSource = tableDSLTC_HUY;
                    this.gridHuyLTC.DataSource = this.bdsDSLTC_HUY;
                    btnTimNKHK.PerformClick();
                }
            }
            else return;
            
        }

        private void btnHuyDangKy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (txbMSVDK.Text.Trim() == "")
            {
                MessageBox.Show("Mã sinh viên không được thiếu!", "", MessageBoxButtons.OK);
                txbMSVDK.Focus();
                return;
            }
            if (bdsDSLTC_HUY.Position < 0)
            {
                MessageBox.Show("Bạn chưa chọn lớp tín chỉ để hủy");
                gridHuyLTC.Focus();
                return;
            }
            if (MessageBox.Show("Bạn có chắc chắn muốn hủy đăng kí lớp học này ?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                string maltc = "";
                if (((DataRowView)bdsDSLTC_HUY[bdsDSLTC_HUY.Position])["MALTC"] != null)
                {
                    maltc = ((DataRowView)bdsDSLTC_HUY[bdsDSLTC_HUY.Position])["MALTC"].ToString();
                }
                SqlConnection conn = new SqlConnection(Program.connstr);
                // bắt đầu transaction
                SqlTransaction tran;

                conn.Open();
                tran = conn.BeginTransaction();

                try
                {
                    SqlCommand cmd = new SqlCommand("[SP_XULY_LTC]", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = conn;
                    cmd.Transaction = tran;

                    cmd.Parameters.Add(new SqlParameter("@MASV", txbMaSV.Text));
                    cmd.Parameters.Add(new SqlParameter("@MALTC", maltc));
                    cmd.Parameters.Add(new SqlParameter("@Type", 2));

                    cmd.ExecuteNonQuery();
                    tran.Commit();
                    XtraMessageBox.Show("Thao tác hủy đăng kí thành công!", "", MessageBoxButtons.OK);
                }
                catch (Exception ex)
                {
                    tran.Rollback();
                    MessageBox.Show("Lỗi trong quá trình hủy đăng kí: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                    string cmd1 = "EXEC dbo.SP_LIST_SVHUYDANGKY '" + txbMaSV.Text + "'";
                    DataTable tableDSLTC_HUY = Program.ExecSqlDataTable(cmd1);
                    this.bdsDSLTC_HUY.DataSource = tableDSLTC_HUY;
                    this.gridHuyLTC.DataSource = this.bdsDSLTC_HUY;
                    btnTimNKHK.PerformClick();
                }
            }
            else return;
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void gridLTC_MouseClick(object sender, MouseEventArgs e)
        {
            if (bdsLopTinchi.Count > 0)
            {
                txbMLTCDK.Text = ((DataRowView)bdsLopTinchi[bdsLopTinchi.Position])["MALTC"].ToString();
            }
        }

    }
}