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
}
