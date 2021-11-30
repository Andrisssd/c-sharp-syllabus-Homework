using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_3
{
    class Car
    {
        private FuelGauge _fuelGauge;
        private Odometer _odometer;

        public Car()
        {
            _fuelGauge = new FuelGauge();
            _odometer = new Odometer();
        }

        public void StartCar(int kilometers)
        {
            _fuelGauge.SetFuelLevel(70);
            for(int i = 0; i < kilometers; i++)
            {
                _odometer.IncrementMileage();
                Console.WriteLine($"km : {i}");
                if(i % 10 == 0)
                {
                    _fuelGauge.DecrementFuelLevel();
                    _fuelGauge.PrintFuelLevel();
                    _odometer.PrintMileage();
                }
            }
        }
    }

    class FuelGauge
    {
        private int _liters;
        
        public void SetFuelLevel(int liters)
        {
            this._liters = liters;
        }

        public void IncrementFuelLevel()
        {
            if(_liters < 70)
            {
                _liters++;
            }
            else
            {
                Console.WriteLine("Max fuel");
            }
        }

        public void DecrementFuelLevel()
        {
            if(_liters >0)
            {
                _liters--;
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
            _liters = 70;
        }

        public void PrintFuelLevel()
        {
            Console.WriteLine($"{_liters} L");
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
