using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise6
{
    public class Program
    {
        private static List<string> finalInfo = new List<string>();

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
                string[] foodTypeAndCount = Console.ReadLine().Split(" ");
                FeedAnimal(animals.Last(), foodTypeAndCount);
                PrintFullInfo(animals.Last());
            }

            Console.WriteLine(string.Join("\n", finalInfo));
        }

        public static Animal MakeAnimal(ref string[] inputs)
        {
            string lowerType = inputs[0].ToLower();
            double result;
            double.TryParse(inputs[2], out result);

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
                throw new TypeNotExistException(lowerType);
            }
        }

        public static void FeedAnimal(Animal animal, string[] foodTypeAndCount)
        {
            string foodType = foodTypeAndCount[0].ToLower();
            string foodCountString = foodTypeAndCount[1];
            int foodCount;

            try
            {
                foodCount = int.Parse(foodCountString);
            }
            catch (Exception)
            {
                throw new StringToIntParseException(foodCountString);
            }

            if(foodCount < 0)
            {
                throw new WrongFoodCountException(foodCountString);
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

        public static string PrintFullInfo(Animal animal)
        {
            if(animal.GetType().Name == "Cat")
            {
                string info = animal.GetType().Name+((Cat)animal).GetInfo();
                finalInfo.Add(info);
                Console.WriteLine(info);
                return info;
            }
            else
            {
                string info = animal.GetType().Name+animal.GetInfo();
                finalInfo.Add(info);
                Console.WriteLine(info);
                return info;
            }
        }
    }
}
