namespace FuelConsumptionCalculator
{
    public class Car
    {
        public double startOdo;
        public double endingOdo;
        public double mileage;
        public double liters;

        public Car(double startOdo, double endingOdo, double liters)
        {
            mileage = endingOdo - startOdo;
            this.startOdo = startOdo;
            this.endingOdo = endingOdo;
            this.liters = liters;
        }

        public Car(double startOdo)
        {
            mileage = endingOdo - startOdo;
            this.startOdo = startOdo;
        }

        public double CalculateConsumption()
        {
            return (endingOdo - startOdo)/liters;
        }

        private double ConsumptionPer100Km()
        {
            return 100/CalculateConsumption();
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
            endingOdo = startOdo + mileage;
            this.liters = liters;
        }
    }
}
