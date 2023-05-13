global using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyCollections;
using AnimalLibrary;

namespace UnitTesting
{
    [TestClass] //тестирование хеш-таблицы (3 часть)
    public class TestingHTable
    {
        ConsoleRedirector cr = new ConsoleRedirector();

        [TestMethod]
        public void TestCtor() //тестирование конструктора и вывода
        {
            HTable<Animal> hTable = new(1);
            hTable.Add(new Animal("1", 2, "3", 4));
            Console.WriteLine(hTable);
            Assert.IsTrue(hTable.Size == 1 
                && cr.ToString().Contains("Цепочка 1:\n\tЖивотное: 1; Возраст: 2; Ареал обитания: 3; ID в зоопарке: 4 => Животное: 1; Возраст: 2; Ареал обитания: 3; ID в зоопарке: 4\n"));
        }

        [TestMethod]
        public void TestAdd() //тестирование добавления в хеш-таблицу элементов
        {
            HTable<Animal> hTable = new(1);
            hTable.Add(new Animal("1", 2, "3", 4));
            hTable.Add(new Animal("2", 2, "3", 4));
            hTable.Add(new Animal("3", 2, "3", 4));
            Assert.IsFalse(hTable.Add(new Animal("2", 2, "3", 4)));
        }

        [TestMethod]
        public void TestFindElement() //тестирование поиска элемента
        {
            HTable<Animal> hTable = new(1);
            hTable.Add(new Animal("1", 2, "3", 4));
            hTable.Add(new Animal("2", 2, "3", 4));
            hTable.Add(new Animal("3", 2, "3", 4));
            Assert.IsTrue(hTable.FindElementData(new Animal("2", 2, "3", 4))
                && !hTable.FindElementData(new Animal("222", 2, "3", 4)));
        }

        [TestMethod]
        public void TestDeleteELement1() //тестирование удаления элемента
        {
            HTable<Animal> hTable = new(1);
            hTable.Add(new Animal("1", 2, "3", 4));
            hTable.Add(new Animal("2", 2, "3", 4));
            hTable.Add(new Animal("3", 2, "3", 4));
            Assert.IsNull(hTable.DeleteElement(new Animal("222", 2, "3", 4)));
        }

        [TestMethod]
        public void TestDeleteELement2() //тестирование удаления элемента
        {
            HTable<Animal> hTable = new(1);
            hTable.Add(new Animal("1", 2, "3", 4));
            hTable.Add(new Animal("2", 2, "3", 4));
            hTable.Add(new Animal("3", 2, "3", 4));
            Assert.IsNotNull(hTable.DeleteElement(new Animal("2", 2, "3", 4)));
        }

        [TestMethod]
        public void TestDeleteELement3() //тестирование удаления элемента
        {
            HTable<Animal> hTable = new(1);
            hTable.Add(new Animal("1", 2, "3", 4));
            hTable.Add(new Animal("2", 2, "3", 4));
            hTable.Add(new Animal("3", 2, "3", 4));
            Assert.IsNotNull(hTable.DeleteElement(new Animal("1", 2, "3", 4)));
        }
    }
}