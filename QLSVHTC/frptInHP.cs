using DevExpress.XtraReports.UI;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLSVHTC
{
    public partial class frptInHP : DevExpress.XtraEditors.XtraForm
    {
        public static SqlConnection conn = new SqlConnection();
        public static String connstr;
        public static String database = "QLDSV_TC";
        public frptInHP()
        {
            InitializeComponent();
        }

        public static string NumberToText(double inputNumber, bool suffix = true)
        {
            string[] unitNumbers = new string[] { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string[] placeValues = new string[] { "", "nghìn", "triệu", "tỷ" };
            bool isNegative = false;

            // -12345678.3445435 => "-12345678"
            string sNumber = inputNumber.ToString("#");
            double number = Convert.ToDouble(sNumber);
            if (number < 0)
            {
                number = -number;
                sNumber = number.ToString();
                isNegative = true;
            }


            int ones, tens, hundreds;

            int positionDigit = sNumber.Length;   // last -> first

            string result = " ";


            if (positionDigit == 0)
                result = unitNumbers[0] + result;
            else
            {
                // 0:       ###
                // 1: nghìn ###,###
                // 2: triệu ###,###,###
                // 3: tỷ    ###,###,###,###
                int placeValue = 0;

                while (positionDigit > 0)
                {
                    // Check last 3 digits remain ### (hundreds tens ones)
                    tens = hundreds = -1;
                    ones = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                    positionDigit--;
                    if (positionDigit > 0)
                    {
                        tens = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                        positionDigit--;
                        if (positionDigit > 0)
                        {
                            hundreds = Convert.ToInt32(sNumber.Substring(positionDigit - 1, 1));
                            positionDigit--;
                        }
                    }

                    if ((ones > 0) || (tens > 0) || (hundreds > 0) || (placeValue == 3))
                        result = placeValues[placeValue] + result;

                    placeValue++;
                    if (placeValue > 3) placeValue = 1;

                    if ((ones == 1) && (tens > 1))
                        result = "một " + result;
                    else
                    {
                        if ((ones == 5) && (tens > 0))
                            result = "lăm " + result;
                        else if (ones > 0)
                            result = unitNumbers[ones] + " " + result;
                    }
                    if (tens < 0)
                        break;
                    else
                    {
                        if ((tens == 0) && (ones > 0)) result = "lẻ " + result;
                        if (tens == 1) result = "mười " + result;
                        if (tens > 1) result = unitNumbers[tens] + " mươi " + result;
                    }
                    if (hundreds < 0) break;
                    else
                    {
                        if ((hundreds > 0) || (tens > 0) || (ones > 0))
                            result = unitNumbers[hundreds] + " trăm " + result;
                    }
                    result = " " + result;
                }
            }
            result = result.Trim();
            if (isNegative) result = "Âm " + result;
            return "(" + result + (suffix ? " đồng chẵn)" : ")");
        }
        void loadLOPcombobox()
        {
            DataTable dt = new DataTable();
            string cmd = "EXEC [dbo].[SP_GetAllLopByRole] ";
            dt = Program.ExecSqlDataTable(cmd);

            BindingSource bdslh = new BindingSource();
            bdslh.DataSource = dt;
            cbLop.DataSource = bdslh;
            cbLop.DisplayMember = "MALOP";
            cbLop.ValueMember = "TENLOP";
        }
        private void frptInHP_Load(object sender, EventArgs e)
        {
            loadLOPcombobox();
        }
        private void btnIn_Click(object sender, EventArgs e)
        {
            if (txbNienKhoa.Text.Trim() == "")
            {
                MessageBox.Show("Niên khóa không được để trống", "", MessageBoxButtons.OK);
                txbNienKhoa.Focus();
                return;
            }
            if (nmHocKy.Value == 0)
            {
                MessageBox.Show("Học Kỳ không được để trống", "", MessageBoxButtons.OK);
                nmHocKy.Focus();
                return;
            }
            string nienkhoa = txbNienKhoa.Text;
            int hocky = (int)nmHocKy.Value;
            string malop = cbLop.Text;
            string tongtien = "";
            string cmd = "SELECT TENKHOA FROM dbo.LOP,dbo.KHOA WHERE MALOP = '" + malop + "' AND KHOA.MAKHOA = LOP.MAKHOA";
            SqlDataReader reader = Program.ExecSqlDataReader(cmd);
            reader.Read();
            string tenkhoa = reader.GetString(0);
            reader.Close();

            // Execute the stored procedure to get the total tuition fee
            string cmd1 = "EXEC [dbo].[SP_TongTienHocPhi] '" + malop + "', '" + nienkhoa + "', " + hocky;
            SqlDataReader reader1 = Program.ExecSqlDataReader(cmd1);
            if (reader1.HasRows)
            {
                reader1.Read();
                tongtien = reader1.GetInt32(0).ToString();
            }
            else
            {
                tongtien = "0";
            }
            reader1.Close(); // Make sure to close the reader

            // If the total tuition fee is not zero, convert it to text
            if (tongtien != "0")
            {
                tongtien = NumberToText(double.Parse(tongtien));
            }
            XtraReport_SinhVienDongHocPhi rpt = new XtraReport_SinhVienDongHocPhi(malop, nienkhoa, hocky);
            rpt.lbMaLop.Text = malop;
            rpt.lbKhoa.Text = tenkhoa;
            rpt.lbTienChu.Text = tongtien;
            ReportPrintTool print = new ReportPrintTool(rpt);
            print.ShowPreviewDialog();

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}