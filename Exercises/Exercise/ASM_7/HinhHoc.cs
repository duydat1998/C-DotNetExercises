using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_7
{
    public class HinhHoc
    {
        protected float mDienTich, mChuVi;
        public virtual void XemChuViDienTich()
        {
            Console.WriteLine("Dien Tich: "+mDienTich);
            Console.WriteLine("Chu Vi: "+mChuVi);
        }

    }
}
