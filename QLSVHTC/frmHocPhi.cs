using DevExpress.DXperience.Demos.CodeDemo.Helpers;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace QLSVHTC
{
    public partial class frmHocPhi : DevExpress.XtraEditors.XtraForm
    {
        //SP sử dụng
        //SP_GetInfoSV_HP - SP_GetDSHP_SV - SV_DONGTIEN
        //TAO_THONGTINHOCPHI - SP_GetCTHP_SV

        BindingSource bdsHocPhi = new BindingSource(); //sử dụng cho binding tự định nghĩa 
        BindingSource bdsCTHP = new BindingSource();

        int vitri_HP = 0;
        int vitri_CTHP = 0;

        public frmHocPhi()
        {
            InitializeComponent();
        }

        void loadHP()
        {
            string cmd1 = "EXEC [dbo].[SP_GetInfoSV_HP] '" + txbMaSV.Text + "'";
            SqlDataReader reader = Program.ExecSqlDataReader(cmd1);
            if (reader.HasRows == false) //không tìm thấy id 
            {
                MessageBox.Show("Mã sinh viên không tồn tại");
                reader.Close();
                return;
            }
            reader.Read();
            txbTenSV.Text = reader.GetString(0);
            txbMaLop.Text = reader.GetString(1);
            reader.Close();
            Program.conn.Close();

            string cmd2 = "EXEC dbo.SP_GetDSHP_SV '" + txbMaSV.Text + "'";
            DataTable tableHocPhi = Program.ExecSqlDataTable(cmd2); //lấy ra bảng dữ liệu để thao tác
            this.bdsHocPhi.DataSource = tableHocPhi;
            this.gridHocPhi.DataSource = this.bdsHocPhi; //grid là về giao diện, bds là về dữ liệu 

        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (txbMaSV.Text.Trim() == "")
            {
                MessageBox.Show("Mã sinh viên không được bỏ trống");
                txbMaSV.Focus();
                return;
            }
            btnThem.Enabled = true;
            btnLamMoi.Enabled = true;
            btnPhucHoi.Enabled = false;
            btnGhi.Enabled = false;
            loadHP();
        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            vitri_HP = bdsHocPhi.Position;
            gridCTHP.Enabled = false;
            bdsHocPhi.AddNew();
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = false;
            btnPhucHoi.Enabled = btnGhi.Enabled = true;
        }

        private void btnGhi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                if (txbMaSV.Text.Trim() == "")
                {
                    MessageBox.Show("Bạn chưa nhập mã sinh viên");
                    txbMaSV.Focus();
                    return;
                }
                if (float.Parse(((DataRowView)bdsHocPhi[bdsHocPhi.Position])["HOCPHI"].ToString()) <= 0)
                {
                    MessageBox.Show("Số tiền không được nhỏ hơn 0đ");
                    return;
                }
                if (((DataRowView)bdsHocPhi[bdsHocPhi.Position])["NIENKHOA"].ToString() == "")
                {
                    MessageBox.Show("Niên khóa chưa nhập!");
                    return;
                }
                if (((DataRowView)bdsHocPhi[bdsHocPhi.Position])["HOCKY"].ToString() == "")
                {
                    MessageBox.Show("Học kỳ chưa nhập!");
                    return;
                }
                if (((DataRowView)bdsHocPhi[bdsHocPhi.Position])["HOCPHI"].ToString() == "")
                {
                    MessageBox.Show("Học phí chưa nhập!");
                    return;
                }
                if (float.Parse(((DataRowView)bdsHocPhi[bdsHocPhi.Position])["HOCKY"].ToString()) <= 0)
                {
                    MessageBox.Show("Học kì không được nhỏ hơn 1");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            string msv = txbMaSV.Text;
            string nienkhoa = ((DataRowView)bdsHocPhi[bdsHocPhi.Position])["NIENKHOA"].ToString();
            string hocki = ((DataRowView)bdsHocPhi[bdsHocPhi.Position])["HOCKY"].ToString();
            string hocphi = ((DataRowView)bdsHocPhi[bdsHocPhi.Position])["HOCPHI"].ToString();
            bdsHocPhi.EndEdit(); //commit change made to the current row
            bdsHocPhi.ResetCurrentItem(); //refresh current row
            SqlConnection conn = new SqlConnection(Program.connstr);
            
            string cmd = "EXEC [dbo].[TAO_THONGTINHOCPHI] '" + msv + "' , '" + nienkhoa + "', " + hocki + " , " + hocphi;
            if (Program.ExecSqlNonQuery(cmd) == 0)
            {
                MessageBox.Show("Thêm học phí thành công!");
            }
            else
            {
                MessageBox.Show("Thêm học phí thất bại!");
            }

            //LOAD lại 
            loadHP();
            gridCTHP.Enabled = true;
            btnThem.Enabled = true;
            btnPhucHoi.Enabled = btnGhi.Enabled = false;
        }

        private void btnPhucHoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            bdsHocPhi.CancelEdit();
            gridHocPhi.Enabled = true;
            gridCTHP.Enabled = true;
            btnThem.Enabled = btnSua.Enabled = btnXoa.Enabled = true;
            btnGhi.Enabled = btnPhucHoi.Enabled = false;
            bdsHocPhi.Position = vitri_HP;
        }

        private void frmHocPhi_Load(object sender, EventArgs e)
        {
            btnThem.Enabled = false;
            btnLamMoi.Enabled = false;
            btnPhucHoi.Enabled = false;
            btnGhi.Enabled = false;
        }

        private void btnThemCTHP_Click(object sender, EventArgs e)
        {
            gridHocPhi.Enabled = false;
            vitri_CTHP = bdsCTHP.Position;
            bdsCTHP.AddNew();
        }

        private void btnGhiCTHP_Click(object sender, EventArgs e)
        {
            try
            {
                if (((DataRowView)bdsCTHP[bdsCTHP.Position])["SOTIENDONG"].ToString() == "")
                {
                    MessageBox.Show("Số tiền không được bỏ trống");
                    return;
                }
                if (float.Parse(((DataRowView)bdsCTHP[bdsCTHP.Position])["SOTIENDONG"].ToString()) <= 0)
                {
                    MessageBox.Show("Số tiền không được nhỏ hơn 0đ");
                    return;
                }

                if (float.Parse(((DataRowView)bdsCTHP[bdsCTHP.Position])["SOTIENDONG"].ToString()) > float.Parse(((DataRowView)bdsHocPhi[bdsHocPhi.Position])["SOTIENCANDONG"].ToString()))
                {
                    MessageBox.Show("Số tiền đóng không được lớn hơn số tiền cần đóng!");
                    return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            string nienkhoa = ((DataRowView)bdsHocPhi[bdsHocPhi.Position])["NIENKHOA"].ToString();
            string hocki = ((DataRowView)bdsHocPhi[bdsHocPhi.Position])["HOCKY"].ToString();
            string msv = txbMaSV.Text;
            string sotiendong = ((DataRowView)bdsCTHP[bdsCTHP.Position])["SOTIENDONG"].ToString();
            bdsCTHP.EndEdit();
            bdsCTHP.ResetCurrentItem();
            SqlConnection conn = new SqlConnection(Program.connstr);
            string cmd = "EXEC [dbo].[SV_DONGTIEN] '" + msv + "' , '" + nienkhoa + "', " + hocki + " , " + sotiendong;
            if (Program.ExecSqlNonQuery(cmd) == 0)
            {
                MessageBox.Show("Thêm chi tiết học phí thành công!");
            }
            else
            {
                MessageBox.Show("Lỗi thêm chi tiết học phí!");
            }
            //LOAD LẠI 
            loadLaiCTHP();
            gridHocPhi.Enabled = true;
            loadHP();
        }

        private void btnPhucHoiCTHP_Click(object sender, EventArgs e)
        {
            bdsCTHP.CancelEdit();
            gridHocPhi.Enabled = true;
            loadLaiCTHP();
            bdsCTHP.Position = vitri_CTHP;
        }

        private void gridHocPhi_MouseClick(object sender, MouseEventArgs e)
        {
            if (bdsHocPhi.Count > 0)
            {
                loadLaiCTHP();
            }
        }

        private void loadLaiCTHP()
        {
            string nienkhoa = ((DataRowView)bdsHocPhi[bdsHocPhi.Position])["NIENKHOA"].ToString();
            string hocki = ((DataRowView)bdsHocPhi[bdsHocPhi.Position])["HOCKY"].ToString();
            string msv = txbMaSV.Text;

            string cmd = "EXEC dbo.SP_GetCTHP_SV '" + msv + "', '" + nienkhoa + "', '" + hocki + "'";
            DataTable tableCTHP = Program.ExecSqlDataTable(cmd);
            this.bdsCTHP.DataSource = tableCTHP;
            this.gridCTHP.DataSource = this.bdsCTHP;
        }
        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnLamMoi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            loadHP();
            bdsHocPhi.Position = 0;
            bdsCTHP.Position = 0;
        }

        private void gridCTHP_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                this.contextMenuStrip1.Show(gridCTHP.PointToScreen(e.Location));
            }
        }
    }
}
