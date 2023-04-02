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
            DoublyLinkedList <Animal> newList = new DoublyLinkedList<Animal>();
            for (int i = 0; i < size; i++)
            {
                newList.AddLast(new Animal().RandomInit()); //заполнение случайными объектами типа Animal
            }
            dList = newList;
        }

        //"переворот" списка
        public static void ReverseList(ref DoublyLinkedList<Animal> dList)
        {
            dList.Reverse();
        }

        public static string GOOD_BYE = @"
   ______                __   __               __
  / ____/___  ____  ____/ /  / /_  __  _____  / /
 / / __/ __ \/ __ \/ __  /  / __ \/ / / / _ \/ / 
/ /_/ / /_/ / /_/ / /_/ /  / /_/ / /_/ /  __/_/  
\____/\____/\____/\__,_/  /_.___/\__, /\___(_)   
                                /____/           ";

    }
}