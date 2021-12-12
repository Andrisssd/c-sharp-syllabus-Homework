using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise6
{
    class Mouse : Mammal
    {
        public Mouse(string type, string name, string region, double weight) : base(name, type, weight, region)
        {
            _livingRegion = region;
        }

        public override void MakeSound()
        {
            Console.WriteLine("PiPiPi");
        }

        public override void Eat(Food food)
        {
            if (food.GetType().Name.ToLower()=="meat")
            {
                Console.WriteLine("Cats are not eating that type of food!");
            }
            else
            {
                base.Eat(food);
            }
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
