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

        public virtual void MakeSound()
        {

        }
        protected virtual void Eat(Food food)
        {
            _foodEaten += food.GetQuantity();
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

        }
        public override void MakeSound()
        {
            Console.WriteLine("PiPiPi");
        }
    }

    class Zebra : Mammal
    {
        public Zebra(string type, string name, string region, double weight) : base(name, type, weight, region)
        {

        }
        public override void MakeSound()
        {
            Console.WriteLine("***zebra's noises***");
        }
    }

    abstract class Felime : Mammal
    {
        public Felime(string type, string name, string region, double weight) : base(name, type, weight, region)
        {

        }
    }

    class Cat : Felime
    {
        private string _breed;
        public Cat(string type, string name, string region, double weight, string breed) : base(name, type, region, weight)
        {
            _breed = breed;
        }
        public override void MakeSound()
        {
            Console.WriteLine("***cat's noises***");
        }
    }

    class Tiger : Felime
    {
        public Tiger(string type, string name, double weight, string region) : base(name, type, region, weight)
        {
            
        }

        public override void MakeSound()
        {
            Console.WriteLine("***tiger's noises***");
        }
    }
}
