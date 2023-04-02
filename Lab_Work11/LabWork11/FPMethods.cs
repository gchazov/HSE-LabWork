using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnimalLibrary;

namespace LabWork11
{
    //класс содержит в себе полезные методы для работы с 1 частью работы
    public class FPMethods
    {
        //добавление n-ого количества случайных элементов в очередь
        public static void AddRandomToQueue(ref Queue<Animal> animalQueue, int amount)
        {
            //amount - количество добавляемых элементов
            for (int i = 0; i < amount; i++)
            {
                switch (Program.random.Next(1, 5))
                {   //рандомизация случайного метода
                    case 1:
                        var animal = new Animal();
                        animal.RandomInit();
                        animalQueue.Enqueue(animal);
                        break;
                    case 2:
                        var bird = new Bird();
                        bird.RandomInit();
                        animalQueue.Enqueue(bird);
                        break;
                    case 3:
                        var mammal = new Mammal();
                        mammal.RandomInit();
                        animalQueue.Enqueue(mammal);
                        break;
                    case 4:
                        var artiodactyl = new Artiodactyl();
                        artiodactyl.RandomInit();
                        animalQueue.Enqueue(artiodactyl);
                        break;
                }
            }
        }

        //возращает список подходящях (3 запроса в 1)
        public static List<Animal> GetTypeRequest(int choice, Queue<Animal> animals)
        {
            //для choice
            //1 - млекопитающие
            //2 - птицы
            //3 - парнокопытные
            Animal animalEx = new(); //успрощённое создание объекта
            Animal[] animals1 = { new Mammal(), new Bird(), new Artiodactyl() };

            //по умолчанию пусть тип будет Animal (его всё равно нет в меню поиска)
            Type typeName = animalEx.GetType();
            switch (choice)
            {
                case 1:
                    typeName = animals1[0].GetType();
                    break;
                case 2:
                    typeName = animals1[1].GetType();
                    break;
                case 3:
                    typeName = animals1[2].GetType();
                    break;
            }
            //создание списка для подходящих объектов
            List<Animal> result = new List<Animal>();
            foreach (Animal animal in animals)
            {
                //создаём переменную для определения типа
                var animal1 = animal;
                if (animal1.GetType() == typeName)
                    result.Add(animal1);
            }
            return result;
        }

        //запрос на старейшее животное
        public static Animal OldestAnimal(Queue<Animal> animals)
        {
            int maxAge = 0;
            var animalOld = new Animal();
            foreach (Animal animal in animals)
            {
                if (animal.Age > maxAge)
                {
                    maxAge = animal.Age;
                    animalOld = animal;
                }
            }
            return animalOld;
        }

        //создание очереди-клона
        public static Queue<Animal> CloneQueue(Queue<Animal> animals)
        {
            Queue<Animal> clone = new();
            foreach(Animal animal in animals)
            {
                var cloneObj = animal.Clone();
                clone.Enqueue((Animal)cloneObj);
            }

            return clone;
        }

        //очистка очереди
        public static void ClearQueue(ref Queue<Animal> animals)
        {
            animals.Clear();
        }

        //сортировка очереди по ID
        public static Queue<Animal> Sort(Queue<Animal> animals)
        {
            ArrayList ar = new(animals);
            ar.Sort();
            
            animals.Clear();
            foreach (Animal item in ar)
            {
                animals.Enqueue(item);
            }
            return animals;
        }

        //поиск в отсортированной очереди
        public static Animal? FindObj(Queue<Animal> animals, Animal objToFind)
        {
            ArrayList ar = new(animals);
            ar.Sort();

            int index = ar.BinarySearch(objToFind);
            if (index < 0)
            { //если не найдётся элемент
                return null;
            }
            //возврат объекта, если значение найдено
            return ar[index] as Animal;
        }
    }
}
