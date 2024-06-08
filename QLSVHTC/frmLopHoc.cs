using DevExpress.XtraEditors;
using DevExpress.XtraReports.Wizards.Templates;
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
    public partial class frmLopHoc : DevExpress.XtraEditors.XtraForm
    {
        //SP: SP_CheckID - SP_CheckName - SP_ChangeClass
        int vitri = 0; //selected row in the table 
        string macn = "";
        private string _flagOptionLop;
        private string _oldTenLop = "";
        public frmLopHoc()
        {
            InitializeComponent();
        }

        private void frmClassRoom_Load(object sender, EventArgs e)
        {
            DS.EnforceConstraints = false;
            this.SINHVIENTableAdapter.Fill(this.DS.SINHVIEN);
            this.SINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.LOPTableAdapter.Connection.ConnectionString = Program.connstr;
            this.LOPTableAdapter.Fill(this.DS.LOP);
            macn = ((DataRowView)bdsLop[0])["MAKHOA"].ToString().Trim();
            
            cmbKhoa.DataSource = Program.bds_dspm;
            cmbKhoa.DisplayMember = "TENKHOA";
            cmbKhoa.ValueMember = "TENSERVER";
            cmbKhoa.SelectedIndex = Program.mChinhanh;

            if (Program.mGroup == "KHOA")
            {
                cmbKhoa.Enabled = false;
            }
            txbMaKhoa.Enabled = false;

            btnGhi.Enabled = false;
            btnPhucHoi.Enabled = false;
        }

        private void cmbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbKhoa.SelectedValue.ToString().Equals("ASUS-VIVOBOOK15\\SQL3"))
            {
                cmbKhoa.SelectedIndex = Program.mChinhanh;
                MessageBox.Show("Lỗi kết nối về chi nhánh mới", "", MessageBoxButtons.OK);
                return;
            }
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
                this.SINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                this.SINHVIENTableAdapter.Fill(this.DS.SINHVIEN);

                this.LOPTableAdapter.Connection.ConnectionString = Program.connstr;
                this.LOPTableAdapter.Fill(this.DS.LOP);

                macn = ((DataRowView)bdsLop[0])["MAKHOA"].ToString().Trim();
            }
        }
        private void beforeButton()
        {
            //===cmb===
            cmbKhoa.Enabled = false;

            //===button===
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = false;
            btnGhi.Enabled = btnPhucHoi.Enabled = true;

            //==grid==
            lOPGridControl.Enabled = false;
        }
        private void afterButton()
        {
            //===cmb===
            cmbKhoa.Enabled = true;
            //===btn===
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
            btnGhi.Enabled = btnPhucHoi.Enabled = false;
            txbMaLop.Enabled = true;
            txbMaKhoa.Enabled = false;
            //==grid==
            lOPGridControl.Enabled = true;
        }
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsLop.Position;
            beforeButton();
            _flagOptionLop = "ADD";
            bdsLop.AddNew(); // new row in bds
            txbMaKhoa.Text = macn;
        }

        private bool validatorLopHoc()
        {
            if (txbMaLop.Text.Trim() == "")
            {
                MessageBox.Show("Mã lớp không được thiếu!", "", MessageBoxButtons.OK);
                txbMaLop.Focus();
                return false;
            }
            if (txbTenLop.Text.Trim() == "")
            {
                MessageBox.Show("Tên lớp không được thiếu!", "", MessageBoxButtons.OK);
                txbTenLop.Focus();
                return false;
            }
            if (txbKhoaHoc.Text.Trim() == "")
            {
                MessageBox.Show("Khóa học không được thiếu!", "", MessageBoxButtons.OK);
                txbKhoaHoc.Focus();
                return false;
            }
            if (txbMaKhoa.Text.Trim() == "")
            {
                MessageBox.Show("Mã khoa không được thiếu!", "", MessageBoxButtons.OK);
                txbMaKhoa.Focus();
                return false;
            }

            //==check ADD==
            if (_flagOptionLop == "ADD")
            {
                //TODO: Check mã lớp có tồn tại chưa
                string query1 = "DECLARE  @return_value int \n"
                            + "EXEC  @return_value = SP_CHECKID \n"
                            + "@Code = N'" + txbMaLop.Text + "',@Type = N'MALOP' \n"
                            + "SELECT  'Return Value' = @return_value ";

                int resultMa = Program.CheckDataHelper(query1);
                if (resultMa == -1)
                {
                    XtraMessageBox.Show("Lỗi kết nối với database. Mời ban xem lại !", "", MessageBoxButtons.OK);
                    this.Close();
                }
                if (resultMa == 1)
                {
                    XtraMessageBox.Show("Mã lớp đã tồn tại ở Khoa hiên tại !", "", MessageBoxButtons.OK);

                    return false;
                }
                if (resultMa == 2)
                {
                    XtraMessageBox.Show("Mã lớp đã tồn tại ở Khoa khác !", "", MessageBoxButtons.OK);

                    return false;
                }

                // TODO : Check tên lớp có tồn tại chưa
                string query2 = "DECLARE @return_value int \n"
                               + "EXEC @return_value = SP_CHECKNAME \n"
                               + "@Name = N'" + txbTenLop.Text + "', @Type = N'TENLOP' \n"
                               + "SELECT 'Return Value' = @return_value ";
                int resultTen = Program.CheckDataHelper(query2);
                if (resultTen == -1)
                {
                    XtraMessageBox.Show("Lỗi kết nối với Database. Mời bạn xem lại !", "", MessageBoxButtons.OK);
                    this.Close();
                }
                if (resultTen == 1)
                {
                    XtraMessageBox.Show("Tên lớp đã có rồi !", "", MessageBoxButtons.OK);

                    return false;
                }
                if (resultTen == 2)
                {
                    XtraMessageBox.Show("Tên lớp đã tồn tại ở Khoa khác !", "", MessageBoxButtons.OK);
                    return false;
                }
            }

            //==check UPDATE==
            if (_flagOptionLop == "UPDATE")
            {
                if (!this.txbTenLop.Text.Trim().ToString().Equals(_oldTenLop))
                {
                    // TODO : Check tên lớp có tồn tại chưa => Mã lớp không cho sửa 
                    string query2 = "DECLARE @return_value int \n"
                                   + "EXEC @return_value = SP_CHECKNAME \n"
                                   + "@Name = N'" + txbTenLop.Text + "', @Type = N'TENLOP' \n"
                                   + "SELECT 'Return Value' = @return_value ";
                    int resultTen = Program.CheckDataHelper(query2);
                    if (resultTen == -1)
                    {
                        XtraMessageBox.Show("Lỗi kết nối với Database. Mời bạn xem lại !", "", MessageBoxButtons.OK);
                        this.Close();
                    }
                    if (resultTen == 1)
                    {
                        XtraMessageBox.Show("Tên lớp đã có rồi !", "", MessageBoxButtons.OK);
                        return false;
                    }
                    if (resultTen == 2)
                    {
                        XtraMessageBox.Show("Tên lớp đã tồn tại ở Khoa khác !", "", MessageBoxButtons.OK);
                        return false;
                    }
                }
            }

            return true;
        }
        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (validatorLopHoc() == true)
            {
                try
                {
                    bdsLop.EndEdit();
                    bdsLop.ResetCurrentItem();
                    this.LOPTableAdapter.Connection.ConnectionString = Program.connstr;

                    string selectedDepartment = ((DataRowView)bdsLop[0])["MAKHOA"].ToString().Trim();
                    string newDepartment = txbMaKhoa.Text.Trim();
                    bool isDepartmentNotChanged = selectedDepartment.Equals(newDepartment); // Check department change
                    String text = isDepartmentNotChanged.ToString();
                    if (isDepartmentNotChanged == false) //có thay đổi 
                    {
                        if (newDepartment != "CNTT" && newDepartment != "VT")
                        {
                            XtraMessageBox.Show("Lỗi kết nối về Khoa, Mời bạn nhập đúng Khoa!", "", MessageBoxButtons.OK);
                            return;
                        }

                        // Department change confirmed 
                        String query = "EXEC sp_ChangeClass \n"
                                   + "@MALOP = N'" + txbMaLop.Text + "', @TENLOP = N'" + txbTenLop.Text + "', @KHOAHOC = N'" + txbKhoaHoc.Text + "', @MAKHOA = N'" + txbMaKhoa.Text + "'";
                        if (Program.ExecSqlNonQuery(query) == 0)
                        {
                            MessageBox.Show("Chuyển Khoa và cập nhật thành công!" + selectedDepartment + " " + newDepartment);
                        }
                    }
                    else this.LOPTableAdapter.Update(this.DS.LOP); //không có thay đổi mã khoa
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi ghi lớp học: " + ex.Message, "", MessageBoxButtons.OK);
                    return;
                }
                afterButton();
            }
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsLop.Position;
            beforeButton();
            txbMaKhoa.Enabled = true;
            txbMaLop.Enabled = false;
            _flagOptionLop = "UPDATE";
            _oldTenLop = this.txbTenLop.Text.Trim();

        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            string malop = "";
            if (bdsSinhVien.Count > 0) //lay sinh vien ra 
            {
                MessageBox.Show("Không thể xóa lớp học này vì đã có sinh viên", "", MessageBoxButtons.OK);
                return;
            }
            if (MessageBox.Show("Bạn có thật sự muốn xóa lớp học này ?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    malop = ((DataRowView)bdsLop[bdsLop.Position])["MALOP"].ToString();
                    bdsLop.RemoveCurrent();
                    this.LOPTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.LOPTableAdapter.Update(this.DS.LOP);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa lớp học: " + ex.Message, "", MessageBoxButtons.OK);
                    this.LOPTableAdapter.Fill(this.DS.LOP);
                    bdsLop.Position = bdsLop.Find("MALOP", malop); //BACK TO CURRENT POSITION
                    return;
                }
            }
            if (bdsLop.Count == 0) btnXoa.Enabled = false;

        }


        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsLop.CancelEdit();
            afterButton();
            frmClassRoom_Load(sender, e);
            if (vitri > 0) bdsLop.Position = vitri;
        }

        private void btnLamMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.LOPTableAdapter.Fill(this.DS.LOP);
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

        private void panelControl2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}