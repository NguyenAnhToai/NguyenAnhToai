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
using System.Runtime.InteropServices;

namespace project_quanlybanhang
{
    public partial class fNhacungcap : Form
    {

        NhaCC nhacungcap;
        public fNhacungcap()
        {
            InitializeComponent();
            nhacungcap = new NhaCC();
        }

        ThaotacCSDL mydb = new ThaotacCSDL();
    

        private void fNhacungcap_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "Mã NCC";
            string query = "Select * from NHACUNGCAP";
            nHACUNGCAPDataGridView.DataSource = HienDL(query);





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
            if (comboBox1.Text == "Mã NCC")
            {
                DataTable dt = HienDL("select * from NHACUNGCAP where MaNCC = '" + textBox1.Text.Trim() + "'");
                if (dt.Rows.Count <= 0)
                {
                    MessageBox.Show("Không có dữ liệu nhà cung cấp", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                else
                {
                    nHACUNGCAPDataGridView.DataSource = dt;
                }

            }
            if (comboBox1.Text == "Tên NCC")
            {
                DataTable dt = HienDL("select * from NHACUNGCAP where TenNCC like N'%" + textBox1.Text.Trim() + "%'");
                if (dt.Rows.Count <= 0)
                {
                    MessageBox.Show("Không có dữ liệu nhà cung cấp", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                }
                else
                {
                    nHACUNGCAPDataGridView.DataSource = dt;
                }


            }
        }

        private void huy_Click(object sender, EventArgs e)
        {
            maNCCTextBox.Text = "";
            tenNCCTextBox.Text = "";
            sDTNCCTextBox.Text = "";
            diaChiNCCTextBox.Text = "";
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            string maNCC = maNCCTextBox.Text;
            string tenNCC = tenNCCTextBox.Text;
            string soDT = sDTNCCTextBox.Text;
            string diaChi = diaChiNCCTextBox.Text;
            if (verif())
            {
                if(nhacungcap.themNhaCungCap(maNCC,tenNCC,diaChi,soDT))
                {
                    MessageBox.Show("Thêm nhà cung cấp thành công!", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fNhacungcap_Load(sender, e);
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
            if(maNCCTextBox.Text =="" ||
                tenNCCTextBox.Text == "" ||
                sDTNCCTextBox.Text == "" ||
                diaChiNCCTextBox.Text == "")
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
            string maNCC = maNCCTextBox.Text;
            string tenNCC = tenNCCTextBox.Text;
            string soDT = sDTNCCTextBox.Text;
            string diaChi = diaChiNCCTextBox.Text;
            if (verif())
            {
                if (nhacungcap.suaNhaCungCap(maNCC, tenNCC, diaChi, soDT))
                {
                    MessageBox.Show("Chỉnh sửa nhà cung cấp thành công!", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fNhacungcap_Load(sender, e);
                }
                else
                {
                    MessageBox.Show("Không được thay đổi mã khách hàng!", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            string maNCC = maNCCTextBox.Text;
            if (maNCC == "")
            {
                MessageBox.Show("Vui lòng nhập mã khách hàng để xóa", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn xóa khách hàng này", "Hệ thống", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                    if (nhacungcap.xoaNhaCungCap(maNCC))
                    {
                        MessageBox.Show("Xóa khách hàng thành công", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        fNhacungcap_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Error", "Hệ thống", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }
        }
    }
}
