using System;

namespace Exercise7
{
    class Dog
    {
        public string name;
        public string sex;
        public Dog mother;
        public Dog father;

        public Dog(string name, string sex)
        {
            this.name = name;
            this.sex = sex;
        }
        
        public string FathersName()
        {
            return father?.name ?? "Unknown";
        }

        public bool HasSameMotherAs(Dog otherDog)
        {
            if (otherDog?.mother!=null)
            {
                return otherDog?.mother == mother;
            }
            return false;
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
            SetParents(dogMax, dogLady, dogRocky);
            SetParents(dogCoco, dogMolly, dogBuster);
            SetParents(dogRocky, dogMolly, dogSam);
            SetParents(dogBuster, dogLady, dogSparky);
            Console.WriteLine(dogMolly.FathersName());
            Console.WriteLine(dogMolly.HasSameMotherAs(dogLady));
        }

        public static void SetParents(Dog dog, Dog mom, Dog dad)
        {
            dog.mother = mom;
            dog.father = dad;
        }
    }
}
