using System;
using System.Collections.Generic;

namespace Exercise6
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            List<Animal> animals = new List<Animal>();
            while (input.ToLower()!="end")
            {
                
                input = Console.ReadLine();
                string[] inputs = input.Split(" ");
                animals.Add(MakeAnimal(ref inputs));
                animals[animals.Count-1].MakeSound();
                
                

                
            }
            Console.WriteLine(animals.Count);
        }
        public static Animal MakeAnimal(ref string[] inputs)
        {
            string lowerType = inputs[0].ToLower();
            if (inputs.Length == 5 && inputs[0] == "cat")
            {
                double result = 0;
                try
                {
                    double.TryParse(inputs[3], out result);
                }
                catch (Exception)
                {
                    throw new Exception("Error with parsing");
                }
                    return new Cat(inputs[0], inputs[1], inputs[2], result, inputs[4]);
            }
            else if(lowerType == "tiger")
            {
                return new Tiger(inputs[0], inputs[1], double.Parse(inputs[3]), inputs[2]);
            }else if(lowerType == "mouse")
            {
                return new Mouse(inputs[0], inputs[1], inputs[2], double.Parse(inputs[3]));
            }else if(lowerType == "zebra")
            {
                return new Zebra(inputs[0], inputs[1], inputs[2], double.Parse(inputs[3]));
            }
            else
            {
                throw new Exception("Wrong type name");
            }
        }
    }
}
