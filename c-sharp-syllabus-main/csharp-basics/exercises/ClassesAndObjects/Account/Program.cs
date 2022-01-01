using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountNamespace
{
    class Program
    {
        private static void Main(string[] args)
        {
            Account bartosAccount = new Account("Barto's account", 100.00);
            Account bartosSwissAccount = new Account("Barto's account in Switzerland", 1000000.00);
            Console.WriteLine("Initial state");
            Console.WriteLine(bartosAccount);
            Console.WriteLine(bartosSwissAccount);
            bartosAccount.Withdrawal(20);
            Console.WriteLine("Barto's account balance is now: "+bartosAccount.Balance());
            bartosSwissAccount.Deposit(200);
            Console.WriteLine("Barto's Swiss account balance is now: "+bartosSwissAccount.Balance());
            Console.WriteLine("Final state");
            Console.WriteLine(bartosAccount);
            Console.WriteLine(bartosSwissAccount);
            Console.WriteLine("=======================================");
            Account mattsAccount = new Account("Matt's account", 1000);
            Account myAccaunt = new Account("My poor account", 0);
            mattsAccount.Withdrawal(100);
            myAccaunt.Deposit(100);
            Console.WriteLine(mattsAccount.ToString());
            Console.WriteLine(myAccaunt.ToString());
            Account.Transfer(mattsAccount, myAccaunt, 100);
            Console.WriteLine(mattsAccount.ToString());
            Console.WriteLine(myAccaunt.ToString());
        }
    }
}
