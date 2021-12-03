using System;
using DragRace;

namespace DragRace
{
    public class Volvo : ICar , IBoostable;
    {
        private int currentSpeed = 0;

        public void SpeedUp()
        {
            currentSpeed += 5;
        }

        public void SlowDown()
        {
            currentSpeed -=5;
        }

        public string ShowCurrentSpeed()
        {
            return currentSpeed.ToString();
        }

        public void UseNitrousOxideEngine()
        {
            currentSpeed+=50;
        }

        public void StartEngine()
        {
            Console.WriteLine("pukpuk..");
        }
    }
}