using AnimalLibrary;
using ConsoleTools;
using MyCollections;
using Functionality;


namespace LabWork14
{
    //ЛАБОРАТОРНАЯ РАБОТА 14
    internal class Program
    {
        static void Main(string[] args)
        {
            //инициализация коллекций по умолчанию

            Dictionary<string, Queue<Animal>> animalSections = new();
            Queue<Animal> sectionA = new();
            Queue<Animal> sectionB = new();
            Queue<Animal> sectionC = new();

            animalSections.Add("Секция A", sectionA);
            animalSections.Add("Секция B", sectionB);
            animalSections.Add("Секция C", sectionC);

            MyCollection<Animal> animals = new();

            Run(ref animalSections, ref animals);
        }

        static void Run(ref Dictionary<string, Queue<Animal>> animalSections,
            ref MyCollection<Animal> animals)
        {
            var mainMenuRun = true;
            do
            {
                switch (MainMenu())
                {
                    case 0:
                        var firstPartMenuRun = true;
                        do
                        {
                            switch (FirstPartMenu())
                            {
                                case 0:
                                    break;
                                case 1:
                                    break;
                                case 2:
                                    break;
                                case 3:
                                    break;
                                case 4:
                                    break;
                                case 5:
                                    break;
                                case 6:
                                    break;
                                case 7:
                                    firstPartMenuRun = false;
                                    break;


                            }
                        } while (firstPartMenuRun);
                        break;
                    case 1:
                        var secondPartMenu = true;
                        do
                        {
                            switch (SecondPartMenu())
                            {
                                case 0:
                                    break;
                                case 1:
                                    break;
                                case 2:
                                    break;
                                case 3:
                                    break;
                                case 4:
                                    break;
                                case 5:
                                    break;
                                case 6:
                                    break;
                                case 7:
                                    secondPartMenu = false;
                                    break;


                            }
                        } while (secondPartMenu);
                        break;
                    case 2:
                        mainMenuRun = false;
                        break;
                }
            }while (mainMenuRun);
            Dialog.PrintHeader(@"
   ______                __   __               __
  / ____/___  ____  ____/ /  / /_  __  _____  / /
 / / __/ __ \/ __ \/ __  /  / __ \/ / / / _ \/ / 
/ /_/ / /_/ / /_/ / /_/ /  / /_/ / /_/ /  __/_/  
\____/\____/\____/\__,_/  /_.___/\__, /\___(_)   
                                /____/           
");
        }

        static int MainMenu()
        {
            string[] options = { "Часть 1 (Словарь очередей)", "Часть 2 (Хеш-таблица)", "Завершение работы"};
            Menu mainMenu = new(@"
        __          __       _       __           __      _____ __
       / /   ____ _/ /_     | |     / /___  _____/ /__   <  / // /
      / /   / __ `/ __ \    | | /| / / __ \/ ___/ //_/   / / // /_
     / /___/ /_/ / /_/ /    | |/ |/ / /_/ / /  / ,<     / /__  __/
    /_____/\__,_/_.___/     |__/|__/\____/_/  /_/|_|   /_/  /_/   
                                                              
                                                      
    Здравствуй, уважаемый Пользователь!
    Данная программа предназначена для работы с коллекциями и запросами LINQ к ним. 
    В коллекциях могут храниться только объекты иерархии Animal, имейте в виду.

    Для навигации используйте клавиши стрелок вверх и вниз, а также клавишу Enter для ввода.
    Приятнонго пользования!
", options);
            return mainMenu.Run();
        }

        static int FirstPartMenu()
        {
            string[] options = { "Заполнение очередей случайными объектами",
                "Печать секций объектов", "Животные, старше заданного значения",
                    "Количество животных, родом с заданного континента",
                    "Средний возраст животных заданнного вида",
                    "Одинаковые животные в секциях зоопарка",
                    "Группировка животных по ареалам обитания", "Назад"};
            Menu menu = new("Часть 1 (Словарь очередей)", options);
            return menu.Run();
        }

        static int SecondPartMenu()
        {
            string[] options = { "Заполнение коллекции случаными объектами",
                "Печать коллекции", "Животные, старше заданного значения",
                    "Количество животных, родом с заданного континента",
                    "Средний возраст животных заданнного вида",
                    "Одинаковые животные в секциях зоопарка",
                    "Группировка животных по ареалам обитания", "Назад"};
            Menu menu = new("Часть 1 (Хеш-таблица)", options);
            return menu.Run();
        }

    }
}