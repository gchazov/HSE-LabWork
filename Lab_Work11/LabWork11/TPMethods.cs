using AnimalLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork11
{
    public class TPMethods
    {

        public static Stopwatch timer = new(); //создание таймера
       
        //работа с коллекцией 1
        public static long TimeCollection1(TestCollections testCollections, Bird objToFind)
        {
            //поиск в коллекции 1 (очередь объектов типа Bird)
            timer.Start();
            bool isIncluded = testCollections.Collection1.Contains(objToFind);
            timer.Stop();
            if (isIncluded)
            {
                Dialog.ColorText($"Элемент найден в коллекции 1 (Queue <Bird>) за {timer.ElapsedTicks} тиков", "green");
            }
            else Dialog.ColorText($"В коллекции 1 (Queue <Bird>) заданного элемента нет, затрачено времени: {timer.ElapsedTicks}");
            return timer.ElapsedTicks; //возврат для юнит тестирования!
        }


        //работа с коллекцией 2
        public static long TimeCollection2(TestCollections testCollections, Bird objToFind)
        {
            //поиск в коллекции 2 (очередь объектов типа string)
            timer.Restart();
            bool isIncluded = testCollections.Collection2.Contains(objToFind.ToString());
            timer.Stop();

            if (isIncluded)
            {
                Dialog.ColorText($"Элемент найден в коллекции 2 (Queue <string>) за {timer.ElapsedTicks} тиков", "green");
            }
            else Dialog.ColorText($"В коллекции 2 (Queue <string>) заданного элемента нет, затрачено времени: {timer.ElapsedTicks}");
            return timer.ElapsedTicks;
        }

        //работа с коллекцией 3
        public static long TimeCollection3(TestCollections testCollections, Bird objToFind)
        {
            //поиск в коллекции 3 (словарь в ключами типа Animal)
            timer.Restart();
            bool isIncluded = testCollections.Collection3.ContainsKey(objToFind.BaseAnimal);
            timer.Stop();

            if (isIncluded)
            {
                Dialog.ColorText($"Элемент найден в коллекции 3 (SortedDictionary <Animal, Bird>) за {timer.ElapsedTicks} тиков", "green");
            }
            else Dialog.ColorText($"В коллекции 3 (SortedDictionary <Animal, Bird>) заданного элемента нет, затрачено времени: {timer.ElapsedTicks}");
            return timer.ElapsedTicks;
        }

        //работа с коллекцией 4
        public static long TimeCollection4(TestCollections testCollections, Bird objToFind)
        {
            //поиск в коллекции 4 (словарь в ключами типа string)
            timer.Restart();
            bool isIncluded = testCollections.Collection3.ContainsKey(objToFind.BaseAnimal);
            timer.Stop();

            if (isIncluded)
            {
                Dialog.ColorText($"Элемент найден в коллекции 4 (SortedDictionary <string, Bird>) за {timer.ElapsedTicks} тиков", "green");
            }
            else Dialog.ColorText($"В коллекции 4 (SortedDictionary <string, Bird>) заданного элемента нет, затрачено времени: {timer.ElapsedTicks}");
            return timer.ElapsedTicks;
        }

    }
}
