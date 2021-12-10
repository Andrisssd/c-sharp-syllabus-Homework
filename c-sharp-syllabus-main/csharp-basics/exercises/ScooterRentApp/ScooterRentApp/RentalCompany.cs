using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ScooterRentApp
{
    public class RentalCompany : IRentalCompany
    {
        public string Name => "Rent.Comp.Express";
        public Dictionary<int, decimal> YearAndTotalIncome;
        public Dictionary<int, decimal> YearAndTotalIncomeCompletedRentalsFalse;

        const int TOTAL_MINUTES_IN_DAY = 1440;

        public RentalCompany()
        {
            YearAndTotalIncomeCompletedRentalsFalse = new Dictionary<int, decimal>();
            YearAndTotalIncome = new Dictionary<int, decimal>();
        }

        public decimal CalculateIncome(int year, bool includeNotCompletedRentals, Dictionary<string, Scooter> scooters, DateTime callTime)
        {
           
            if (includeNotCompletedRentals)
            {
                CheckYearAndMakeNewYearKeyIfNeeded(YearAndTotalIncome, callTime);

                foreach(var scooter in scooters)
                {
                    if (scooter.Value.IsRented)
                    {
                        Scooter scooteR = scooter.Value;
                        YearAndTotalIncome[year] += CountRentForActiveScooters(scooteR.Id, scooters, callTime);
                    }
                }

                return YearAndTotalIncome[year];
            }
            else
            {
                CheckYearAndMakeNewYearKeyIfNeeded(YearAndTotalIncomeCompletedRentalsFalse, callTime);
                return YearAndTotalIncomeCompletedRentalsFalse[year];
            }
        }

        public decimal EndRent(string id, Dictionary<string, Scooter> dictionary, DateTime functionCallTime)
        {
            Scooter scooter = dictionary[id];

            if (scooter.IsRented)
            {
                DateTime ScooterRentTimeStart = scooter.RentTimeStart;
                DateTime currentDateTime = ScooterRentTimeStart;

                decimal totalIncomePerDay = 0;
                decimal totalRentPrice = 0;
                var totalMinutesInRent = functionCallTime - scooter.RentTimeStart;

                for (decimal i = 0; i < Math.Floor((decimal)totalMinutesInRent.TotalMinutes); i++) 
                { 
                    
                    if (totalIncomePerDay >= 20)
                    {
                        currentDateTime = currentDateTime.AddDays(1);
                        i += TOTAL_MINUTES_IN_DAY - totalIncomePerDay/scooter.PricePerMinute;
                        totalIncomePerDay = 0;
                        continue;
                    }

                    totalIncomePerDay += scooter.PricePerMinute;

                    CheckYearAndMakeNewYearKeyIfNeeded(YearAndTotalIncome, currentDateTime);
                    CheckYearAndMakeNewYearKeyIfNeeded(YearAndTotalIncomeCompletedRentalsFalse, currentDateTime);

                    YearAndTotalIncome[currentDateTime.Year] += scooter.PricePerMinute;
                    YearAndTotalIncomeCompletedRentalsFalse[currentDateTime.Year] += scooter.PricePerMinute;

                    totalRentPrice += scooter.PricePerMinute;
                    currentDateTime = currentDateTime.AddMinutes(1);
                }
                
                scooter.IsRented = false;
                return totalRentPrice;
            }
            else
            {
                Console.WriteLine("This scooter wasn't rented");
                return 0M;
            }
        }

        public void StartRent(string id, Dictionary<string, Scooter> dictionary)
        {
            if (!dictionary[id].IsRented)
            {
                CheckYearAndMakeNewYearKeyIfNeeded(YearAndTotalIncomeCompletedRentalsFalse, DateTime.Now);
                dictionary[id].IsRented = true;
                dictionary[id].StartRent(DateTime.Now);
            }
            else
            {
                Console.WriteLine($"Scooter {id} already taken");
            }
        }

        public void StartRent(string id, Dictionary<string, Scooter> dictionary, DateTime time)
        {
            if (!dictionary[id].IsRented)
            {
                CheckYearAndMakeNewYearKeyIfNeeded(YearAndTotalIncomeCompletedRentalsFalse, time);
                dictionary[id].IsRented = true;
                dictionary[id].StartRent(time);
            }
            else
            {
                Console.WriteLine($"Scooter {id} already taken");
            }
        }

        public decimal CountRentForActiveScooters(string id, Dictionary<string, Scooter> dictionary, DateTime functionCallTime)
        {
            Scooter scooter = dictionary[id];
            if (scooter.IsRented)
            { 
                DateTime ScooterRentTimeStart = scooter.RentTimeStart;
                DateTime currentDateTime = ScooterRentTimeStart;
                decimal totalIncomePerDay = 0;
                decimal totalRentPrice = 0;
                var totalMinutesInRent = functionCallTime - scooter.RentTimeStart;
                decimal totalMinutesInDay = 1440;

                for (decimal i = 0; i < Math.Floor((decimal)totalMinutesInRent.TotalMinutes); i++)
                {
                    if (totalIncomePerDay >= 20)
                    {
                        currentDateTime = currentDateTime.AddDays(1);
                        i += totalMinutesInDay - totalIncomePerDay/scooter.PricePerMinute;
                        totalIncomePerDay = 0;
                        continue;
                    }

                    totalIncomePerDay += scooter.PricePerMinute;

                    CheckYearAndMakeNewYearKeyIfNeeded(YearAndTotalIncome, currentDateTime);
                    CheckYearAndMakeNewYearKeyIfNeeded(YearAndTotalIncomeCompletedRentalsFalse, currentDateTime);

                    YearAndTotalIncome[currentDateTime.Year] += scooter.PricePerMinute;
                    YearAndTotalIncomeCompletedRentalsFalse[currentDateTime.Year] += scooter.PricePerMinute;

                    totalRentPrice += scooter.PricePerMinute;
                    currentDateTime = currentDateTime.AddMinutes(1);
                }

                return totalRentPrice;
            }
            else
            {
                Console.WriteLine("This scooter wasn't rented");
                return 0M;
            }
        }

        private void CheckYearAndMakeNewYearKeyIfNeeded(Dictionary<int, decimal> yearDictionary,DateTime time)
        {
            int currentYear = time.Year;
            if (!yearDictionary.ContainsKey(currentYear))
            {
                yearDictionary.Add(currentYear, 0);
            }
        }
    }
}
