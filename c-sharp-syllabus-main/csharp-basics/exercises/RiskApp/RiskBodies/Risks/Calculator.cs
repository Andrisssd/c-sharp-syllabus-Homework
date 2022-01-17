namespace Risks
{
    public static class Calculator
    {
        public static decimal CountRisksWorth(IList<Risk> risks)
        {
            decimal worth = 0;

            if (risks != null)
            {
                foreach (var risk in risks)
                {
                    worth += risk.YearlyPrice;
                }
            }

            return worth;
        }
    }
}