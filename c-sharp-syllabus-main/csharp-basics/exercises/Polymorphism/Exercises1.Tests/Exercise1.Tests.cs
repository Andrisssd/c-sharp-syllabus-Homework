using NUnit.Framework;
using DragRace;

namespace Exercises1.Tests
{
    public class Exercise1_Tests
    {
        private Lexus _lexus;
        private Lada _lada;

        [SetUp]
        public void Setup()
        {
            _lexus = new Lexus();
            _lada = new Lada();
        }

        [Test]
        public void ICar_Lada_ShouldBeTrue()
        {
            //Act
            bool isCar = _lada is ICar;
            //Assert
            Assert.IsTrue(isCar);
        }

        [Test]
        public void IBoostable_Lada_ShouldBeFalse()
        {
            //Act
            bool isBoostable = _lada is IBoostable;
            //Assert
            Assert.IsFalse(isBoostable);
        }

        [Test]
        public void ICar_Lexus_ShouldBeTrue()
        {
            //Act
            bool isCar = _lexus is ICar;
            //Assert
            Assert.IsTrue(isCar);
        }

        [Test]
        public void IBoostable_Lexus_ShouldBeTrue()
        {
            //Act
            bool isBoostable = _lexus is IBoostable;
            //Assert
            Assert.IsTrue(isBoostable);
        }

        [Test]
        public void SpeedUp_Lada_ShouldIncrementSpeedBy10()
        {
            //Arrange
            int expectedSpeed = 10;
            //Act 
            _lada.SpeedUp();
            int actualSpeed = int.Parse(_lada.ShowCurrentSpeed());
            //Assert
            Assert.AreEqual(expectedSpeed, actualSpeed);
        }

        [Test]
        public void SlowDown_Lada_ShouldDecrementSpeedBy10()
        {
            //Arrange
            int expectedSpeed = 10;
            _lada.SpeedUp();
            _lada.SpeedUp();
            //Act
            _lada.SlowDown();
            int actualSpeed = int.Parse(_lada.ShowCurrentSpeed());
            //Assert
            Assert.AreEqual(expectedSpeed, actualSpeed);
        }

        [Test]
        public void UseNitrousOxideEngine_Lexus_ShouldIncrementSpeedBy40()
        {
            //Arrange
            int expectedSpeed = 40;
            //Act
            _lexus.UseNitrousOxideEngine();
            int actualSpeed = int.Parse(_lexus.ShowCurrentSpeed());
            //Assert
            Assert.AreEqual(expectedSpeed, actualSpeed);
        }
    }
}