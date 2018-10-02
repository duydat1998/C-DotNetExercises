using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ASM_1
{
    class SinhVien
    {
        private const string DATE_FORMAT = "dd/MM/yyyy";

        private string mMaSV;

        public string MaSV
        {
            get { return mMaSV; }
            set { mMaSV = value; }
        }

        private string mHoTen;

        public string HoTen
        {
            get { return mHoTen; }
            set { mHoTen = value; }
        }

        private DateTime mNgaySinh;

        public DateTime NgaySinh
        {
            get { return mNgaySinh; }
            set { mNgaySinh = value; }
        }

        private string mDiaChi;

        public string DiaChi
        {
            get { return mDiaChi; }
            set { mDiaChi = value; }
        }

        private string mDienThoai;

        public string DienThoai
        {
            get { return mDienThoai; }
            set { mDienThoai = value; }
        }

        public SinhVien()
        {

        }

        public SinhVien(string maSV, string hoTen, DateTime ngaySinh, string diaChi, string dienThoai)
        {
            mMaSV = maSV;
            mHoTen = hoTen;
            mNgaySinh = ngaySinh;
            mDiaChi = diaChi;
            mDienThoai = dienThoai;
        }

        public void XemThongTin()
        {
            WriteLine("Thong tin sinh vien "+MaSV);
            WriteLine("Ma Sinh Vien: "+MaSV);
            WriteLine("Ho Ten: "+HoTen);
            WriteLine("Ngay Sinh: "+NgaySinh.ToString(DATE_FORMAT,null));
            WriteLine("Dia Chi: "+DiaChi);
            WriteLine("Dien thoai:"+DienThoai);
            WriteLine("--- --- --- --- ---");
        }
        

    }
}
