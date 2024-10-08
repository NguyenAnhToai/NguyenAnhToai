﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace project_quanlybanhang
{
    public partial class fKhachhang : Form
    {
        Khachhang khachhang;
        public fKhachhang()
        {
            khachhang = new Khachhang();
            InitializeComponent();
        }
        ThaotacCSDL mydb = new ThaotacCSDL();

       

        private void fKhachhang_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "Mã khách hàng";
            gioiTinhKHComboBox.SelectedIndex = 0;
            string query = "Select * from KHACHHANG";
            kHACHHANGDataGridView.DataSource = HienDL(query);
            //kHACHHANGDataGridView.AllowUserToAddRows = false;
            kHACHHANGDataGridView.ReadOnly = true;

        }

        private void maKHLabel_Click(object sender, EventArgs e)
        {

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
            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "E1");

            head.MergeCells = true;

            head.Value2 = title;

            head.Font.Bold = true;

            head.Font.Name = "Times New Roman";

            head.Font.Size = "20";

            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo tiêu đề cột 

            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A3", "A3");

            cl1.Value2 = "Mã khách hàng";

            cl1.ColumnWidth = 12;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");

            cl2.Value2 = "Tên khách hàng";

            cl2.ColumnWidth = 25.0;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");

            cl3.Value2 = "Địa chỉ ";
            cl3.ColumnWidth = 25.0;

            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D3", "D3");

            cl4.Value2 = "Số điện thoại";

            cl4.ColumnWidth = 20.5;

            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E3", "E3");

            cl5.Value2 = "Giới tính";

            cl5.ColumnWidth = 20.5;

            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A3", "E3");

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

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            DataColumn col1 = new DataColumn("MaKH");
            DataColumn col2 = new DataColumn("TenKH");
            DataColumn col3 = new DataColumn("Diachi");
            DataColumn col4 = new DataColumn("Sdt");
            DataColumn col5 = new DataColumn("Gioitinh");
            

            dataTable.Columns.Add(col1);
            dataTable.Columns.Add(col2);
            dataTable.Columns.Add(col3);
            dataTable.Columns.Add(col4);
            dataTable.Columns.Add(col5);

            foreach (DataGridViewRow dtgvRow in kHACHHANGDataGridView.Rows)
            {
                DataRow dtrow = dataTable.NewRow();
                dtrow[0] = dtgvRow.Cells[0].Value;
                dtrow[1] = dtgvRow.Cells[1].Value;
                dtrow[2] = dtgvRow.Cells[2].Value;
                dtrow[3] = dtgvRow.Cells[3].Value;
                dtrow[4] = dtgvRow.Cells[4].Value;

                dataTable.Rows.Add(dtrow);
            }
            ExportFile(dataTable, "Danh sach", "Danh sách khách hàng");
        }
        public SqlConnection cn = new SqlConnection();
        public void Ketnoi()
        {
            try
            {
                if (cn.State == 0)
                {
                    cn.ConnectionString = "Data Source = LAPTOP-KNCJTSN8; Initial Catalog = QUANLY_CUAHANGMAYTINH; Integrated Security = True";
                    cn.Open();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Ngatketnoi()
        {
            if (cn.State != 0)
            {
                cn.Close();
            }
        }
        public DataTable HienDL(string sql)
        {
            
            SqlDataAdapter adap = new SqlDataAdapter(sql, mydb.getConnection);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            return dt;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Mã khách hàng")
            {
                DataTable dt = HienDL("select * from KHACHHANG where MaKH like N'%" + textBox1.Text.Trim() + "%'");
                if(dt.Rows.Count <= 0)
                {
                    MessageBox.Show("Không có dữ liệu khách hàng","Hệ thống",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                
                } 
                else
                {
                    kHACHHANGDataGridView.DataSource = dt;
                }    
                
            }
            if (comboBox1.Text == "Tên khách hàng")
            {
                DataTable dt = HienDL("select * from KHACHHANG where TenKH like N'%" + textBox1.Text.Trim() + "%'");
                if (dt.Rows.Count <= 0)
                {
                    MessageBox.Show("Không có dữ liệu khách hàng", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                else
                {
                    kHACHHANGDataGridView.DataSource = dt;
                }

               
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            maKHTextBox.Text = "";
            tenKHTextBox.Text = "";
            diaChiKHTextBox.Text = "";
            sDT_KHTextBox.Text = "";
            gioiTinhKHComboBox.Text = "";
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {

        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            string maKH = maKHTextBox.Text;
            string tenKH = tenKHTextBox.Text;
            string sdt = sDT_KHTextBox.Text;
            string diaChi = diaChiKHTextBox.Text;
            string gioiTinh = gioiTinhKHComboBox.SelectedItem.ToString();

            if(verif())
            {
                if(khachhang.themKhachHang(maKH, tenKH, diaChi, sdt, gioiTinh))
                {
                    MessageBox.Show("Thêm khách hàng thành công", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fKhachhang_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Error", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }    
            }    
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }    
        }

        private bool verif()
        {
            if(maKHTextBox.Text =="" ||
                tenKHTextBox.Text=="" ||
                diaChiKHTextBox.Text =="" ||
                sDT_KHTextBox.Text =="")
            {
                return false;
            }
            else
                return true;
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            string maKH = maKHTextBox.Text;
            if (maKH == "")
            {
                MessageBox.Show("Vui lòng nhập mã khách hàng để xóa", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn xóa khách hàng này", "Hệ thống", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                    if (khachhang.xoaKhachHang(maKH))
                    {
                        MessageBox.Show("Xóa khách hàng thành công", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        fKhachhang_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Error", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }
        }

        private void kHACHHANGDataGridView_DoubleClick(object sender, EventArgs e)
        {
            maKHTextBox.Text = kHACHHANGDataGridView.CurrentRow.Cells[0].Value.ToString();
            tenKHTextBox.Text = kHACHHANGDataGridView.CurrentRow.Cells[1].Value.ToString();
            diaChiKHTextBox.Text = kHACHHANGDataGridView.CurrentRow.Cells[2].Value.ToString();
            sDT_KHTextBox.Text = kHACHHANGDataGridView.CurrentRow.Cells[3].Value.ToString();
            gioiTinhKHComboBox.Text = kHACHHANGDataGridView.CurrentRow.Cells[4].Value.ToString();

        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            string maKH = maKHTextBox.Text;
            string tenKH = tenKHTextBox.Text;
            string sdt = sDT_KHTextBox.Text;
            string diaChi = diaChiKHTextBox.Text;
            string gioiTinh = gioiTinhKHComboBox.SelectedItem.ToString();

            if (verif())
            {
                if (khachhang.suaKhachHang(maKH, tenKH, diaChi, sdt, gioiTinh))
                {
                    MessageBox.Show("Sửa khách hàng thành công", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fKhachhang_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Không được thay đổi mã khách hàng", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
