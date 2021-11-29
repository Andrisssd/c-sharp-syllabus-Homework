using System;

namespace Exercise7
{
    class Dog
    {
        private string _name;
        private string _sex;
        private Dog _mother;
        private Dog _father;

        public Dog(string name, string sex)
        {
            this._name = name;
            this._sex = sex;
        }

        public Dog(string name, string sex, Dog father, Dog mother)
        {
            this._name = name;
            this._sex = sex;
            this._father = father;
            this._mother = mother;
        }
        
        public string FathersName()
        {
            return _father?._name ?? "Unknown";
        }

        public bool HasSameMotherAs(Dog otherDog)
        {
            if (otherDog?._mother!=null)
            {
                return otherDog?._mother == _mother;
            }
            return false;
        }

        public static void SetParents(Dog dog, Dog mom, Dog dad)
        {
            dog._mother = mom;
            dog._father = dad;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Dog dogMax = new Dog("Max", "male");
            Dog dogRocky = new Dog("Rocky", "male");
            Dog dogSparky = new Dog("Sparky", "male");
            Dog dogBuster = new Dog("Buster", "male");
            Dog dogSam = new Dog("Sam", "male");
            Dog dogLady = new Dog("Lady", "female");
            Dog dogMolly = new Dog("Molly", "female");
            Dog dogCoco = new Dog("Coco", "female");
            Dog.SetParents(dogMax, dogLady, dogRocky);
            Dog.SetParents(dogCoco, dogMolly, dogBuster);
            Dog.SetParents(dogRocky, dogMolly, dogSam);
            Dog.SetParents(dogBuster, dogLady, dogSparky);
            Console.WriteLine(dogMolly.FathersName());
            Console.WriteLine(dogMolly.HasSameMotherAs(dogLady));
        }
    }
}
