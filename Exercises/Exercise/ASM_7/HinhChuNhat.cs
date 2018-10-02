using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_7
{
    public class HinhChuNhat:HinhHoc
    {
        private float mChieuDai, mChieuRong;
        public HinhChuNhat()
        {
            mChieuDai = 4;
            mChieuRong = 2;

        }

        public HinhChuNhat(float chieuDai, float chieuRong)
        {
            mChieuDai = chieuDai;
            mChieuRong = chieuRong;
        }

        public void TinhChuVi_DienTich()
        {
            mChuVi = (mChieuDai + mChieuRong) * 2;
            mDienTich = mChieuRong * mChieuDai;

        }
        public override void XemChuViDienTich()
        {
            Console.WriteLine("Thong tin Hinh Chu Nhat");
            base.XemChuViDienTich();
        }
    }
}
