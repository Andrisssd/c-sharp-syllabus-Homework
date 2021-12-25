using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace If_Scooters_ver2
{
    public class DataBase
    {
        private Dictionary<string,string> _incomeDataDictionary;
        private decimal _dayLimitPrice = 20M;

        public DataBase()
        {
            _incomeDataDictionary = new Dictionary<string,string>();
        }

        public Dictionary<string,string> GetIncomeDataDictionary()
        {
            return _incomeDataDictionary;
        }

        public void AddScootersTime(Scooter scooter, DateTime time)
        {
            if (_incomeDataDictionary.ContainsKey(GetScootersIdRideTimesAndRentStartYear(scooter)))
            {
                _incomeDataDictionary[GetScootersIdRideTimesAndRentStartYear(scooter)] += $"&{time}";
                return;
            }

            _incomeDataDictionary.Add(GetScootersIdRideTimesAndRentStartYear(scooter), scooter.PricePerMinute.ToString() + "&" + time.ToString());
        }

        public string GetScootersIdRideTimesAndRentStartYear(Scooter scooter)
        {
            string IdRideTimesAndRentStartYear = $"{scooter.Id} {scooter.GetNumberOfRides()} {scooter.GetInvokeStartRentTime().Year}";
            return IdRideTimesAndRentStartYear;
        }

        public static decimal CheckDayLimitPrice(decimal amount, decimal _dayLimitPrice)
        {
            if (amount > _dayLimitPrice)
            {
                return _dayLimitPrice;
            }

            return amount;
        }

        public decimal CountIncomeByDates(DateTime rentStartTime, DateTime rentEndTime, decimal pricePerMinute)
        {
            TimeSpan totalRentTime = rentEndTime - rentStartTime;
            TimeSpan totalRentDays = rentEndTime.Date - rentStartTime.Date;
            decimal dayIncome = (decimal)totalRentTime.TotalMinutes * pricePerMinute;
            decimal sum = 0;

            for (int i = 0; i <= totalRentDays.TotalDays; i++)
            {
                if (totalRentDays.TotalDays == 0)
                {
                    sum = CheckDayLimitPrice(dayIncome, _dayLimitPrice);
                }
                else
                {
                    if (i == 0)
                    {
                        sum+=CheckDayLimitPrice((decimal)(rentStartTime.AddDays(1).Date - rentStartTime).TotalMinutes * pricePerMinute, _dayLimitPrice);
                    }
                    else if (i == totalRentDays.TotalDays)
                    {
                        sum+=CheckDayLimitPrice((decimal)(rentEndTime - rentEndTime.Date).TotalMinutes * pricePerMinute, _dayLimitPrice);
                    }
                    else
                    {
                        sum+= _dayLimitPrice;
                    }
                }

                if (i == totalRentDays.TotalDays)
                {
                    break;
                }
            }

            return sum;
        }

        public decimal CountIncomeForScooter(Scooter scooter, DateTime rentEndTime)
        {
            decimal pricePerMinute = scooter.PricePerMinute;
            DateTime rentStartTime = scooter.GetInvokeStartRentTime();
            TimeSpan totalRentTime = rentEndTime - rentStartTime;
            TimeSpan totalRentDays = rentEndTime.Date - rentStartTime.Date;
            decimal sum = 0;

            for (int i = 0; i <= totalRentDays.TotalDays; i++)
            {
                if (totalRentDays.TotalDays == 0)
                {
                    decimal dayIncome = (decimal)totalRentTime.TotalMinutes * pricePerMinute;
                    sum = CheckDayLimitPrice(dayIncome, _dayLimitPrice);
                }
                else
                {
                    if (i == 0)
                    {
                        sum+=CheckDayLimitPrice((decimal)(rentStartTime.AddDays(1).Date - rentStartTime).TotalMinutes * pricePerMinute, _dayLimitPrice);
                    }
                    else if (i == totalRentDays.TotalDays)
                    {
                        sum+=CheckDayLimitPrice((decimal)(rentEndTime - rentEndTime.Date).TotalMinutes * pricePerMinute, _dayLimitPrice);
                    }
                    else
                    {
                        sum+= _dayLimitPrice;
                    }
                }

                if (i == totalRentDays.TotalDays)
                {
                    break;
                }
            }

            return Math.Round(sum,2);
        }

        public decimal CountTotalIncome(int? year, bool includeNotCompletedRentals)
        {
            List<string> dataList = new List<string>();
            decimal sum = 0;

            foreach (var data in _incomeDataDictionary)
            {
                if (year.HasValue){
                    if (data.Key.Split(" ")[2] == year.ToString())
                    {
                        dataList.Add(data.Value);
                    }
                }
                else
                {
                    dataList.Add(data.Value);
                }
            }

            foreach(var startTimeEndTime in dataList)
            {
                if (includeNotCompletedRentals)
                {
                    DateTime startTime = DateTime.Parse(startTimeEndTime.Split("&")[1]);
                    decimal pricePerMinute = decimal.Parse(startTimeEndTime.Split("&")[0]);

                    if (startTimeEndTime.Split("&").Length==3)
                    {
                        DateTime endTime = DateTime.Parse(startTimeEndTime.Split("&")[2]);
                        sum += Math.Round(CountIncomeByDates(startTime, endTime, pricePerMinute),2);
                    }
                    else
                    {
                        sum += Math.Round(CountIncomeByDates(startTime, DateTime.Now, pricePerMinute),2);
                    }
                }
                else
                {
                    if (startTimeEndTime.Split("&").Length==3)
                    {
                        DateTime startTime = DateTime.Parse(startTimeEndTime.Split("&")[1]);
                        DateTime endTime = DateTime.Parse(startTimeEndTime.Split("&")[2]);
                        decimal pricePerMinute = decimal.Parse(startTimeEndTime.Split("&")[0]);
                        sum += Math.Round(CountIncomeByDates(startTime, endTime, pricePerMinute),2);
                    }
                }
            }

            return sum;
        }

        public void SetDictionaryData(string id, string scooterRideNumber, int year, decimal pricePerMinute, DateTime rentStartTime, DateTime? rentEndTime)
        {
            if (!rentEndTime.HasValue)
            {
                _incomeDataDictionary.Add($"{id} {scooterRideNumber} {year}", $"{pricePerMinute}&{rentStartTime.ToString()}");
                return;
            }

            _incomeDataDictionary.Add($"{id} {scooterRideNumber} {year}", $"{pricePerMinute}&{rentStartTime.ToString()}&{rentEndTime.ToString()}");
        }
    }
}
