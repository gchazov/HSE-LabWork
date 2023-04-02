using Microsoft.VisualStudio.TestTools.UnitTesting;
using AnimalLibrary;
using LabWork11;

namespace MethodTesting
{
    //тестирование методов для первой части работы
    [TestClass]
    public class FPTesting
    {
        [TestMethod]
        public void TestRandomdAdd() //тест добавления элементов в очередь
        {
            int expected = 25; //содержимое проверить не можем, только длину
            Queue<Animal> actual = new Queue<Animal>();
            FPMethods.AddRandomToQueue(ref actual, 25);
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
            Queue<Animal> animals = new();
            Mammal m1 = new();
            Bird b1 = new();
            Artiodactyl a1 = new();
            //добавляем 
            animals.Enqueue(m1);
            animals.Enqueue(b1);
            animals.Enqueue(a1);
            List<Animal> res = FPMethods.GetTypeRequest(1, animals);
            List<Animal> actual = new();
            actual.Add(m1);

            //для сравнений коллекция лучше использовать:
            Assert.IsTrue(res.SequenceEqual(actual));
        }

        [TestMethod]
        public void TestTypeRequest2() //тест запроса на птиц
        {
            Queue<Animal> animals = new();
            Mammal m1 = new();
            Bird b1 = new();
            Artiodactyl a1 = new();
            //добавляем 
            animals.Enqueue(m1);
            animals.Enqueue(b1);
            animals.Enqueue(a1);
            List<Animal> res = FPMethods.GetTypeRequest(2, animals);
            List<Animal> actual = new();
            actual.Add(b1);

            //для сравнений коллекция лучше использовать:
            Assert.IsTrue(res.SequenceEqual(actual));
        }

        [TestMethod]
        public void TestTypeRequest3() //тест запроса на парнокопытных
        {
            Queue<Animal> animals = new();
            Mammal m1 = new();
            Bird b1 = new();
            Artiodactyl a1 = new();
            //добавляем 
            animals.Enqueue(m1);
            animals.Enqueue(b1);
            animals.Enqueue(a1);
            List<Animal> res = FPMethods.GetTypeRequest(3, animals);
            List<Animal> actual = new();
            actual.Add(a1);

            //для сравнений коллекция лучше использовать:
            Assert.IsTrue(res.SequenceEqual(actual));
        }

        [TestMethod]
        public void TestOldestAnimal() //тест запроса на старейшее животное
        {
            Queue<Animal> animals = new();
            Mammal m1 = new("кошка", 1, "поляна", true,1);
            Bird b1 = new("перепел", 3, "africa", true, 2);
            Artiodactyl a1 = new("козлик", 19, "гора", true, "чёткие", 3);
            //добавляем 
            animals.Enqueue(m1);
            animals.Enqueue(b1);
            animals.Enqueue(a1);
            Artiodactyl expected = new("козлик", 19, "гора", true, "чёткие", 4);
            var actual = FPMethods.OldestAnimal(animals);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCloneQueue() //тест клонирования очереди
        {
            Queue<Animal> animals = new();
            Mammal m1 = new("rabbit", 1, "selo Kapustino", true, 1);
            Bird b1 = new("перепел", 3, "кого он перепел?", true, 2);
            Artiodactyl a1 = new("goat", 19, "гора", true, "cool", 3);
            //добавляем 
            animals.Enqueue(m1);
            animals.Enqueue(b1);
            animals.Enqueue(a1);

            Queue<Animal> actual = FPMethods.CloneQueue(animals);
            Assert.IsTrue(actual.SequenceEqual(animals));
        }

        [TestMethod]
        public void TestClearQueue() //тест очистки очереди
        {
            Queue<Animal> animals = new();
            Mammal m1 = new("koshak", 1, "Bishkek", true, 1);
            Bird b1 = new("птиц планирует", 3, "что она планирует?", true, 2);
            Artiodactyl a1 = new("ram", 19, "NYC", true, "sharp", 3);
            //добавляем 
            animals.Enqueue(m1);
            animals.Enqueue(b1);
            animals.Enqueue(a1);

            FPMethods.ClearQueue(ref animals);
            Assert.AreEqual(0, animals.Count);
        }

        [TestMethod]
        public void TestSort() //тест сортировки очереди по именам
        {
            Queue<Animal> animals = new();
            Mammal m1 = new("кот", 1, "Bishkek", true, 1);
            Bird b1 = new("птица планирует", 3, "что она планирует?", true, 2);
            Artiodactyl a1 = new("собака", 19, "NYC", true, "sharp", 3);
            //добавляем в хаотичном порядке
            animals.Enqueue(b1);
            animals.Enqueue(a1);
            animals.Enqueue(m1);

            animals.Clear();
            //добавляем в отсорт. порядке
            animals.Enqueue(m1);
            animals.Enqueue(b1);
            animals.Enqueue(a1);
            Queue<Animal> sorted = FPMethods.Sort(animals);
            Assert.IsTrue(sorted.SequenceEqual(animals));
        }

        [TestMethod]
        public void TestFindObj1() //если объект не найден
        {
            Queue<Animal> animals = new();
            Mammal m1 = new("кот", 1, "Bishkek", true, 1);
            Bird b1 = new("птица планирует", 3, "что она планирует?", true, 2);
            Artiodactyl a1 = new("собака", 19, "NYC", true, "sharp", 3);
            //очередь изначально отсортирована
            animals.Enqueue(m1);
            animals.Enqueue(b1);
            animals.Enqueue(a1);

            Animal animalFind = new("козлик", 2, "егошихинское кладбище", 666);
            var found = FPMethods.FindObj(animals, animalFind);
            Assert.AreEqual(null, found);
        }

        [TestMethod]
        public void TestFindObj2() //если объект найден
        {
            Queue<Animal> animals = new();
            Mammal m1 = new("кот", 1, "Bishkek", true, 1);
            Bird b1 = new("птица планирует", 3, "что она планирует?", true, 2);
            Artiodactyl a1 = new("собака", 19, "NYC", true, "sharp", 3);
            //очередь изначально отсортирована
            animals.Enqueue(m1);
            animals.Enqueue(b1);
            animals.Enqueue(a1);

            Mammal animalFind = new("кот", 1, "Bishkek", true, 1);
            var found = FPMethods.FindObj(animals, animalFind);
            Assert.AreEqual(m1, found);
        }





    }
}