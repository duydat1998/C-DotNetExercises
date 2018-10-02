﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3_Lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            Account acc = new Account(1, "David", 1000);
            int accChoice = 0;
            Console.WriteLine("*****Welcome to ATM banking*****");
            while (true)
            {
                do
                {
                    Console.WriteLine("---What do you want to do?---");
                    Console.WriteLine("1.Get Cash");
                    Console.WriteLine("2.Deposit cash");
                    Console.WriteLine("3.Deposit heck");
                    Console.WriteLine("4.Balance statement");
                    Console.WriteLine("5.Transfer");
                    Console.WriteLine("6.Exit");
                    Console.WriteLine("Enter your choice: ");
                    accChoice = Convert.ToInt32(Console.ReadLine());
                    if(accChoice < 1 || accChoice > 6)
                    {
                        Console.WriteLine("You have entered the wrong choice");
                    }
                } while (accChoice < 1 || accChoice > 6);

                switch (accChoice)
                {
                    case 1:
                        Console.WriteLine("Input the cash you want to get:");
                        int getCash = Convert.ToInt32(Console.ReadLine());
                        acc.GetCash = getCash;
                        break;
                    case 2:
                        Console.WriteLine("Input the cash you want to deposit:");
                        int depositCash = Convert.ToInt32(Console.ReadLine());
                        acc.DepositCash = depositCash;
                        break;
                    case 3:
                        Console.WriteLine("Input the cash you want to deposit:");
                        int depositCheck = Convert.ToInt32(Console.ReadLine());
                        acc.DepositCheck = depositCheck;
                        break;
                    case 4:
                        Console.WriteLine("The current balance of this account: "+acc.BalanceStatement);
             
                        break;
                    case 5:
                        Console.WriteLine("Input the cash you want to transfer:");
                        int transfer = Convert.ToInt32(Console.ReadLine());
                        acc.Transfer = transfer;
                        break;
                    case 6:
                        Console.WriteLine("Thanks for using our ATM");
                        return;
                }
            }

            
        }
    }
}
