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
namespace project_quanlybanhang
{
    public partial class fLoaiDienThoai : Form
    {
        LoaiDienThoai loaidt;
        public fLoaiDienThoai()
        {
            InitializeComponent();
            loaidt = new LoaiDienThoai();
        }
        ThaotacCSDL mydb = new ThaotacCSDL();

        

        private void fLoaimaytinh_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "Mã loại";
            string query = "SELECT * FROM LOAIDIENTHOAI";
            dataGridViewLoaiDienThoai.DataSource = HienDL(query);
           
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
            if (comboBox1.Text == "Mã loại")
            {
                DataTable dt = HienDL("select * from LOAIDIENTHOAI where MaLoai = '" + textBoxTimKiem.Text.Trim() + "'");
                if (dt.Rows.Count <= 0)
                {
                    MessageBox.Show("Không có dữ liệu loại điện thoại", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                else
                {
                    dataGridViewLoaiDienThoai.DataSource = dt;
                }

            }
            if (comboBox1.Text == "Tên loại")
            {
                DataTable dt = HienDL("select * from LOAIDIENTHOAI where TenLoai like '%" + textBoxTimKiem.Text.Trim() + "%'");
                if (dt.Rows.Count <= 0)
                {
                    MessageBox.Show("Không có dữ liệu loại điện thoại", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                else
                {
                    dataGridViewLoaiDienThoai.DataSource = dt;
                }


            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            maLDTTextBox.Text = "";
            tenLDTTextBox.Text = "";
            textBoxMoTa.Text = "";

        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            string maLoai = maLDTTextBox.Text;
            string tenLoai = tenLDTTextBox.Text;
            string moTa = textBoxMoTa.Text;
            if(verif())
            {
                if (loaidt.themLoaiDienThoai(maLoai, tenLoai, moTa))
                { 
                    MessageBox.Show("Thêm loại điện thoại thành công","Hệ thống",MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fLoaimaytinh_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("ERROR","Hệ thống",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }    
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }    
        }

        private bool verif()
        {
            if(maLDTTextBox.Text == "" || tenLDTTextBox.Text == "")
            {
                return false;

            }
            else
            {
                return true;
            }
        }

        private void buttonChinhSua_Click(object sender, EventArgs e)
        {
            string maLoai = maLDTTextBox.Text;
            string tenLoai = tenLDTTextBox.Text;
            string moTa = textBoxMoTa.Text;
            if (verif())
            {
                if (loaidt.suaLoaiDienThoai(maLoai, tenLoai, moTa))
                {
                    MessageBox.Show("Sửa loại điện thoại thành công", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fLoaimaytinh_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Không thể thay đổi mã loại điện thoại", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            string maLoai = maLDTTextBox.Text;
            if (maLoai == "")
            {
                MessageBox.Show("Vui lòng nhập mã loại để xóa", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn xóa loại này", "Hệ thống", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                    if (loaidt.xoaLoaiDienThoai(maLoai))
                    {
                        MessageBox.Show("Xóa thành công", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        fLoaimaytinh_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Error", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }
        }
    }
}
