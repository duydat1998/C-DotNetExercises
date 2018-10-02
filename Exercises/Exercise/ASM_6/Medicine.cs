using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM_6
{
    class Medicine
    {
        private string code; // mã thuốc
        private string name; // tên thuốc
        private string manufacturer; // hãng sản xuất
        private int price; // đơn giá
        private int quantity; // số lượng
        private string date; // ngày sản xuất
        private string expireDate; // ngày hết hạn
        private int batchNumber; // mã lô hàng

        public Medicine()
        {
            code = null;
            name = null;
            manufacturer = null;
            price = 0;
            quantity = 0;
            date = null;
            expireDate = null;
            batchNumber = 0;
        }

        public Medicine(string code, string name, string manufacturer, int price, int quantity, string date, string expireDate, int batchNumber)
        {
            this.code = code;
            this.name = name;
            this.manufacturer = manufacturer;
            this.price = price;
            this.quantity = quantity;
            this.date = date;
            this.expireDate = expireDate;
            this.batchNumber = batchNumber;
        }

        public void Accept()
        {
            do
            {
                Console.WriteLine("Input Code:");
                code = Console.ReadLine();
                Console.WriteLine("Input Name:");
                name = Console.ReadLine();
                Console.WriteLine("Input Manufature name:");
                manufacturer = Console.ReadLine();
                Console.WriteLine("Input Unit price:");
                price = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Input Quantity on hand:");
                quantity = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Input Manufactured date:");
                date = Console.ReadLine();
                Console.WriteLine("Input Expiry date:");
                expireDate = Console.ReadLine();
                Console.WriteLine("Input Batch number:");
                batchNumber = Convert.ToInt32(Console.ReadLine());
            } while (code==null||name==null||manufacturer==null||date==null||expireDate==null);
            
            
        }

        public void IncreaseQuantity()
        {
            this.quantity += 50;
        }

        public void Print()
        {
            Console.WriteLine("\n***** The Medicine detail ******");
            Console.WriteLine("Medicine Code: "+code);
            Console.WriteLine("Medicine Name: "+name);
            Console.WriteLine("Manufature name: "+manufacturer);
            Console.WriteLine("Unit price: "+price);
            Console.WriteLine("Quantity on hand: "+quantity);
            Console.WriteLine("Manufactured date: " +date);
            Console.WriteLine("Expiry date: "+expireDate);
            Console.WriteLine("Batch number: "+batchNumber);
        }

        public void Print(string code)
        {
            Console.WriteLine("Medicine Code: " + code);
            Console.WriteLine("Quantity on hand: " + quantity);
        }

        public void Print(string code, string name)
        {
            Console.WriteLine("Medicine Code: " + code);
            Console.WriteLine("Medicine Name: " + name);
            Console.WriteLine("Manufactured date: " + date);
            Console.WriteLine("Expiry date: " + expireDate);
        }


    }
}
