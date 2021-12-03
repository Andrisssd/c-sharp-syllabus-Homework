using System;
using System.Collections.Generic;

namespace DragRace
{
    interface ICar
    {
        void SpeedUp();
        void SlowDown();
        string ShowCurrentSpeed();
        void StartEngine();

    }

    interface IBoostable
    {
        void UseNitrousOxideEngine();
    }

    class Program
    {
        private static void Main(string[] args)
        {
            Volvo volvo = new Volvo();
            Lexus lexus = new Lexus();
            Tesla tesla = new Tesla();
            Lada lada = new Lada();
            Bmw bmw = new Bmw();
            Audi audi = new Audi();

            List<ICar> cars = new List<ICar>()
            {
                volvo, audi, lexus, tesla, bmw, lada
            };
            for (int i = 1; i <= 10; i++)
            {
                foreach(var car in cars)
                {
                    if (i==1)
                    {
                        car.StartEngine();
                        continue;
                    }

                    if(i%3==0 && car is IBoostable)
                    {
                        ((IBoostable)car).UseNitrousOxideEngine();
                        continue;
                    }
                    car.SpeedUp();
                }
            }
            foreach(var car in cars)
            {
                Console.WriteLine($"{car.GetType().Name} = {car.ShowCurrentSpeed()}");
            }
        }
    }
}