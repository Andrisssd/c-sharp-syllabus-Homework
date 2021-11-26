namespace FuelConsumptionCalculator
{
    public class Car
    {
        public double startOdo;
        public double endingOdo;
        public double liters;
        public Car(double startOdo, double endingOdo, double liters)
        {          
        }

        public double CalculateConsumption()
        {
            return 0;
        }

        private double ConsumptionPer100Km()
        {
            return 0;
        }

        public bool GasHog()
        {
            return ConsumptionPer100Km() > 15;
        }

        public bool EconomyCar()
        {
            return ConsumptionPer100Km() < 5;
        }

        public void FillUp(int mileage, double liters)
        {
        }
    }
}
