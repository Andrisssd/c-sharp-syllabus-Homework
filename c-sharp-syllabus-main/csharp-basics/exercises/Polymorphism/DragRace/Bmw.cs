using System;

namespace DragRace
{
    public class Bmw : ICar;
    {
        private int currentSpeed = 0;

        public void SpeedUp() 
        {
            currentSpeed+=19;
        }

        public void SlowDown() 
        {
            currentSpeed-=19;
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