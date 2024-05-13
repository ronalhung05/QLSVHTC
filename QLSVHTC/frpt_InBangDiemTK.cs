using DevExpress.XtraReports.UI;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLSVHTC
{
    public partial class frpt_InBangDiemTK : DevExpress.XtraEditors.XtraForm
    {
        public frpt_InBangDiemTK()
        {
            InitializeComponent();
            //if (Program.mGroup == "PGV")
            //    cbKhoa.Enabled = true;
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            string malop = cbLop.Text;
            string cmd = "SELECT TENKHOA,KHOAHOC FROM dbo.LOP,dbo.KHOA WHERE MALOP = '" + malop + "' AND KHOA.MAKHOA = LOP.MAKHOA";
            SqlDataReader reader = Program.ExecSqlDataReader(cmd);
            reader.Read();
            string tenkhoa = reader.GetString(0);
            string khoahoc = reader.GetString(1);
            reader.Close();
            XtraReport_BangDiemTongKet rpt = new XtraReport_BangDiemTongKet(malop);
            rpt.lbKhoa.Text = tenkhoa;
            rpt.lbKhoaHoc.Text = khoahoc;
            rpt.lbLop.Text = malop;

            ReportPrintTool print = new ReportPrintTool(rpt);
            print.ShowPreviewDialog();
        }

        private void fprt_InBangDiemTK_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dS.LOP' table. You can move, or remove it, as needed.
            DS.EnforceConstraints = false;
            this.LOPTableAdapter.Connection.ConnectionString = Program.connstr;
            this.LOPTableAdapter.Fill(this.DS.LOP);

            cbLop.DataSource = bdsLop;
            cbLop.DisplayMember = "MALOP";
            cbLop.ValueMember = "TENLOP";


            cbKhoa.DataSource = Program.bds_dspm;
            cbKhoa.DisplayMember = "TENKHOA";
            cbKhoa.ValueMember = "TENSERVER";
            cbKhoa.SelectedIndex = Program.mChinhanh;
            if (Program.mGroup == "KHOA")
            {
                cbKhoa.Enabled = false;
            }
        }

        private void cbKhoa_SelectedIndexChanged(object sender, EventArgs e)
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
                this.LOPTableAdapter.Connection.ConnectionString = Program.connstr;
                this.LOPTableAdapter.Fill(this.DS.LOP);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lOPBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsLop.EndEdit();
            this.tableAdapterManager.UpdateAll(this.DS);

        }

        private void cbLop_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}