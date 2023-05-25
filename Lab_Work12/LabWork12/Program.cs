using AnimalLibrary;
using ConsoleTools;
using MyCollections;
using Functionality;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Data;

//ЛАБОРАТОРНАЯ РАБОТА 12 ВАРИАНТ 4

namespace LabWork12
{
    internal class Program
    {

        static void Main(string[] args)
        {
            //инициализация коллекций по умолчанию
            DoublyLinkedList<Animal> dList = new();
            BinaryTree<Animal> tree = new();
            HTable<Animal> htable = new();
            MyCollection<Animal> myCollection = new();
            //запуск выполнения всех методов подряд
            Run(ref dList, ref tree, ref htable, ref myCollection);
        }



        static int MainMenu(ref DoublyLinkedList<Animal> dList)
            {
                string[] options = { "Двунаправленный список","Бинарное дерево", 
                    "Хеш-таблица", "MyCollection (хеш-таблица)", "Завершить работу"};
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
    Приятнонго пользования!
    ", options);

                return mainMenu.Run();
            }

        static void Run(ref DoublyLinkedList<Animal> dList,
            ref BinaryTree<Animal> tree,
            ref HTable<Animal> htable,
            ref MyCollection<Animal> myCollection)
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
                                case 4: //КЛОНИРОВАТЬ СПИСОК
                                    DListClone(ref dList);
                                    break;
                                case 5: //ОЧИСТИТЬ СПИСОК
                                    DListClear(ref dList);
                                    break;
                                case 6: //В ГЛАВНОЕ МЕНЮ
                                    dListRun = false;//выход в главное меню
                                    break;
                            }
                        } while (dListRun); //конструкция встречаться будет часто
                        break;
                    case 1: //БИНАРНОЕ ДЕРЕВО
                        var bTreeRun = true;
                        do
                        {
                            switch (TreeMenu(ref tree))
                            {
                                case 0: //СОЗДАТЬ ДЕРЕВО
                                    TreeMakeIdeal(ref tree);
                                    break;
                                case 1: //РАСПЕЧАТАТЬ ДЕРЕВО
                                    TreeShow(ref tree);
                                    break;
                                case 2: //НАЙТИ МИНИМАЛЬНЫЙ ЭЛЕМЕНТ ДЕРЕВА
                                    TreeGetMinimal(ref tree);
                                    break;
                                case 3: //ПРЕОБРАЗОВАТЬ В ДЕРЕВО ПОИСКА
                                    TreeTransform(ref tree);
                                    break;
                                case 4: //В ГЛАВНОЕ МЕНЮ
                                    bTreeRun = false;
                                    break;

                            }
                        } while (bTreeRun);
                        break;
                    case 2: //ХЕШ-ТАБЛИЦА
                        var hTableRun = true;
                        do
                        {
                            switch (HTableMenu(ref htable))
                            {
                                case 0: //СОЗДАТЬ ХЕШ-ТАБЛИЦУ
                                    HTableMakeMenu(ref htable);
                                    break;
                                case 1: //ЗАПОЛНИТЬ ХЕШ-ТАБЛИЦУ
                                    HTableFill(ref htable);
                                    break;
                                case 2: //РАСПЕЧАТАТЬ ХЕШ-ТАБЛИЦУ
                                    HTablePrint(ref htable);
                                    break;
                                case 3: //ДОБАВИТЬ ЭЛЕМЕНТ В ХЕШ-ТАБЛИЦУ
                                    HTableAdd(ref htable);
                                    break;
                                case 4: //НАЙТИ ЭЛЕМЕНТ В ХЕШ-ТАБЛИЦЕ
                                    HTableFind(ref htable);
                                    break;
                                case 5: //В ГЛАВНОЕ МЕНЮ
                                    hTableRun = false;
                                    break;

                            }
                        } while (hTableRun);
                        break;
                    case 3: //МАЙКОЛЛЕКШН
                        var myCollectionRun = true;
                        do
                        {
                            switch (MyCollectionMenu(ref myCollection))
                            {
                                case 0: //СОЗДАТЬ ХЕШ-ТАБЛИЦУ
                                    MyCollectionMakeMenu(ref myCollection);
                                    break;
                                case 1: //ЗАПОЛНИТЬ ХЕШ-ТАБЛИЦУ
                                    MyCollectionFill(ref myCollection);
                                    break;
                                case 2: //РАСПЕЧАТАТЬ ХЕШ-ТАБЛИЦУ
                                    MyCollectionPrint(ref myCollection);
                                    break;
                                case 3: //ДОБАВИТЬ ЭЛЕМЕНТЫ В ХЕШ-ТАБЛИЦУ
                                    MyCollectionAdd(ref myCollection);
                                    break;
                                case 4://НАЙТИ ЭЛЕМЕНТ В ХЕШ-ТАБЛИЦЕ
                                    MyCollectionAdd(ref myCollection);
                                    break;
                                case 5: //ЗАМЕНА ЭЛЕМЕНТА В ХЕШ-ТАБЛИЦЕ ПО КЛЮЧУ
                                    MyCollectionChange(ref myCollection);
                                    break;
                                case 6: //УДАЛИТЬ ЭЛЕМЕНТЫ В ХЕШ-ТАБЛИЦЕ
                                    MyCollectionDelete(ref myCollection);
                                    break;
                                case 7: //КЛОНИРОВАНИЕ И КОПИРОВАНИЕ
                                    MyCollectionCopyClone(ref myCollection);
                                    break;
                                case 8: //В ГЛАВНОЕ МЕНЮ
                                    myCollectionRun = false;
                                    break;

                            }
                        } while (myCollectionRun);
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

                        //удаление (зануление) коллекций
                        dList = new();
                        tree= new();
                        htable = new();
                        myCollection = new();

                        Environment.Exit(0);
                        break;
                }
            }while (true); //условие выхода есть, переживать не за что
        }

        #region DoublyLinkedList
        //самое главное меню
        static int DListMenu(ref DoublyLinkedList<Animal> dList)
        {
            string[] options = { "Создать список","Распечатать список",
                "Добавить элемент по номеру", "Перевернуть список", "Клонировать список" ,"Очистить список", "В главное меню"};
            Menu dListMenuenu = new("Двунаправленный список", options);

            return dListMenuenu.Run();
        }

        //меню для двунапр. списка
        static int DListMakeMenu(ref DoublyLinkedList<Animal> dList)
        {
            string[] options = { "Заполнение с помощью ДСЧ", "Ввод элементов вручную", "Назад" };
            Menu dListMenuenu = new("Создание двунаправленного списка", options);

            return dListMenuenu.Run();
        }

        //создание списка с помощью ДСЧ
        static void DListRandom(ref DoublyLinkedList<Animal> dList)
        {
            Dialog.PrintHeader("Генерация с помощью ДСЧ");
            int size = Dialog.EnterNumber("Введите длину списка:", 0, 1000);
            CollectionMethods.MakeRandomList(ref dList, size);
            Dialog.ColorText(dList.isEmpty ? "Пустой список успешно создан!" :
                $"Двунаправленный список длиной {dList.Count} успешно создан!", "green");
            Dialog.BackMessage();
        }

        //ввод с помощью клавиатуры
        static void DListKeyboard(ref DoublyLinkedList<Animal> dList)
        {
            Dialog.PrintHeader("Добавление элементов вручную");
            dList = new();
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

        //печать списка
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
                Dialog.ColorText($"Длина списка - {dList.Count}, ниже представлены его элементы\n", "green");
                //можно юзать итератор, т.к. айэнумерэйбл реализован в коллекции
                dList.Show();
                Dialog.BackMessage();
            }
        }

        //меню вставки элемента на позицию
        static int DListInsert(ref DoublyLinkedList<Animal> dList)
        {
            string[] options = {"Случайный элемент", 
                "Ввод элемента с клавиатуры", "Назад"};
            Menu dListMenuenu = new("Добавление элемента в список", options);

            return dListMenuenu.Run();
        }

        //вставка элемента на позицию (случайный)
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
                    0, dList.Count + 1);
                dList.Insert(new Animal().RandomInit(), index);
                Dialog.ColorText($"В список добавлени элемент на {index} позицию! " +
                    "Распечатайте его и убедитесь", "green");
                Dialog.BackMessage();
            }
        }

        //вставка элемента на позицию (с клавы)
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
                    0, dList.Count + 1);
                dList.Insert(new Animal().Init(), index);
                Dialog.ColorText($"В список добавлени элемент на {index} позицию! " +
                    "Распечатайте его и убедитесь", "green");
                Dialog.BackMessage();
            }
        }

        //переворот списка
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
                CollectionMethods.ReverseList(ref dList);
                Dialog.ColorText("Список успешно перевернулся!", "green");
                Dialog.BackMessage();
            }
        }

        //клонирование списка
        static void DListClone(ref DoublyLinkedList<Animal> dList)
        {
            Dialog.PrintHeader("Клонирование списка");
            if (dList.isEmpty)
            {
                Dialog.ColorText("Коллекция пустая! Клонировать особо нечего...", "yellow");
                Dialog.BackMessage();
            }
            else
            {
                DoublyLinkedList<Animal> clone = dList.Clone();

                Console.WriteLine("Происходит клонирование списка...");
                Console.WriteLine($"33%");
                Thread.Sleep(1000);
                Console.WriteLine($"75%");
                Thread.Sleep(1000);
                Console.WriteLine($"100%");
                Thread.Sleep(1000);
                Dialog.ColorText("\nСписок успешно склонирован!", "green");
                Dialog.ColorText("\nИсходный список имеет вид:", "yellow");
                foreach (Animal animal in dList)
                {
                    animal.Show();
                }

                Dialog.ColorText("\nСписок-клон выглядит так:", "red");
                foreach (Animal animal in clone)
                {
                    animal.Show();
                }

                Console.WriteLine();
                int indexToNull = Dialog.EnterNumber("Введите позицию исходного списка, элемент которой будет изменён", 1, dList.Count);

                Console.WriteLine("Теперь инициализируйте сам элемент");
                dList[indexToNull - 1] = new Animal().Init();


                Dialog.ColorText("\nСейчас же исходный список имеет вид:", "yellow");
                foreach (Animal animal in dList)
                {
                    animal.Show();
                }

                Dialog.ColorText("\nА список-клон остался прежним!", "red");
                foreach (Animal animal in clone)
                {
                    animal.Show();
                }
                clone.Clear();
                Dialog.ColorText("\nКлон удалён из памяти!", "green");
                Dialog.BackMessage();
            }
        }


        //очистка списка
        static void DListClear(ref DoublyLinkedList<Animal> dList)
        {
            Dialog.PrintHeader("Очистка списка");
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

        #endregion

        #region BinaryTree

        //главное меню для бинарного дерева
        static int TreeMenu(ref BinaryTree<Animal> tree)
        {
            string[] options = { "Создать идеально сбалансированное дерево", 
                "Распечатать дерево",
                "Найти элемент с наименьшим ID", "Преобразовать в дерево поиска", 
                "В главное меню"};
            Menu TreeMenuenu = new("Бинарное дерево", options);

            return TreeMenuenu.Run();
        }

        //создание идеально сбалансированного дерева
        static void TreeMakeIdeal(ref BinaryTree<Animal> tree)
        {
            Dialog.PrintHeader("Создание дерева из случайных элементов");
            int heigth = Dialog.EnterNumber("Введите количество элементов дерева:", 0, 100);
            tree = new();
            if (heigth == 0)
            {
                Dialog.ColorText("\nДерево создано! Правда, в нём нет элементов...", "green");
                Dialog.BackMessage();
                return;
            }
            else
            {
                BinaryTree<Animal>.Add(tree, new Animal().RandomInit());
                tree = BinaryTree<Animal>.IdealTree(heigth, tree);
                Dialog.ColorText($"\nБинарное дерево из {heigth} элементов создано!\n" +
                    $"Распечатайте его и убедитесь в этом", "green");
                Dialog.BackMessage();
                return;
            }
        }

        //создание идеально сбалансированного дерева
        static void TreeShow(ref BinaryTree<Animal> tree)
        {
            Dialog.PrintHeader("Печать дерева");
            if (tree.IsEmpty())
            {
                Dialog.ColorText("Дерево пустое и не содержит каких-либо элементов", "green");
                Dialog.BackMessage();
                return;
            }
            else
            {

                Console.WriteLine("Дерево имеет следующий вид:\n");
                BinaryTree<Animal>.ShowTree(tree, 1);
                Dialog.BackMessage();
                return;
            }
        }

        
        //нахождение минимального элемента в дереве
        static void TreeGetMinimal(ref BinaryTree<Animal> tree)
        {
            Dialog.PrintHeader("Поиск элемента с наименьшим ID");
            if (tree.IsEmpty())
            {
                Dialog.ColorText("Дерево пустое и искать в нём нечего!", "green");
                Dialog.BackMessage();
                return;
            }
            BinaryTree<Animal> potenital = tree.GetFirst();
            BinaryTree<Animal>.Transform(potenital, tree);

            if(BinaryTree<Animal>.PrefixWalk(potenital).
                SequenceEqual(BinaryTree <Animal>.PrefixWalk(tree)))
            {
                var result = BinaryTree<Animal>.GetMinimalBST(tree);
                Dialog.ColorText("Успех! В дереве поиска найден элемент с наименьшим ID:", "green");
                Console.WriteLine(result);
                Dialog.BackMessage();
                return;
            }
            else
            {
                var list = BinaryTree<Animal>.PrefixWalk(potenital);
                var result = list.Min();
                Dialog.ColorText("Успех! В дереве найден элемент с наименьшим ID:", "green");
                Console.WriteLine(result);
                Dialog.BackMessage();
                return;
            }
        }

        //преобразование дерева в дерево поиска
        static void TreeTransform(ref BinaryTree<Animal> tree)
        {
            Dialog.PrintHeader("Преобразование в дерево поиска");
            if (tree.IsEmpty())
            {
                Dialog.ColorText("Дерево пустое и преобразовывать особо нечего!", "green");
                Dialog.BackMessage();
                return;
            }
            else
            {
                BinaryTree<Animal> root = tree.GetFirst();
                BinaryTree<Animal>.Transform(root, tree);
                tree = root;
                Dialog.ColorText("Дерево успешно преобразовано в дерево поиска!", "green");
                Dialog.BackMessage();
                return;
            }
        }
        #endregion

        #region HashTable

        //самое главное меню
        static int HTableMenu(ref HTable<Animal> htable)
        {
            string[] options = { "Создать хеш-таблицу", "Очистить и заполнить структуру","Распечатать хеш-таблицу",
                "Добавить элемент в хеш-таблицу", "Поиск и удаление элемента", "В главное меню"};
            Menu dListMenuenu = new("Хеш-таблица", options);

            return dListMenuenu.Run();
        }

        //создание хеш-таблицы
        static void HTableMakeMenu(ref HTable<Animal> htable)
        {
            Dialog.PrintHeader("Создание хеш-таблицы");
            htable = new HTable<Animal>(Dialog.EnterNumber("Введите размер будущей хеш-таблицы:", 0, 100));
            if (htable.Size == 0)
            {
                Dialog.ColorText("Пустая хеш-таблица успешно создана!", "green");
            }
            else
            {
                Dialog.ColorText($"Хеш-таблица длиной {htable.Size} успешно создана!\n" +
                    $"Чтобы в ней появились элементы, используйте второй пункт предыдущего меню", "green");
            }
            Dialog.BackMessage();
        }

        //заполнение таблицы
        private static void HTableFill(ref HTable<Animal> htable)
        {
            Dialog.PrintHeader("Заполнение хеш-таблицы");
            if (htable.Size == 0)
            {
                Dialog.ColorText("Сначала стоит создать структуру данных, а потом уже её заполнять!", "green");
            }
            else
            {
                htable = new(htable.Size);
                for(int i = 0; i < htable.Size; i++)
                    htable.Add(CollectionMethods.GetRandomAnimal());

                Dialog.ColorText($"Хеш-таблица заполнена случайными элементами иерархии Animal!\n" +
                    $"Убедитесь в этом, распечатав коллекцию", "green");
            }
            Dialog.BackMessage();
        }

        //печать хт
        private static void HTablePrint(ref HTable<Animal> htable)
        {
            Dialog.PrintHeader("Печать хеш-таблицы");
            if (htable.Size == 0)
            {
                Dialog.ColorText("Хеш-таблица пустая! Заполните её, а там уже интереснее будет!", "green");
            }
            else
            {
                Dialog.ColorText($"Структура хеш-таблицы из {htable.Size} ячеек памяти " +
                    $"и элементов выглядит следующим образом:\n", "green");
                Console.WriteLine(htable);
            }
            Dialog.BackMessage();
        }

        //добавление в хеш-таблицу
        private static void HTableAdd(ref HTable<Animal> htable)
        {
            Dialog.PrintHeader("Добавление в таблицу случайного объекта");
            if (htable.Size == 0)
            {
                htable = new(1);
                var toAdd = CollectionMethods.GetRandomAnimal();
                htable.Add(toAdd);
                Dialog.ColorText("Хеш-таблица была пустая! До настоящего момента\n" +
                    "Теперь в ней содержится 1 добавленный элемент:", "green");
                Console.WriteLine(toAdd);
            }
            else
            {
                var toAdd = CollectionMethods.GetRandomAnimal();
                htable.Add(toAdd);
                Dialog.ColorText("В хеш-таблицу добавлен новый элемент!\n" +
                    "Он имеет вид:", "green");
                Console.WriteLine(toAdd);
            }
            Dialog.BackMessage();
        }

        //поиск элемента в хт
        private static void HTableFind(ref HTable<Animal> htable)
        {
            Dialog.PrintHeader("Поиск и удаление элемента в хеш-таблице");
            if (htable.Size == 0)
            {
                Dialog.ColorText("В пустой таблице искать нечего! Заполните уже её!", "green");
            }
            else
            {
                Console.WriteLine("Введите ключ элемента для поиска и удаления:");
                var animal = new Animal().Init();

                bool result = htable.FindElementData(animal);
                if (result == false)
                {
                    Dialog.ColorText("\nВ таблице такого элемента нет!");
                }
                else
                {
                    var animalResult = htable.DeleteElement(animal);
                    Dialog.ColorText("\nУспех! Из таблицы удалён искомый элемент и он имеет вид:", "green");
                    Console.WriteLine(animalResult);
                }
            }
            Dialog.BackMessage();
        }

        //меню поиска
        static int FindMenu(ref HTable<Animal> htable)
        {
            string[] options = { "Животное", "Птица","Млекопитающее",
                "Парнокопытное"};
            Menu dListMenuenu = new("Выбор типа объекта", options);

            return dListMenuenu.Run();
        }
        #endregion
        
        #region MyCollection

        //самое главное меню
        static int MyCollectionMenu(ref MyCollection<Animal> myCollection)
        {
            string[] options = { "Создать хеш-таблицу", "Заполнить структуру","Распечатать хеш-таблицу",
                "Добавить элемент(-ы) в хеш-таблицу", "Поиск элемента в хеш-таблице","Изменение элемента по ключу",
                "Удаление элементов по ключам", "Клонирование и копирование",
                "В главное меню"};
            Menu dListMenuenu = new("Хеш-таблица (MyCollection)", options);

            return dListMenuenu.Run();
        }

        private static void MyCollectionMakeMenu(ref MyCollection<Animal> myCollection) //создание коллекции
        {
            Dialog.PrintHeader("Создание хеш-таблицы");
            myCollection = new MyCollection<Animal>(Dialog.EnterNumber("Введите количество цепочек будущей хеш-таблицы:", 0, 100));
            if (myCollection.Length == 0)
            {
                Dialog.ColorText("Пустая хеш-таблица успешно создана!", "green");
            }
            else
            {
                Dialog.ColorText($"\nХеш-таблица длиной в {myCollection.Length} цепочек успешно создана!\n" +
                    $"Чтобы в ней появились элементы, используйте второй пункт предыдущего меню", "green");
            }
            Dialog.BackMessage();
        }

        private static void MyCollectionFill(ref MyCollection<Animal> myCollection) //заполнение коллекции
        {
            Dialog.PrintHeader("Очистка и заполнение коллекции");
            myCollection.Clear();
            Animal[] values = new Animal[Dialog.EnterNumber("Введите элементов в будущей коллекции:", 0, 500)];
            if (values.Length == 0)
            {
                Dialog.ColorText($"Теперь в коллекции есть {myCollection.Length} пустых цепочек!", "green");
                Dialog.BackMessage();
                return;
            }
            for (int i  = 0; i < values.Length; i++)
                values[i] = CollectionMethods.GetRandomAnimal();

            myCollection.AddRange(values);

            Dialog.ColorText($"Теперь коллекция состоит из {myCollection.Count} элементов!", "green");
            Dialog.BackMessage();
            return;
        }

        private static void MyCollectionPrint(ref MyCollection<Animal> myCollection)    //печать коллекции
        {
            Dialog.PrintHeader("Печать коллекции");
            if (myCollection.Length == 0)
            {
                Dialog.ColorText($"В текущей хеш-таблице нет ни одной цепочки!", "green");
                Dialog.BackMessage();
                return;
            }

            Dialog.ColorText($"Текущая хеш-таблица состоит из следующих цепочек:", "green");
            Console.WriteLine(myCollection);
            Dialog.BackMessage();
        }

        private static void MyCollectionAdd(ref MyCollection<Animal> myCollection)  //добавление элементов
        {
            Dialog.PrintHeader("Добавление элементов в коллекцию");
            Animal[] values = new Animal[Dialog.EnterNumber("Введите количество добавляемых элементов:", 0, 20)];
            if (values.Length == 0)
            {
                Dialog.ColorText($"Коллекция осталось без изменений, ведь ничего не прибавилось к ней!", "green");
                Dialog.BackMessage();
                return;
            }

            if (myCollection.Length == 0)
            {
                myCollection = new MyCollection<Animal>(values.Length);
            }
            for (int i = 0; i < values.Length; i++)
                values[i] = CollectionMethods.GetRandomAnimal();

            myCollection.AddRange(values);

            Dialog.ColorText($"Теперь количество элементов равно {myCollection.Count}", "green");
            Dialog.BackMessage();
            return;
        }

        private static void MyCollectionContains(ref MyCollection<Animal> myCollection)   //изменение элемента
        {
            Dialog.PrintHeader("Поиск элемента в хеш-таблицы");

            Console.WriteLine("Введите ключ искомого элемента:");
            Animal key = new Animal().Init();
            if (!myCollection.Contains(key))
            {
                Dialog.ColorText($"В коллекции такого элемента нет!");
            }
            else
            {
                Dialog.ColorText($"Элемент присутствует в коллекции!");
            }
            Dialog.BackMessage();
            return;
        }

            private static void MyCollectionChange(ref MyCollection<Animal> myCollection)   //изменение элемента
        {
            Dialog.PrintHeader("Изменение элемента хеш-таблицы");

            Console.WriteLine("Хеш-таблица имеет следующий вид:");
            Console.WriteLine(myCollection + "\n");
            Console.WriteLine("Сначала введите ключ элемента, который хотите изменить");
            Animal key = new Animal().Init();
            if (!myCollection.Contains(key)) 
            {
                Dialog.ColorText($"В коллекции нет такого элемента!");
                Dialog.BackMessage();
                return;
            }

            Console.WriteLine("\nТеперь введите данные нового объекта");
            Animal animal = new Animal().Init();

            //чтобы элемент по правилам соответствовал цепочке
            while (animal.GetHashCode()%myCollection.Length != key.GetHashCode() % myCollection.Length)
                animal.Name += ")";
            myCollection[key] = animal; 

            Dialog.ColorText($"В коллекции обновлён элемент {key.GetHashCode()%myCollection.Length + 1} цепочки!\n" +
                $"Распечатайте коллекцию и убедитесь в этом. Имя объекта могло измениться для соответствия структуре таблицы.",
                "green");
            Dialog.BackMessage();
            return;
        }

        private static void MyCollectionDelete(ref MyCollection<Animal> myCollection)       //удаление элемента
        {
            Dialog.PrintHeader("Удаление элементов из коллекции");
            if (myCollection.Count == 0)
            {
                Dialog.ColorText($"В пустой хеш-табоице удалять нечего!!!", "green");
                Dialog.BackMessage();
                return;
            }
            Console.WriteLine("Хеш-таблица имеет следующий вид:");
            Console.WriteLine(myCollection+"\n");
            Animal[] values = new Animal[Dialog.EnterNumber("Введите количество удаляемых элементов:", 0, 20)];
            if (values.Length == 0)
            {
                Dialog.ColorText($"Ничего удалено не было, всё на своих местах!", "green");
                Dialog.BackMessage();
                return;
            }

            for (int i = 0; i < values.Length; i++)
            {
                Dialog.ColorText($"Инициализация {i + 1} объекта", "yellow");
                values[i] = new Animal().Init();
            }

            myCollection.RemoveRange(values);

            Dialog.ColorText($"Теперь длина коллекции равна {myCollection.Count}", "green");
            Dialog.BackMessage();
            return;
        }

        private static void MyCollectionCopyClone(ref MyCollection<Animal> myCollection)    //клонирование/копирование
        {
            Dialog.PrintHeader("Клонирование и копирование коллекции");
            if (myCollection.Count == 0)
            {
                Dialog.ColorText($"В коллекции без элементов мало чего можно скопировать...\n" +
                    $"Заполните её и возвращайтесь!", "green");
                Dialog.BackMessage();
                return;
            }

            MyCollection<Animal> copy = (MyCollection<Animal>)myCollection.ShallowCopy();
            MyCollection<Animal> clone = (MyCollection<Animal>)myCollection.Clone();

            Dialog.ColorText("КОПИЯ хеш-таблицы");
            Console.WriteLine(copy);

            Dialog.ColorText("КЛОН хеш-таблицы", "green");
            Console.WriteLine(clone);

            Console.WriteLine("\nТеперь изменим ПЕРВЫЙ элемент в первоначальной коллекции");

            Animal key = new Animal();
            foreach (var element in myCollection)
            {
                if (element is Animal)
                {
                    key = (Animal)element.Clone();
                    break;
                }
            }

            Dialog.ColorText("Инициализация нового элемента", "yellow");
            myCollection[key.GetBase()] = new Animal().Init();

            Console.WriteLine("\nТеперь коллекции имеют следующий вид. Выводы напрашиваются сами :)\n");

            Dialog.ColorText("КОПИЯ хеш-таблицы");
            Console.WriteLine(copy);

            Dialog.ColorText("КЛОН хеш-таблицы", "green");
            Console.WriteLine(clone);

            Dialog.BackMessage();
            return;
        }

        #endregion
    }
}