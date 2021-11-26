using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_3
{
    class Car
    {
        FuelGauge fuelGauge;
        Odometer odometer;
        public Car()
        {
            fuelGauge = new FuelGauge();
            odometer = new Odometer();
        }
        public void StartCar(int kilometers)
        {
            fuelGauge.SetFuelLevel(70);
            for(int i = 0; i < kilometers; i++)
            {
                odometer.IncrementMileage();
                Console.WriteLine($"km : {i}");
                if(i % 10 == 0)
                {
                    fuelGauge.DecrementFuelLevel();
                    fuelGauge.PrintFuelLevel();
                    odometer.PrintMileage();
                }
            }
        }
    }
    class FuelGauge
    {
        private int liters;
        
        public void SetFuelLevel(int liters)
        {
            this.liters = liters;
        }

        public void IncrementFuelLevel()
        {
            if(liters < 70)
            {
                liters++;
            }
            else
            {
                Console.WriteLine("Max fuel");
            }
        }

        public void DecrementFuelLevel()
        {
            if(liters >0)
            {
                liters--;
            }
            else
            {
                Console.WriteLine("None fuel left");
                Console.WriteLine("Filling tank...");
                FillTankFull();
            }
        }

        public void FillTankFull()
        {
            liters = 70;
        }

        public void PrintFuelLevel()
        {
            Console.WriteLine($"{liters} L");
        }

    }

    class Odometer
    {
        private int mileage;

        public Odometer()
        {
            mileage = 0;
        }

        public void IncrementMileage()
        {
            mileage++;
            if(mileage == 1_000_000)
            {
                mileage = 0;
            }
        }

        public void PrintMileage()
        {
            Console.WriteLine($"Current mileage: {mileage}");
        }
    }
}
