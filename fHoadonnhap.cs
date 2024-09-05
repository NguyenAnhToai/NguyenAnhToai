using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.Http.Headers;

namespace project_quanlybanhang
{
    public partial class fHoadonnhap : Form
    {
        Hoadonnhap hoadonnhap;
        public fHoadonnhap()
        {
            hoadonnhap = new Hoadonnhap();
            InitializeComponent();
        }
        ThaotacCSDL mydb = new ThaotacCSDL();
        int tongTienThanhToan = 0;
        

        private void fHoadonnhap_Load(object sender, EventArgs e)
        {
          

            comboBoxTenThietBi.DataSource = HienDL("SELECT * FROM DIENTHOAI");
            comboBoxTenThietBi.DisplayMember = "TenDT";
            comboBoxTenThietBi.ValueMember = "MaDT";


            comboBoxMaNV.DataSource = HienDL("SELECT * FROM NHANVIEN");
            comboBoxMaNV.DisplayMember = "MaNV";
            comboBoxMaNV.ValueMember = "MaNV";


            comboBoxMaNV_SelectedIndexChanged(null, null);
            if(dataGridViewDanhSachHoaDon.Columns.Count <= 0)
            {
                dataGridViewDanhSachHoaDon.Columns.Add("MaThietBi", "Mã thiết bị");
                dataGridViewDanhSachHoaDon.Columns.Add("DonGia", "Đơn giá");
                dataGridViewDanhSachHoaDon.Columns.Add("SoLuong", "Số lượng");
                dataGridViewDanhSachHoaDon.Columns.Add("TongTien", "Thành tiền");
                dataGridViewDanhSachHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }

           
            tongTienThanhToanTextBox.ReadOnly = true;

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            string maHoaDon = maHDNTextBox.Text;
            if( maHoaDon =="")
            {
                MessageBox.Show("Vui lòng nhập mã hóa đơn để in", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }    
            fInHoaDonNhap fInHoaDonNhap = new fInHoaDonNhap(maHoaDon);
            fInHoaDonNhap.ShowDialog();
        }

        public DataTable HienDL(string sql)
        {
            SqlDataAdapter adap = new SqlDataAdapter(sql, mydb.getConnection);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            return dt;
        }
        

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            DataColumn col1 = new DataColumn("TenLinhKienNhapHang");
            DataColumn col2 = new DataColumn("SoLuongNhapHang");
            DataColumn col3 = new DataColumn("DonGiaNhapHang");
            DataColumn col4 = new DataColumn("TongTienNhap");
            DataColumn col5 = new DataColumn("MaNV");
            DataColumn col6 = new DataColumn("TenNVNhapHang");
            DataColumn col7 = new DataColumn("NgayXuatHDN");
            DataColumn col8 = new DataColumn("NCCNhapHang");
            DataColumn col9 = new DataColumn("MaHDN");

            dataTable.Columns.Add(col1);
            dataTable.Columns.Add(col2);
            dataTable.Columns.Add(col3);
            dataTable.Columns.Add(col4);
            dataTable.Columns.Add(col5);
            dataTable.Columns.Add(col6);
            dataTable.Columns.Add(col7);
            dataTable.Columns.Add(col8);
            dataTable.Columns.Add(col9);

            foreach (DataGridViewRow dtgvRow in dataGridViewDanhSachHoaDon.Rows)
            {
                DataRow dtrow = dataTable.NewRow();
                dtrow[0] = dtgvRow.Cells[0].Value;
                dtrow[1] = dtgvRow.Cells[1].Value;
                dtrow[2] = dtgvRow.Cells[2].Value;
                dtrow[3] = dtgvRow.Cells[3].Value;
                dtrow[4] = dtgvRow.Cells[4].Value;
                dtrow[5] = dtgvRow.Cells[5].Value;
                dtrow[6] = dtgvRow.Cells[6].Value;
                dtrow[7] = dtgvRow.Cells[7].Value;
                dtrow[8] = dtgvRow.Cells[8].Value;

                dataTable.Rows.Add(dtrow);
            }
            ExportFile(dataTable, "Danh sach", "Danh sách thiết bị đã nhập");
        }
        public void ExportFile(DataTable dataTable, string sheetName, string title)
        {
            //Tạo các đối tượng Excel

            Microsoft.Office.Interop.Excel.Application oExcel = new Microsoft.Office.Interop.Excel.Application();

            Microsoft.Office.Interop.Excel.Workbooks oBooks;

            Microsoft.Office.Interop.Excel.Sheets oSheets;

            Microsoft.Office.Interop.Excel.Workbook oBook;

            Microsoft.Office.Interop.Excel.Worksheet oSheet;

            //Tạo mới một Excel WorkBook 

            oExcel.Visible = true;

            oExcel.DisplayAlerts = false;

            oExcel.Application.SheetsInNewWorkbook = 1;

            oBooks = oExcel.Workbooks;

            oBook = (Microsoft.Office.Interop.Excel.Workbook)(oExcel.Workbooks.Add(Type.Missing));

            oSheets = oBook.Worksheets;

            oSheet = (Microsoft.Office.Interop.Excel.Worksheet)oSheets.get_Item(1);

            oSheet.Name = sheetName;

            // Tạo phần Tiêu đề
            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "I1");

