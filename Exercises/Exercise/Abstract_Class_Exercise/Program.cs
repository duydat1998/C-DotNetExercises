using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_Class_Exercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Socola:");
            Socola s = new Socola("SCL", "France Socola", 12, 3, "Nau", "Hop");
            Console.WriteLine("Thanh tien:"+s.ThanhTien());
            s.XemChiTiet();
            Console.WriteLine("Milf:");
            Milk m = new Milk("Milk","Milk",30,4,new DateTime(2018,3,12), new DateTime(2018,4,30),"Hop");
            Console.WriteLine("Thanh tien:" + m.ThanhTien());
            m.XemChiTiet();
            Console.ReadLine();
        }
    }
}
