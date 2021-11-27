using System;

namespace Exercise2
{
    class Odometer
    {
        public double kilometerCount = 0;
        public double lastOdometerRide;
        public double liters;
        public Odometer(double startOdo, double endingOdo, double liters)
        {
            lastOdometerRide = endingOdo - startOdo;
            this.liters = liters;
        }
        public double CountConsumption()
        {
            return liters/lastOdometerRide;
        }
        public void IncrementKilometerCount()
        {
            kilometerCount++;
        }
    }
    class Car
    {
        private double literPer100Km;
        private double currentFuelLevel;
        Odometer odometer;

        public Car(double startOdo, double endingOdo, double liters)
        {
            odometer = new Odometer(startOdo, endingOdo, liters);
            literPer100Km = odometer.CountConsumption()*100;
        }

        public bool IsTankEmpty()
        {
            return currentFuelLevel <= 0;
        }

        public void SpendFuelLevel()
        {
                currentFuelLevel--;
        }

        public void FillUp(double liters)
        {
            currentFuelLevel += liters;
            Console.WriteLine("Filled up to {0} liters",currentFuelLevel);
        }

        public double CalculateConsumption()
        {
            return odometer.CountConsumption();
        }

        public bool GasHog()
        {
            return CalculateConsumption() > 0.15;
        }

        public bool EconomyCar()
        {
            return CalculateConsumption() < 0.5;
        }

        public void Drive(int distance, double liters) 
        {
            currentFuelLevel = liters;
            for(int i = 1; i <= distance; i++)
            {
                odometer.IncrementKilometerCount();
                Console.WriteLine("Riding {0} km",odometer.kilometerCount);
                if(odometer.kilometerCount % (100/literPer100Km) == 0)
                {
                    SpendFuelLevel();
                    if (IsTankEmpty())
                    {
                        Console.WriteLine("Need some fuel");
                        break;
                    }
                }
            }
        }
        public void Drive(int distance)
        {
            for (int i = 1; i <= distance; i++)
            {
                odometer.IncrementKilometerCount();
                Console.WriteLine("Riding {0} km", odometer.kilometerCount);
                if (odometer.kilometerCount % (100/literPer100Km) == 0)
                {                                 
                    SpendFuelLevel();
                    if (IsTankEmpty())
                    {
                        Console.WriteLine("Need some fuel");
                        break;
                    }
                }
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter start ");
            Car car = new Car(0, 100, 5);
            car.Drive(100, 4);
            car.FillUp(10);
            car.Drive(200);
        }
    }
}
