using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise6
{
    public class Tiger : Felime
    {
        public Tiger(string type, string name, double weight, string region) : base(name, type, weight, region)
        {
        }

        public override void Eat(Food food)
        {
            if (food.GetType().Name.ToLower()=="vegetable")
            {
                Console.WriteLine("Tigers are not eating that type of food!");
                throw new WrongFoodTypeException();
            }
            else
            {
                base.Eat(food);
            }
        }

        public override void MakeSound()
        {
            Console.WriteLine("***tiger's noises***");
        }

        public override Dictionary<string, string> AddInfoToInfoDictionary()
        {
            var infos = base.AddInfoToInfoDictionary();
            infos.Add("location", _livingRegion);
            return infos;
        }

        public override string GetInfo()
        {
            var info = AddInfoToInfoDictionary();
            return $"[{info["type"]}, {info["weight"]}, {info["location"]}, {info["foodCount"]}]";
        }
    }
}
