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

        /// <summary>
        /// Calculates included years income for company
        /// </summary>
        /// <param name="year"> Year filter </param>
        /// <param name="includeNotCompletedRentals"> bool param that changes count logic, make active scooters included in count </param>
        /// <param name="scooters"> Dictionary collection that represents all scooters in scooterService </param>
        /// <param name="callTime"> Param needed for tests, but can be used for some logic </param>
        /// <returns> Total income filtered by params </returns>
        public decimal CalculateIncome(int year, bool includeNotCompletedRentals, Dictionary<string, Scooter> scooters, DateTime callTime)
        {
            if (includeNotCompletedRentals)
            {
                CheckYearAndMakeNewYearKeyIfNeeded(YearAndTotalIncome, callTime);
                decimal rentedScootersIncomeSum = 0;

                foreach(var scooter in scooters)
                {
                    if (scooter.Value.IsRented)
                    {
                        Scooter scooteR = scooter.Value;
                        rentedScootersIncomeSum += CountRentForActiveScooters(scooteR.Id, scooters, callTime);
                    }
                }

                return YearAndTotalIncome[year] + rentedScootersIncomeSum;
            }
            else
            {
                CheckYearAndMakeNewYearKeyIfNeeded(YearAndTotalIncomeCompletedRentalsFalse, callTime);
                return YearAndTotalIncomeCompletedRentalsFalse[year];
            }
        }

        // Overload that sums all years income and return it
        public decimal CalculateIncome(bool includeNotCompletedRentals, Dictionary<string, Scooter> scooters, DateTime callTime)
        {
            if (includeNotCompletedRentals)
            {
                CheckYearAndMakeNewYearKeyIfNeeded(YearAndTotalIncome, callTime);
                decimal rentedScootersIncomeSum = 0;

                foreach (var scooter in scooters)
                {
                    if (scooter.Value.IsRented)
                    {
                        Scooter scooteR = scooter.Value;
                        rentedScootersIncomeSum += CountRentForActiveScooters(scooteR.Id, scooters, callTime);
                    }
                }

                decimal totalAllTimeIncome = 0;

                foreach(var yearIncome in YearAndTotalIncome)
                {
                    totalAllTimeIncome += yearIncome.Value;
                }

                return totalAllTimeIncome + rentedScootersIncomeSum;
            }
            else
            {
                CheckYearAndMakeNewYearKeyIfNeeded(YearAndTotalIncomeCompletedRentalsFalse, callTime);
                decimal totalAllTimeIncome = 0;

                foreach (var yearIncome in YearAndTotalIncomeCompletedRentalsFalse)
                {
                    totalAllTimeIncome += yearIncome.Value;
                }

                return totalAllTimeIncome;
            }
        }

        /// <summary>
        /// Method used to deactivate scooters
        /// </summary>
        /// <param name="id"> needed scooters id </param>
        /// <param name="dictionary"> Dictionary collection that represents all scooters in scooterService </param>
        /// <param name="functionCallTime"> param needed in tests </param>
        /// <returns> scooters bill, also add this bill to totalIncome Dictionary </returns>
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

        /// <summary>
        /// Method that starts rent for scooter
        /// </summary>
        /// <param name="id"> scooters id, that we want to start rent and make active </param>
        /// <param name="dictionary"> Dictionary collection that represents all scooters in scooterService </param>
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

        //Overload needed for tests
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

        /// <summary>
        /// Method that is similar to EndRent, but is used only to count income for active scooters and dont make thair isRented param false
        /// </summary>
        /// <param name="id"> scooters id </param>
        /// <param name="dictionary"> Dictionary collection that represents all scooters in scooterService </param>
        /// <param name="functionCallTime"> for tests </param>
        /// <returns> income that scooter made until functionCallTime </returns>
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

        /// <summary>
        /// Total Income is represented in Dictionary with keys that represents years, this method check DateTime.Year data and make new key if needed, with income 0;
        /// </summary>
        /// <param name="yearDictionary"> Income dictionary we want work with </param>
        /// <param name="time"> DateTime needed for tests or some other logic </param>
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
