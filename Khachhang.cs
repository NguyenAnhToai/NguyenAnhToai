using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Reporting.Map.WebForms.BingMaps;

namespace project_quanlybanhang
{
    class Khachhang
    {
        
        public Khachhang()
        {
            
        }
        ThaotacCSDL mydb = new ThaotacCSDL();
      
        
        public bool themKhachHang(string maKH, string tenKH, string diaChi, string SDT, string gioiTinh)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO KHACHHANG (MaKH, TenKH, DiaChi, SDT, GioiTinh) Values (@ma, @ten, @dchi, @sdt, @gioitinh)", mydb.getConnection);
            cmd.Parameters.Add("@ma", SqlDbType.VarChar).Value = maKH;
            cmd.Parameters.Add("ten", SqlDbType.NVarChar).Value = tenKH;
            cmd.Parameters.Add("@dchi", SqlDbType.NVarChar).Value = diaChi;
            cmd.Parameters.Add("@sdt", SqlDbType.VarChar).Value = SDT;
            cmd.Parameters.Add("gioitinh", SqlDbType.NVarChar).Value = gioiTinh;
            mydb.openConnection();
            if (cmd.ExecuteNonQuery() == 1)
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
        public bool xoaKhachHang(string maKH)
        {
            SqlCommand command = new SqlCommand("DELETE FROM KHACHHANG WHERE MaKH=@ma", mydb.getConnection);
            command.Parameters.Add("@ma", SqlDbType.VarChar).Value = maKH;
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

        public bool suaKhachHang(string maKH, string tenKH, string diaChi, string SDT, string gioiTinh)
        {

            SqlCommand command = new SqlCommand("Update KHACHHANG SET TenKH=@ten, DiaChi=@diachi, SDT=@sdt, GioiTinh=@gioitinh WHERE MaKH=@ma", mydb.getConnection);
            command.Parameters.Add("@ma", SqlDbType.VarChar).Value = maKH;
            command.Parameters.Add("@ten", SqlDbType.NVarChar).Value = tenKH;
            command.Parameters.Add("@diachi", SqlDbType.NVarChar).Value = diaChi;         
            command.Parameters.Add("@sdt", SqlDbType.VarChar).Value = SDT;
            command.Parameters.Add("@gioitinh", SqlDbType.NVarChar).Value = gioiTinh;
            
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
