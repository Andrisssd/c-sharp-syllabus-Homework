using NUnit.Framework;
using Exercise6;
using System.Linq;
using System;

namespace Exercise6.Tests
{
    public class Exercise6_Tests
    {
        [Test]
        [TestCase("Tiger Typcho 160 Asia")]
        [TestCase("Mouse MouseName America 0.5")]
        [TestCase("Zebra ZebraName Africa 200.4")]
        [TestCase("Cat Gray Home 1.1 Persian")]
        public void MakeAnimal_AnimalParameters_ReturnRightAnimalType(string input)
        {
            //Arrange
            string[] inputs = input.Split(" ");
            string expectedReturnObjectTypeName = inputs[0];
            //Act
            Animal actualAnimal = Program.MakeAnimal(ref inputs);
            string actualReturnObjectTypeName = actualAnimal.GetType().Name;
            //Assert
            Assert.AreEqual(expectedReturnObjectTypeName, actualReturnObjectTypeName);
        }

        [Test]
        [TestCase("Tigerr Typcho 160 Asia")]
        [TestCase("Mouese MouseName America 0.5")]
        [TestCase("Zecbra ZebraName Africa 200.4")]
        [TestCase("Caxt Gray Home 1.1 Persian")]
        public void MakeAnimal_InvalidAnimalType_ShouldThrowException(string input)
        {
            //Arrange
            string[] inputs = input.Split(" ");
            //Assert
            Assert.Throws<TypeNotExistException>(() => Program.MakeAnimal(ref inputs));
        }

        [Test]
        [TestCase("Zebra ZebraName Africa 200.4", "meat 10")]
        [TestCase("Cat Gray Home 1.1 Persian", "vegetable 4")]
        [TestCase("Mouse MouseName America 0.5", "meat 1")]
        [TestCase("Tiger Typcho 160 Asia", "vegetable 2")]
        public void FeedAnimal_InvalidFood_ShouldThrowException(string animalParameters, string foodTypeAndCount)
        {
            //Arrange
            string[] foodTypeAndCountSplitted = foodTypeAndCount.Split(" ");
            string[] inputs = animalParameters.Split(" ");
            Animal animal = Program.MakeAnimal(ref inputs);
            //Assert
            Assert.Throws<WrongFoodTypeException>(() => Program.FeedAnimal(animal, foodTypeAndCountSplitted));
        }

        [Test]
        [TestCase("Zebra ZebraName Africa 200.4", "vegetable 10")]
        [TestCase("Cat Gray Home 1.1 Persian", "meat 4")]
        [TestCase("Mouse MouseName America 0.5", "vegetable 1")]
        [TestCase("Tiger Typcho 160 Asia", "meat 2")]
        public void FeedAnimal_ValidFood_ShouldIncrementEatenFoodCount(string animalParameters, string foodTypeAndCount)
        {
            //Arrange
            string[] foodTypeAndCountSplitted = foodTypeAndCount.Split(" ");
            string[] inputs = animalParameters.Split(" ");
            Animal animal = Program.MakeAnimal(ref inputs);
            int expectedFoodCount = int.Parse(foodTypeAndCountSplitted[1]);
            //Act
            Program.FeedAnimal(animal, foodTypeAndCountSplitted);
            int actualFoodCount = animal.GetFoodEaten();
            //Assert
            Assert.AreEqual(expectedFoodCount, actualFoodCount);
        }

        [Test]
        [TestCase("Zebra ZebraName Africa 200.4", "vegetable -1")]
        [TestCase("Cat Gray Home 1.1 Persian", "meat -10")]
        [TestCase("Mouse MouseName America 0.5", "vegetable -2")]
        [TestCase("Tiger Typcho 160 Asia", "meat -3")]
        public void FeedAnimal_InvalidFoodCount_ShouldThrowException(string animalParameters, string foodTypeAndCount)
        {
            //Arrange
            string[] foodTypeAndCountSplitted = foodTypeAndCount.Split(" ");
            string[] inputs = animalParameters.Split(" ");
            Animal animal = Program.MakeAnimal(ref inputs);
            //Assert
            Assert.Throws<WrongFoodCountException>(() => Program.FeedAnimal(animal, foodTypeAndCountSplitted));
        }

        [Test]
        [TestCase("Zebra ZebraName Africa 200.4", "vegetable b")]
        [TestCase("Cat Gray Home 1.1 Persian", "meat &")]
        [TestCase("Mouse MouseName America 0.5", "vegetable *")]
        [TestCase("Tiger Typcho 160 Asia", "meat vvv")]
        public void FeedAnimal_InvalidFoodFormat_ShouldThrowException(string animalParameters, string foodTypeAndCount)
        {
            //Arrange
            string[] foodTypeAndCountSplitted = foodTypeAndCount.Split(" ");
            string[] inputs = animalParameters.Split(" ");
            Animal animal = Program.MakeAnimal(ref inputs);
            //Assert
            Assert.Throws<StringToIntParseException>(() => Program.FeedAnimal(animal, foodTypeAndCountSplitted));
        }
    }
}