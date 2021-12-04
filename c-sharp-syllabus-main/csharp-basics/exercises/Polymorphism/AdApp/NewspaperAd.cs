namespace AdApp
{
    public class NewspaperAd : Advert
    {
        private int _column;
        private int _rate;

        public NewspaperAd(int fee, int column, int rate) : base(fee)
        {
            _column = column;
            _rate = rate;

        }

        public override int Cost()
        {
            var fee = base.Cost() + _column * _rate;
            return fee;
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}