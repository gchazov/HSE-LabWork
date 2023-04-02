using AnimalLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LabWork11;

namespace LibraryTesting
{
    //тестирование класса Mammal
    [TestClass]
    public class MammalTesting
    {
        [TestMethod]
        public void TestMammalEmptyCtor() //тестирование пустого конструктора
        {
            Mammal actual = new Mammal();
            Mammal expected = new Mammal("NoName", 1, "NoHabitat", true, 1);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMammalCtor1() //тест конструктора с параметрами 1
        {
            Mammal expected = new Mammal("Кошка", 20, "Пермь", false, 1);
            Mammal actual = new Mammal("Кошка", 999, "Пермь", false, 2);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMammalCtor2() //тест конструктора с параметрами 2
        {
            Mammal expected = new Mammal("Собачка", 1, "Москва", true, 1);
            Mammal actual = new Mammal("Собачка", -100, "Москва", true, 3);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMammalProps() //тест свойств Animal
        {
            Mammal expected = new Mammal("Медведь", 20, "НИУ ВШЭ Пермь", true, 12);
            Mammal actual = new Mammal("Капибара", 2, "Чусовой", false, 122);
            actual.Name = "Медведь";
            actual.Age = 727;
            actual.Habitat = "НИУ ВШЭ Пермь";
            actual.IsWoolen = true;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMammalRandom() //тест ДСЧ генерации
        {
            string[] habitatArray = { "Евразия", "Африка", "Австралия", "Южная Америка", "Антарктида", "Северная Америка" };
            string[] mammalArray = { "Броненосец", "Слон", "Коала", "Ёж", "Бурый медведь",
            "Муравьед", "Панда", "Заяц-русак", "Носорог", "Амурский тигр", "Капибара" };
            Mammal actual = new Mammal();
            actual.RandomInit();
            bool isCorrect = mammalArray.Contains(actual.Name)
                && habitatArray.Contains(actual.Habitat)
                && actual.Age > 0
                && actual.Age <= 20;
            Assert.AreEqual(true, isCorrect);
        }

        [TestMethod]
        public void TestMammalShow() //тест вывода с консоли
        {
            ConsoleRedirector cr = new ConsoleRedirector();
            Assert.IsFalse(cr.ToString().Contains("Млекопитающее: Слон; Возраст: 20; Ареал обитания: Африка; Покрыто шерстью: False; ID в зоопарке: 123"));
            Mammal animal = new Mammal("Слон", 20, "Африка", false, 123);
            animal.Show();
            Assert.IsTrue(cr.ToString().Contains("Млекопитающее: Слон; Возраст: 20; Ареал обитания: Африка; Покрыто шерстью: False; ID в зоопарке: 123"));
        }

        [TestMethod]
        public void TestMammalPrint() //тест вывода с консоли
        {
            ConsoleRedirector cr = new ConsoleRedirector();
            Assert.IsFalse(cr.ToString().Contains("Млекопитающее: Слон; Возраст: 20; Ареал обитания: Африка; Покрыто шерстью: False; ID в зоопарке: 200"));
            Mammal animal = new Mammal("Слон", 20, "Африка", false, 200);
            animal.Print();
            Assert.IsTrue(cr.ToString().Contains("Млекопитающее: Слон; Возраст: 20; Ареал обитания: Африка; Покрыто шерстью: False; ID в зоопарке: 200"));
        }

        [TestMethod]
        public void TestMammalNotEquals1()
        {
            Mammal actual1 = new Mammal("Бульдог", 2, "США", false, 1);
            Mammal actual2 = new Mammal("Медведь", 12, "Россия", true, 2222);
            Assert.AreNotEqual(actual1, actual2);
        }

        [TestMethod]
        public void TestMammalNotEquals2()
        {
            string actual1 = "Шляпа";
            Mammal actual2 = new Mammal("Волк", 2, "Каир", false, 1337);
            Assert.IsFalse(actual2.Equals(actual1));
        }
    }
}
