using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary;
using System.Web.Http;


namespace FirstWebApi1.Controllers
{
    [ApiController]
    public class HouseFlatResidentController : ControllerBase
    {
        private static Dictionary<string, Object> _info = new Dictionary<string, object>();
        private readonly ILogger<HouseFlatResidentController> _logger;

        public HouseFlatResidentController(ILogger<HouseFlatResidentController> logger)
        {
            _logger = logger;
        }

        [Microsoft.AspNetCore.Mvc.HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("HouseFlatResident/Info")]
        public Dictionary<string,Object>.ValueCollection GetAllElements()
        {
            return _info.Values;
        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        [Microsoft.AspNetCore.Mvc.Route("Flat")]
        public IActionResult AddFlat(Flat flat)
        {
            if (flat.IsValid())
            {
                CheckKeyAndAddObject(flat.UniqueId, flat);
                AddHouse(flat.HouseWhereLocated);
                return Ok();
            }

            return ValidationProblem();
        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        [Microsoft.AspNetCore.Mvc.Route("House")]
        public IActionResult AddHouse(House house)
        {
            if (house.IsValid())
            {
                CheckKeyAndAddObject(house.UniqueId, house);
                return Ok();
            }

            return ValidationProblem();
        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        [Microsoft.AspNetCore.Mvc.Route("Resident")]
        public IActionResult AddResident(Resident resident)
        {
            if (resident.IsValid())
            {
                CheckKeyAndAddObject(resident.UniqueId, resident);
                AddHouse(resident.LivingFlat.HouseWhereLocated);
                AddFlat(resident.LivingFlat);
                return Ok();
            }

            return ValidationProblem();
        }

        [Microsoft.AspNetCore.Mvc.HttpPut]
        [Microsoft.AspNetCore.Mvc.Route("House/Update")]
        public IActionResult UpdateInfoData(string id, [Microsoft.AspNetCore.Mvc.FromBody] House house)
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
                return Ok();
            }

            return NotFound();
        }

        [Microsoft.AspNetCore.Mvc.HttpPut]
        [Microsoft.AspNetCore.Mvc.Route("Flat/Update")]
        public IActionResult UpdateInfoData(string id, [Microsoft.AspNetCore.Mvc.FromBody] Flat flat)
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
                return Ok();
            }

            return NotFound();
        }

        [Microsoft.AspNetCore.Mvc.HttpPut]
        [Microsoft.AspNetCore.Mvc.Route("Resident/Update")]
        public IActionResult UpdateInfoData(string id, [Microsoft.AspNetCore.Mvc.FromBody] Resident resident)
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
                return Ok();
            }

            return NotFound();
        }

        [Microsoft.AspNetCore.Mvc.HttpDelete]
        [Microsoft.AspNetCore.Mvc.Route("HouseFlatResident/Delete")]
        public IActionResult DeleteItem(string id)
        {
            if (_info.ContainsKey(id))
            {
                _info.Remove(id);
                return Ok();
            }

            return NotFound();
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
