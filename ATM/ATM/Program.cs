using System;

namespace ATM
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter your pin.");
            InputHander();
        }

        static public int ChooseTransaction()
        {
            Console.WriteLine("Please select your transaction type:");
            Console.WriteLine("1. View Balance");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Deposit");

            return Convert.ToInt32(Console.ReadLine()); ;
        }

        public void ViewBalance(decimal balance)
        {
            Console.WriteLine($"Your current balance is: {balance}");
        }

        public int Withdraw()
        {
            Console.WriteLine("How much would you like to withdraw? Please enter a multiple of 20.");

            return Convert.ToInt32(Console.ReadLine());
        }

        public decimal Deposit(decimal balance)
        {
            Console.WriteLine("Please enter amount of deposit:");

            decimal depositAmount = Convert.ToInt32(Console.ReadLine());
            decimal newBalance = balance + depositAmount;
            return newBalance;
        }

        public void InputHandler()
        {

            decimal balance = 5280.00M;

            int transactionType = ChooseTransaction();

            if(transactionType == 1)
            {
                ViewBalance(balance);
            }

            if(transactionType == 2)
            {
                int input = Withdraw();
                if(input > balance)
                {
                    Console.WriteLine($"Insufficient funds for this transaction.");
                }
                else
                {
                    decimal newBalance = (balance - input);
                    balance = newBalance;
                    Console.WriteLine($"Your current balance is: {newBalance}");
                }
            }

            if(transactionType == 3)
            {
                Deposit();
            }
        }

 
    }
}
