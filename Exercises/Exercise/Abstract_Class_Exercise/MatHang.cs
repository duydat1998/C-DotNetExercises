using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Class_Exercise
{
    abstract class MatHang
    {
        protected string mMaHang { get; set; }
        protected string mTenHang { get; set; }
        protected int mSoLuong { get; set; }
        protected float mDonGia { get; set; }

        public abstract float ThanhTien();
        public abstract void XemChiTiet();
        public MatHang()
        {

        }
        public MatHang(string maHang, string tenHang, int soLuong, float donGia)
        {
            mMaHang = maHang;
            mTenHang = tenHang;
            mDonGia = donGia;
            mSoLuong = soLuong;
        }

    }
}
