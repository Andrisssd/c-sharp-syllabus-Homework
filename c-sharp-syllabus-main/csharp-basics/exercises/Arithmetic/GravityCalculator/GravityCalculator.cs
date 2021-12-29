using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GravityCalculator_7
{
    public class GravityCalculator
    {
        private const double _gravity = -9.81;
        private double _initialVelocity;
        private double _initialPosition;
        private double _fallingTime;
        private double _finalPosition;

        public GravityCalculator()
        {
            _initialVelocity = 0.0;
            _initialPosition = 0.0;
        }

        public double CalculateFinalPositionAfter(double fallingTime)
        {
            if (fallingTime >= 0)
            {
                _fallingTime = fallingTime;
                double finalPosition = (double)Math.Round((decimal)((0.5 * Math.Pow((_gravity*fallingTime), 2) + _initialVelocity*fallingTime + _initialPosition)/fallingTime), 4);
                _finalPosition = finalPosition;
                return finalPosition;
            }

            throw new InvalidInputTimeException(fallingTime);
        }

        public string GetResultString()
        {
            return $"The object's position after " + _fallingTime + " seconds is " + _finalPosition + " m.";
        }
    }
}
