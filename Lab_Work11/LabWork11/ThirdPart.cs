using AnimalLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork11
{
    //класс для работы с третью частью
    public class ThirdPart
    {
        //печать основного меню третьей части работы
        public static void TPMainPage(TestCollections testCollections) //здесь и далее: TP - сокращение Third Part
        {
            Console.WriteLine("Работа с коллекциями:\n\n" +
                "   1) Queue <Bird>\n" +
                "   2) Queue <string>\n" +
                "   3) SortedDictionary <Animal, Bird>\n" +
                "   4) SortedDictionary <string, Bird>\n");

            Console.WriteLine($"Текущий размер каждой из коллекций: {testCollections.GetSize()}");

            Console.WriteLine("\n1. Заполнить коллекции случайными элементами \n" +
                "2. Вывести содержимое одной из коллекций\n" +
                "3. Добавить элементы в коллекции\n" +
                "4. Удалить элементы из коллекций\n" +
                "5. Очистить коллекции\n" +
                "6. Засечь время выполнения поиска элемента\n\n" +
                "7. Вернуться в главное меню\n");
        }

        //главное меню третьей части работы
        public static void TPMenu(ref TestCollections testCollections)
        {
            bool isRunning = true;
            do
            {
                Dialog.PrintHeader("Третья часть работы (4 коллекции)");


                TPMainPage(testCollections); //печать основного меню третьей части
                int choice = Dialog.EnterNumber("Выберите пункт меню:", 1, 7);

                Console.WriteLine();
                switch (choice)
                {
                    case 1:
                        MakeRandomCollections(ref testCollections);
                        break;
                    case 2:
                        PrintCollection(testCollections);
                        break;
                    case 3:
                        AddElements(ref testCollections);
                        break;
                    case 4:
                        DeleteElements(ref testCollections);
                        break;
                    case 5:
                        ClearCollections(ref testCollections);
                        break;
                    case 6:
                        FindElementMenu(testCollections);
                        break;
                    case 7: //выход в самое первое меню
                        isRunning = false;
                        break;
                }
            } while (isRunning);
            return;
        }

        //создание коллекций
        public static void MakeRandomCollections(ref TestCollections testCollections)
        {
            Dialog.PrintHeader("Заполнение коллекций");
            int length = Dialog.EnterNumber("Введите размер будущих коллекций:", 0, 1000);
            if (length == 0)
            {
                Dialog.ColorText("\nПустые коллекции созданы", "green");
                Dialog.BackMessage();
                return;
            }

            testCollections.RandomInit(length);
            Dialog.ColorText($"\nКоллекции созданы. Длина каждой из них - {length}", "green");
            Dialog.BackMessage();
            return;
        }

        //вывод на печать коллекций
        public static void PrintCollection(TestCollections testCollections)
        {
            Dialog.PrintHeader("Печать коллекций");

            if (testCollections.GetSize() == 0)
            {
                Dialog.ColorText("Все коллекции пустые! Да и элементов в них нет", "green");
                Dialog.BackMessage();
                return;
            }

            bool isRunning = true;
            do
            {
                Dialog.PrintHeader("Печать коллекций");
                Console.WriteLine("1. Печать Queue <Bird>\n" +
                "2. Печать Queue <string>\n" +
                "3. Печать SortedDictionary <Animal, Bird>\n" +
                "4. Печать SortedDictionary <string, Bird>\n" +
                "5. Печать всех коллекций\n\n" +
                "6. Назад\n");

                int choice = Dialog.EnterNumber("Выберите один из вариантов:", 1, 6);

                if (choice == 6)
                {
                    //выход из меню
                    isRunning = false;
                    break;
                }

                switch (choice)
                {
                    case 1: //печать определённой из коллекций
                        Dialog.PrintHeader("Печать коллекции 1");
                        testCollections.PrintBirdQueue();
                        break;
                    case 2:
                        Dialog.PrintHeader("Печать коллекции 2");
                        testCollections.PrintStringQueue();
                        break;
                    case 3:
                        Dialog.PrintHeader("Печать коллекции 3");
                        testCollections.PrintAnimalDict();
                        break;
                    case 4:
                        Dialog.PrintHeader("Печать коллекции 4");
                        testCollections.PrintStringDict();
                        break;
                    case 5:
                        Dialog.PrintHeader("Печать всех коллекций");
                        Dialog.ColorText("\nКоллекция 1:", "green");
                        testCollections.PrintBirdQueue();
                        Dialog.ColorText("\nКоллекция 2:", "green");
                        testCollections.PrintStringQueue();
                        Dialog.ColorText("\nКоллекция 3:", "green");
                        testCollections.PrintAnimalDict();
                        Dialog.ColorText("\nКоллекция 4:", "green");
                        testCollections.PrintStringDict();
                        break;
                }
                Dialog.BackMessage();
            } while (isRunning);
            return;
        }

        //добавление случайных элементов в коллекции
        public static void AddElements(ref TestCollections testCollections)
        {
            Dialog.PrintHeader("добавление случайных элементов");
            int amount = Dialog.EnterNumber("Введите количество добавляемых элементов:", 0, 500);
            if (amount == 0)
            {
                Dialog.ColorText("\nКоллекции остались без изменений", "green");
                Dialog.BackMessage();
                return;
            }

            testCollections.AddElements(amount);
            Dialog.ColorText($"\nВ коллекции добавлено {amount} элементов. Выполните просмотр коллекций" +
                $" для наблюдения изменений", "green");
            Dialog.BackMessage();
            return;
        }

        //удаление случайных элементов из коллекции
        public static void DeleteElements(ref TestCollections testCollections)
        {
            Dialog.PrintHeader("Удаление элементов");

            if (testCollections.GetSize() == 0)
            {
                Dialog.ColorText("Все коллекции пустые! Это значит, что удалять в них нечего", "green");
                Dialog.BackMessage();
                return;
            }
            Console.WriteLine("\nУчтите, удалить элементов больше, чем их есть в коллекциях, у вас не получится!\n");

            int amount = Dialog.EnterNumber("Введите количество удаляемых элементов:", 0, testCollections.GetSize());
            if (amount == 0)
            {
                Dialog.ColorText("\nКоллекции остались без изменений", "green");
                Dialog.BackMessage();
                return;
            }

            testCollections.DeleteElements(amount);
            Dialog.ColorText($"\nИз коллекций удалено {amount} элементов. Выполните просмотр коллекций" +
                $" для наблюдения изменений", "green");
            Dialog.BackMessage();
            return;
        }

        //очистка коллекций
        public static void ClearCollections(ref TestCollections testCollections)
        {
            Dialog.PrintHeader("очистка коллекций");
            if (testCollections.GetSize() == 0)
            {
                Dialog.ColorText("В пустых коллекциях удалять-то нечего... Заполните их для начала!", "green");
                Dialog.BackMessage();
                return;
            }
            testCollections.Clear();
            Dialog.ColorText("Теперь коллекции стали пустыми!", "green");
            Dialog.BackMessage();
            return;
        }

        //замеры времени по поиску элемента в коллекциях
        public static void FindElementMenu(TestCollections testCollections)
        {
            Dialog.PrintHeader("Поиск элементов");

            if (testCollections.GetSize() == 0)
            {
                Dialog.ColorText("Все коллекции пустые! Очень жаль, но в них нечего искать", "green");
                Console.WriteLine("Совет: заполните их, и уже потом проведите операцию поиска");
                Dialog.BackMessage();
                return;
            }

            testCollections.SetValues();
            bool isRunning = true;
            do
            {
                Dialog.PrintHeader("Поиск элементов");
                Console.WriteLine("Элементы:");
                Console.Write("Первый добавленный: ");
                Bird element = testCollections.GetElement("first");
                element.Show();
                Console.Write("Центральный: ");
                element = testCollections.GetElement("middle");
                element.Show();
                Console.Write("Последний: ");
                element = testCollections.GetElement("last");
                element.Show();
                Console.Write("Несуществующий в коллекциях: ");
                element = testCollections.GetElement("notFound");
                element.Show();

                Console.WriteLine("\n1. Первый добавленный\n" +
                    "2. Элемент, расположенный в середине\n" +
                    "3. Последний элемент\n" +
                    "4. Несуществующий в коллекциях элемент\n\n" +
                    "5. Назад\n");

                int choice = Dialog.EnterNumber("Выберите элемент для поиска (они представлены выше):", 1, 5);
                if (choice == 5)
                {
                    //выход из меню
                    isRunning = false;
                    break;
                }

                Dialog.PrintHeader("Поиск элементов");
                ElementSearch(choice, testCollections);
                Dialog.BackMessage();
            } while (isRunning);
            return;

        }

        //поиск элемента за опр. время
        public static void ElementSearch(int type, TestCollections testCollections)
        {
            Bird? objToFind = new Bird();

            switch (type)
            {
                case 1: //выбор элемента для поиска
                    objToFind = testCollections.GetElement("first") as Bird;
                    break;
                case 2:
                    objToFind = testCollections.GetElement("middle") as Bird;
                    break;
                case 3:
                    objToFind = testCollections.GetElement("last") as Bird;
                    break;
                case 4:
                    objToFind = testCollections.GetElement("notFound") as Bird;
                    break;
            }

            //добавление в делегат указателей на методы
            TimeDelegate timeDelegate = TPMethods.TimeCollection1;
            timeDelegate += TPMethods.TimeCollection2;
            timeDelegate += TPMethods.TimeCollection3;
            timeDelegate += TPMethods.TimeCollection4;

            //вызов делегата
            timeDelegate.Invoke(testCollections, objToFind);
        }

        //определение сигнатуры делегата
        public delegate long TimeDelegate(TestCollections testCollections, Bird objToFind);
    }
}
