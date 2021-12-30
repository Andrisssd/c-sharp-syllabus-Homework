using AccountNamespace;
using System;

namespace AccountNamespace
    
{
    public class Account
    {
        private string _name;
        private double _money;

        public Account(string v1, double v2)
        {
            _name = v1;
            _money = v2;
        }

        public double Withdrawal(double i)
        {
            RemoveMoney(i);
            return i;
        }

        public void Deposit(double i)
        {
            AddMoney(i);
        }

        public double Balance()
        {
            return _money;
        }

        public override string ToString()
        {
            return $"{_name}: {_money}";
        }

        private void RemoveMoney(double i)
        {
            if (_money-i>=0)
            {
                _money -= i;
                return;
            }

            throw new NotEnoughMoneyException();
        }

        private void AddMoney(double i)
        {
            _money += i;
        }

        public void Transfer(Account to, double howMuch)
        {
            RemoveMoney(howMuch);
            to.AddMoney(howMuch);
        }

        public string Name
        {
            get => _name;
            set => _name = value;
        }
    }
}
