using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace project_quanlybanhang
{
    class NhaCC
    {
        
        public NhaCC()
        {
            
        }
        ThaotacCSDL mydb = new ThaotacCSDL();
        public bool themNhaCungCap(string maNCC, string tenNCC, string diaChi, string soDT)
        {
            SqlCommand command = new SqlCommand("INSERT INTO NHACUNGCAP (MaNCC, TenNCC, DiaChi, SoDT) Values (@ma, @ten, @dchi, @sdt)",mydb.getConnection);
            command.Parameters.Add("@ma",SqlDbType.VarChar).Value = maNCC;
            command.Parameters.Add("@ten",SqlDbType.NVarChar).Value = tenNCC;
            command.Parameters.Add("@dchi",SqlDbType.NVarChar).Value=diaChi;
            command.Parameters.Add("@sdt",SqlDbType.VarChar).Value = soDT;

            mydb.openConnection();
            if(command.ExecuteNonQuery()==1)
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }
        }

        public bool xoaNhaCungCap(string maNCC)
        {
            SqlCommand command = new SqlCommand("DELETE FROM NHACUNGCAP WHERE MaNCC=@ma", mydb.getConnection);
            command.Parameters.Add("@ma", SqlDbType.VarChar).Value = maNCC;
            mydb.openConnection();
            if ((command.ExecuteNonQuery() == 1))
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }
        }

        public bool suaNhaCungCap(string maNCC, string tenNCC, string diaChi, string soDT)
        {
            SqlCommand command = new SqlCommand("UPDATE NHACUNGCAP SET TenNCC = @ten, DiaChi = @dchi, SoDT = @sdt WHERE MaNCC = @ma", mydb.getConnection);
            command.Parameters.Add("@ma", SqlDbType.VarChar).Value = maNCC;
            command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = tenNCC;
            command.Parameters.Add("@dchi", SqlDbType.NVarChar).Value = diaChi;
            command.Parameters.Add("@sdt", SqlDbType.VarChar).Value = soDT;

            mydb.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }
        }
        
    }
}
