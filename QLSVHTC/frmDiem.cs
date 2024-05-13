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
using System.Windows.Forms;

namespace QLSVHTC
{
    public partial class frmDiem : DevExpress.XtraEditors.XtraForm
    {
        int vitri = 0;
        string macn = "";
        private BindingSource bdsDiem = new BindingSource();
        public frmDiem()
        {
            InitializeComponent();
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
            cmbHocKi.DataSource = bdsHocKi;
            cmbHocKi.DisplayMember = "HOCKY";
            cmbHocKi.ValueMember = "HOCKY";
        }
        void loadcmbNhom(string nienkhoa, string hocki)
        {
            DataTable dt = new DataTable();
            string cmd = "EXEC dbo.GetAllNhom '" + nienkhoa + "', " + hocki;
            dt = Program.ExecSqlDataTable(cmd);

            BindingSource bdsNhom = new BindingSource();
            bdsNhom.DataSource = dt;
            cmbNhom.DataSource = bdsNhom;
            cmbNhom.DisplayMember = "NHOM";
            cmbNhom.ValueMember = "NHOM";
        }
        private void frmDiem_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dS.MONHOC' table. You can move, or remove it, as needed.
            this.MONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
            this.MONHOCTableAdapter.Fill(this.DS.MONHOC);

            cmbKhoa.DataSource = Program.bds_dspm;
            cmbKhoa.DisplayMember = "TENKHOA";
            cmbKhoa.ValueMember = "TENSERVER";
            cmbKhoa.SelectedIndex = Program.mChinhanh;

            cmbMonHoc.DataSource = bdsMH;
            cmbMonHoc.DisplayMember = "TENMH";
            cmbMonHoc.ValueMember = "TENMH";

            if (Program.mGroup == "KHOA")
            {
                cmbKhoa.Enabled = false;
            }
            loadcmbNienkhoa();
            cmbNienKhoa.SelectedIndex = 0;
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
                loadcmbNienkhoa();
                cmbNienKhoa.SelectedIndex = 0;
            }
        }

        private void cmbNienKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadcmbHocKi(cmbNienKhoa.Text);
            //cmbHocKi.SelectedIndex = 0;
        }

        private void cmbHocKi_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadcmbNhom(cmbNienKhoa.Text, cmbHocKi.Text);
            //cmbNhom.SelectedIndex = 0;

        }
        void loadBDMH()
        {
            string cmd = "EXEC [dbo].[SP_BDMH] '" + cmbNienKhoa.Text + "', " + cmbHocKi.Text + ", " + cmbNhom.Text + ", N'" + cmbMonHoc.SelectedValue.ToString() + "'";
            DataTable diemTable = Program.ExecSqlDataTable(cmd);
            this.bdsDiem.DataSource = diemTable;
            this.gridDiem.DataSource = this.bdsDiem;
        }
        private void btnBatDau_Click(object sender, EventArgs e)
        {
            loadBDMH();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            BindingSource bdsTemp = (BindingSource)this.gridDiem.DataSource;
            if (bdsTemp == null)
            {
                MessageBox.Show("Chưa có thông tin để ghi điểm!", "", MessageBoxButtons.OK);
                return;
            }

            bdsTemp.EndEdit();
            SqlConnection conn = new SqlConnection(Program.connstr);
            // bắt đầu transaction
            SqlTransaction tran;

            conn.Open();
            tran = conn.BeginTransaction();
            try
            {
                for (int i = 0; i < bdsTemp.Count; i++)
                {
                    SqlCommand cmd = new SqlCommand("SP_XULY_DIEM", conn);
                    cmd.Connection = conn;
                    cmd.Transaction = tran;

                    cmd.CommandType = CommandType.StoredProcedure;
                    string masv = ((DataRowView)bdsTemp[i])["MASV"].ToString();
                    cmd.Parameters.Add(new SqlParameter("@MSSV", masv));
                    cmd.Parameters.Add(new SqlParameter("@MALTC", ((DataRowView)bdsTemp[i])["MALC"].ToString()));
                    float diemcc = 0;
                    float diemgk = 0;
                    float diemck = 0;
                    if (((DataRowView)bdsTemp[i])["DIEM_CC"].ToString() != "")
                    {
                        diemcc = float.Parse(((DataRowView)bdsTemp[i])["DIEM_CC"].ToString());
                    }
                    if (((DataRowView)bdsTemp[i])["DIEM_GK"].ToString() != "")
                    {
                        diemgk = RoundToHalf(float.Parse(((DataRowView)bdsTemp[i])["DIEM_GK"].ToString()));
                    }
                    if (((DataRowView)bdsTemp[i])["DIEM_CK"].ToString() != "")
                    {
                        diemck = RoundToHalf(float.Parse(((DataRowView)bdsTemp[i])["DIEM_CK"].ToString()));
                    }
                    if (diemcc < 0 || diemcc > 10 || diemck < 0 || diemck > 10 || diemgk < 0 || diemgk > 10)
                    {
                        tran.Rollback();
                        XtraMessageBox.Show("Điểm số chỉ được nhập từ 0 đến 10! Xin vui lòng nhập lại");
                        conn.Close();
                        loadBDMH();
                        return;
                    }
                    cmd.Parameters.Add(new SqlParameter("@DIEMCC", diemcc));
                    cmd.Parameters.Add(new SqlParameter("@DIEMGK", diemgk));
                    cmd.Parameters.Add(new SqlParameter("@DIEMCK", diemck));
                    cmd.ExecuteNonQuery();
                }

                tran.Commit();
            }
            catch (SqlException sqlex)
            {
                try
                {
                    tran.Rollback();
                    XtraMessageBox.Show("Lỗi ghi toàn bộ điểm vào Database. Bạn hãy xem lại ! " + sqlex.Message, "", MessageBoxButtons.OK);
                    loadBDMH();
                }
                catch (Exception ex2)
                {
                    Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType());
                    Console.WriteLine("  Message: {0}", ex2.Message);
                }
                conn.Close();
                return;
            }
            finally
            {
                conn.Close();
            }
            XtraMessageBox.Show("Thao tác thành công!", "", MessageBoxButtons.OK);
            string cmd1 = "EXEC [dbo].[SP_BDMH] '" + cmbNienKhoa.Text + "', " + cmbHocKi.Text + ", " + cmbNhom.Text + ", N'" + cmbMonHoc.SelectedValue.ToString() + "'";
            DataTable diemTable = Program.ExecSqlDataTable(cmd1);
            this.bdsDiem.DataSource = diemTable;
            this.gridDiem.DataSource = this.bdsDiem;
            return;
        }

        private float RoundToHalf(float number)
        {
            double lower = Math.Floor(number);
            double upper = lower + 0.5;
            double upperNext = lower + 1.0;

            double lowerDiff = number - lower;
            double upperDiff = upper - number;
            double upperNextDiff = upperNext - number;

            if (lowerDiff <= 0.25)
            {
                return (float)lower;
            }
            else if (lowerDiff > 0.25 && lowerDiff < 0.75)
            {
                return (float)upper;
            }
            else
            {
                return (float)upperNext;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridDiem_Click(object sender, EventArgs e)
        {

        } 
    }
}