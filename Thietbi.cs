using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Data.SqlClient;

namespace project_quanlybanhang
{
    class Thietbi
    {
        ThaotacCSDL mydb;
        public Thietbi()
        {
            mydb = new ThaotacCSDL();
        }
        public bool themThietBi(string maDT, string tenDT, string maNCC, string maLoai, int soLuong, MemoryStream hinhAnh, int gia)
        {
            SqlCommand command = new SqlCommand("INSERT INTO DIENTHOAI (MaDT, TenDT, MaNCC, MaLoai, SoLuong, HinhAnh, Gia) VALUES" +
                " (@mdt, @tendt, @mncc, @mloai, @sl, @hanh, @gia) ",mydb.getConnection);
            command.Parameters.Add("@mdt",SqlDbType.VarChar).Value = maDT;
            command.Parameters.Add("@tendt",SqlDbType.NVarChar).Value= tenDT;
            command.Parameters.Add("@mncc", SqlDbType.VarChar).Value = maNCC;
            command.Parameters.Add("@mloai", SqlDbType.VarChar).Value = maLoai;
            command.Parameters.Add("@sl",SqlDbType.Int).Value = soLuong;
            command.Parameters.Add("@hanh",SqlDbType.Image).Value = hinhAnh.ToArray();
            command.Parameters.Add("@gia",SqlDbType.Int).Value = gia;

            mydb.openConnection();
            if(command.ExecuteNonQuery() == 1)
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

        public bool suaThietBi(string maDT, string tenDT, string maNCC, string maLoai, int soLuong, MemoryStream hinhAnh, int gia)
        {
            SqlCommand command = new SqlCommand("UPDATE DIENTHOAI SET TenDT = @tendt, MaNCC = @mncc, MaLoai = @mloai, SoLuong = @sl, " +
                "HinhAnh = @hanh, Gia = @gia WHERE MaDT = @mdt", mydb.getConnection);
            command.Parameters.Add("@mdt", SqlDbType.VarChar).Value = maDT;
            command.Parameters.Add("@tendt", SqlDbType.NVarChar).Value = tenDT;
            command.Parameters.Add("@mncc", SqlDbType.VarChar).Value = maNCC;
            command.Parameters.Add("@mloai", SqlDbType.VarChar).Value = maLoai;
            command.Parameters.Add("@sl", SqlDbType.Int).Value = soLuong;
            command.Parameters.Add("@hanh", SqlDbType.Image).Value = hinhAnh.ToArray();
            command.Parameters.Add("@gia", SqlDbType.Int).Value = gia;

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

        public bool xoaThietBi(string maDT)
        {
            SqlCommand command = new SqlCommand("DELETE FROM DIENTHOAI WHERE MaDT = @mdt", mydb.getConnection);
            command.Parameters.Add("@mdt", SqlDbType.VarChar).Value = maDT;
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
