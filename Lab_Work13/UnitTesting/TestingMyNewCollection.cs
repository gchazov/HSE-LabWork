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
    public class TestingMyNewCollection
    {
        ConsoleRedirector cr = new ConsoleRedirector();
        [TestMethod]
        public void TestCtors() //тестирование конструкторов
        {
            MyNewCollection<Animal> collection1 = new(5);
            for(int i = 0; i < 5; i++)
            {
                collection1.Add(CollectionMethods.GetRandomAnimal());
            }
            MyNewCollection<Animal> collection2 = new("Collection 1");
            collection1 = new(5,"Collection 2");
            Assert.IsFalse(collection1.Length < collection2.Length
                && collection2.Count == 5 && !collection2.IsReadOnly);
        }

        [TestMethod] public void TestEmptyCtor() 
        {
            MyNewCollection<Animal> col = new();
            Assert.IsTrue(col.Length == 0 && col.Count == 0 &&
                col.CollectionName == "NoNameCollection"); 
        }

        [TestMethod] public void TestDefaultAddition()
        {
            MyNewCollection<Animal> col = new(1);
            col.AddDefault();
            col.AddDefault();
            Assert.IsTrue(col.Count == 2 && col.Length == 1);
        }

        [TestMethod]
        public void TestAddition()  //тестирование добавления
        {
            MyNewCollection<Animal> collection1 = new(5);
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
            MyNewCollection<Animal> collection1 = new(5);
            collection1.AddRange(new Animal(), new Animal("1", 2, "3", 4));
            collection1.RemoveRange(new Animal(), new Animal("1", 2, "3", 4));
            Assert.IsTrue(collection1.Count == 0);
        }

        [TestMethod]
        public void TestRemoving2()  //тестирование удаления
        {
            MyNewCollection<Animal> collection1 = new(1);
            collection1.AddRange(new Animal(), new Animal("2222",1,"2", 222222),new Animal("1", 2, "3", 4));
            collection1.RemoveRange(new Animal(), new Animal("1", 2, "3", 4));
            Assert.IsTrue(collection1.Count != 0);
        }

        [TestMethod]
        public void TestContaining()    //тестирование поиска
        {
            MyNewCollection<Animal> collection = new(5);
            collection.AddRange(new Animal(), new Animal("1", 2, "3", 4), new Animal("1", 2, "444", 4));
            Assert.IsTrue(collection.Contains(new Animal("1", 2, "3", 4))
                && !collection.Contains(new Animal("122", 2, "3", 4)));
        }

        [TestMethod]
        public void TestPrint() //тест вывода
        {
            MyNewCollection<Animal> collection = new(1)
            {
                new Animal("1", 2, "3", 4)
            };
            Console.WriteLine(collection);
            collection.Clear();
            Assert.IsTrue(collection.Count == 0
                && cr.ToString().Contains("Цепочка 1:\n\tЖивотное: 1; Возраст: 2; Ареал обитания: 3; ID в зоопарке: 4 => Животное: 1; Возраст: 2; Ареал обитания: 3; ID в зоопарке: 4\n")) ;
        }

       
        [TestMethod]
        public void TestIndex1() //тест индексатора
        {
            MyNewCollection<Animal> collection = new(1);
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
            MyNewCollection<Animal> collection = new(1);
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

        [TestMethod]
        [ExpectedException (typeof(ArgumentNullException))]
        public void TestUpdatedIndex1() //тест на выброс исключения
        {
            MyNewCollection<Animal> animals = new(1);
            animals.Add(new Animal("барбос", 12, "гагарина 41", 15));
            var animalThatNotExistInAnimals = animals[new Animal()];
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestUpdatedIndex2()     //тест на выброс исключения при присваивании
        {
            MyNewCollection<Animal> animals = new(1);
            animals.Add(new Animal("барбос", 12, "гагарина 41", 15));
            animals[new Animal()] = new Artiodactyl();
        }

        [TestMethod]
        public void TestUpdatedIndex3()     //тест на замену элемента
        {
            MyNewCollection<Animal> animals = new(1);
            animals.Add(new Animal("барбос", 12, "гагарина 41", 15));
            animals[new Animal("барбос", 12, "гагарина 41", 15)] = new Animal("барбос", 15, "гагарина 41", 12);
            Assert.AreEqual(animals[new Animal("барбос", 15, "гагарина 41", 12)], new Animal("барбос", 15, "гагарина 41", 12));
        }

    }
}
