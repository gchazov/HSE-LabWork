using AnimalLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork11
{
    //класс с 4 разными коллекциями
    public class TestCollections
    {

        // поля класса
        Queue<Bird> collection1 = new(); //упрощённое создание коллекций
        Queue<string> collection2 = new();
        SortedDictionary<Animal, Bird> collection3 = new();
        SortedDictionary<string, Bird> collection4 = new();


        Bird? first, middle, last;
        Bird? notFound = new Bird(); //такого объекта создать рнд не может

        //заполнение коллекций случайными элементами
        public void RandomInit(int size)
        {
            Clear();
            for (int i = 0; i < size; i++)
            {

                try
                {
                    //генерация объекта
                    Bird bird = new Bird();
                    bird.RandomInit();
                    Animal animal = bird.BaseAnimal;

                    //добавление элемента в коллекции
                    collection3.Add(animal, bird);
                    collection4.Add(animal.ToString(), bird);
                    collection1.Enqueue(bird);
                    collection2.Enqueue(bird.ToString());

                    //проверка на позицию объекта в коллекциях
                    if (i == 0) first = new(bird.Name, bird.Age, bird.Habitat, bird.FlyAbility, bird.id.number);
                    if (i == size / 2) middle = new(bird.Name, bird.Age, bird.Habitat, bird.FlyAbility, bird.id.number);
                    if (i == size - 1) last = new(bird.Name, bird.Age, bird.Habitat, bird.FlyAbility, bird.id.number);
                }
                catch (Exception)
                {
                    size++; //случай, если вылетит исключение
                }
            }
        }

        //свойства для доступа к коллекциям без нарушения инкапсуляции
        public Queue<Bird> Collection1
        {
            get { return collection1; }
        }

        public Queue<string> Collection2
        {
            get { return collection2; }
        }
        public SortedDictionary<Animal, Bird> Collection3
        {
            get { return collection3; }
        }
        public SortedDictionary<string, Bird> Collection4
        {
            get { return collection4; }
        }


        //заполнение коллекций случайными элементами
        public void SetValues()
        {
            int i = 0; //счётчик для удобства
            foreach (Bird bird in collection1)
            {
                if (i == 0) first = (Bird)bird.Clone();
                if (i == collection1.Count / 2) middle = (Bird)bird.Clone();
                if (i == collection1.Count - 1) last = (Bird)bird.Clone();
                ++i;
            }
        }
        public void Clear()
        {
            //очистка всех коллекций
            collection1.Clear();
            collection2.Clear();
            collection3.Clear();
            collection4.Clear();
        }


        public void DeleteElements(int amount)
        {
            //удаление из очереди
            for (int i = 0; i < amount; i++)
            {
                collection1.Dequeue();
                collection2.Dequeue();
            }

            //очищаем 3 и 4 коллекции
            collection3.Clear();
            collection4.Clear();

            //восстановление до определённого числа элементов
            foreach(Bird item in collection1)
            {
                Animal animal = item.BaseAnimal;
                collection3.Add(animal, item);
                collection4.Add(animal.ToString(), item);
            }
        }

        //добавление определённого количества элементов к коллекциям
        public void AddElements(int amount)
        {
            //добавление элементов
            for (int i = 0; i < amount; i++)
            {
                try
                {
                    //генерация объекта
                    Bird bird = new Bird();
                    bird.RandomInit();
                    Animal animal = bird.BaseAnimal;

                    //добавление элемента в коллекции
                    collection3.Add(animal, bird);
                    collection4.Add(animal.ToString(), bird);
                    collection1.Enqueue(bird);
                    collection2.Enqueue(bird.ToString());
                }
                catch (Exception)
                {
                    amount++; //случай, если вылетит исключение
                }
            }
        }

        //получение определённого элемента (first, last и тд)
        public Bird GetElement(string type)
        {
            switch (type)
            { //для поиска элементов в 3 части
                case "first":
                    return first;
                case "middle":
                    return middle;
                case "last":
                    return last;
                case "notFound":
                    return notFound;
                default:
                    return notFound;
            }
        }
        
        //размер коллекций
        public int GetSize()
        {
            return collection4.Count;
        }

        //к сожалению, вывод СЛУЧАЙНЫХ объектов проверить не получится :(

        //печать очереди с объектами Bird
        public void PrintBirdQueue()
        {
            foreach (Bird bird in collection1)
            {
                Console.WriteLine(bird);
            }
        }

        //печать очереди с string объектами
        public void PrintStringQueue()
        {
            foreach (string bird in collection2)
            {
                Console.WriteLine(bird);
            }
        }

        //печать словаря с ключами Animal
        public void PrintAnimalDict()
        {
            ICollection<Animal> keys = collection3.Keys;
            foreach (Animal animal in keys)
            {
                Console.WriteLine($"Ключ: {animal} - {collection3[animal]}");
            }
        }

        public void PrintStringDict()
        {
            ICollection<string> keys = collection4.Keys;
            foreach (string animal in keys)
            {
                Console.WriteLine($"Ключ: {animal} - {collection4[animal]}");
            }
        }
    }
}
