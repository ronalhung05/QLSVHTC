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
            if (bdsTemp == null || bdsTemp.Count == 0)
            {
                MessageBox.Show("Chưa có thông tin để ghi điểm!", "", MessageBoxButtons.OK);
                return;
            }

            // Create a DataTable to hold the scores
            DataTable dtDiem = new DataTable();
            dtDiem.Columns.Add("MALC", typeof(int));
            dtDiem.Columns.Add("MASV", typeof(string));
            dtDiem.Columns.Add("DIEM_CC", typeof(int));
            dtDiem.Columns.Add("DIEM_GK", typeof(float));
            dtDiem.Columns.Add("DIEM_CK", typeof(float));

            // Populate the DataTable
            foreach (DataRowView row in bdsTemp)
            {
                DataRow newRow = dtDiem.NewRow();
                newRow["MALC"] = row["MALC"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["MALC"]);
                newRow["MASV"] = row["MASV"].ToString();
                newRow["DIEM_CC"] = row["DIEM_CC"] == DBNull.Value ? (int?)null : Convert.ToInt32(row["DIEM_CC"]);
                newRow["DIEM_GK"] = row["DIEM_GK"] == DBNull.Value ? (float?)null : RoundToHalf(Convert.ToSingle(row["DIEM_GK"]));
                newRow["DIEM_CK"] = row["DIEM_CK"] == DBNull.Value ? (float?)null : RoundToHalf(Convert.ToSingle(row["DIEM_CK"]));
                dtDiem.Rows.Add(newRow);
            }

            using (SqlConnection conn = new SqlConnection(Program.connstr))
            {
                conn.Open();

                try
                {
                    using (SqlCommand cmd = new SqlCommand("SP_UpdateDiem", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter tvpParam = cmd.Parameters.AddWithValue("@BANGDIEM", dtDiem);
                        tvpParam.SqlDbType = SqlDbType.Structured;

                        cmd.ExecuteNonQuery();
                    }
                    XtraMessageBox.Show("Thao tác thành công!", "", MessageBoxButtons.OK);
                }
                catch (SqlException sqlex)
                {
                    XtraMessageBox.Show("Lỗi ghi toàn bộ điểm vào Database. Bạn hãy xem lại ! " + sqlex.Message, "", MessageBoxButtons.OK);
                }
                finally
                {
                    conn.Close();
                }
            }

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