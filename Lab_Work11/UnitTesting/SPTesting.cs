using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AnimalLibrary;
using LabWork11;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MethodTesting
{
    //тестирование методов второй части работы
    [TestClass]
    public class SPTesting
    {
        [TestMethod]
        public void TestRndDictAdd() //тест добавления элементов в словарь
        {
            int expected = 15; //содержимое проверить не можем, только длину
            SortedDictionary<int, Animal> actual = new();
            SPMethods.AddRandomToDict(ref actual, 15);
            Assert.AreEqual(expected, actual.Count);
        }

        [TestMethod]
        public void TestTypeRequest1() //тест запроса на млекопитающих
        {
            //для choice (целочисленный параметр метода)
            //1 - млекопитающие
            //2 - птицы
            //3 - парнокопытные

            //упрощённое создание объектов
            SortedDictionary<int, Animal> animals = new();
            Mammal m1 = new();
            Bird b1 = new();
            Artiodactyl a1 = new();
            //добавляем 
            animals.Add(1, m1);
            animals.Add(2, b1);
            animals.Add(3, a1);
            List<Animal> res = SPMethods.GetTypeRequest(1,  animals);
            List<Animal> actual = new();
            actual.Add(m1);

            //для сравнений коллекция лучше использовать:
            Assert.IsTrue(res.SequenceEqual(actual));
        }

        [TestMethod]
        public void TestTypeRequest2() //тест запроса на птиц
        {
            //упрощённое создание объектов
            SortedDictionary<int, Animal> animals = new();
            Mammal m1 = new();
            Bird b1 = new();
            Artiodactyl a1 = new();
            //добавляем 
            animals.Add(1, m1);
            animals.Add(2, b1);
            animals.Add(3, a1);
            List<Animal> res = SPMethods.GetTypeRequest(2, animals);
            List<Animal> actual = new();
            actual.Add(b1);

            //для сравнений коллекция лучше использовать:
            Assert.IsTrue(res.SequenceEqual(actual));
        }

        [TestMethod]
        public void TestTypeRequest3() //тест запроса на парнокопытных
        {
            //упрощённое создание объектов
            SortedDictionary<int, Animal> animals = new();
            Mammal m1 = new();
            Bird b1 = new();
            Artiodactyl a1 = new();
            //добавляем 
            animals.Add(1, m1);
            animals.Add(2, b1);
            animals.Add(3, a1);
            List<Animal> res = SPMethods.GetTypeRequest(3, animals);
            List<Animal> actual = new();
            actual.Add(a1);

            //для сравнений коллекция лучше использовать:
            Assert.IsTrue(res.SequenceEqual(actual));
        }

        [TestMethod]
        public void TestOldestAnimal() //тест запроса на молодое животное
        {
            SortedDictionary<int, Animal> animals = new();
            Mammal m1 = new("кошка", 12, "поляна", true, 1);
            Bird b1 = new("перепел", 3, "africa", true, 2);
            Artiodactyl a1 = new("козлик", 19, "гора", true, "чёткие", 3);
            //добавляем 
            animals.Add(1, m1);
            animals.Add(2, b1);
            animals.Add(3, a1);
            Bird expected = new("перепел", 3, "africa", true, 2);
            var actual = SPMethods.YoungestAnimal(animals);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCloneQueue() //тест клонирования словаря
        {
            SortedDictionary<int, Animal> animals = new();
            Mammal m1 = new("rabbit", 1, "selo Kapustino", true, 1);
            Bird b1 = new("перепел", 3, "кого он перепел?", true, 2);
            Artiodactyl a1 = new("goat", 19, "гора", true, "cool", 3);
            //добавляем 
            animals.Add(1, m1);
            animals.Add(2, b1);
            animals.Add(3, a1);

            SortedDictionary<int, Animal> actual = SPMethods.CloneDict(animals);
            Assert.IsTrue(actual.SequenceEqual(animals));
        }

        [TestMethod]
        public void TestClearQueue() //тест очистки словаря
        {
            SortedDictionary<int, Animal> animals = new();
            SPMethods.AddRandomToDict(ref animals, 500);
            SPMethods.ClearDict(ref animals);
            SortedDictionary<int, Animal> actual = SPMethods.CloneDict(animals);
            Assert.AreEqual(0, animals.Count);
        }

    }
}
