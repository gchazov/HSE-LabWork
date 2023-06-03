using MyCollections;
using AnimalLibrary;
using System.Drawing;
using System;
using System.Runtime.CompilerServices;

namespace Functionality
{
    //методы для паботы с двунаправленным списком
    public static class CollectionMethods
    {
        //для удобства вывода листа
        public static void Print(this List<Animal> animals)
        {
            foreach (var animal in animals)
            {
                if (animal != null)
                    Console.WriteLine(animal);
            }
        }

        //создание двунаправленного списка
        public static void MakeRandomList(ref DoublyLinkedList<Animal> dList, int size)
        {
            Random random = new(); //для рандомизации
            DoublyLinkedList<Animal> newList = new DoublyLinkedList<Animal>();
            for (int i = 0; i < size; i++)
            {
                switch (random.Next(1, 5))
                {   //рандомизация случайного типа
                    case 1:
                        newList.AddLast(new Animal().RandomInit());
                        break;
                    case 2:
                        newList.AddLast(new Bird().RandomInit());
                        break;
                    case 3:
                        newList.AddLast(new Mammal().RandomInit());
                        break;
                    case 4:
                        newList.AddLast(new Artiodactyl().RandomInit());
                        break;
                } //заполнение случайными объектами
            }
            dList = newList;
        }

        //"переворот" списка
        public static void ReverseList(ref DoublyLinkedList<Animal> dList)
        {
            dList.Reverse();
        }

        //получение случайного элемента иерархии
        public static Animal GetRandomAnimal()
        {
            Random random = new();
            Animal animal = new();
            switch (random.Next(1, 5))
            {   //рандомизация случайного типа
                case 1:
                    animal = new Animal().RandomInit();
                    break;
                case 2:
                    animal = new Bird().RandomInit();
                    break;
                case 3:
                    animal = new Mammal().RandomInit();
                    break;
                case 4:
                    animal = new Artiodactyl().RandomInit();
                    break;
            }
            return animal;
        }
    }
}