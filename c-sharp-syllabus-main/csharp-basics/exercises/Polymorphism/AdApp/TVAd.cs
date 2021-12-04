namespace AdApp
{
    public class TVAd: Advert
    {
        private int _rate;
        private int _seconds;
        private bool _isPrimeTime;
        public TVAd(int fee, int rate, int seconds, bool isPrimeTime) : base(fee)
        {
            _rate = rate;
            _seconds = seconds;
            _isPrimeTime = isPrimeTime;
        }
        
        public override int Cost() 
        {
            int sum = _seconds * _rate;
            if (_isPrimeTime)
            {
                sum *= 2;
            }
            return base.Cost() + sum;
        }

        public override string ToString() 
        {
            return base.ToString();
        }
    }
}