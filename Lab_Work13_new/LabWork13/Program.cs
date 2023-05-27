using AnimalLibrary;
using ConsoleTools;
using MyCollections;
using Functionality;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Data;

//ЛАБОРАТОРНАЯ РАБОТА 12 ВАРИАНТ 4

namespace LabWork13
{
    //ЛАБОРАТОРНАЯ РАБОТА 13
    internal class Program
    {
        static void Main(string[] args)
        {
            //инициализация по коллекций и журналов по умолчанию
            MyNewCollection<Animal> firstCollection = new("Коллекция 1");
            MyNewCollection<Animal> secondCollection = new("Коллекция 2");

            Journal<Animal> firstJournal = new("Журнал 1");
            Journal<Animal> secondJournal = new("Журнал 2");

            Run(ref firstCollection, ref secondCollection,
                ref firstJournal, ref secondJournal);
        }

        static void Run(ref MyNewCollection<Animal> firstCollection,
            ref MyNewCollection<Animal> secondCollection,
            ref Journal<Animal> firstJournal, ref Journal<Animal> secondJournal)
        {
            var mainMenuRun = true;
            do
            {
                switch (MainMenu())
                {
                    case 0: //СОЗДАНИЕ ЦЕПОЧЕК ХЕШ-ТАБЛИЦЫ
                        var makeMenuRun = true;
                        do
                        {
                            switch(CollectionChoice(ref firstCollection, ref secondCollection))
                            {
                                case 0:
                                    MakeFirstCollection(ref firstCollection, ref firstJournal, ref secondJournal);
                                    break;
                                case 1:
                                    MakeSecondCollection(ref secondCollection, ref secondJournal);
                                    break;
                                case 2:
                                    makeMenuRun = false;
                                    break;
                            }
                        } while (makeMenuRun);
                        break;
                    case 1: //ЗАПОЛНЕНИЕ КОЛЛЕКЦИИ
                        var fillMenuRun = true;
                        do
                        {
                            switch (CollectionChoice(ref firstCollection, ref secondCollection))
                            {
                                case 0:
                                    CollectionFill(ref firstCollection);
                                    break;
                                case 1:
                                    CollectionFill(ref secondCollection);
                                    break;
                                case 2:
                                    fillMenuRun = false;
                                    break;
                            }
                        } while (fillMenuRun);
                        break;
                    case 2: //ПЕЧАТЬ КОЛЛЕКЦИИ
                        var printCollectionRun = true;
                        do
                        {
                            switch (CollectionChoice(ref firstCollection, ref secondCollection))
                            {
                                case 0:
                                    CollectionPrint(ref firstCollection);
                                    break;
                                case 1:
                                    CollectionPrint(ref secondCollection);
                                    break;
                                case 2:
                                    printCollectionRun = false;
                                    break;
                            }
                        } while (printCollectionRun);
                        break;
                    case 3: //ДОБАВЛЕНИЕ ЭЛЕМЕНТОВ
                        var addToCollectionRun = true;
                        do
                        {
                            switch (CollectionChoice(ref firstCollection, ref secondCollection))
                            {
                                case 0:
                                    AddElement(ref firstCollection, ref firstJournal, ref secondJournal);
                                    break;
                                case 1:
                                    AddElement(ref secondCollection, ref firstJournal, ref secondJournal);
                                    break;
                                case 2:
                                    addToCollectionRun = false;
                                    break;
                            }
                        } while (addToCollectionRun);
                        break;
                    case 4: //УДАЛЕНИЕ ЭЛЕМЕНТА
                        var removeRun = true;
                        do
                        {
                            switch (CollectionChoice(ref firstCollection, ref secondCollection))
                            {
                                case 0:
                                    RemoveElement(ref firstCollection);
                                    break;
                                case 1:
                                    RemoveElement(ref secondCollection);
                                    break;
                                case 2:
                                    removeRun = false;
                                    break;
                            }
                        } while (removeRun);
                        break;
                    case 5: //ИЗМЕНЕНИЕ ЭЛЕМЕНТА
                        var changeRun = true;
                        do
                        {
                            switch (CollectionChoice(ref firstCollection, ref secondCollection))
                            {
                                case 0:
                                    ChangeElement(ref firstCollection);
                                    break;
                                case 1:
                                    ChangeElement(ref secondCollection);
                                    break;
                                case 2:
                                    changeRun = false;
                                    break;
                            }
                        } while (changeRun);
                        break;
                    case 6: //ПЕРЕИМЕНОВАТЬ КОЛЛЕКЦИЮ
                        var changeCollectionRun = true;
                        do
                        {
                            switch (CollectionChoice(ref firstCollection, ref secondCollection))
                            {
                                case 0:
                                    ChangeCollectionName(ref firstCollection);
                                    break;
                                case 1:
                                    ChangeCollectionName(ref secondCollection);
                                    break;
                                case 2:
                                    changeCollectionRun = false;
                                    break;
                            }
                        } while (changeCollectionRun);
                        break;
                    case 7: //ПЕРЕИМЕНОВАТЬ ЖУРНАЛ
                        var changeJournalRun = true;
                        do
                        {
                            switch (CollectionChoice(ref firstCollection, ref secondCollection))
                            {
                                case 0:
                                    ChangeJournalName(ref firstJournal);
                                    break;
                                case 1:
                                    ChangeJournalName(ref secondJournal);
                                    break;
                                case 2:
                                    changeJournalRun = false;
                                    break;
                            }
                        } while (changeJournalRun);
                        break;
                    case 8: //ПРОСМОТР ЖУРНАЛОВ
                        ShowJournals(ref firstJournal, ref secondJournal);
                        break;
                    case 9: //ЗАВЕРШЕНИЕ РАБОТЫ
                        Dialog.PrintHeader(@"
   ______                __   __               __
  / ____/___  ____  ____/ /  / /_  __  _____  / /
 / / __/ __ \/ __ \/ __  /  / __ \/ / / / _ \/ / 
/ /_/ / /_/ / /_/ / /_/ /  / /_/ / /_/ /  __/_/  
\____/\____/\____/\__,_/  /_.___/\__, /\___(_)   
                                /____/           
");

                        //удаление (зануление) коллекций
                        firstCollection = new();
                        secondCollection = new();
                        firstJournal = new();
                        firstJournal = new();

                        Environment.Exit(0);
                        break;
                }
            } while (mainMenuRun);
        }

        static int MainMenu()
        {
            string[] options = { "Создание цепочек хеш-таблицы", "Заполнение коллекции", "Печать коллекции",
            "Добавление случайного элемента", "Удаление элемента", "Изменение элемента хеш-таблицы", "Переименовать коллекцию",
            "Переименовать журнал", "Просмотр журналов", "Завершение работы"};
            Menu mainMenu = new(@"
        __          __       _       __           __      ________
       / /   ____ _/ /_     | |     / /___  _____/ /__   <  /__  /
      / /   / __ `/ __ \    | | /| / / __ \/ ___/ //_/   / / /_ < 
     / /___/ /_/ / /_/ /    | |/ |/ / /_/ / /  / ,<     / /___/ / 
    /_____/\__,_/_.___/     |__/|__/\____/_/  /_/|_|   /_//____/  
                                                              
    Здравствуй, уважаемый Пользователь!
    Данная программа предназначена для работы с хеш-таблицей и отслеживания происходящих с ней событий. 
    В коллекциях могут храниться только объекты типа Animal, имейте в виду.

    Для навигации используйте клавиши стрелок вверх и вниз, а также клавишу Enter для ввода.
    Приятнонго пользования!
", options);
            return mainMenu.Run();
        }

        static int CollectionChoice(ref MyNewCollection<Animal> firstCollection,
            ref MyNewCollection<Animal> secondCollection)   //выбор коллекции
        {
            string[] options = { $"{firstCollection.CollectionName}", $"{secondCollection.CollectionName}", "Назад" };
            Menu collChoiceMenu = new("Выбор коллекции", options);
            return collChoiceMenu.Run();
        }

        static void MakeFirstCollection(ref MyNewCollection<Animal> collection,
            ref Journal<Animal> firstJournal, ref Journal<Animal> secondJournal) //создание коллекции
        {
            Dialog.PrintHeader($"Создание цепочек {collection.CollectionName}");
            string name = collection.CollectionName;
            collection = new MyNewCollection<Animal>(Dialog.EnterNumber("Введите количество цепочек будущей хеш-таблицы:", 0, 100));
            collection.CollectionName = name;
            //подписка первого журнала на события о изм. кол-ва элементов ПЕРВОЙ коллекции
            collection.CollectionCountChanged += new(firstJournal.CollectionCountChanged);

            //подписка первого журнала на события о изм. элемента ПЕРВОЙ коллекции
            collection.CollectionReferenceChanged += new(firstJournal.CollectionReferenceChanged);

            //подписка второго журнала на события о изм. кол-ва элементов ПЕРВОЙ коллекции
            collection.CollectionReferenceChanged += new(secondJournal.CollectionReferenceChanged);

            if (collection.Length == 0)
            {
                Dialog.ColorText("Пустая хеш-таблица успешно создана!", "green");
            }
            else
            {
                Dialog.ColorText($"\nХеш-таблица длиной в {collection.Length} цепочек успешно создана!\n" +
                    $"Чтобы в ней появились элементы, используйте второй пункт предыдущего меню", "green");
            }
            Dialog.BackMessage();
        }

        static void MakeSecondCollection(ref MyNewCollection<Animal> collection,
            ref Journal<Animal> secondJournal) //создание коллекции
        {
            Dialog.PrintHeader($"Создание цепочек {collection.CollectionName}");
            string name = collection.CollectionName;
            collection = new MyNewCollection<Animal>(Dialog.EnterNumber("Введите количество цепочек будущей хеш-таблицы:", 0, 100));
            collection.CollectionName = name;
            //подписка второго журнала на события о изм. элемента ВТОРОЙ коллекции
            collection.CollectionReferenceChanged += new(secondJournal.CollectionReferenceChanged);

            if (collection.Length == 0)
            {
                Dialog.ColorText("Пустая хеш-таблица успешно создана!", "green");
            }
            else
            {
                Dialog.ColorText($"\nХеш-таблица длиной в {collection.Length} цепочек успешно создана!\n" +
                    $"Чтобы в ней появились элементы, используйте второй пункт предыдущего меню", "green");
            }
            Dialog.BackMessage();
        }

        static void CollectionFill(ref MyNewCollection<Animal> collection) //заполнение коллекции
        {
            Dialog.PrintHeader($"Очистка и заполнение {collection.CollectionName}");
            if (collection.Length == 0)
            {
                Dialog.ColorText("Нельзя заполнить хеш-таблицу без цепочек!");
                Dialog.BackMessage();
                return;
            }
            collection.Clear();
            Animal[] values = new Animal[Dialog.EnterNumber("Введите элементов в будущей коллекции:", 0, 500)];
            if (values.Length == 0)
            {
                Dialog.ColorText($"Теперь в коллекции {collection.CollectionName} есть {collection.Length} пустых цепочек!", "green");
                Dialog.BackMessage();
                return;
            }
            for (int i = 0; i < values.Length; i++)
                values[i] = CollectionMethods.GetRandomAnimal();

            collection.AddRange(values);

            Dialog.ColorText($"Теперь {collection.CollectionName} состоит из {collection.Count} элементов!", "green");
            Dialog.BackMessage();
            return;
        }

        static void CollectionPrint(ref MyNewCollection<Animal> collection)    //печать коллекции
        {
            Dialog.PrintHeader($"Печать {collection.CollectionName}");
            if (collection.Length == 0)
            {
                Dialog.ColorText($"В коллекции {collection.CollectionName} нет ни одной цепочки!", "green");
                Dialog.BackMessage();
                return;
            }

            Dialog.ColorText($"{collection.CollectionName} состоит из следующих цепочек:", "green");
            Console.WriteLine(collection);
            Dialog.BackMessage();
        }

        private static void AddElement(ref MyNewCollection<Animal> collection,
            ref Journal<Animal> firstJournal1, ref Journal<Animal> secondJournal)  //добавление элемента
        {
            Dialog.PrintHeader($"Добавление случайного элемента в {collection.CollectionName}");

            if (collection.Length == 0)
            {
                Dialog.ColorText("Нельзя добавить элемент в хеш-таблицу без цепочек!");
                Dialog.BackMessage();
                return;
            }
            var randomAnimal = CollectionMethods.GetRandomAnimal();
            collection.Add(randomAnimal);
            Console.WriteLine($"В {collection.CollectionName} был добавлен новый элемент:");
            randomAnimal.Show();
            Dialog.ColorText($"Теперь количество элементов равно {collection.Count}", "green");
            Dialog.BackMessage();
            return;
        }

        private static void RemoveElement(ref MyNewCollection<Animal> collection)       //удаление элемента
        {
            Dialog.PrintHeader($"Удаление элемента из {collection.CollectionName}");
            if (collection.Count == 0)
            {
                Dialog.ColorText($"В пустой хеш-табоице удалять нечего!!!", "green");
                Dialog.BackMessage();
                return;
            }
            Console.WriteLine("Хеш-таблица имеет следующий вид:");
            Console.WriteLine(collection + "\n");
            Console.WriteLine("Введите ключ элемента, который хотите удалить:");
            var key = new Animal().Init();
            if (!collection.Contains(key)) 
            {
                Console.WriteLine("Такого элемента в коллекции нет!");
                Dialog.BackMessage();
                return;
            }
            collection.Remove(key);

            Dialog.ColorText($"Теперь длина коллекции равна {collection.Count}", "green");
            Dialog.BackMessage();
            return;
        }

        static void ChangeElement(ref MyNewCollection<Animal> collection)   //изменение элемента
        {
            Dialog.PrintHeader($"Изменение элемента в {collection.CollectionName}");

            if (collection.Count == 0)
            {
                Dialog.ColorText("Нельзя изменить что-то в пустой коллекции!");
                Dialog.BackMessage();
                return;
            }
            Console.WriteLine("Хеш-таблица имеет следующий вид:");
            Console.WriteLine(collection + "\n");
            Console.WriteLine("Сначала введите ключ элемента, который хотите изменить");
            Animal key = new Animal().Init();
            if (!collection.Contains(key))
            {
                Dialog.ColorText($"В коллекции нет такого элемента!");
                Dialog.BackMessage();
                return;
            }

            Console.WriteLine("\nТеперь введите данные нового объекта");
            Animal animal = new Animal().Init();

            //чтобы элемент по правилам соответствовал цепочке
            while (animal.GetHashCode() % collection.Length != key.GetHashCode() % collection.Length)
                animal.Name += ")";
            collection[key] = animal;

            Dialog.ColorText($"В коллекции {collection.CollectionName} элемент {key.GetHashCode() % collection.Length + 1} цепочки!\n" +
                $"Распечатайте коллекцию и убедитесь в этом. Имя объекта могло измениться для соответствия структуре таблицы.",
                "green");
            Dialog.BackMessage();
            return;
        }

        static void ChangeCollectionName(ref MyNewCollection<Animal> collection)    //изменение названия коллекции
        {
            Dialog.PrintHeader($"Изменение названия коллекции");
            Console.WriteLine($"Текущее название коллекции - {collection.CollectionName}");
            collection.CollectionName = Dialog.EnterString("Введите новое название:", true);
            Dialog.ColorText("Название коллекции успешно изменено!");
            Dialog.BackMessage();
            return;
        }

        static void ChangeJournalName(ref Journal<Animal> journal)  //изменение названия журнала
        {
            Dialog.PrintHeader($"Изменение названия журнала");
            Console.WriteLine($"Текущее название журнала - {journal.JournalName}");
            journal.JournalName = Dialog.EnterString("Введите новое название:", true);
            Dialog.ColorText("Название коллекции успешно изменено!");
            Dialog.BackMessage();
            return;
        }

        static void ShowJournals(ref Journal<Animal> firstJournal,  //просмотр журналов
            ref Journal<Animal> secondJournal)
        {
            Dialog.PrintHeader($"Просмотр записей в журналах событий");
            if (firstJournal.IsEmpty && secondJournal.IsEmpty)
            {
                Dialog.ColorText("Ни в одном из журналов записей нет!");
                Dialog.BackMessage();
                return;
            }
            Dialog.ColorText("Записи в журналах имеют следующий вид:\n", "green");
            firstJournal.ShowJournal();
            secondJournal.ShowJournal();
            Dialog.BackMessage();
            return;
        }


    }
}