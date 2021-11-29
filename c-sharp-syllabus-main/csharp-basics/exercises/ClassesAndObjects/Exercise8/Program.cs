using System;

namespace Exercise8
{
    class SavingsAccount
    {
        private decimal _rate;
        private decimal _balance;
        private int _monthAccountLives;
        private decimal _interestEarned = 0;
        private decimal _deposited = 0;
        private decimal _withdrawn = 0;

        public SavingsAccount(decimal balance, decimal rate, int months)
        {
            this._balance = balance;
            this._rate = rate;
            this._monthAccountLives = months;
        }

        public void Withdraw(decimal amount)
        {
            _withdrawn += amount;
            _balance -= amount;
        }

        public void Deposit(decimal amount)
        {
            _deposited += amount;
            _balance += amount;
        }

        public void AddMonthlyInterest()
        {
            _interestEarned += _balance*(_rate/12);
            _balance = _balance + _balance*(_rate/12);
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
            for(int i = 1; i <= _monthAccountLives; i++)
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
            Console.WriteLine("Total deposited: ${0}",Math.Round(_deposited,2));
            Console.WriteLine("Total withdrawn: ${0}",Math.Round(_withdrawn,2));
            Console.WriteLine("Interest earned: ${0}",Math.Round(_interestEarned,2));
            Console.WriteLine("Ending balance: ${0}",Math.Round(_balance,2));
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
