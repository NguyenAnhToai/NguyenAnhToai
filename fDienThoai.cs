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
using System.IO;
using System.Net.NetworkInformation;

namespace project_quanlybanhang
{
    public partial class fDienThoai : Form
    {
        Thietbi thietbi;
        public fDienThoai()
        {
            thietbi = new Thietbi();
            InitializeComponent();
        }
        ThaotacCSDL mydb = new ThaotacCSDL();
        private void fMaytinh_Load(object sender, EventArgs e)
        {
            
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

        private void mAYTINHBindingNavigator_RefreshItems(object sender, EventArgs e)
        {

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
            if (comboBox1.Text == "Mã thiết bị")
            {

                DataGridViewImageColumn picCol = new DataGridViewImageColumn(); // Doi tuong lam viec voi dang picture cua datagridview
                dataGridViewDienThoai.RowTemplate.Height = 80; // Co gian de picture dep
                dataGridViewDienThoai.DataSource = HienDL("select * from MAYTINH where Mamt like '%" + textBox1.Text.Trim() + "%'");
                picCol = (DataGridViewImageColumn)dataGridViewDienThoai.Columns[5];
                picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
                dataGridViewDienThoai.AllowUserToAddRows = false;
            }
            if (comboBox1.Text == "Tên thiết bị")
            {

                DataGridViewImageColumn picCol = new DataGridViewImageColumn(); // Doi tuong lam viec voi dang picture cua datagridview
                dataGridViewDienThoai.RowTemplate.Height = 80; // Co gian de picture dep
                dataGridViewDienThoai.DataSource = HienDL("select * from MAYTINH where Tenmt like '%" + textBox1.Text.Trim() + "%'");
                picCol = (DataGridViewImageColumn)dataGridViewDienThoai.Columns[5];
                picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;
                dataGridViewDienThoai.AllowUserToAddRows = false;

            }

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            textBoxMaThietBi.Text = "";
            textBoxTenThietBi.Text = "";
           
            comboBoxLoaiThietBi.Text = "";
            
            comboBoxNCC.Text = "";
          
            textBoxDonGia.Text = "";
            textBoxSoLuong.Text = "";
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            




        }

        private bool verif()
        {
            if (textBoxMaThietBi.Text == "" || textBoxTenThietBi.Text == "" || textBoxSoLuong.Text == "" || textBoxDonGia.Text == "" || hinhAnhPictureBox.Image == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void fDienThoai_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "Mã thiết bị";

            comboBoxLoaiThietBi.DataSource = HienDL("SELECT * FROM LOAIDIENTHOAI");
            comboBoxLoaiThietBi.DisplayMember = "TenLoai";
            comboBoxLoaiThietBi.ValueMember = "MaLoai";

            comboBoxNCC.DataSource = HienDL("SELECT * FROM NHACUNGCAP");
            comboBoxNCC.DisplayMember = "TenNCC";
            comboBoxNCC.ValueMember = "MaNCC";

            string query = "Select * from DIENTHOAI";
            DataGridViewImageColumn picCol = new DataGridViewImageColumn(); // Doi tuong lam viec voi dang picture cua datagridview
            dataGridViewDienThoai.RowTemplate.Height = 80; // Co gian de picture dep
            dataGridViewDienThoai.DataSource = HienDL(query);
            picCol = (DataGridViewImageColumn)dataGridViewDienThoai.Columns[5];
            picCol.ImageLayout = DataGridViewImageCellLayout.Stretch;

            dataGridViewDienThoai.AllowUserToAddRows = false;
            dataGridViewDienThoai.ReadOnly = true;

        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            string maTB = textBoxMaThietBi.Text;
            if (maTB == "")
            {
                MessageBox.Show("Vui lòng nhập mã thiết bị để xóa", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn xóa thiết bị này", "Hệ thống", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                    if (thietbi.xoaThietBi(maTB))
                    {
                        MessageBox.Show("Xóa thiết bị thành công", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        fDienThoai_Load(sender,e);
                    }
                    else
                    {
                        MessageBox.Show("Error", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }
        }

        private void buttonChinhSua_Click(object sender, EventArgs e)
        {
            string maTB = textBoxMaThietBi.Text;
            string tenTB = textBoxTenThietBi.Text;
            string maLoai = comboBoxLoaiThietBi.SelectedValue.ToString();
            string maNCC = comboBoxNCC.SelectedValue.ToString();
            MemoryStream pic = new MemoryStream();
            if (verif())
            {
                int soLuong = Convert.ToInt32(textBoxSoLuong.Text);
                int donGia = Convert.ToInt32(textBoxDonGia.Text);
                hinhAnhPictureBox.Image.Save(pic, hinhAnhPictureBox.Image.RawFormat);
                if (thietbi.suaThietBi(maTB, tenTB, maNCC, maLoai, soLuong, pic, donGia))
                {
                    MessageBox.Show("Sửa thiết bị thành công", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fDienThoai_Load(sender, e);
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

        private void dataGridViewDienThoai_DoubleClick(object sender, EventArgs e)
        {
            textBoxMaThietBi.Text = dataGridViewDienThoai.CurrentRow.Cells[0].Value.ToString();
            textBoxTenThietBi.Text = dataGridViewDienThoai.CurrentRow.Cells[1].Value.ToString();
            comboBoxNCC.Text = dataGridViewDienThoai.CurrentRow.Cells[2].Value.ToString();
            comboBoxLoaiThietBi.Text = dataGridViewDienThoai.CurrentRow.Cells[3].Value.ToString();
            textBoxSoLuong.Text = dataGridViewDienThoai.CurrentRow.Cells[4].Value.ToString();
            byte[] pic;
            pic = (byte[])dataGridViewDienThoai.CurrentRow.Cells[5].Value;
            MemoryStream picture = new MemoryStream(pic);
            hinhAnhPictureBox.Image = Image.FromStream(picture);
            textBoxDonGia.Text = dataGridViewDienThoai.CurrentRow.Cells[6].Value.ToString();
        }

        private void buttonThem_Click_1(object sender, EventArgs e)
        {
            string maTB = textBoxMaThietBi.Text;
            
            string tenTB = textBoxTenThietBi.Text;
            string maLoai = comboBoxLoaiThietBi.SelectedValue.ToString();
            string maNCC = comboBoxNCC.SelectedValue.ToString();
            MemoryStream pic = new MemoryStream();
            if (verif())
            {
                int soLuong = Convert.ToInt32(textBoxSoLuong.Text);
                int donGia = Convert.ToInt32(textBoxDonGia.Text);
                hinhAnhPictureBox.Image.Save(pic, hinhAnhPictureBox.Image.RawFormat);
                if (thietbi.themThietBi(maTB, tenTB, maNCC, maLoai, soLuong, pic, donGia))
                {
                    MessageBox.Show("Thêm thiết bị thành công", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fDienThoai_Load(sender, e);
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
    }
}
