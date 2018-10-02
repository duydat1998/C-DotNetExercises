using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_Exercise
{
    class HinhChuNhat:IHinh
    {
        private float mChieuCao{get;set;}
        private float mChieuRong { get; set; }
        public HinhChuNhat()
        {

        }
        public HinhChuNhat(float chieuCao, float chieuRong)
        {
            mChieuCao = chieuCao;
            mChieuRong = chieuRong;
        }

        public float TinhChuVi()
        {
            return (mChieuRong + mChieuCao) * 2;
        }

        public float TinhDienTich()
        {
            return mChieuCao * mChieuRong;
        }

        public void XemThongTin()
        {
            Console.WriteLine("Chieu Cao: "+mChieuCao);
            Console.WriteLine("Chieu rong: "+mChieuRong);
        }
    }
}
