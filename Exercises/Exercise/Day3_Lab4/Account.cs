using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day3_Lab4
{
    class Account
    {
        private int mCode, mBalance;
        private string mName;

        public Account()
        {
            mCode = 0;
            mName = null;
            mBalance = 0;
        }

        public Account(int code, string name, int balance)
        {
            mCode = code;
            mName = name;
            mBalance = balance;

        }


        public int GetCash
        {

            set {
                if(value > mBalance)
                {
                    Console.WriteLine("The value cannot be greater than the current balance ");
                }
                else
                {
                    mBalance -= value;
                    Console.WriteLine("Succeed to withdraw "+value+" by cash");
                }
            }
        }

        public int DepositCash
        {
            set
            {
                if (value <=0 )
                {
                    Console.WriteLine("The value cannot be smaller than 0 ");
                }
                else
                {
                    mBalance += value;
                    Console.WriteLine("Succeed to deposit " + value + " by cash");
                }
            }
        }

        public int DepositCheck
        {
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("The value cannot be smaller than 0 ");
                }
                else
                {
                    mBalance += value;
                    Console.WriteLine("Succeed to deposit " + value + " by check");
                }
            }
        }

        public int BalanceStatement
        {
            get => mBalance;
        }

        public int Transfer
        {
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("The value cannot be smaller than 0 ");
                }
                else if(value >mBalance){
                    Console.WriteLine("Your account is insufficient");
                }
                else
                {
                    mBalance -= value;
                    Console.WriteLine("Succeed to transfer " + value + " to received account");
                }
            }
        }



    }
}
