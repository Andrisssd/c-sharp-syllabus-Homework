using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{
    class Account
    {
        private string _name;
        private double _money;
        private string _nameAndMoney;
        
        public Account(string v1, double v2)
        {
            _name = v1;
            _money = v2;
        }

        private void SetNameAndBalance()
        {
            string money = String.Format("{0:0.00}",_money);
            _nameAndMoney = $"{_name}, ${money}";
        }

        public string ShowUserNameAndBalance()
        {
            SetNameAndBalance();
            if (_money < 0)
            {
                _nameAndMoney = _nameAndMoney.Replace("$-", "-$");
            }

            return _nameAndMoney;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            double money = Convert.ToDouble(Console.ReadLine());
            Account account = new Account(name, money);
            Console.WriteLine(account.ShowUserNameAndBalance());
        }
    }
}
