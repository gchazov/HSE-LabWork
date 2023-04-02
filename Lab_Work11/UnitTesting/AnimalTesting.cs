using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnimalLibrary;
using LabWork11;

namespace LibraryTesting
{
    //тестирование класса Animal
    [TestClass]
    public class AnimalTesting
    {
        [TestMethod]
        public void TestAnimalEmptyCtor() //тестирование пустого конструктора
        {
            Animal actual = new Animal();
            Animal expected = new Animal("NoName", 1, "NoHabitat", 0);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestAnimalCtor1() //тест конструктора с параметрами 1
        {
            Animal expected = new Animal("Крокодил", 20, "Пермь");
            Animal actual = new Animal("Крокодил", 40, "Пермь");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestAnimalCtor2() //тест конструктора с параметрами 2
        {
            Animal expected = new Animal("Крыса", 1, "Москва");
            Animal actual = new Animal("Крыса", -100, "Москва");
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestAnimalProps() //тест свойств Animal
        {
            Animal expected = new Animal("Ворон", 20, "НИУ ВШЭ Пермь");
            Animal actual = new Animal("Крокодил", 2, "Чусовой");
            actual.Name = "Ворон";
            actual.Age = 777;
            actual.Habitat = "НИУ ВШЭ Пермь";
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestAnimalRandom() //тест ДСЧ генерации
        {
            string[] habitatArray = { "Евразия", "Африка", "Австралия", "Южная Америка", "Антарктида", "Северная Америка" };
            string[] animalArray = { "Комар", "Карась", "Ондатра", "Крокодил", "Щука", "Таракан", "Ящерица", "Лягушка", "Тарантул" };
            Animal actual = new Animal();
            actual.RandomInit();
            bool isCorrect = animalArray.Contains(actual.Name)
                && habitatArray.Contains(actual.Habitat) 
                && actual.Age > 0 
                && actual.Age <= 20;
            Assert.AreEqual(true, isCorrect);
        }

        [TestMethod]
        public void TestAnimalShow() //тест вывода с консоли
        {
            ConsoleRedirector cr = new ConsoleRedirector();
            Assert.IsFalse(cr.ToString().Contains("Животное: Крокодил; Возраст: 2; Ареал обитания: Куба"));
            Animal animal = new Animal("Крокодил", 2, "Куба");
            animal.Show();
            Assert.IsTrue(cr.ToString().Contains("Животное: Крокодил; Возраст: 2; Ареал обитания: Куба"));
        }

        [TestMethod]
        public void TestAnimalPrint() //тест вывода с консоли
        {
            ConsoleRedirector cr = new ConsoleRedirector();
            Assert.IsFalse(cr.ToString().Contains("Животное: Крокодил; Возраст: 2; Ареал обитания: Куба"));
            Animal animal = new Animal("Крокодил", 2, "Куба");
            animal.Print();
            Assert.IsTrue(cr.ToString().Contains("Животное: Крокодил; Возраст: 2; Ареал обитания: Куба"));
        }

        [TestMethod]
        public void TestAnimalNotEquals1()
        {
            Animal animal1 = new Animal("Крокодил", 1, "Айдохья");
            Animal animal2 = new Animal("Крокодил", 2, "Айдохья");
            Assert.AreNotEqual(animal1, animal2);
        }

        [TestMethod]
        public void TestAnimalNotEquals2()
        {
            string animal1 = "Крокодил";
            Animal animal2 = new Animal("Крокодил", 2, "Айдохья");
            Assert.IsFalse(animal2.Equals(animal1));
        }

        [TestMethod]
        public void TestAnimalId() //тест поля id
        {
            AnimalId id = new AnimalId(55);
            Assert.IsFalse(id.Equals(1));
        }

        [TestMethod]
        public void TestShallowCopy() //пов. копирование
        {
            Animal expected = new Animal();
            expected.RandomInit();
            Animal actual = new Animal();
            actual.RandomInit();
            actual = (Animal)expected.ShallowCopy();
            expected.id.number = 1;
            Assert.AreEqual(expected.id, actual.id);
        }

        [TestMethod]
        public void TestClone() //глубокое копирование
        {
            Animal expected = new Animal();
            expected.RandomInit();
            Animal actual = new Animal();
            actual.RandomInit();
            actual = (Animal)expected.Clone();
            actual.id.number = 1;
            Assert.AreNotEqual(expected.id, actual.id);
        }

    }
}