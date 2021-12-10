using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScooterRentApp
{
    public class Scooter
    {
        private static int _totalSeriesNumber { get; set; }
        public int _individualNumber { get; }
        private DateTime _rentTimeStart { get; set; }

        /// <summary>
        /// Create new instance of the scooter.
        /// </summary>
        /// <param name="id">ID of the scooter.</param>
        /// <param name="pricePerMinute">Rental price of the scooter per one minute.</param>
        static Scooter()
        {
            _totalSeriesNumber = 0;
        }

        public Scooter(string id, decimal pricePerMinute)
        {
            _totalSeriesNumber++;
            Id = id;
            PricePerMinute = pricePerMinute;
            _individualNumber = _totalSeriesNumber;
        }
        /// <summary>
        /// Unique ID of the scooter.
        /// </summary>
        public string Id { get; }
        /// <summary>
        /// Rental price of the scooter per one
        ///minute.
        /// </summary>
        public decimal PricePerMinute { get; }
        /// <summary>
        /// Identify if someone is renting this
        ///scooter.
        /// </summary>
        public bool IsRented { get; set; }

        public void StartRent(DateTime time)
        {
            _rentTimeStart = time;
        }

        public TimeSpan CountTotalRentTime(DateTime time)
        {
            return time - _rentTimeStart;
        }

        public DateTime RentTimeStart { get => _rentTimeStart; }
    }
}
