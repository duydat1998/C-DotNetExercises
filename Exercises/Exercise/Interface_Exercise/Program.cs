using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            HinhChuNhat h = new HinhChuNhat((float)12.5,(float) 2.5);
            Console.WriteLine("Chu Vi: "+h.TinhChuVi());
            Console.WriteLine("Dien Tich: "+h.TinhDienTich());
            h.XemThongTin();
            Console.ReadLine();
        }
    }
}
