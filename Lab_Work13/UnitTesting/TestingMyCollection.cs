using AnimalLibrary;
using MyCollections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Functionality;
using System.Collections.ObjectModel;

namespace UnitTesting
{
    [TestClass]
    public class TestingMyCollection
    {
        ConsoleRedirector cr = new ConsoleRedirector();
        [TestMethod]
        public void TestCtors() //тестирование конструкторов
        {
            MyCollection<Animal> collection1 = new(5);
            for(int i = 0; i < 5; i++)
            {
                collection1.Add(CollectionMethods.GetRandomAnimal());
            }
            MyCollection<Animal> collection2 = new(collection1);
            collection1 = new();
            Assert.IsTrue(collection1.Length < collection2.Length
                && collection2.Count == 5 && !collection2.IsReadOnly);
        }

        [TestMethod]
        public void TestAddition()  //тестирование добавления
        {
            MyCollection<Animal> collection1 = new(5);
            for (int i = 0; i < 5; i++)
            {
                collection1.Add(new Animal());
            }
            for (int i = 0; i < 5; i++)
            {
                collection1.Add(CollectionMethods.GetRandomAnimal());
            }
            collection1.AddRange(new Animal(), new Animal("1", 2, "3", 4));
            Assert.IsTrue(collection1.Count == 7);
        }

        [TestMethod]
        public void TestRemoving1()  //тестирование удаления
        {
            MyCollection<Animal> collection1 = new(5);
            collection1.AddRange(new Animal(), new Animal("1", 2, "3", 4));
            collection1.RemoveRange(new Animal(), new Animal("1", 2, "3", 4));
            Assert.IsTrue(collection1.Count == 0);
        }

        [TestMethod]
        public void TestRemoving2()  //тестирование удаления
        {
            MyCollection<Animal> collection1 = new(1);
            collection1.AddRange(new Animal(), new Animal("2222",1,"2", 222222),new Animal("1", 2, "3", 4));
            collection1.RemoveRange(new Animal(), new Animal("1", 2, "3", 4));
            Assert.IsTrue(collection1.Count != 0);
        }

        [TestMethod]
        public void TestContaining()    //тестирование поиска
        {
            MyCollection<Animal> collection = new(5);
            collection.AddRange(new Animal(), new Animal("1", 2, "3", 4), new Animal("1", 2, "444", 4));
            Assert.IsTrue(collection.Contains(new Animal("1", 2, "3", 4))
                && !collection.Contains(new Animal("122", 2, "3", 4)));
        }

        [TestMethod]
        public void TestPrint() //тест вывода
        {
            MyCollection<Animal> collection = new(1)
            {
                new Animal("1", 2, "3", 4)
            };
            Console.WriteLine(collection);
            collection.Clear();
            Assert.IsTrue(collection.Count == 0
                && cr.ToString().Contains("Цепочка 1:\n\tЖивотное: 1; Возраст: 2; Ареал обитания: 3; ID в зоопарке: 4 => Животное: 1; Возраст: 2; Ареал обитания: 3; ID в зоопарке: 4\n")) ;
        }

        [TestMethod]
        public void TestCopyTo()    //тест копирования в массив
        {
            MyCollection<Animal> collection = new(5);
            collection.AddRange(new Animal(), new Animal("1", 2, "3", 4), new Animal("1", 2, "444", 4));
            Animal[] array = new Animal[3];
            collection.CopyTo(array, 0);
            Assert.IsTrue(array.Length == 3);
        }

        [TestMethod]
        public void TestShallowCopy()    //тест поверхностного копирования
        {
            MyCollection<Animal> collection = new(5);
            collection.AddRange(new Animal(), new Animal("1", 2, "3", 4), new Animal("1", 2, "444", 4));
            MyCollection<Animal> copy = (MyCollection < Animal > )collection.ShallowCopy();
            Assert.IsTrue(copy.Count == collection.Count);
        }

        [TestMethod]
        public void TestShallowClone()    //тест клонирования
        {
            MyCollection<Animal> collection = new(5);
            collection.AddRange(new Animal(), new Animal("1", 2, "3", 4), new Animal("1", 2, "444", 4));
            MyCollection<Animal> clone = (MyCollection<Animal>)collection.Clone();
            Assert.IsTrue(clone.Count == collection.Count);
        }

        [TestMethod]
        public void TestIndex1() //тест индексатора
        {
            MyCollection<Animal> collection = new(1);
            collection.AddRange(new Animal(), new Animal("1", 2, "3", 4), new Animal("1", 2, "444", 4));
            collection[new Animal("1", 2, "3", 4)] = new Animal("1", 2, "@@@", 2);
            bool isCaught = false;
            try
            {
                collection[null] = new Animal();
            }
            catch (ArgumentNullException)
            {
                isCaught = true;
            }
            Assert.IsTrue(isCaught);
        }

        [TestMethod]
        public void TestIndex2() //тест индексатора
        {
            MyCollection<Animal> collection = new(1);
            collection.AddRange(new Animal(), new Animal("1", 2, "3", 4), new Animal("1", 2, "444", 4));
            collection[new Animal("1", 2, "3", 4)] = new Animal("1", 2, "@@@", 2);
            bool isCaught = false;
            try
            {
                Animal animal = collection[new Animal("1", 2, "@@222@", 2)];
            }
            catch (ArgumentNullException)
            {
                isCaught = true;
            }
            Assert.IsTrue(isCaught);
        }

    }
}
