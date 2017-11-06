using System;

namespace ATM
{
    class Program
    {
        static void Main(string[] args)
        {
            InputHandler();
        }

        static public int ChooseTransaction()
        {
            Console.WriteLine("Please select your transaction type:");
            Console.WriteLine("1. View Balance");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Deposit");
            Console.WriteLine("4. End transaction.");

            return Convert.ToInt32(Console.ReadLine());
        }

        static public void ViewBalance(decimal balance)
        {
            Console.WriteLine($"Your current balance is: {balance}");
        }

        static public decimal Withdraw(decimal balance)
        {
            Console.WriteLine("How much would you like to withdraw? Please enter a multiple of 20.");
            return balance - Convert.ToDecimal(Console.ReadLine());
        }

        static public decimal Deposit(decimal balance)
        {
            Console.WriteLine("Please enter amount of deposit:");

            decimal depositAmount = Convert.ToInt32(Console.ReadLine());
            decimal newBalance = balance + depositAmount;
            return newBalance;
        }

        static public void InputHandler(decimal balance = 5280.00M)
        {
            int transactionType = ChooseTransaction();

           // decimal balance = 5280.00M;

            switch (transactionType)
            {
                case 1:
                    ViewBalance(balance);
                    InputHandler(balance);
                    break;
                case 2:
                    decimal newBalance = Withdraw(balance);
                    if(newBalance > balance)
                    {
                        Console.WriteLine($"Insufficient funds for this transaction.");
                    }
                    else
                    {
                        balance = newBalance;
                        Console.WriteLine($"Your current balance is: {newBalance}");
                    }
                    InputHandler(balance);
                    break;
                case 3:
                    balance = Deposit(balance);
                    Console.WriteLine($"Your current balance is: {balance}");
                    InputHandler(balance);
                    break;
                case 4:
                    Console.WriteLine("Thank you for banking with Bank Fellows. Have a great day!");
                    break;
                default:
                    InputHandler();
                    break;
            }
        }
 
    }
}
