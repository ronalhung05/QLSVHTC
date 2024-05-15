using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLSVHTC
{
    public partial class frmDangNhap : DevExpress.XtraEditors.XtraForm
    {
        private bool isSinhVien = false;
        private SqlConnection conn_publisher = new SqlConnection();
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void LayDSPM(String cmd)
        {
            DataTable dt = new DataTable();
            if (conn_publisher.State == ConnectionState.Closed) conn_publisher.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd, conn_publisher);
            da.Fill(dt);
            conn_publisher.Close();
            Program.bds_dspm.DataSource = dt;
            cmbChiNhanh.DataSource = Program.bds_dspm;
            cmbChiNhanh.DisplayMember = "TENKHOA";
            cmbChiNhanh.ValueMember = "TENSERVER";
        }
        private int KetNoi_CSDLGOC()
        {
            if (conn_publisher != null && conn_publisher.State == ConnectionState.Open)
                conn_publisher.Close();
            try
            {
                conn_publisher.ConnectionString = Program.connstr_publisher;
                conn_publisher.Open();
                return 1;
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi kết nối cơ sở dữ liệu. \nBạn xem lại tên Sever của Publisher, và tên CSDL trong chuỗi kết nối.\n" + e.Message);
                return 0;
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            if (KetNoi_CSDLGOC() == 0) return;
            LayDSPM("SELECT * FROM [dbo].[Get_Subscribers]");
            cmbChiNhanh.SelectedIndex = 1;
            cmbChiNhanh.SelectedIndex = 0;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (isSinhVien == false)
            {
                if (txbTaiKhoan.Text.Trim() == "" || txbMatKhau.Text.Trim() == "")
                {
                    MessageBox.Show("Login name và mật khẩu không được trống", "", MessageBoxButtons.OK);
                    return;
                }
            }
            else
            {
                if (txbTaiKhoan.Text.Trim() == "")
                {
                    MessageBox.Show("Login name không được trống", "", MessageBoxButtons.OK);
                    return;
                }
            }

            if (isSinhVien == true)
            {
                Program.mlogin = "SVKN";
                Program.password = "123";
                if (Program.KetNoi() == 0) return;
            }
            else
            {
                Program.mlogin = txbTaiKhoan.Text; Program.password = txbMatKhau.Text;
                if (Program.KetNoi() == 0) return;
            }


            Program.mChinhanh = cmbChiNhanh.SelectedIndex;
            Program.mloginDN = Program.mlogin;
            Program.passwordDN = Program.password;

            string strLenh = "EXEC dbo.SP_Lay_Thong_Tin_GV_Tu_Login '" + Program.mlogin + "'";
            Program.myReader = Program.ExecSqlDataReader(strLenh);
            if (Program.myReader == null) return;
            
            Program.myReader.Read(); // Đọc 1 dòng nếu dữ liệu có nhiều dùng thì dùng for lặp nếu null thì break
            Program.mGroup = Program.myReader.GetString(2);

            if (isSinhVien == false)
            {
                Program.mHoten = Program.myReader.GetString(1);
                Program.username = Program.myReader.GetString(0);
            }
            Program.myReader.Close();

            string strlenh1 = "EXEC [dbo].[SP_LayThongTinSV_DangNhap] '" + txbTaiKhoan.Text + "', '" + txbMatKhau.Text + "'";
            SqlDataReader reader = Program.ExecSqlDataReader(strlenh1);

            if (reader.HasRows == false && isSinhVien == true)
            {
                MessageBox.Show("Đăng nhập thất bại! \nMã sinh viên không tồn tại");
                return;
            }

            reader.Read();

            if (Convert.IsDBNull(Program.username))
            {
                MessageBox.Show("Login bạn nhập không có quyền truy cập dữ liệu\n Bạn xem lại username, password", "", MessageBoxButtons.OK);
                return;
            }

            if (isSinhVien == true)
            {
                try
                {
                    Program.mHoten = reader.GetString(1);
                    Program.username = reader.GetString(0);
                }
                catch (Exception) { }
            }
            Program.conn.Close();
            reader.Close();
            MessageBox.Show("Đăng nhập thành công !!!");
            Form f = new MainForm();
            f.ShowDialog();

        }

        private void cmbChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Program.servername = cmbChiNhanh.SelectedValue.ToString();
            }
            catch (Exception) { }
        }


        private void cbSinhVien_CheckedChanged(object sender, EventArgs e)
        {
            isSinhVien = !isSinhVien;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}