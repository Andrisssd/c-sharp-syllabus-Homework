using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary;

namespace FirstWebApi1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HouseFlatResidentController : ControllerBase
    {
        private static Dictionary<string, Object> _info = new Dictionary<string, object>();
        private readonly ILogger<HouseFlatResidentController> _logger;

        public HouseFlatResidentController(ILogger<HouseFlatResidentController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("Info")]
        public Dictionary<string,Object>.ValueCollection GetAllElements()
        {
            return _info.Values;
        }

        [HttpPost]
        [Route("Flat")]
        public void AddFlat(Flat flat)
        {
            double minimalLivingSpace = 5;
            if (flat.Number>0 && flat.Floor>0 && flat.RoomCount>0 && flat.ResidentCount>=0 && flat.LivingSpace>minimalLivingSpace)
            {
                CheckKeyAndAddObject(flat.UniqueId, flat);
                AddHouse(flat.HouseWhereLocated);
            }
        }

        [HttpPost]
        [Route("House")]
        public void AddHouse(House house)
        {
            if (house.Number > 0)
            {
                CheckKeyAndAddObject(house.UniqueId, house);
            }
        }

        [HttpPost]
        [Route("Resident")]
        public void AddResident(Resident resident)
        {
            if (resident.PhoneNumber.ToString().Where(x => Char.IsDigit(x)).Count()==8 && resident.PersonalCode.Contains("-") && resident.PersonalCode.Length==13)
            {
                CheckKeyAndAddObject(resident.UniqueId, resident);
                AddHouse(resident.LivingFlat.HouseWhereLocated);
                AddFlat(resident.LivingFlat);
            }
        }

        [HttpPut]
        [Route("UpdateHouseData")]
        public void UpdateInfoData(string id, [FromBody] House house)
        {
            if (_info.ContainsKey(id))
            {
                House houseToUpdate = (House)_info[id];
                houseToUpdate.Country = house.Country;
                houseToUpdate.City = house.City;
                houseToUpdate.Street = house.Street;
                houseToUpdate.Number = house.Number;
                houseToUpdate.ZIPCode = house.ZIPCode;
                _info[id] = houseToUpdate;
            }
        }

        [HttpPut]
        [Route("UpdateFlatData")]
        public void UpdateInfoData(string id, [FromBody] Flat flat)
        {
            if (_info.ContainsKey(id))
            {
                Flat flatToUpdate = (Flat)_info[id];
                flatToUpdate.Floor = flat.Floor;
                flatToUpdate.LivingSpace = flat.LivingSpace;
                flatToUpdate.Number = flat.Number;
                flatToUpdate.ResidentCount = flat.ResidentCount;
                flatToUpdate.RoomCount = flat.RoomCount;
                _info[id] = flatToUpdate;
            }
        }

        [HttpPut]
        [Route("UpdateResidentData")]
        public void UpdateInfoData(string id, [FromBody] Resident resident)
        {
            if (_info.ContainsKey(id))
            {
                Resident residentToUpdate = (Resident)_info[id];
                residentToUpdate.Email = resident.Email;
                residentToUpdate.LivingFlat = resident.LivingFlat;
                residentToUpdate.Name = resident.Name;
                residentToUpdate.PersonalCode = resident.PersonalCode;
                residentToUpdate.PhoneNumber = resident.PhoneNumber;
                residentToUpdate.Surname = resident.Surname;
                _info[id] = residentToUpdate;
            }
        }

        [HttpDelete]
        [Route("DeleteItem")]
        public void DeleteItem(string id)
        {
            if (_info.ContainsKey(id))
            {
                _info.Remove(id);
            }
        }

        private void CheckKeyAndAddObject(string Id, Object obj)
        {
            if (!_info.ContainsKey(Id))
            {
                _info.Add(Id, obj);
            }
        }
    }
}
