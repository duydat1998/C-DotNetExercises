using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_6
{
    class Program
    {
        static void Main(string[] args)
        {
            Medicine med = new Medicine();
            med.Accept();
            med.IncreaseQuantity();
            Console.WriteLine("The first Print() method:");
            med.Print();
            Console.WriteLine("The second Print() method:");
            med.Print("M002");
            Console.WriteLine("The third Print() method:");
            med.Print("M003", "Paracetamol");
            Console.ReadLine();
        }
    }
}
