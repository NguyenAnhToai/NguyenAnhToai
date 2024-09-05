using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace project_quanlybanhang
{
    class LoaiDienThoai
    {
        ThaotacCSDL mydb;
        public LoaiDienThoai()
        {
            mydb = new ThaotacCSDL();
        }
        public bool themLoaiDienThoai(string maLoai, string tenLoai, string moTa)
        {
            SqlCommand command = new SqlCommand("INSERT INTO LOAIDIENTHOAI (MaLoai, TenLoai, MoTa) VALUES (@ma, @ten, @mota)",mydb.getConnection);
            command.Parameters.Add("@ma",SqlDbType.VarChar).Value = maLoai;
            command.Parameters.Add("@ten",SqlDbType.NVarChar).Value = tenLoai;
            command.Parameters.Add("@mota",SqlDbType.Text).Value = moTa;

            mydb.openConnection();
            if(command.ExecuteNonQuery() ==1)
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

        public bool xoaLoaiDienThoai(string maLoai)
        {
            SqlCommand command = new SqlCommand("DELETE FROM LOAIDIENTHOAI WHERE MaLoai=@ma", mydb.getConnection);
            command.Parameters.Add("@ma", SqlDbType.VarChar).Value = maLoai;
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

        public bool suaLoaiDienThoai(string maLoai, string tenLoai, string moTa)
        {
            SqlCommand command = new SqlCommand("UPDATE LOAIDIENTHOAI SET TenLoai = @ten, MoTa = @mota WHERE MaLoai = @ma", mydb.getConnection);
            command.Parameters.Add("@ma", SqlDbType.VarChar).Value = maLoai;
            command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = tenLoai;
            command.Parameters.Add("@mota", SqlDbType.Text).Value = moTa;

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
