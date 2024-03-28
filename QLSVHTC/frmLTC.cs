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
    public partial class frmLTC : DevExpress.XtraEditors.XtraForm
    {
        String macn = "";

        public frmLTC()
        {
            InitializeComponent();
        }


        private void frmLTC_Load(object sender, EventArgs e)
        {
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
            //if (cmbTenMH.SelectedValue != null)
            //{
            //    txbMaMH.Text = cmbTenMH.SelectedValue.ToString();
            //}
        }

        private void cmbTenGV_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cmbTenGV.SelectedValue != null)
            //{
            //    txbMaGV.Text = cmbTenGV.SelectedValue.ToString();
            //}
        }
        private void txbMaMH_EditValueChanged(object sender, EventArgs e)
        {
            cmbTenMH.SelectedValue = txbMaMH.Text;
        }

        private void txbMaGV_EditValueChanged(object sender, EventArgs e)
        {
            cmbTenGV.SelectedValue = txbMaGV.Text;
        }

        private void txbMaKhoa_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}