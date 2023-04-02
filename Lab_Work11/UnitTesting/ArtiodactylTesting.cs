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
    //тестирование класса Artiodactyl
    [TestClass]
    public class ArtiodactylTesting
    {
        [TestMethod]
        public void TestMammalEmptyCtor() //тестирование пустого конструктора
        {
            Artiodactyl actual = new Artiodactyl();
            Artiodactyl expected = new Artiodactyl("NoName", 1, "NoHabitat", true, "NoStyle", 1);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMammalCtor1() //тест конструктора с параметрами 1
        {
            Artiodactyl expected = new Artiodactyl("Баран", 20, "Пермь", false, "рога крутые", 1);
            Artiodactyl actual = new Artiodactyl("Баран", 999, "Пермь", false, "рога крутые", 1);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMammalCtor2() //тест конструктора с параметрами 2
        {
            Artiodactyl expected = new Artiodactyl("Овца", 1, "Москва", true, "маленькие", 2);
            Artiodactyl actual = new Artiodactyl("Овца", -100, "Москва", true, "маленькие", 2);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMammalProps() //тест свойств Animal
        {
            Artiodactyl expected = new Artiodactyl("Овцебык", 20, "НИУ ВШЭ Пермь", true, "ветвистые", 3);
            Artiodactyl actual = new Artiodactyl("Бык", 2, "Чусовой", false, "круговые", 3);
            actual.Name = "Овцебык";
            actual.Age = 727;
            actual.Habitat = "НИУ ВШЭ Пермь";
            actual.IsWoolen = true;
            actual.HornStyle = "ветвистые";
            actual.id.number = 3;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMammalRandom() //тест ДСЧ генерации
        {
            string[] habitatArray = { "Евразия", "Африка", "Австралия", "Южная Америка", "Антарктида", "Северная Америка" };
            string[] artiArray = { "Баран", "Антилопа", "Газель", "Горный козёл",
            "Лань", "Карликовая свинья", "Зубр", "Олень", "Косуля", "Лось" };
            string[] hornStyles = { "Карликовые", "Ветвистые", "Развесистые", "Клинообразные", "Винтообразные" };
            Artiodactyl actual = new Artiodactyl();
            actual.RandomInit();
            bool isCorrect = artiArray.Contains(actual.Name)
                && habitatArray.Contains(actual.Habitat)
                && actual.Age > 0
                && actual.Age <= 20
                && hornStyles.Contains(actual.HornStyle);

            Assert.AreEqual(true, isCorrect);
        }

        [TestMethod]
        public void TestMammalShow() //тест вывода с консоли
        {
            ConsoleRedirector cr = new ConsoleRedirector();
            Assert.IsFalse(cr.ToString().Contains("Парнокопытное: Барашек; Возраст: 20; Ареал обитания: Россия; Покрыто шерстью: False; Вид рогов: нет; ID в зоопарке: 2"));
            Artiodactyl animal = new Artiodactyl("Барашек", 20, "Россия", false, "нет", 2);
            animal.Show();
            Assert.IsTrue(cr.ToString().Contains("Парнокопытное: Барашек; Возраст: 20; Ареал обитания: Россия; Покрыто шерстью: False; Вид рогов: нет; ID в зоопарке: 2"));
        }

        [TestMethod]
        public void TestMammalPrint() //тест вывода с консоли
        {
            ConsoleRedirector cr = new ConsoleRedirector();
            Assert.IsFalse(cr.ToString().Contains("Парнокопытное: Барашек; Возраст: 20; Ареал обитания: Россия; Покрыто шерстью: False; Вид рогов: нет; ID в зоопарке: 2"));
            Artiodactyl animal = new Artiodactyl("Барашек", 20, "Россия", false, "нет", 2);
            animal.Print();
            Assert.IsTrue(cr.ToString().Contains("Парнокопытное: Барашек; Возраст: 20; Ареал обитания: Россия; Покрыто шерстью: False; Вид рогов: нет; ID в зоопарке: 2"));
        }

        [TestMethod]
        public void TestMammalNotEquals1()
        {
            Artiodactyl actual1 = new Artiodactyl("Овца", 2, "США", false, "no", 2222);
            Artiodactyl actual2 = new Artiodactyl("Медведь", 12, "Россия", true, "yes", 0099);
            Assert.AreNotEqual(actual1, actual2);
        }

        [TestMethod]
        public void TestMammalNotEquals2()
        {
            string actual1 = "Лабораторная работа номер 10";
            Artiodactyl actual2 = new Artiodactyl("Буйвол", 10, "Африка", false, "прямые", 222);
            Assert.IsFalse(actual2.Equals(actual1));
        }
    }
}
