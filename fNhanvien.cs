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
using app = Microsoft.Office.Interop.Excel.Application;
using System.IO;

namespace project_quanlybanhang
{
    public partial class fNhanvien : Form
    {
        
        Nhanvien nhanvien;

        public fNhanvien()
        {

            InitializeComponent();
            nhanvien = new Nhanvien();
        }
        ThaotacCSDL mydb = new ThaotacCSDL();
        private void fNhanvien_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "Mã nhân viên";
            comboBoxChucVu.SelectedIndex = 0;
            
            gioiTinhComboBox.SelectedIndex = 0;

            string query = "Select * from NHANVIEN";
            DataGridViewImageColumn picCol = new DataGridViewImageColumn(); // Doi tuong lam viec voi dang picture cua datagridview
            nHANVIENDataGridView.RowTemplate.Height = 80; // Co gian de picture dep
            nHANVIENDataGridView.DataSource = HienDL(query);
            picCol = (DataGridViewImageColumn)nHANVIENDataGridView.Columns[6];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
           
            nHANVIENDataGridView.AllowUserToAddRows = false;
            nHANVIENDataGridView.ReadOnly = true;
            

        }

        private void nHANVIENBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            /*this.Validate();
            this.nHANVIENBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.qUANLY_CUAHANGMAYTINHDataSet);*/

        }

        private void nHANVIENBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            /*this.Validate();
            this.nHANVIENBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.qUANLY_CUAHANGMAYTINHDataSet);*/

        }

        private void hinhAnhPictureBox_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                hinhAnhPictureBox.Image = Image.FromFile(open.FileName);
                this.Text = open.FileName;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            DataColumn col1 = new DataColumn("MaNV");
            DataColumn col2 = new DataColumn("TenNV");
            DataColumn col3 = new DataColumn("Diachi");
            DataColumn col4 = new DataColumn("Sdt");
           
            DataColumn col5 = new DataColumn("NgaySinh");
            DataColumn col6 = new DataColumn("Gioitinh");
            DataColumn col7 = new DataColumn("Hinhanh");

            dataTable.Columns.Add(col1);
            dataTable.Columns.Add(col2);
            dataTable.Columns.Add(col3);
            dataTable.Columns.Add(col4);
            dataTable.Columns.Add(col5);
            dataTable.Columns.Add(col6);
            dataTable.Columns.Add(col7);

            for (int i = 0; i < nHANVIENDataGridView.Rows.Count; i++)
            {
               
                DataGridViewRow dtgvRow = nHANVIENDataGridView.Rows[i];
                DataRow dtrow = dataTable.NewRow();
                dtrow[0] = dtgvRow.Cells[0].Value;
                dtrow[1] = dtgvRow.Cells[1].Value;
                dtrow[2] = dtgvRow.Cells[2].Value;
                dtrow[3] = dtgvRow.Cells[3].Value;
                dtrow[4] = dtgvRow.Cells[4].Value;
                dtrow[5] = dtgvRow.Cells[5].Value;
                dtrow[6] = dtgvRow.Cells[6].Value;

                dataTable.Rows.Add(dtrow);

            }
           /* foreach (DataGridViewRow dtgvRow in nHANVIENDataGridView.Rows)
            {
                DataRow dtrow = dataTable.NewRow();
                dtrow[0] = dtgvRow.Cells[0].Value;
                dtrow[1] = dtgvRow.Cells[1].Value;
                dtrow[2] = dtgvRow.Cells[2].Value;
                dtrow[3] = dtgvRow.Cells[3].Value;
                dtrow[4] = dtgvRow.Cells[4].Value;
                dtrow[5] = dtgvRow.Cells[5].Value;
                dtrow[6] = dtgvRow.Cells[6].Value;

                dataTable.Rows.Add(dtrow);
            }*/
            ExportFile(dataTable, "Danh sach", "Danh sách nhân viên");
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
            Microsoft.Office.Interop.Excel.Range head = oSheet.get_Range("A1", "H1");

            head.MergeCells = true;

            head.Value2 = title;

            head.Font.Bold = true;

            head.Font.Name = "Times New Roman";

            head.Font.Size = "20";

            head.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;

            // Tạo tiêu đề cột 

            Microsoft.Office.Interop.Excel.Range cl1 = oSheet.get_Range("A3", "A3");

            cl1.Value2 = "Mã nhân viên";

            cl1.ColumnWidth = 12;

            Microsoft.Office.Interop.Excel.Range cl2 = oSheet.get_Range("B3", "B3");

            cl2.Value2 = "Tên nhân viên";

            cl2.ColumnWidth = 25.0;

            Microsoft.Office.Interop.Excel.Range cl3 = oSheet.get_Range("C3", "C3");

            cl3.Value2 = "Địa chỉ";
            cl3.ColumnWidth = 25.0;

            Microsoft.Office.Interop.Excel.Range cl4 = oSheet.get_Range("D3", "D3");

            cl4.Value2 = "Số điện thoại";

            cl4.ColumnWidth = 10.5;

            Microsoft.Office.Interop.Excel.Range cl5 = oSheet.get_Range("E3", "E3");

            cl5.Value2 = "Ngày sinh";

            cl5.ColumnWidth = 20.5;

            Microsoft.Office.Interop.Excel.Range cl6 = oSheet.get_Range("F3", "F3");

            cl6.Value2 = "Giới tính";

            cl6.ColumnWidth = 18.5;

            Microsoft.Office.Interop.Excel.Range cl7 = oSheet.get_Range("G3", "G3");

            cl7.Value2 = "Hình Ảnh";

            cl7.ColumnWidth = 10.5;
            /*Microsoft.Office.Interop.Excel.Range cl8= oSheet.get_Range("H3", "H3");

            cl8.Value2 = "Hình ảnh";

            cl8.ColumnWidth = 10.5;*/

            Microsoft.Office.Interop.Excel.Range rowHead = oSheet.get_Range("A3", "H3");

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

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            maNVTextBox.Text = "";
            tenNVTextBox.Text = "";
            diaChiNVTextBox.Text = "";
            sDT_NVTextBox.Text = "";
            ngaySinhDateTimePicker.Text = "";
            gioiTinhComboBox.Text = "";
            hinhAnhPictureBox.Image = null;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public SqlConnection cn = new SqlConnection();
        public void Ketnoi()
        {
            try
            {
                if (cn.State == 0)
                {
                    cn.ConnectionString = "Data Source=.;Initial Catalog=QLCuaHangDT;Persist Security Info=True;User ID=sa;Password=1234;Encrypt=True;TrustServerCertificate=True";
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
            if (comboBox1.Text == "Mã nhân viên")
            {
                
                DataGridViewImageColumn picCol = new DataGridViewImageColumn(); // Doi tuong lam viec voi dang picture cua datagridview
                nHANVIENDataGridView.RowTemplate.Height = 80; // Co gian de picture dep
                nHANVIENDataGridView.DataSource = HienDL("select * from NHANVIEN where Manv like N'%" + textBox1.Text.Trim() + "%'");
                picCol = (DataGridViewImageColumn)nHANVIENDataGridView.Columns[6];
                picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
                nHANVIENDataGridView.AllowUserToAddRows = false;
            }
            if (comboBox1.Text == "Tên nhân viên")
            {

                DataGridViewImageColumn picCol = new DataGridViewImageColumn(); // Doi tuong lam viec voi dang picture cua datagridview
                nHANVIENDataGridView.RowTemplate.Height = 80; // Co gian de picture dep
                nHANVIENDataGridView.DataSource = HienDL("select * from NHANVIEN where Tennv like N'%" + textBox1.Text.Trim() + "%'");
                picCol = (DataGridViewImageColumn)nHANVIENDataGridView.Columns[6];
                picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
                nHANVIENDataGridView.AllowUserToAddRows = false;
                
            }
         }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            
            
        }

        private bool verif()
        {
           // MessageBox.Show(maNVTextBox.Text);
            if(maNVTextBox.Text == "" ||
                tenNVTextBox.Text == "" ||
                diaChiNVTextBox.Text == "" ||
                sDT_NVTextBox.Text == "" || textBoxUsername.Text ==""|| textBoxPassword.Text =="" ||
                hinhAnhPictureBox.Image == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

      

        private void btn_Them_Click(object sender, EventArgs e)
        {
            string maNV = maNVTextBox.Text;
            //MessageBox.Show(maNV);
            string tenNV = tenNVTextBox.Text;
            string diaChi = diaChiNVTextBox.Text;
            string sdt = sDT_NVTextBox.Text;
            DateTime ngaySinh = ngaySinhDateTimePicker.Value.Date;
            string gioiTinh = gioiTinhComboBox.SelectedItem.ToString();
            string chucVu = comboBoxChucVu.SelectedItem.ToString();
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;
            MemoryStream pic = new MemoryStream();
            if (verif())
            {
                hinhAnhPictureBox.Image.Save(pic, hinhAnhPictureBox.Image.RawFormat);
                if (nhanvien.themNhanVien(maNV, tenNV, diaChi, ngaySinh, sdt, gioiTinh, pic,chucVu))
                {
                    SqlCommand command = new SqlCommand("INSERT INTO DANGNHAP (MaNV, Username, Password) VALUES ( @ma, @usn, @pass)",mydb.getConnection);
                    command.Parameters.Add("@ma",SqlDbType.VarChar).Value = maNV;
                    command.Parameters.Add("@usn", SqlDbType.VarChar).Value = username;
                    command.Parameters.Add("@pass",SqlDbType.VarChar).Value = password;
                    mydb.openConnection();
                    command.ExecuteNonQuery();
                    mydb.closeConnection();
                    MessageBox.Show("Thêm nhân viên thành công", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fNhanvien_Load(sender, e);
                    toolStripButton2_Click(sender, e);
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

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            
            string maNV = maNVTextBox.Text;
            if(maNV == "")
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên để xóa","Hệ thống",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn xóa nhân viên này","Hệ thống", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result == DialogResult.Yes)
                    if (nhanvien.xoaNhanVien(maNV))
                    {
                        MessageBox.Show("Xóa nhân viên thành công", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        fNhanvien_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Error", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }    
            }    
        }

        private void nHANVIENDataGridView_DoubleClick(object sender, EventArgs e)
        {
            maNVTextBox.Text = nHANVIENDataGridView.CurrentRow.Cells[0].Value.ToString();
            tenNVTextBox.Text = nHANVIENDataGridView.CurrentRow.Cells[1].Value.ToString();
            diaChiNVTextBox.Text = nHANVIENDataGridView.CurrentRow.Cells[2].Value.ToString();
            sDT_NVTextBox.Text = nHANVIENDataGridView.CurrentRow.Cells[3].Value.ToString();
            ngaySinhDateTimePicker.Value = (DateTime)nHANVIENDataGridView.CurrentRow.Cells[4].Value;
            gioiTinhComboBox.Text = nHANVIENDataGridView.CurrentRow.Cells[5].Value.ToString();
            byte[] pic;
            pic = (byte[])nHANVIENDataGridView.CurrentRow.Cells[6].Value;
            MemoryStream picture = new MemoryStream(pic);
           hinhAnhPictureBox.Image = Image.FromStream(picture);
        }

        private void buttonChinhSua_Click(object sender, EventArgs e)
        {
            string maNV = maNVTextBox.Text;
            //MessageBox.Show(maNV);
            string tenNV = tenNVTextBox.Text;
            string diaChi = diaChiNVTextBox.Text;
            string sdt = sDT_NVTextBox.Text;
            DateTime ngaySinh = ngaySinhDateTimePicker.Value.Date;
            string gioiTinh = gioiTinhComboBox.SelectedItem.ToString();
            string chucVu = comboBoxChucVu.SelectedItem.ToString();
            MemoryStream pic = new MemoryStream();
            if (verif())
            {
                hinhAnhPictureBox.Image.Save(pic, hinhAnhPictureBox.Image.RawFormat);
                if (nhanvien.chinhSuaNhanVien(maNV, tenNV, diaChi, ngaySinh, sdt, gioiTinh, pic, chucVu))
                {
                    MessageBox.Show("Sửa thông tin nhân viên thành công", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fNhanvien_Load(sender, e);
                    toolStripButton2_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("Không được phép thay đổi mã nhân viên", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
