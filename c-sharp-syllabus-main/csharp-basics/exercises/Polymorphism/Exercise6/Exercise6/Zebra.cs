using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise6
{
    class Zebra : Mammal
    {
        public Zebra(string type, string name, string region, double weight) : base(name, type, weight, region)
        {
            _livingRegion = region;
        }

        public override void Eat(Food food)
        {
            if (food.GetType().Name.ToLower()=="meat")
            {
                Console.WriteLine("Zebras are not eating that type of food!");
            }
            else
            {
                base.Eat(food);
            }
        }

        public override void MakeSound()
        {
            Console.WriteLine("***zebra's noises***");
        }

        public override Dictionary<string, string> GetInfoArray()
        {
            var infos = base.GetInfoArray();
            infos.Add("location", _livingRegion);
            return infos;
        }

        public override string GetInfo()
        {
            var info = GetInfoArray();
            return $"[{info["type"]}, {info["weight"]}, {info["location"]}, {info["foodCount"]}]";
        }
    }

}
