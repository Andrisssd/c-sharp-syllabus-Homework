using System;
using If_Scooters_ver2;

namespace Tests1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Make scooter and dataBase objects
            Scooter scooter = new Scooter("id", 0.05M);
            DataBase dataBase = new DataBase();
            //Set invoke start rent time 
            scooter.SetInvokeStartRentTime(new DateTime(2021, 10, 10, 10, 10, 10));
            //Set expected key in dataBase and get actual key
            string expected = "id 2021 ";
            string actual = dataBase.GetScootersIdRideTimesAndRentStartYear(scooter);
            //Compare expected and actual keys
            Console.WriteLine(actual);

        }
    }
}
