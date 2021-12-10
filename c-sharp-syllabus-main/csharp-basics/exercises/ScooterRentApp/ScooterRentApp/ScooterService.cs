using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScooterRentApp
{
    public class ScooterService : IScooterService
    {
        public Dictionary<string, Scooter> _scooterDictionary;

        public ScooterService()
        {
            _scooterDictionary = new Dictionary<string,Scooter>();
        }
        
        public void AddScooter(string id, decimal pricePerMinute)
        {
            var newScooter = new Scooter(id, pricePerMinute);
            newScooter.IsRented = false;
            _scooterDictionary.Add(id,newScooter);
        }

        public Scooter GetScooterById(string scooterId)
        {
            try
            {
                return _scooterDictionary[scooterId];
            }
            catch (Exception)
            {
                throw new Exception("Error 001 || ScooterService line 34");
            }
        }

        public Dictionary<string, Scooter> GetScooters()
        {
            return _scooterDictionary;
        }

        public void RemoveScooter(string id)
        {
            try
            {
                _scooterDictionary.Remove(id);
            }
            catch (Exception)
            {
                throw new Exception("Error 002 || ScooterService line 52");
            }
        }
    }
}
