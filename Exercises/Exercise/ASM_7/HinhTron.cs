using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_7
{
    public class HinhTron:HinhHoc
    {
        private float mBanKinh;
        public HinhTron()
        {
            mBanKinh = 0;
        }
        public HinhTron(float banKinh)
        {
            mBanKinh = banKinh;
        }

        public void TinhChuVi_DienTich()
        {
            mChuVi = 2 * (float) Math.PI * mBanKinh;
            mDienTich = (float)Math.PI * mBanKinh * mBanKinh;

        }

        public override void XemChuViDienTich()
        {
            Console.WriteLine("Thong tin Hinh Tron");
            base.XemChuViDienTich();
        }
    }
}
