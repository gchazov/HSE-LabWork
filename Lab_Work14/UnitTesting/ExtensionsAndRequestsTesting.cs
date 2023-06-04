using AnimalLibrary;
using Functionality;
using MyCollections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting.ExpressionsAndRequests
{
    //тестирование запросов и методов расширения
    [TestClass]
    public class ExtensionsAndRequestsTesting
    {
        public Dictionary<string, Queue<Animal>> animalSections = new();
        public void InitializeDictionary(ref Dictionary<string, Queue<Animal>> animalSections)
        {   //метод инициализации словаря, чтобы по 48 раз одно и то же не писать
            animalSections.Clear();
            Queue<Animal> animals1 = new();
            Queue<Animal> animals2 = new();
            animals1.Enqueue(new Animal("леопард", 1, "европа", 5));
            animals1.Enqueue(new Animal("кошка", 2, "европа", 4));
            animals1.Enqueue(new Animal("собака", 4, "африка", 16));
            animals1.Enqueue(new Animal("крокодайл", 15, "африка", 1234));
            animals1.Enqueue(new Animal("кит", 19, "южная америка", 54));

            animals2.Enqueue(new Animal("тигр", 5, "европа", 522));
            animals2.Enqueue(new Animal("баран", 1, "европа", 51));
            animals2.Enqueue(new Animal("кошка", 4, "африка", 119));
            animals2.Enqueue(new Animal("анаконда", 2, "африка", 12));
            animals2.Enqueue(new Animal("варан", 3, "южная америка", 777));

            animalSections.Add("sectionA", animals1);
            animalSections.Add("sectionB", animals2);
        }

        [TestMethod]
        public void TestHabitatCount()  //запрос на количество из выбранного региона
        {
            InitializeDictionary(ref animalSections); //как раз-таки выполнение инициализации
            var result = ExtensionsAndRequests.HabitatCount(animalSections, "европа");
            Assert.IsTrue(result == 4);
        }

        [TestMethod]
        public void TestAnimalsYoungerThan()   //запрос на тех, кто моложе значения
        {
            InitializeDictionary(ref animalSections);
            var result = ExtensionsAndRequests.AnimalsYoungerThan(animalSections, 4);
            var expected = new List<Animal>
            {
                new Animal("леопард", 1, "европа", 5),
                new Animal("кошка", 2, "европа", 4),
                new Animal("баран", 1, "европа", 51),
                new Animal("анаконда", 2, "африка", 12),
                new Animal("варан", 3, "южная америка", 777)
            };
            Assert.IsTrue(result.SequenceEqual(expected));
        }

        [TestMethod]
        public void TestAverageDictAge()  //запрос на возраст средний в словаре
        {
            InitializeDictionary(ref animalSections);
            var result = ExtensionsAndRequests.AverageAgeOfType(animalSections, "кошка");
            Assert.IsTrue(result == 3);
        }

        [TestMethod]
        public void TestGroupByHabitat()  //запрос на группировку по ареалам обитания
        {
            InitializeDictionary(ref animalSections);
            var result = ExtensionsAndRequests.GroupByHabitat(animalSections);
            Assert.IsTrue(result.Count() == 3); //три региона потому что
        }

        [TestMethod]
        public void TestNameCountDict()  //запрос на количество особей вида
        {
            InitializeDictionary(ref animalSections);
            var result = ExtensionsAndRequests.HabitatCountExtension(animalSections, "rerere");
            Assert.IsTrue(result == 0);
        }

        [TestMethod]
        public void TestQueueInterSection()  //запрос на пересечение очередей
        {
            InitializeDictionary(ref animalSections);
            var result = ExtensionsAndRequests.QueueIntersection(animalSections);
            Assert.IsTrue(result.First().Equals(new Animal("кошка", 2, "европа", 4)));
        }

        [TestMethod]
        public void TestWhereCusomDictionary()  //запрос на возвращение по опр. полю
            //тестирование метода WhereCusomDictionary() который я написал сам
        {
            InitializeDictionary(ref animalSections);
            var result = animalSections.WhereCustomDictionary(x => x.id.number == 777);
            Assert.IsTrue(result.First().Equals(new Animal("варан", 3, "южная америка", 777)));
        }

        public MyCollection<Animal> animals = new MyCollection<Animal>(10);
        public void InitializeMyCollection(ref MyCollection<Animal> animals)
        {   //метод инициализации коллекции, чтобы по 41248 раз одно и то же не писать
            animals.Clear();
            animals.Add(new Animal("леопард", 1, "европа", 5));
            animals.Add(new Animal("кошка", 2, "европа", 4));
            animals.Add(new Animal("собака", 4, "африка", 16));
            animals.Add(new Animal("крокодайл", 15, "африка", 1234));
            animals.Add(new Animal("кит", 19, "южная америка", 54));

            animals.Add(new Animal("тигр", 5, "европа", 522));
            animals.Add(new Animal("баран", 1, "европа", 51));
            animals.Add(new Animal("кошка", 4, "африка", 119));
            animals.Add(new Animal("кит", 2, "африка", 12));
            animals.Add(new Animal("варан", 3, "южная америка", 777));
        }

        [TestMethod]
        public void TestNameCount() //запрос на количество животных определённого названия в коллекции
        {
            InitializeMyCollection(ref animals);
            Assert.IsTrue(ExtensionsAndRequests.NameCount(animals, "кит") == 2);
        }

        [TestMethod]
        public void TestGroupByType() //запрос на группировку
        {
            InitializeMyCollection(ref animals);
            Assert.IsTrue(ExtensionsAndRequests.GroupByType(animals).Count() == 1); //т.к. только Animal
        }

        [TestMethod]
        public void TestMyCollectionIntersection() //запрос на пересечение
        {
            InitializeMyCollection(ref animals);

            MyCollection<Animal> animalsAddition = new MyCollection<Animal>(5);

            animalsAddition.Add(new Animal("кошка", 2, "африка", 1129));
            animalsAddition.Add(new Animal("варан", 1, "евразия", 111));
            animalsAddition.Add(new Animal("енот", 5, "евразия", 4));
            Assert.IsTrue(ExtensionsAndRequests.MyCollectionIntersection(animalsAddition,
                animals).Count() == 2); //т.к. совпадают только кошки и вараны
        }

        [TestMethod]
        public void TestOlderThan() //запрос на животных, старше опр. знач.
        {
            InitializeMyCollection(ref animals);
            Assert.IsTrue(ExtensionsAndRequests.OlderThan(animals, 5).Count() == 2);
        }
        
        [TestMethod]
        public void TestCustomWhere() //запрос на кастомную where (по айди здесь)
        {
            InitializeMyCollection(ref animals);
            Assert.IsTrue(animals.WhereCustom(x => x.id.number > 500).Count() == 3);
        }

        [TestMethod]
        public void TestAverageAge() //запрос на средний возраст
        {
            InitializeMyCollection(ref animals);
            Assert.IsTrue(ExtensionsAndRequests.AverageAge(animals) == 5);
        }
        
        [TestMethod]
        public void TestMinByCustom() //запрос на минимальный элемент по полю
        {
            InitializeMyCollection(ref animals);
            Assert.IsTrue(animals.MinByCustom(x => x.id.number, Comparer<int>.Default)
                .Equals(new Animal("кошка", 2, "европа", 4)));
        }

        [TestMethod]
        public void TestMaxByCustom() //запрос на максимальный элемент по полю
        {
            InitializeMyCollection(ref animals);
            Assert.IsTrue(animals.MaxByCustom(x => x.Age, Comparer<int>.Default)
                .Equals(new Animal("кит", 19, "южная америка", 54)));
        }
        
        [TestMethod]
        public void TestOrderCustom() //сортировка по возрастанию
        {
            InitializeMyCollection(ref animals);
            Assert.IsTrue(animals.OrderCustom(x => x.Age, Comparer<int>.Default).First()
                .Equals(new Animal("леопард", 1, "европа", 5)));
        }

        [TestMethod]
        public void TestOrderDescendingCustom() //сортировка по убыванию
        {
            InitializeMyCollection(ref animals);
            Assert.IsTrue(animals.OrderByDescendingCustom(x => x.Age, Comparer<int>.Default).First()
                .Equals(new Animal("кит", 19, "южная америка", 54)));
        }


    }
}
