using DevExpress.Xpo.DB;
using DevExpress.XtraEditors;
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
    public partial class frmSinhVien : DevExpress.XtraEditors.XtraForm
    {
        //SP: SP_Check_ID - SP_CheckName - SP_ChangeClassSV
        int vitri = 0;
        int sub_vitri = 0;
        string macn = "";
        private string _flagOptionSinhVien;
        private string _oldMaSV = "";
        private string _oldMaLop = "";
        public frmSinhVien()
        {
            InitializeComponent();
        }

        private void frmSinhVien_Load(object sender, EventArgs e)
        {
            DS.EnforceConstraints = false;
            this.DANGKYTableAdapter.Fill(this.DS.DANGKY);
            this.DANGKYTableAdapter.Connection.ConnectionString = Program.connstr;
            this.SINHVIENTableAdapter.Fill(this.DS.SINHVIEN);
            this.SINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
            this.LOPTableAdapter.Fill(this.DS.LOP);
            this.LOPTableAdapter.Connection.ConnectionString = Program.connstr;

            macn = ((DataRowView)bdsLop[0])["MAKHOA"].ToString().Trim();
            cmbKhoa.DataSource = Program.bds_dspm;
            cmbKhoa.DisplayMember = "TENKHOA";
            cmbKhoa.ValueMember = "TENSERVER";
            cmbKhoa.SelectedIndex = Program.mChinhanh;
            if (Program.mGroup == "KHOA")
            {
                cmbKhoa.Enabled = false;
            }

            btnGhi.Enabled = false; 
            btnPhucHoi.Enabled = false;
        }

        private void beforeButton()
        {
            //===cmb===
            cmbKhoa.Enabled = false;

            //===button===
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = false;
            btnGhi.Enabled = btnPhucHoi.Enabled = true;

            //==grid==
            LOPGridControl.Enabled = SINHVIENGridControl.Enabled = false;
        }
        private void afterButton()
        {
            //===cmb===
            cmbKhoa.Enabled = true;

            //===btn===
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
            btnGhi.Enabled = btnPhucHoi.Enabled = false;
            txbMaSV.Enabled = true;
            //==grid==
            LOPGridControl.Enabled = SINHVIENGridControl.Enabled = true;
        }
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri = bdsLop.Position;
            sub_vitri = bdsSinhVien.Position;
            _flagOptionSinhVien = "ADD";
            beforeButton();
            txbMaSV.Enabled = true;

            bdsSinhVien.AddNew();
            txbMaLop.Text = ((DataRowView)bdsLop[bdsLop.Position])["MALOP"].ToString();
            _oldMaLop = txbMaLop.Text.Trim();
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
                this.SINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                this.SINHVIENTableAdapter.Fill(this.DS.SINHVIEN);

                this.LOPTableAdapter.Connection.ConnectionString = Program.connstr;
                this.LOPTableAdapter.Fill(this.DS.LOP);

                this.DANGKYTableAdapter.Connection.ConnectionString = Program.connstr;
                this.DANGKYTableAdapter.Fill(this.DS.DANGKY);


                macn = ((DataRowView)bdsLop[0])["MAKHOA"].ToString().Trim();
            }
        }


        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(bdsSinhVien.Count == 0)
            {
                MessageBox.Show("Lớp học này không tồn tại sinh viên", "", MessageBoxButtons.OK);
                return;
            }
            vitri = bdsLop.Position;
            sub_vitri = bdsSinhVien.Position;
            _flagOptionSinhVien = "UPDATE";
            _oldMaSV = txbMaSV.Text.Trim();
            _oldMaLop = txbMaLop.Text.Trim();

            beforeButton();
            txbMaSV.Enabled = false;
        }
       
        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string masv = "";
            if(bdsSinhVien.Count > 0 && bdsDangKy.Count > 0) 
            {
                MessageBox.Show("Không thể xóa sinh viên này vì sinh viên đã đăng kí lớp tín chỉ", "", MessageBoxButtons.OK);
                return;
            }

            if (bdsSinhVien.Count == 0)
            {
                MessageBox.Show("Lớp học này không tồn tại sinh viên", "", MessageBoxButtons.OK);
                return;
            }

            if (MessageBox.Show("Bạn có thật sự muốn xóa sinh viên khỏi lớp học này ?", "", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                try
                {
                    masv = ((DataRowView)bdsSinhVien[bdsSinhVien.Position])["MASV"].ToString().Trim();
                    bdsSinhVien.RemoveCurrent();
                    this.SINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.SINHVIENTableAdapter.Update(this.DS.SINHVIEN);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi xóa sinh viên: " + ex.Message, "", MessageBoxButtons.OK);
                    this.SINHVIENTableAdapter.Fill(this.DS.SINHVIEN);
                    bdsSinhVien.Position = bdsLop.Find("MASV", masv);
                    return;
                }
            }
            if (bdsLop.Count == 0) btnXoa.Enabled = false;
        }
        private bool validatorSinhVien()
        {
            if (txbMaSV.Text.Trim() == "")
            {
                MessageBox.Show("Mã sinh viên không được thiếu!", "", MessageBoxButtons.OK);
                txbMaLop.Focus();
                return false;
            }
            if (txbHo.Text.Trim() == "")
            {
                MessageBox.Show("họ không được thiếu!", "", MessageBoxButtons.OK);
                txbHo.Focus();
                return false;
            }
            if (txbTen.Text.Trim() == "")
            {
                MessageBox.Show("Tên không được thiếu!", "", MessageBoxButtons.OK);
                txbTen.Focus();
                return false;
            }
            if (txbDiaChi.Text.Trim() == "")
            {
                MessageBox.Show("Địa chỉ không được thiếu!", "", MessageBoxButtons.OK);
                txbDiaChi.Focus();
                return false;
            }
            if (txbMaLop.Text.Trim() == "")
            {
                MessageBox.Show("Mã lớp không được thiếu!", "", MessageBoxButtons.OK);
                txbDiaChi.Focus();
                return false;
            }
            if (cbPhai.Checked == null)
            {
                MessageBox.Show("Phái không được thiếu!", "", MessageBoxButtons.OK);
                cbPhai.Focus();
                return false;
            }
            if (cbDangNghiHoc.Checked == null)
            {
                MessageBox.Show("Đang nghỉ học không được thiếu!", "", MessageBoxButtons.OK);
                cbDangNghiHoc.Focus();
                return false;
            }
            if (_flagOptionSinhVien == "ADD")
            {
                string query1 = " DECLARE @return_value INT " +

                            " EXEC @return_value = [dbo].[SP_CHECKID] " +

                            " @Code = N'" + txbMaSV.Text.Trim() + "',  " +

                            " @Type = N'MASV' " +

                            " SELECT  'Return Value' = @return_value ";

                int resultMa = Program.CheckDataHelper(query1);
                if (resultMa == -1)
                {
                    XtraMessageBox.Show("Lỗi kết nối với database. Mời bạn xem lại", "", MessageBoxButtons.OK);
                    this.Close();
                }
                if (resultMa == 1)
                {
                    XtraMessageBox.Show("Mã Sinh Viên đã tồn tại. Mời bạn nhập mã khác !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (resultMa == 2)
                {
                    XtraMessageBox.Show("Mã Sinh Viên đã tồn tại ở Khoa khác. Mời bạn nhập lại !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            if (_flagOptionSinhVien == "UPDATE") //==không sửa mã sinh viên
            {
                
                //if (!this.txbMaSV.Text.Trim().ToString().Equals(_oldMaSV))
                //{
                //    string query2 = " DECLARE @return_value INT " +

                //            " EXEC @return_value = [dbo].[SP_CHECKID] " +

                //            " @Code = N'" + txbMaSV.Text.Trim() + "',  " +

                //            " @Type = N'MASV' " +

                //            " SELECT  'Return Value' = @return_value ";

                //    int resultMa = Program.CheckDataHelper(query2);
                //    if (resultMa == -1)
                //    {
                //        XtraMessageBox.Show("Lỗi kết nối với database. Mời bạn xem lại", "", MessageBoxButtons.OK);
                //        this.Close();
                //    }
                //    if (resultMa == 1)
                //    {
                //        XtraMessageBox.Show("Mã Sinh Viên đã tồn tại. Mời bạn nhập mã khác !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        return false;
                //    }
                //    if (resultMa == 2)
                //    {
                //        XtraMessageBox.Show("Mã Sinh Viên đã tồn tại ở Khoa khác. Mời bạn nhập lại !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //        return false;
                //    }
                //}

            }
            return true;
        }
        //CHUYỂN SINH VIÊN SANG LỚP QUA KHOA KHÁC -> LỖI CÒN BẢN GHI 
        //private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    if (validatorSinhVien() == true)
        //    {
        //        try
        //        {
        //            bdsSinhVien.EndEdit();
        //            bdsSinhVien.ResetCurrentItem();
        //            this.SINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;

        //            string newClass = txbMaLop.Text.Trim();
        //            bool isClassNotChange = _oldMaLop.Equals(newClass); // Check class change
        //            if (isClassNotChange == false)
        //            {
        //                string query2 = " DECLARE @return_value INT " +

        //                    " EXEC @return_value = [dbo].[SP_CHECKID] " +

        //                    " @Code = N'" + newClass + "',  " +

        //                    " @Type = N'MALOP' " +

        //                    " SELECT  'Return Value' = @return_value ";
        //                int resultMa = Program.CheckDataHelper(query2);

        //                DateTime selectedDate = (DateTime)cmbNgaySinh.EditValue;
        //                string formattedDate = selectedDate.ToString("dd-MM-yyyy");
        //                if (_flagOptionSinhVien == "UPDATE" && resultMa == 0)
        //                {
        //                    XtraMessageBox.Show("Lớp bạn nhập không tồn tại trong các Khoa! ", "", MessageBoxButtons.OK);
        //                    return;
        //                }
        //                if (resultMa == 2)
        //                {
        //                    // Department change confirmed 
        //                    String query = "EXEC sp_ChangeClassSV \n"
        //                               + "@MASV = N'" + txbMaSV.Text + "', @HO = N'" + txbHo.Text + "', @TEN = N'" + txbTen.Text + "', @PHAI = " + (cbPhai.Checked ? 1 : 0)
        //                               + ",@DIACHI = N'" + txbDiaChi.Text + "', @NGAYSINH = N'" + formattedDate + "', @MALOP = N'" + txbMaLop.Text
        //                               + "',@DANGHIHOC = " + (cbDangNghiHoc.Checked ? 1 : 0);
        //                    if (Program.ExecSqlNonQuery(query) == 0)
        //                    {
        //                        MessageBox.Show("Chuyển lớp và cập nhật thành công!" + " " + macn + " " + newClass + " " + _oldMaLop);
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                this.SINHVIENTableAdapter.Update(this.DS.SINHVIEN);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Lỗi ghi lớp học: " + ex.Message, "", MessageBoxButtons.OK);
        //            return;
        //        }
        //        afterButton();
        //    }
        //}
        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (validatorSinhVien() == true)
            {
                try
                {
                    bdsSinhVien.EndEdit();
                    bdsSinhVien.ResetCurrentItem();
                    this.SINHVIENTableAdapter.Connection.ConnectionString = Program.connstr;
                    this.SINHVIENTableAdapter.Update(this.DS.SINHVIEN);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi ghi sinh viên: " + ex.Message, "", MessageBoxButtons.OK);
                    return;
                }
                afterButton();
            }
            else
            {
                return;
            }

        }
        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsSinhVien.CancelEdit();
            afterButton();
            frmSinhVien_Load(sender, e);
            bdsLop.Position = vitri;
            bdsSinhVien.Position = sub_vitri;
        }

        private void btnLamMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                this.LOPTableAdapter.Fill(this.DS.LOP);
                this.SINHVIENTableAdapter.Fill(this.DS.SINHVIEN);
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
    }
}