using DevExpress.XtraReports.UI;
using System;
using System.Data;
using System.Windows.Forms;

namespace QLSVHTC
{
    public partial class frptBDMH : DevExpress.XtraEditors.XtraForm
    {
        public frptBDMH()
        {
            InitializeComponent();
            if (Program.mGroup == "PGV")
                cbKhoa.Enabled = true;
        }

        private void BDMH_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dS.MONHOC' table. You can move, or remove it, as needed.
            this.MONHOCTableAdapter.Connection.ConnectionString = Program.connstr;
            this.MONHOCTableAdapter.Fill(this.DS.MONHOC);
            cbKhoa.DataSource = Program.bds_dspm;
            cbKhoa.DisplayMember = "TENKHOA";
            cbKhoa.ValueMember = "TENSERVER";
            cbKhoa.SelectedIndex = Program.mChinhanh;
            if (Program.mGroup == "KHOA")
            {
                cbKhoa.Enabled = false;
            }
            cmbMonHoc.DataSource = bdsMonHoc;
            cmbMonHoc.DisplayMember = "TENMH";
            cmbMonHoc.ValueMember = "TENMH";
            loadcmbNienkhoa();
            cmbNienKhoa.SelectedIndex = 0;
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

        private void cmbNienKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadcmbHocKi(cmbNienKhoa.Text);
            //cmbHocKi.SelectedIndex = 0;
        }

        private void cmbHocKi_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadcmbNhom(cmbNienKhoa.Text, cmbHocKi.Text);
            cmbNhom.SelectedIndex = 0;
        }

        private void cmbKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbKhoa.SelectedValue.ToString() == "System.Data.DataRowView")
                return;
            Program.servername = cbKhoa.SelectedValue.ToString();
            if (cbKhoa.SelectedIndex != Program.mChinhanh)
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

        private void btnIn_Click(object sender, EventArgs e)
        {
            string nienkhoa = cmbNienKhoa.Text;
            int hocky = Int32.Parse(cmbHocKi.Text);
            int nhom = Int32.Parse(cmbNhom.Text);
            string monhoc = cmbMonHoc.SelectedValue.ToString();
            string khoa = cbKhoa.Text;
            XtraReport_InBangDiemMonHoc rpt = new XtraReport_InBangDiemMonHoc(nienkhoa, hocky, nhom, monhoc);
            rpt.lbMH.Text = monhoc;
            rpt.lbHK.Text = hocky.ToString();
            rpt.lbNhom.Text = nhom.ToString();
            rpt.lbNK.Text = nienkhoa;
            rpt.lbKhoa.Text = khoa;
            ReportPrintTool print = new ReportPrintTool(rpt);
            print.ShowPreviewDialog();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}