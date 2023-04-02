using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LabWork11;
using AnimalLibrary;

namespace LibraryTesting
{
    [TestClass]
    public class CarTesting
    {
        string[] carArray = {"ВАЗ 2114", "BMW M5 e60", "Toyota Camry XV70",
        "Audi RS6 C7", "Mercedes-Benz S-Klasse w223", "Volkswagen Toureg",
        "Honda Civic Type-R", "Toyota Mark II", "ВАЗ 2105", "Toyota GT86"};

        [TestMethod]
        public void TestEmptyCtor() //тестирование пустого конструктора
        {
            Car expected = new Car("NoName", 0);
            Car actual = new Car();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCtorProp1() //тестирование конструктора и свойств
        {
            Car expected = new Car("", 0);
            Car actual = new Car();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCtorProp2() //тестирование конструктора и свойств
        {
            Car expected = new Car("Formula-1", 1000);
            Car actual = new Car("Formula-1", 500);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCtorProp3() //тестирование конструктора и свойств
        {
            Car expected = new Car("BMW", 200);
            Car actual = new Car("BMW", 200);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCtorProp4() //тестирование конструктора и свойств
        {
            Car expected = new Car("LADA", -1000);
            Car actual = new Car("LADA", 0);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod] //тестирование генерации объекта с помощью ДСЧ
        public void TestRandomInit()
        {
            Car car = new Car();
            car.RandomInit();
            Assert.IsTrue(carArray.Contains(car.Name)
                && car.MaxSpeed >= 120
                && car.MaxSpeed <= 300);
        }

        [TestMethod]
        public void TestEquals1() //тест Equals
        {
            Car car = new Car();
            int notCar = 22;
            Assert.IsFalse(car.Equals(notCar));
        }

        [TestMethod]
        public void TestEquals2() //тест Equals
        {
            Car vedro1 = new Car("ваз 2105", 170);
            Car vedro2 = new Car("ваз 2106", 170);
            Assert.IsFalse(vedro1.Equals(vedro2));
        }

        [TestMethod]
        public void TestEquals3() //тест Equals
        {
            Car vedro1 = new Car("ваз 2105", 171);
            Car vedro2 = new Car("ваз 2105", 170);
            Assert.IsFalse(vedro1.Equals(vedro2));
        }

    }
}
