using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnergyDrinks
{
    class Program
    {
        private const int NumberedSurveyed = 12467;
        private const double PurchasedEnergyDrinks = 0.14;
        private const double PreferCitrusDrinks = 0.64;

        private static void Main(string[] args)
        {
             double energyDrinkers = CalculateEnergyDrinkers(NumberedSurveyed);
             double preferCitrus = CalculatePreferCitrus(NumberedSurveyed);
             Console.WriteLine("Total number of people surveyed " + NumberedSurveyed);
             Console.WriteLine("Approximately " + energyDrinkers + " bought at least one energy drink");
             Console.WriteLine(preferCitrus + " of those " + "prefer citrus flavored energy drinks.");
        }

        public static double CalculateEnergyDrinkers(int numberSurveyed)
        {
            return Math.Round(numberSurveyed*0.14);
        }

        public static double CalculatePreferCitrus(int numberSurveyed)
        {
            return Math.Round(numberSurveyed*0.14*0.64);
        }
    }
}
