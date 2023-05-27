using AnimalLibrary;
using ConsoleTools;
using MyCollections;

namespace LabWork13
{
    //ЛАБОРАТОРНАЯ РАБОТА 13
    internal class Program
    {
        static void Main(string[] args)
        {
            MyNewCollection<Animal> firstCollection = new("Коллекция №1");
            MyNewCollection<Animal> secondCollection = new("Коллекция №2");
            Run(ref firstCollection, ref secondCollection);
            Console.WriteLine("yesss");
            Dialog.BackMessage();
        }

        static void Run(ref MyNewCollection<Animal> firstCollection, 
            ref MyNewCollection<Animal> secondCollection)
        {

        }

        static void MainMenu(ref MyNewCollection<Animal> firstCollection,
            ref MyNewCollection<Animal> secondCollection)
        {
            string[] options = { "Создание хеш-таблицы", "Заполнение коллекции", "Печать коллекции",
            "Добавление элементов", "Удаление элементов", "Изменение элемента хеш-таблицы", };
        }
    }
}