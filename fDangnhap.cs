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
    public partial class fLogin : Form
    {
        
        ThaotacCSDL mydb = new ThaotacCSDL();
        public fLogin()
        {
            InitializeComponent();
        }

        private void txtuser_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            
        }
         
        private void btnExit_Click(object sender, EventArgs e)
        {
            
        }

        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void fLogin_Load(object sender, EventArgs e)
        {
             

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.button1.BackColor = Color.Transparent;
            //SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-KNCJTSN8;Initial Catalog=QUANLY_CUAHANGMAYTINH;Integrated Security=True");
            //try
            //{
            //    conn.Open();
            //    string tk = txtuser.Text;
            //    string mk = txtpass.Text;
            //    string sql = "select *from TAIKHOAN where TenTaiKhoan = '" + tk + "'and MatKhau= '" + mk + "'";
            //    SqlCommand cmd = new SqlCommand(sql, conn);
            //    SqlDataReader dta = cmd.ExecuteReader();
            //    if (dta.Read() == true)
            //    {
            //        MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        fTableManager f = new fTableManager(tk);
            //        f.ShowDialog();
            //        this.Hide();
            //        this.Show();
            //    }
            //    else
            //    {
            //        MessageBox.Show("Đăng nhập thất bại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Lỗi kết nối!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string username= txtuser.Text;
            string password = txtpass.Text;
            string query = "Select TenNV, ChucVu from DANGNHAP INNER JOIN NHANVIEN ON DANGNHAP.MaNV = NHANVIEN.MaNV WHERE DANGNHAP.Username = '"+username+"' AND DANGNHAP.Password = '"+password+"'";
            SqlDataAdapter adapter = new SqlDataAdapter(query, mydb.getConnection);
            DataTable dt = new DataTable(); 
            adapter.Fill(dt);
            if(dt.Rows.Count > 0)
            {
                string TenNV = dt.Rows[0]["TenNV"].ToString();
                string ChucVu = dt.Rows[0]["ChucVu"].ToString();
                fTableManager f = new fTableManager(TenNV, ChucVu);
                f.Show();
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại!!!");
            }

            
                
            
        }
    }
}
