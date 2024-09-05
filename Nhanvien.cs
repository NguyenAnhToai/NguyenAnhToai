using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace project_quanlybanhang
{
    class Nhanvien
    {
        ThaotacCSDL db;
        ThaotacCSDL mydb = new ThaotacCSDL();
        public Nhanvien()
        {
            db = new ThaotacCSDL();
        }


        public bool themNhanVien(string manv, string tennv, string diachi,DateTime ngaySinh, string sdt,string gioitinh,MemoryStream picture, string chucVu)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO NHANVIEN (MaNV, TenNV, DiaChi, SDT, NgaySinh, GioiTinh, HinhAnh, ChucVu) Values (@ma, @ten, @dchi, @sdt, @ngaysinh, @gioitinh, @hinhanh, @chucvu)",mydb.getConnection);
            cmd.Parameters.Add("@ma", SqlDbType.NVarChar).Value = manv;
            cmd.Parameters.Add("ten", SqlDbType.NVarChar).Value = tennv;
            cmd.Parameters.Add("@dchi",SqlDbType.NVarChar).Value = diachi;
            cmd.Parameters.Add("@sdt", SqlDbType.VarChar).Value = sdt;
            cmd.Parameters.Add("@ngaysinh",SqlDbType.DateTime).Value = ngaySinh;
            cmd.Parameters.Add("gioitinh", SqlDbType.NVarChar).Value = gioitinh;
            cmd.Parameters.Add("@hinhanh",SqlDbType.Image).Value = picture.ToArray();
            cmd.Parameters.Add("@chucvu",SqlDbType.NVarChar).Value = chucVu;
            mydb.openConnection();
            if(cmd.ExecuteNonQuery()==1)
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
        public bool xoaNhanVien(string maNV)
        {
            SqlCommand command = new SqlCommand("DELETE  FROM NHANVIEN  WHERE MaNV=@ma", mydb.getConnection);
            command.Parameters.Add("@ma", SqlDbType.VarChar).Value = maNV;
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

        public bool chinhSuaNhanVien(string manv, string tennv, string diachi, DateTime ngaySinh, string sdt, string gioitinh, MemoryStream picture, string chucVu)
        {
            SqlCommand cmd = new SqlCommand("UPDATE NHANVIEN SET TenNV = @ten, DiaChi = @dchi, SDT = @sdt, NgaySinh = @ngaysinh, GioiTinh = @gioitinh, HinhAnh = @hinhanh, ChucVu = @chucvu Where MaNV = @ma", mydb.getConnection);
            cmd.Parameters.Add("@ma", SqlDbType.NVarChar).Value = manv;
            cmd.Parameters.Add("ten", SqlDbType.NVarChar).Value = tennv;
            cmd.Parameters.Add("@dchi", SqlDbType.NVarChar).Value = diachi;
            cmd.Parameters.Add("@sdt", SqlDbType.VarChar).Value = sdt;
            cmd.Parameters.Add("@ngaysinh", SqlDbType.DateTime).Value = ngaySinh;
            cmd.Parameters.Add("gioitinh", SqlDbType.NVarChar).Value = gioitinh;
            cmd.Parameters.Add("@hinhanh", SqlDbType.Image).Value = picture.ToArray();
            cmd.Parameters.Add("@chucvu", SqlDbType.NVarChar).Value = chucVu;
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
    }
}
