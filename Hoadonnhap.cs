using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace project_quanlybanhang
{
    class Hoadonnhap
    {
        ThaotacCSDL mydb;
        public Hoadonnhap()
        {
            mydb = new ThaotacCSDL();
        }
        public bool nhapHoaDon(string maHDN, string maNV, DateTime ngayXuatHD, int tongTienNhap)
        {
            SqlCommand command = new SqlCommand("INSERT INTO HOADONNHAP (MaHDN, MaNV, NgayXuatHDN, TongTienNhap) VALUES (@mahd, @manv, @ngayxuat, @tongtien)",mydb.getConnection);
            command.Parameters.Add("@mahd", SqlDbType.VarChar).Value = maHDN;
            command.Parameters.Add("@manv", SqlDbType.VarChar).Value = maNV;
            command.Parameters.Add("@ngayxuat",SqlDbType.DateTime).Value = ngayXuatHD;
            command.Parameters.Add("@tongtien",SqlDbType.Int).Value = tongTienNhap;

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

        public bool suaHoaDon(string maHDN, string maNV, DateTime ngayXuatHD, int tongTienNhap)
        {
            SqlCommand command = new SqlCommand("UPDATE HOADONNHAP SET MaNV= @manv, NgayXuatHD = @ngayxuat, TongTienNhap = @tongtien WHERE MaHDN = @mahd", mydb.getConnection);
            command.Parameters.Add("@mahd", SqlDbType.VarChar).Value = maHDN;
            command.Parameters.Add("@manv", SqlDbType.VarChar).Value = maNV;
            command.Parameters.Add("@ngayxuat", SqlDbType.DateTime).Value = ngayXuatHD;
            command.Parameters.Add("@tongtien", SqlDbType.Int).Value = tongTienNhap;

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

        public bool xoaHoaDon(string maHDN)
        {
            SqlCommand command = new SqlCommand("DELETE  FROM HOADONNHAP  WHERE MaHDN=@ma", mydb.getConnection);
            command.Parameters.Add("@ma", SqlDbType.VarChar).Value = maHDN;
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
    }
}
