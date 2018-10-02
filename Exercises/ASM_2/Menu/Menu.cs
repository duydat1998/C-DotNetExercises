using System;
using System.Collections.Generic;

namespace Menu
{
    public class Menu
    {
        public static void PrintOption(List<string> options)
        {
            int i = 1;
            Console.WriteLine("--------------------------------------------------");
            foreach (string s in options)
            {
                Console.WriteLine(i + ". " + s);
                i++;
            }
            Console.Write("Please enter option:");
        }

        public static int GetChoice(int min, int max)
        {
            int accChoice =-1;
            bool check = false;
            do
            {
                check = false;
                try
                {
                    accChoice = Convert.ToInt32(Console.ReadLine());
                    check = true;
                    if (accChoice < min || accChoice > max)
                    {
                        Console.WriteLine("Choice doesn't exist. Please enter again");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Choice doesn't exist. Please enter again");
                }
            } while (accChoice < min || accChoice > max || check == false);
            return accChoice;

        }

    }
}
