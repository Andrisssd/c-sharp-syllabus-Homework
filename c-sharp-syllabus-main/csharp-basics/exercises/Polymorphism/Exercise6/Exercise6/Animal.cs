using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise6
{
    abstract class Animal
    {
        protected string _animalName;
        protected string _animalType;
        protected double _animalWeight;
        protected int _foodEaten;

        public Animal(string type, string name, double weight)
        {
            _animalName = name;
            _animalType = type;
            _animalWeight = weight;
        }

        public virtual string GetInfo()
        {
            return "";
        }

        public virtual void MakeSound()
        {

        }

        public virtual void Eat(Food food)
        {
            _foodEaten += food.GetQuantity();
        }

        public virtual Dictionary<string, string> GetInfoArray()
        { 
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("type", _animalType);
            dictionary.Add("name", _animalName);
            dictionary.Add("weight", _animalWeight.ToString());
            dictionary.Add("foodCount", _foodEaten.ToString());
            return dictionary;
        }
    }
    abstract class Mammal : Animal
    {
        protected string _livingRegion;

        public Mammal(string type, string name, double weight, string region) : base (name, type, weight)
        {
            _livingRegion = region;
        }
    }

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

    abstract class Felime : Mammal
    {
        public Felime(string type, string name, double weight, string region) : base(name, type, weight, region)
        {
        }
    }

    class Cat : Felime
    {
        private string _breed;
        
        public Cat(string type, string name, string region, double weight, string breed) : base(name, type, weight,region)
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
            }
            else
            {
                base.Eat(food);
            }
        }

        public override Dictionary<string, string> GetInfoArray()
        {
            var infos = base.GetInfoArray();
            infos.Add("breed", _breed);
            infos.Add("location", _livingRegion);
            return infos;
        }

        public override string GetInfo()
        {
            var info = GetInfoArray();
            return $"[{info["type"]}, {info["breed"]}, {info["weight"]}, {info["location"]}, {info["foodCount"]}]";
        }
    }

    class Tiger : Felime
    {
        public Tiger(string type, string name, double weight, string region) : base(name, type, weight, region)
        {
        }

        public override void Eat(Food food)
        {
            if (food.GetType().Name.ToLower()=="vegetable")
            {
                Console.WriteLine("Tigers are not eating that type of food!");
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
