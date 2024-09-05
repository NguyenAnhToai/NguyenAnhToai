using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project_quanlybanhang
{
    class ThaotacCSDL
    {
        SqlConnection sqlConn;
        SqlDataAdapter da;
        DataSet ds;
        public SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-54LB2A8\HUYSEVER;Initial Catalog=QLSHOPDT;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");
        public SqlConnection getConnection
        {
            get { return con; }
        }
        public ThaotacCSDL()
        {
            string strCnn = @"Data Source=DESKTOP-54LB2A8\HUYSEVER;Initial Catalog=QLSHOPDT;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
            sqlConn = new SqlConnection(strCnn);
        }
        //Cho cau lenh select
        public DataTable Execute(string sqlStr)
        {
            da = new SqlDataAdapter(sqlStr, sqlConn);
            ds = new DataSet();
            da.Fill(ds);  // Lấy dữ liệu từ CSDL đổ vào dataset (fill)
            return ds.Tables[0];
        }
        //Cho cau lenh Them, Xoa, Sua
        public void ExecuteNonQuery(string strSQL) // insert, delete, update
        {
            SqlCommand sqlcmd = new SqlCommand(strSQL, sqlConn);
            sqlConn.Open(); //Mo ket noi

            sqlcmd.ExecuteNonQuery();//Lenh hien lenh Them/Xoa/Sua
            sqlConn.Close();//Dong ket noi          
        }
        public void openConnection()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }

        // close the connection
        public void closeConnection()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }

    }
    
}
