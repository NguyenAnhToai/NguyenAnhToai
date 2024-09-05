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
    public partial class fInhoadonban : Form
    {
        string maHD;
        public fInhoadonban(string maHD)
        {
            this.maHD = maHD;
            InitializeComponent();
        }
        ThaotacCSDL mydb = new ThaotacCSDL();
        private void fInhoadonban_Load(object sender, EventArgs e)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter("Select * from View_HOADONBAN WHERE MaHDB = '" + maHD + "' ", mydb.getConnection);
                DataSet_HoaDonBan ds = new DataSet_HoaDonBan();
                adapter.Fill(ds, "DataTable1");
                ReportDataSource dataSource = new ReportDataSource("DataSetViewHoaDon", ds.Tables[0]);
                this.reportViewerHoaDonBan.LocalReport.DataSources.Clear();
                this.reportViewerHoaDonBan.LocalReport.DataSources.Add(dataSource);
                this.reportViewerHoaDonBan.RefreshReport();
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
            
        }
    }
}
