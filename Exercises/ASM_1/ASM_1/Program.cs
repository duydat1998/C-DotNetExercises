using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_1
{
    class Program
    {
        
        static void Main(string[] args)
        {
            DanhSachSinhVien ds = new DanhSachSinhVien();
            int accChoice = 0;
            bool check = false;
            while (true)
            {
                do
                {
                    check = false;
                    Console.WriteLine("****** Quan li sinh vien ******");
                    Console.WriteLine("1. Xem danh sach sinh vien");
                    Console.WriteLine("2. Them sinh vien");
                    Console.WriteLine("3. Tim sinh vien");
                    Console.WriteLine("4. Cap nhat thong tin sinh vien");
                    Console.WriteLine("5. Thoat");
                    Console.WriteLine("Vui long chon: ");
                    try
                    {
                        accChoice = Convert.ToInt32(Console.ReadLine());
                        check = true;
                        if (accChoice < 1 || accChoice > 5)
                        {
                            Console.WriteLine("Lua chon khong ton tai. Vui long chon lai.");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Lua chon khong ton tai. Vui long chon lai.");
                    }
                } while (accChoice < 1 || accChoice > 5 || check==false );

                switch (accChoice)
                {
                    case 1:
                        ds.XemDanhSachSinhVien();
                        break;
                    case 2:
                        ds.ThemSinhVien();
                        break;
                    case 3:
                        ds.TimSinhVien();
                        break;
                    case 4:
                        ds.CapNhapThongTinSinhVien();
                        break;
                    case 5:
                        return;
                }
            }
        }

        

    }
}
