using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Class_Exercise
{
    class Milk : MatHang
    {
        private DateTime mNgaySanXuat { get; set; }
        private DateTime mHanSuDung { get; set; }
        private string mDonViTinh { get; set; }
        public override float ThanhTien()
        {
            return mDonGia * mSoLuong;
        }

        public override void XemChiTiet()
        {
            Console.WriteLine("Ma Hang:" + mMaHang);
            Console.WriteLine("Ten Hang:" + mTenHang);
            Console.WriteLine("Don Gia:" + mDonGia);
            Console.WriteLine("So Luong:" + mSoLuong);
            Console.WriteLine("Ngay San Xuat:" + mNgaySanXuat);
            Console.WriteLine("Han Su Dung:"+mHanSuDung);
            Console.WriteLine("Don Vi Tinh:" + mDonViTinh);
        }
        public Milk()
        {
                
        }
        public Milk(string maHang, string tenHang, int soLuong, float donGia, DateTime ngaySanXuat, DateTime hanSuDung, string donVi): base(maHang, tenHang, soLuong, donGia)
        {
            mNgaySanXuat = ngaySanXuat;
            mHanSuDung = hanSuDung;
            mDonViTinh = donVi;
        }
    }
}
