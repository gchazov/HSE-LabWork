using AnimalLibrary;
using ConsoleTools;
using MyCollections;
using Functionality;
using System.Security.Cryptography.X509Certificates;

namespace LabWork14
{
    //ЛАБОРАТОРНАЯ РАБОТА 14
    internal class Program
    {
        static void Main(string[] args)
        {
            string helloString = @"
        __          __       _       __           __      _____ __
       / /   ____ _/ /_     | |     / /___  _____/ /__   <  / // /
      / /   / __ `/ __ \    | | /| / / __ \/ ___/ //_/   / / // /_
     / /___/ /_/ / /_/ /    | |/ |/ / /_/ / /  / ,<     / /__  __/
    /_____/\__,_/_.___/     |__/|__/\____/_/  /_/|_|   /_/  /_/   
      
    Здравстуй, уважаемый пользователь!
    Это демонстрационная программа для работы с LINQ to objects.
    Все события происходят с объектами иерархии Animal.
    ";


            Dialog.PrintHeader(helloString);
            Dialog.ForwardMessage();

            //инициализация словаря по умолчанию

            Dictionary<string, Queue<Animal>> animalSections = new();
            Queue<Animal> sectionA = new();
            Queue<Animal> sectionB = new();

            //заполнение очередей псевдослучайными животными
            for (int i = 0; i < 10; i++)
            {
                sectionA.Enqueue(CollectionMethods.GetRandomAnimal());
                sectionB.Enqueue(CollectionMethods.GetRandomAnimal());
            }

            animalSections.Add("Секция A", sectionA);
            animalSections.Add("Секция B", sectionB);

            //печать словаря
            Dialog.ColorText("Словарь имеет следующий вид:\n", "green");
            foreach (var keyValuePair in animalSections)
            {
                Console.WriteLine(keyValuePair.Key + ":");
                foreach (Animal animal in keyValuePair.Value)
                {
                    Console.WriteLine(animal);
                }
                Console.WriteLine();
            }

            Dialog.ForwardMessage();

            #region Часть 1 (Словарь очередей)

            //выборка данных
            Dialog.ColorText("Выборка животных, МЛАДШЕ определённого возраста", "yellow");
            var animalAge = Dialog.EnterNumber("Введите целочисленный возраст:", 1, 20);
            foreach(var queue in animalSections)
            {
                
            }
            List<Animal> result = animalSections.Where(x => x.Age < animalAge).ToList();
            Dialog.ColorText($"\nЖивотные, возраст которых меньше {animalAge}:\n", "green");
            CheckEmpty(result);
            Dialog.ForwardMessage();

            //получение счётчика
            Dialog.ColorText("Отбор животных, родом из одного континента\n" +
                "Возможные континенты: Евразия, Антарктида, Южная Америка, Северная Америка," +
                "Африка, Австралия", "yellow");
            var animalHabitat = Dialog.EnterString("Введите ареал обитания:", true);
            int resultCount = (from section in animalSections
                     from animal in section.Value
                     where animal.Habitat == animalHabitat
                     select animal).Count();
            Dialog.ColorText($"\nВ зоопарке есть {resultCount} животных, родина которых - это {animalHabitat}\n", "green");
            CheckEmpty(result);
            Dialog.ForwardMessage();

            //пересечение множеств по названиям животных
            Dialog.ColorText("Особи животных в обеих секциях", "yellow");
            result = animalSections["Секция A"].IntersectBy(animalSections["Секция B"].Select(x => x.Name), y => y.Name).ToList();
            Dialog.ColorText($"\nЖивотные Секции А, особи которых есть в Секции B:\n", "green");
            CheckEmpty(result);
            Dialog.ForwardMessage();

            //агрегирование
            Dialog.ColorText("Средний возраст животных заданного вида", "yellow");
            var animalType = Dialog.EnterString("Введите наименование вида животного:", true);
            var averageAgeSequence = from queue in animalSections
                              from animal in queue.Value
                              where animal.Name == animalType
                              select animal;
            int averageAge = 0;
            if (averageAgeSequence.Count() != 0)
            {
                averageAge = (int)averageAgeSequence.Average(x => x.Age);
            }
            if (averageAge > 0)
                Dialog.ColorText($"\nСредний возраст всех животных вида {animalType} - {averageAge}:\n", "green");
            else
                Dialog.ColorText($"\nИскомого вида животного в зоопарке нет!\n");
            Dialog.ForwardMessage();

            //группировка
            Dialog.ColorText("Группировка животных по ареалам обитания\n", "yellow");
            var habitatGroups = (from queue in animalSections
                          from animal in queue.Value
                          select animal).GroupBy(x => x.Habitat);
            foreach(var group in habitatGroups)
            {
                Console.WriteLine($"{group.Key}:");
                foreach(Animal animal in group)
                {
                    Console.WriteLine(animal);
                }
                Console.WriteLine();
            }
            Dialog.ForwardMessage();
            #endregion

            #region Часть 2 (Хеш-таблицы)
            Console.WriteLine();
            string clearOrNot = Dialog.EnterString("Желаете ли очистить консоль перед тем, как работать с хеш-таблицами? (Да или Нет)", true);
            switch (clearOrNot.ToUpper())
            {
                case "НЕТ":
                    break;
                default:
                    Console.Clear();
                    break;
            }

            //инициализация и заполнение двух хеш-таблиц

            MyCollection<Animal> animals = new(10);
            MyCollection<Animal> animalsAddition = new(10); //понадобится позже
            for (int i = 0; i < animals.Length; i++)
            {
                animals.Add(CollectionMethods.GetRandomAnimal());
                animalsAddition.Add(CollectionMethods.GetRandomAnimal());
            }

            //печать хэш-таблиц
            Dialog.ColorText("Печать хеш-таблицы", "green");
            Console.WriteLine(animals);
            Dialog.ForwardMessage();

            //запрос на выборку по условию
            Dialog.ColorText("Выборка животных, СТАРШЕ определённого возраста", "yellow");
            animalAge = Dialog.EnterNumber("Введите целочисленный возраст:", 1, 20);
            result = animals.Where(x => x.Age > animalAge).ToList();
            Dialog.ColorText($"\nЖивотные, возраст которых превышает {animalAge}:\n", "green");
            CheckEmpty(result);
            Dialog.ForwardMessage();

            //получение счётчика
            Dialog.ColorText("Отбор животных одного вида\n", "yellow");
            animalType = Dialog.EnterString("Введите вид животного:", true);
            result = (from animal in animals
                      where animal.Name == animalType
                      select animal).ToList();
            Dialog.ColorText($"\nВ зоопарке есть {result.Count} животных, вид которых - это {animalType}:\n", "green");
            CheckEmpty(result);
            Dialog.ForwardMessage();

            //пересечение множеств по названиям животных
            Dialog.ColorText("Особи животных в двух колллекциях", "yellow");
            Console.WriteLine("Используем вспомогательную вторую коллекцию для демонстрации этой задачи.\n" +
                "Коллекция имеет вид:\n");
            Console.WriteLine(animalsAddition);
            result = animals.IntersectBy(animalsAddition.Select(x => x.Name), x => x.Name).ToList();
            Dialog.ColorText($"\nЖивотные первой коллекции, особи которых есть во второй:\n", "green");
            CheckEmpty(result);
            Dialog.ForwardMessage();

            //сортировка
            Dialog.ColorText("Сортировка по указанному полю (можно менять в коде)", "yellow");
            result = animals.OrderCustom(x => x.Age, Comparer<int>.Default).ToList();
            CheckEmpty(result);
            Dialog.ForwardMessage();

            //агрегирование
            Dialog.ColorText("Сортировка по указанному полю (можно менять в коде)", "yellow");
            var minimal = animals.MinByCustom(x => x.Age, Comparer<int>.Default);
            var maximal = animals.MaxByCustom(x => x.Age, Comparer<int>.Default);
            var average = animals.AverageAge();
            Console.WriteLine(@$"
Минимальный объект - {minimal}
Максимальный объект - {maximal}
Средний возраст животных - {average}");
            Dialog.ForwardMessage();


            //группировка по виду животных
            Dialog.ColorText("Группировка по виду:\n", "yellow");
            var typeGroups = (from animal in animals
                              select animal)
                .GroupBy(x => x.GetType());
            foreach (var group in typeGroups)
            {
                Console.WriteLine($"{group.Key.Name}:");
                foreach (Animal animal in group)
                {
                    Console.WriteLine(animal);
                }
                Console.WriteLine();
            }
            Dialog.ForwardMessage();
            Dialog.PrintHeader(@"Демонстрационная версия программы успешно пройдена! Спасибо за пользование!

   ______                __   __               __
  / ____/___  ____  ____/ /  / /_  __  _____  / /
 / / __/ __ \/ __ \/ __  /  / __ \/ / / / _ \/ / 
/ /_/ / /_/ / /_/ / /_/ /  / /_/ / /_/ /  __/_/  
\____/\____/\____/\__,_/  /_.___/\__, /\___(_)   
                                /____/           
");
            #endregion

        }

        static void CheckEmpty(List<Animal> list)
        {
            if (list.Count == 0)
                Dialog.ColorText("Искомых объектов в коллекции нет");
            else
                list.Print();
        }
    }
}