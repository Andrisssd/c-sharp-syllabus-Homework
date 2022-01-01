using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise6
{
    public class Cat : Felime
    {
        private string _breed;

        public Cat(string type, string name, string region, double weight, string breed) : base(name, type, weight, region)
        {
            _breed = breed;
        }

        public override void MakeSound()
        {
            Console.WriteLine("***cat's noises***");
        }

        public override void Eat(Food food)
        {
            if (food.GetType().Name.ToLower()=="vegetable")
            {
                Console.WriteLine("Cats are not eating that type of food!");
                throw new WrongFoodTypeException();
            }
            else
            {
                base.Eat(food);
            }
        }

        public override Dictionary<string, string> AddInfoToInfoDictionary()
        {
            var infos = base.AddInfoToInfoDictionary();
            infos.Add("breed", _breed);
            infos.Add("location", _livingRegion);
            return infos;
        }

        public override string GetInfo()
        {
            var info = AddInfoToInfoDictionary();
            return $"[{info["type"]}, {info["breed"]}, {info["weight"]}, {info["location"]}, {info["foodCount"]}]";
        }
    }
}
