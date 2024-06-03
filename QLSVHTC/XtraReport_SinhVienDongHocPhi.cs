namespace QLSVHTC
{
    public partial class XtraReport_SinhVienDongHocPhi : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport_SinhVienDongHocPhi()
        {
            InitializeComponent();
        }
        public XtraReport_SinhVienDongHocPhi(string malop, string nienkhoa, int hocky)
        {
            InitializeComponent();
            this.sqlDataSource1.Queries[0].Parameters[0].Value = malop;
            this.sqlDataSource1.Queries[0].Parameters[1].Value = nienkhoa;
            this.sqlDataSource1.Queries[0].Parameters[2].Value = hocky;
        }

    }
}
