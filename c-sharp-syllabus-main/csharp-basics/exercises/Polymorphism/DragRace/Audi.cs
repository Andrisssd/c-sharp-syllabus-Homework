using System;

namespace DragRace
{
    public class Audi : ICar
    {
        private int currentSpeed = 0;

        public void SpeedUp() 
        {
            currentSpeed+=15;
        }

        public void SlowDown() 
        {
            currentSpeed+=15;
        }

        public string ShowCurrentSpeed() 
        {
            return currentSpeed.ToString();
        }

        public void StartEngine() 
        {
            Console.WriteLine("Rrrrrrr.....");
        }
    }
}