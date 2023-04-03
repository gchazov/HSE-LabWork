using AnimalLibrary;
using ConsoleTools;
using MyCollections;
using Functionality;

namespace LabWork12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //инициализация коллекций по умолчанию
            DoublyLinkedList<Animal> dList = new();

            //запуск выполнения всех методов подряд
            Run(ref dList);
        }



    static int MainMenu(ref DoublyLinkedList<Animal> dList)
        {
            string[] options = { "Двунаправленный список","Бинарное дерево", 
                "Хеш-таблица", "Дерево поиска", "Завершить работу"};
            Menu mainMenu = new(@"
    __          __       _       __           __      ______ 
   / /   ____ _/ /_     | |     / /___  _____/ /__   <  /__ \
  / /   / __ `/ __ \    | | /| / / __ \/ ___/ //_/   / /__/ /
 / /___/ /_/ / /_/ /    | |/ |/ / /_/ / /  / ,<     / // __/ 
/_____/\__,_/_.___/     |__/|__/\____/_/  /_/|_|   /_//____/ 

Здравствуй, уважаемый Пользователь!
Данная программа предназначена для работы с пользовательскими коллекциями.
В коллекциях могут храниться только объекты типа Animal, имейте в виду.

Для навигации используйте клавиши стрелок вверх и вниз, а также клавишу Enter для ввода.
Успеха!
", options);

            return mainMenu.Run();
        }

        static void Run(ref DoublyLinkedList<Animal> dList)
        {
            do
            {
                switch (MainMenu(ref dList))
                {
                    case 0: //ДВУНАПРАВЛЕННЫЙ СПИСОК
                        var dListRun = true;
                        do
                        {
                            switch (DListMenu(ref dList))
                            {
                                case 0: //СОЗДАТЬ СПИСОК
                                    switch (DListMakeMenu(ref dList))
                                    {
                                        case 0: //ЗАПОЛНЕНИЕ С ПОМОЩЬЮ ДСЧ
                                            DListRandom(ref dList);
                                            break;
                                        case 1: //ВВОД ЭЛЕМЕНТОВ ВРУЧНУЮ
                                            DListKeyboard(ref dList);
                                            break;
                                        case 2: //ВОЗВРАТ В МЕНЮ
                                            break;
                                    }
                                    break;
                                case 1: //ПЕЧАТЬ СПИСКА
                                    DListPrint(ref dList);
                                    break;
                                case 2: //ДОБАВИТЬ ЭЛЕМЕНТ ПО НОМЕРУ

                                    switch(DListInsert(ref dList))
                                    {
                                        case 0: //СЛУЧАЙНЫЙ ЭЛЕМЕНТ
                                            DListInsertRandom(ref dList);
                                            break;
                                        case 1: //ВВОД С КЛАВИАТУРЫ
                                            DListInsertKeyBoard(ref dList);
                                            break;
                                        case 2: //НАЗАД
                                            break;
                                    }
                                    break;
                                case 3: //ПЕРЕВЕРНУТЬ СПИСОК
                                    DListReverse(ref dList);
                                    break;
                                case 4: //ОЧИСТИТЬ СПИСОК
                                    DListClear(ref dList);
                                    break;
                                case 5: //В ГЛАВНОЕ МЕНЮ
                                    dListRun = false;//выход в главное меню
                                    break;
                            }
                        } while (dListRun); //конструкция встречаться будет часто
                        break;
                    case 1: //БИНАРНОЕ ДЕРЕВО
                        break;
                    case 2: //ХЕШ-ТАБЛИЦА
                        break;
                    case 3: //БИНАРНОЕ ДЕРЕВО ПОИСКА
                        break;
                    case 4: //ЗАВЕРШЕНИЕ РАБОТЫ
                        Dialog.PrintHeader(@"
   ______                __   __               __
  / ____/___  ____  ____/ /  / /_  __  _____  / /
 / / __/ __ \/ __ \/ __  /  / __ \/ / / / _ \/ / 
/ /_/ / /_/ / /_/ / /_/ /  / /_/ / /_/ /  __/_/  
\____/\____/\____/\__,_/  /_.___/\__, /\___(_)   
                                /____/           
");
                        Environment.Exit(0);
                        break;
                }
            }while (true); //условие выхода есть, переживать не за что
        }

        static int DListMenu(ref DoublyLinkedList<Animal> dList)
        {
            string[] options = { "Создать список","Распечатать список",
                "Добавить элемент по номеру", "Перевернуть список", "Очистить список", "В главное меню"};
            Menu dListMenuenu = new("Двунаправленный список", options);

            return dListMenuenu.Run();
        }

        static int DListMakeMenu(ref DoublyLinkedList<Animal> dList)
        {
            string[] options = { "Заполнение с помощью ДСЧ", "Ввод элементов вручную", "Назад" };
            Menu dListMenuenu = new("Создание двунаправленного списка", options);

            return dListMenuenu.Run();
        }

        static void DListRandom(ref DoublyLinkedList<Animal> dList)
        {
            Dialog.PrintHeader("Генерация с помощью ДСЧ");
            int size = Dialog.EnterNumber("Введите длину списка:", 0, 1000);
            DListMethods.MakeRandomList(ref dList, size);
            Dialog.ColorText(dList.isEmpty ? "Пустой список успешно создан!" :
                $"Двунаправленный список длиной {dList.Count} успешно создан!", "green");
            Dialog.BackMessage();
        }

        static void DListKeyboard(ref DoublyLinkedList<Animal> dList)
        {
            Dialog.PrintHeader("Добавление элементов вручную");
            int size = Dialog.EnterNumber("Введите длину списка:", 0, 1000);
            for (int i = 0; i < size; i++)
            {
                Dialog.ColorText($"Введите {i + 1} элемент:", "yellow");
                dList.AddLast(new Animal().Init()); //заполнение вводимыми объектами
            }
            Dialog.ColorText(dList.isEmpty ? "Пустой список успешно создан!" :
                $"Двунаправленный список длиной {dList.Count}  успешно создан!", "green");
            Dialog.BackMessage();
        }

        static void DListPrint(ref DoublyLinkedList<Animal> dList)
        {
            Dialog.PrintHeader("Печать списка");
            if (dList.isEmpty)
            {
                Dialog.ColorText("Текущий список пуст!", "green");
                Dialog.BackMessage();
            }
            else
            {
                Dialog.ColorText($"Длина списка - {dList.Count}, ниже представлены его элементы", "green");
                //можно юзать итератор, т.к. айэнумерэйбл реализован в коллекции
                foreach(Animal animal in dList)
                {
                    animal.Show();
                }
                Dialog.BackMessage();
            }
        }

        static int DListInsert(ref DoublyLinkedList<Animal> dList)
        {
            string[] options = {"Случайный элемент", 
                "Ввод элемента с клавиатуры", "Назад"};
            Menu dListMenuenu = new("Добавление элемента в список", options);

            return dListMenuenu.Run();
        }

        static void DListInsertRandom(ref DoublyLinkedList<Animal> dList)
        {
            Dialog.PrintHeader("Добавление случайного элемента");
            if (dList.isEmpty)
            {
                dList.AddFirst(new Animal().RandomInit());
                Console.WriteLine("Список пуст... был... до настоящего момента");
                Dialog.ColorText("Теперь список состоит из одного элемента! " +
                    "Распечатайте его и убедитесь", "green");
                Dialog.BackMessage();
            }
            else
            {
                int index = Dialog.EnterNumber("Введите позицию, на которую встанет элемент",
                    0, dList.Count);
                dList.Insert(new Animal().RandomInit(), index);
                Dialog.ColorText($"В список добавлени элемент на {index} позицию! " +
                    "Распечатайте его и убедитесь", "green");
                Dialog.BackMessage();
            }
        }

        static void DListInsertKeyBoard(ref DoublyLinkedList<Animal> dList)
        {
            Dialog.PrintHeader("Добавление введённого элемента");
            if (dList.isEmpty)
            {
                dList.AddFirst(new Animal().Init());
                Console.WriteLine("Список пуст... был... до настоящего момента");
                Dialog.ColorText("Теперь список состоит из одного элемента! " +
                    "Распечатайте его и убедитесь", "green");
                Dialog.BackMessage();
            }
            else
            {
                int index = Dialog.EnterNumber("Введите позицию, на которую встанет элемент",
                    0, dList.Count);
                dList.Insert(new Animal().Init(), index);
                Dialog.ColorText($"В список добавлени элемент на {index} позицию! " +
                    "Распечатайте его и убедитесь", "green");
                Dialog.BackMessage();
            }
        }

        static void DListReverse(ref DoublyLinkedList<Animal> dList)
        {
            Dialog.PrintHeader("Переворот списка");
            if (dList.isEmpty)
            {
                Console.WriteLine("К сожалению, в пустом списке переворачивать нечего");
                Dialog.ColorText("Заполните его элементами и возвращайтесь!", "yellow");
                Dialog.BackMessage();
            }
            else
            {
                DListMethods.ReverseList(ref dList);
                Dialog.ColorText("Список успешно перевернулся!", "green");
                Dialog.BackMessage();
            }
        }

        static void DListClear(ref DoublyLinkedList<Animal> dList)
        {
            Dialog.PrintHeader("Переворот списка");
            if (dList.isEmpty)
            {
                Console.WriteLine("Коллекция как была пустой, так ей и осталась");
                Dialog.ColorText("Изменений не произошло!", "yellow");
                Dialog.BackMessage();
            }
            else
            {
                dList.Clear();
                Dialog.ColorText("Список был успешно очищен! Теперь его длина равна нулю", "green");
                Dialog.BackMessage();
            }
        }
    }
}