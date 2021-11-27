using System;

namespace Exercise2
{
    class Car
    {
        private double startKilometers;
        private double endKulimeters;
        double liters;
        public Car(double startOdo, double endingOdo, double liters)
        {
            startKilometers = startOdo;
            endKulimeters = endingOdo;
            this.liters = liters;
        }

        public double CalculateConsumption()
        {
            endKulimeters - startKilometers
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}
