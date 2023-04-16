using MyCollections;
using AnimalLibrary;

namespace Functionality
{
    //методы для паботы с двунаправленным списком
    public class DListMethods
    {
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
    }
}