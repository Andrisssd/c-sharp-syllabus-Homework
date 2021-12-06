using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise6
{
    class Program
    {
        public static List<string> finalInfo = new List<string>();

        static void Main(string[] args)
        {
            string input = "";
            List<Animal> animals = new List<Animal>();
            while (true)
            {
                input = Console.ReadLine();
                string[] inputs = input.Split(" ");

                if(inputs[0] == "end")
                {
                    break;
                }

                animals.Add(MakeAnimal(ref inputs));
                animals.Last().MakeSound();
                FeedAnimal(animals.Last());
                PrintFullInfo(animals.Last());
            }

            Console.WriteLine(string.Join("\n", finalInfo));
        }

        public static Animal MakeAnimal(ref string[] inputs)
        {
            string lowerType = inputs[0].ToLower();
            double result = 0;

            try
            {
                double.TryParse(inputs[2], out result);
            }
            catch (Exception)
            {
                throw new Exception("Error with parsing");
            }

            if (inputs.Length == 5 && lowerType == "cat")
            {
                
                    return new Cat(inputs[0], inputs[1], inputs[3], result, inputs[4]);
            }
            else if(lowerType == "tiger")
            {
                return new Tiger(inputs[0], inputs[1], result, inputs[3]);
            }
            else if(lowerType == "mouse")
            {
                return new Mouse(inputs[0], inputs[1], inputs[3], result);
            }
            else if(lowerType == "zebra")
            {
                return new Zebra(inputs[0], inputs[1], inputs[3], result);
            }
            else
            {
                throw new Exception("Wrong type name");
            }
        }

        static void FeedAnimal(Animal animal)
        {
            string[] foodTypeAndCount = Console.ReadLine().Split(" ");
            string foodType = foodTypeAndCount[0].ToLower();
            int foodCount ;

            try
            {
                int.TryParse(foodTypeAndCount[1], out foodCount );
            }
            catch (Exception)
            {

                throw new Exception("Wrong food count input");
            }

            if(foodType == "vegetable")
            {
                animal.Eat(new Vegetable(foodCount));
            }
            else if(foodType == "meat")
            {
                animal.Eat(new Meat(foodCount));
            }
            
        }

        static void PrintFullInfo(Animal animal)
        {
            if(animal.GetType().Name == "Cat")
            {
                string info = animal.GetType().Name+((Cat)animal).GetInfo();
                finalInfo.Add(info);
                Console.WriteLine(info);
            }
            else
            {
                string info = animal.GetType().Name+animal.GetInfo();
                finalInfo.Add(info);
                Console.WriteLine(info);
            }
        }
    }
}
