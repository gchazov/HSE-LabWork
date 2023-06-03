using AnimalLibrary;
using ConsoleTools;
using MyCollections;

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

            //инициализация коллекций по умолчанию

            Dictionary<string, Queue<Animal>> animalSections = new();
            Queue<Animal> sectionA = new();
            Queue<Animal> sectionB = new();
            Queue<Animal> sectionC = new();

            animalSections.Add("Секция A", sectionA);
            animalSections.Add("Секция B", sectionB);
            animalSections.Add("Секция C", sectionC);

            MyCollection<Animal> animals = new();

            Dialog.PrintHeader(helloString);
            Dialog.ForwardMessage();
            

            //ЧАСТЬ 1


        }
    }
}