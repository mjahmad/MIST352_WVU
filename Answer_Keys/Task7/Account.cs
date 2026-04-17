using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7
{
    internal class Account
    {
        //########## Fields ###############
        private int _accountNumber;
        private string _ownerName;
        private double _balance;
       

        //########## Properties ###############
        public int AccountNumber{ get => _accountNumber; }
        public string OwnerName
        { get => _ownerName;
            set { 
                _ownerName = value;
            }
        }
        public double Balance
        { get => _balance;
            private set { _balance = value; }
        }

        //########## Constructors ###############
        public Account()
        {
            _accountNumber = 0;
            _ownerName = "N/P";
            _balance = 0;
        }

        public Account(int accNum, string ownName)
        {
            _accountNumber = accNum;
            _ownerName = ownName;
            _balance = 0;
        }

        public Account(int accNum, string ownName, int bal)
        {
            _accountNumber = accNum;
            _ownerName = ownName;
            if (bal < 0)
            {
                Console.WriteLine("Starting Balance can not be less\n Provide balance again");
                bal = Int32.Parse(Console.ReadLine());

            }
            _balance = bal;
        }


        //###### Methods #############
        public void Deposit(double amnt)
        {
            if (amnt <= 0)
            {
                Console.WriteLine("Deposite can not be zero or less");

            }
            else
            {
                _balance += amnt;

            }
        }


        public void Withdraw(double amnt)
        {
            if (amnt > _balance)
            {
                Console.WriteLine("Withdraw should not exceed balance");

            }
            else
            {
                _balance -= amnt;

            }
        }

        public void PrintInfo()
                {
                    Console.WriteLine($"Account Number: {_accountNumber}\nOwner Name: {_ownerName}\nBalance : {_balance}");
                }


    }
}