            head.MergeCells = true;

            head.Value2 = title;

            head.Font.Bold = true;

            head.Font.Name = "Times New Roman";

            head.Font.Size = "20";

            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo tiêu đề cột 

            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A3", "A3");

            cl1.Value2 = "Tên thiết bị";

            cl1.ColumnWidth = 30.5;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");

            cl2.Value2 = "Số lượng";

            cl2.ColumnWidth = 20.0;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");

            cl3.Value2 = "Đơn giá";
            cl3.ColumnWidth = 20.5;

            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D3", "D3");

            cl4.Value2 = "Thành tiền";

            cl4.ColumnWidth = 20.5;

            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E3", "E3");

            cl5.Value2 = "Mã nhân viên";

            cl5.ColumnWidth = 10.5;

            Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F3", "F3");

            cl6.Value2 = "Tên nhân viên";

            cl6.ColumnWidth = 30.5;

            Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("G3", "G3");

            cl7.Value2 = "Ngày lập";

            cl7.ColumnWidth = 10.5;
            Microsoft.Office.Interop.Excel.Range cl8 = oSheet.get_Range("H3", "H3");

            cl8.Value2 = "Nhà cung cấp";

            cl8.ColumnWidth = 20.5;
            Microsoft.Office.Interop.Excel.Range cl9 = oSheet.get_Range("I3", "I3");

            cl9.Value2 = "Mã hóa đơn";

            cl9.ColumnWidth = 10.5;

            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A3", "I3");

            rowHead.Font.Bold = true;

            // Kẻ viền

            rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            // Thiết lập màu nền

            rowHead.Interior.ColorIndex = 6;

            rowHead.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo mảng theo datatable

            object[,] arr = new object[dataTable.Rows.Count, dataTable.Columns.Count];

            //Chuyển dữ liệu từ DataTable vào mảng đối tượng

            for (int row = 0; row < dataTable.Rows.Count; row++)
            {
                DataRow dataRow = dataTable.Rows[row];

                for (int col = 0; col < dataTable.Columns.Count; col++)
                {
                    arr[row, col] = dataRow[col];
                }
            }

            //Thiết lập vùng điền dữ liệu

            int rowStart = 4;

            int columnStart = 1;

            int rowEnd = rowStart + dataTable.Rows.Count - 2;

            int columnEnd = dataTable.Columns.Count;

            // Ô bắt đầu điền dữ liệu

            Microsoft.Office.Interop.Excel.Range c1 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowStart, columnStart];

            // Ô kết thúc điền dữ liệu

