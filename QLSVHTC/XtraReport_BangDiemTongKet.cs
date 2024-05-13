namespace QLSVHTC
{
    public partial class XtraReport_BangDiemTongKet : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport_BangDiemTongKet()
        {
            InitializeComponent();
        }
        public XtraReport_BangDiemTongKet(string malop)
        {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Program.connstr;
            this.sqlDataSource1.Queries[0].Parameters[0].Value = malop;
        }
    }
}
