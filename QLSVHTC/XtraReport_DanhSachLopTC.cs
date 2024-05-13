using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

namespace QLSVHTC
{
    public partial class XtraReport_DanhSachLopTC : DevExpress.XtraReports.UI.XtraReport
    {
        public XtraReport_DanhSachLopTC()
        {
            InitializeComponent();
        }
        public XtraReport_DanhSachLopTC(String nienkhoa, int hocky)
        {
            InitializeComponent();
            this.sqlDataSource1.Connection.ConnectionString = Program.connstr;
            this.sqlDataSource1.Queries[0].Parameters[0].Value = nienkhoa;
            this.sqlDataSource1.Queries[0].Parameters[1].Value = hocky;
            this.sqlDataSource1.Fill();
        }

    }
}