            Microsoft.Office.Interop.Excel.Range c2 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnEnd];

            // Lấy về vùng điền dữ liệu

            Microsoft.Office.Interop.Excel.Range range = oSheet.get_Range(c1, c2);

            //Điền dữ liệu vào vùng đã thiết lập

            range.Value2 = arr;

            // Kẻ viền

            range.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;

            // Căn giữa cột mã nhân viên

            //Microsoft.Office.Interop.Excel.Range c3 = (Microsoft.Office.Interop.Excel.Range)oSheet.Cells[rowEnd, columnStart];

            //Microsoft.Office.Interop.Excel.Range c4 = oSheet.get_Range(c1, c3);

            //Căn giữa cả bảng 
            oSheet.get_Range(c1, c2).HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
        }

        private void tongTienNhapTextBox_TextChanged(object sender, EventArgs e)
        {


        }

        private void donGiaNhapHangTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                tongTienNhapTextBox.Text = (long.Parse(soLuongNhapHangTextBox.Text) * long.Parse(donGiaNhapHangTextBox.Text)).ToString();
            }
            catch
            {

            }
        }

        private void comboBoxMaNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxMaNV.SelectedValue != null)
            {
                string maNV = comboBoxMaNV.SelectedValue.ToString();
                string query = $"SELECT * FROM NHANVIEN WHERE MaNV = '{maNV}'";
                DataTable dt = HienDL(query);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    textBoxTenNV.Text = row["TenNV"].ToString();

                }
            }
        }

        private void buttonTaoPhieu_Click(object sender, EventArgs e)
        {
            if (verif() == false)
                return;

            
            try
            {
                string maHD = maHDNTextBox.Text;
                string maNV = comboBoxMaNV.SelectedValue.ToString();
                DateTime ngayNhap = ngayXuatHDNDateTimePicker.Value;
                int tongTien = tongTienThanhToan;

                SqlCommand command = new SqlCommand("INSERT INTO HOADONNHAP (MaHDN, MaNV, NgayXuatHDN, TongTienNhap) VALUES (@mahd, @manv, @ngay, @tong)", mydb.getConnection);
                command.Parameters.Add("@mahd", SqlDbType.VarChar).Value = maHD;
                command.Parameters.Add("@manv", SqlDbType.VarChar).Value = maNV;
                command.Parameters.Add("@ngay", SqlDbType.DateTime).Value = ngayNhap;
                command.Parameters.Add("@tong", SqlDbType.Int).Value = tongTien;
                mydb.openConnection();
                command.ExecuteNonQuery();

                for (int i = 0; i < dataGridViewDanhSachHoaDon.Rows.Count; i++)
                {
                    DataGridViewRow row = dataGridViewDanhSachHoaDon.Rows[i];

                    SqlCommand cmd = new SqlCommand("INSERT INTO CHITIETNhap (MaDT, MaHDN, SLNhap, GiaNhap) VALUES (" +
                        " @madt, @mahd, @sl, @gianhap)", mydb.getConnection);
                    
                    

                    if (!row.IsNewRow)
                    {
                        cmd.Parameters.Add("@madt", SqlDbType.VarChar).Value = row.Cells["MaThietBi"].Value.ToString();
                        cmd.Parameters.Add("@mahd", SqlDbType.VarChar).Value = maHD;
                        cmd.Parameters.Add("@sl", SqlDbType.Int).Value = Convert.ToInt32(row.Cells["SoLuong"].Value.ToString());
                        cmd.Parameters.Add("@gianhap", SqlDbType.Int).Value = Convert.ToInt32(row.Cells["DonGia"].Value.ToString());
     
                        cmd.ExecuteNonQuery();
                        SqlCommand command1 = new SqlCommand("Update DIENTHOAI SET SoLuong = SoLuong + @sl1 Where MaDT = @ma", mydb.getConnection);
                        command1.Parameters.Add("@ma",SqlDbType.VarChar).Value = row.Cells["MaThietBi"].Value.ToString();
                        command1.Parameters.Add("@sl1",SqlDbType.VarChar).Value = Convert.ToInt32(row.Cells["SoLuong"].Value.ToString());
                        command1.ExecuteNonQuery();

                    }

                }
                mydb.closeConnection();
                MessageBox.Show("Tạo hóa đơn thành công", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fHoadonnhap_Load(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public bool verif()
        {
            if (maHDNTextBox.Text == "" || soLuongNhapHangTextBox.Text == "" || donGiaNhapHangTextBox.Text == "" || tongTienNhapTextBox.Text == "")
                return false;
            else
               return true;
        }

        private void buttonChon_Click(object sender, EventArgs e)
        {
            string maSP = comboBoxTenThietBi.SelectedValue.ToString();
            int donGia = Convert.ToInt32(donGiaNhapHangTextBox.Text);
            int soLuong = Convert.ToInt32(soLuongNhapHangTextBox.Text);
            int tongTien = Convert.ToInt32(tongTienNhapTextBox.Text);


            dataGridViewDanhSachHoaDon.Rows.Add(maSP, donGia, soLuong, tongTien);

            for (int i = 0; i < dataGridViewDanhSachHoaDon.Rows.Count; i++)
            {
                DataGridViewRow row = dataGridViewDanhSachHoaDon.Rows[i];


                if (!row.IsNewRow)
                {
                    tongTienThanhToan += Convert.ToInt32(row.Cells["TongTien"].Value);


                }
                tongTienThanhToanTextBox.Text = tongTienThanhToan.ToString();
            }
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            if (dataGridViewDanhSachHoaDon.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridViewDanhSachHoaDon.SelectedRows)
                {
                    if (!row.IsNewRow) // Kiểm tra nếu hàng không phải là hàng mới đang được chỉnh sửa
                    {
                       dataGridViewDanhSachHoaDon.Rows.Remove(row);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn 1 hàng để xóa.");
            }
        }
    }
    
}
