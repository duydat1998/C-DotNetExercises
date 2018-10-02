using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_7
{
    class Program
    {
        static void Main(string[] args)
        {
            HinhChuNhat hcn = new HinhChuNhat(8, 4);
            hcn.TinhChuVi_DienTich();
            hcn.XemChuViDienTich();

            HinhTron ht = new HinhTron(10);
            ht.TinhChuVi_DienTich();
            ht.XemChuViDienTich();
            Console.WriteLine("------***-----");
            Console.WriteLine("Su dung tinh da hinh");
            HinhHoc[] danhSachHinh = new HinhHoc[2];
            danhSachHinh[0] = hcn;
            danhSachHinh[1] = ht;
            foreach(var hh in danhSachHinh)
            {
                hh.XemChuViDienTich();
            }
            Console.ReadLine();
        }
    }
}
