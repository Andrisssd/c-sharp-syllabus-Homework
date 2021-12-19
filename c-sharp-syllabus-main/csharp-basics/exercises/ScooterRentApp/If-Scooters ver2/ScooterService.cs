using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace If_Scooters_ver2
{
    public class ScooterService : IScooterService
    {
        private List<Scooter> _scooterList;

        public ScooterService()
        {
            _scooterList = new List<Scooter>();
        }

        public void AddScooter(string id, decimal pricePerMinute)
        {
            if(_scooterList.Where(x=>x.Id==id).Count() == 0)
            {
                _scooterList.Add(new Scooter(id, pricePerMinute));
            }
            else
            {
                throw new Exception("This id is already taken");
            }
        }

        public Scooter GetScooterById(string scooterId)
        {
            return _scooterList.Where(x => x.Id==scooterId).First();
        }

        public IList<Scooter> GetScooters()
        {
            return _scooterList;
        }

        public void RemoveScooter(string id)
        {
            _scooterList.Remove(_scooterList.Where(x => x.Id==id).First());
        }
    }
}
