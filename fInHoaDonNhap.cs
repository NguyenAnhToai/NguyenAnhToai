using Microsoft.Reporting.WinForms;
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

namespace project_quanlybanhang
{
    public partial class fInHoaDonNhap : Form
    {
        string maHD;
        public fInHoaDonNhap(string maHD)
        {
            InitializeComponent();
            this.maHD = maHD;
        }
        ThaotacCSDL mydb = new ThaotacCSDL();   
        private void fInHoaDonNhap_Load(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter("Select * from View_HOADONNHAP WHERE MaHDN = '" + maHD + "' ", mydb.getConnection);
                DataSet_HoaDonNhap ds = new DataSet_HoaDonNhap();
                adapter.Fill(ds, "DataTable_HoaDonNhap");
                ReportDataSource dataSource = new ReportDataSource("DataSet_HoaDonNhap", ds.Tables[0]);
                this.reportViewerHoaDonNhap.LocalReport.DataSources.Clear();
                this.reportViewerHoaDonNhap.LocalReport.DataSources.Add(dataSource);
                this.reportViewerHoaDonNhap.RefreshReport();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }
    }
}
