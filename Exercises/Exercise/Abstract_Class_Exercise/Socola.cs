using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Class_Exercise
{
    class Socola : MatHang
    {
        private string mMauSac { get; set; }
        private string mDonViTinh { get; set; }
        public override float ThanhTien()
        {
            return mDonGia * mSoLuong;
        }

        public override void XemChiTiet()
        {
            Console.WriteLine("Ma Hang:"+mMaHang);
            Console.WriteLine("Ten Hang:"+mTenHang);
            Console.WriteLine("Don Gia:"+mDonGia);
            Console.WriteLine("So Luong:"+mSoLuong);
            Console.WriteLine("Mau Sac:"+mMauSac);
            Console.WriteLine("Don Vi Tinh:"+mDonViTinh);
        }
        public Socola()
        {

        }

        public Socola(string maHang, string tenHang, int soLuong, float donGia, string mauSac, string donVi):base(maHang,tenHang,soLuong,donGia)
        {
            mMauSac = mauSac;
            mDonViTinh = donVi;
        }
    }
}
