using System;

namespace Exercise8
{
    class SavingsAccount
    {
        private decimal rate;
        private decimal balance;
        private int monthAccountLives;
        private decimal interestEarned = 0;
        private decimal deposited = 0;
        private decimal withdrawn = 0;

        public SavingsAccount(decimal balance, decimal rate, int months)
        {
            this.balance = balance;
            this.rate = rate;
            this.monthAccountLives = months;
        }

        public void Withdraw(decimal amount)
        {
            withdrawn += amount;
            balance -= amount;
        }

        public void Deposit(decimal amount)
        {
            deposited += amount;
            balance += amount;
        }

        public void AddMonthlyInterest()
        {
            interestEarned += balance*(rate/12);
            balance = balance + balance*(rate/12);
        }

        public static SavingsAccount InitializeAccount()
        {
            Console.Write("How much money is in the account?: ");
            decimal newBalance = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Enter the annual interest rate: ");
            decimal newRate = Convert.ToDecimal(Console.ReadLine());
            Console.Write("How long has the account been opened? ");
            int months = Convert.ToInt32(Console.ReadLine());
            return new SavingsAccount(newBalance, newRate, months);
        }
       
        public void TakeInfoAboutOperations()
        {
            for(int i = 1; i <= monthAccountLives; i++)
            {
                Console.Write("Enter amount deposited for month: {0}: ",i);
                decimal amountToDeposit = Convert.ToDecimal(Console.ReadLine());
                Deposit(amountToDeposit);
                Console.Write("Enter amount withdrawn for {0}: ",i);
                decimal amountToWithdraw = Convert.ToDecimal(Console.ReadLine());
                Withdraw(amountToWithdraw);
                AddMonthlyInterest();
            }
        }

        public void PrintFinalInfo()
        {
            Console.WriteLine("Total deposited: ${0}",Math.Round(deposited,2));
            Console.WriteLine("Total withdrawn: ${0}",Math.Round(withdrawn,2));
            Console.WriteLine("Interest earned: ${0}",Math.Round(interestEarned,2));
            Console.WriteLine("Ending balance: ${0}",Math.Round(balance,2));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            SavingsAccount account1 = SavingsAccount.InitializeAccount();
            account1.TakeInfoAboutOperations();
            account1.PrintFinalInfo();
        }
    }
}
