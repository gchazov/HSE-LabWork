using AnimalLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace LabWork11
{
    //класс для реализации второй части работы
    //по структуре методов +- такой же, как и для первой части
    public class SecondPart
    {
        public const int MAX_CAPACITY = 100; //макс.ёмкость словаря

        //печать основного меню второй части работы
        public static void SPMainPage() //здесь и далее: SP - сокращение Second Part
        {
            Console.WriteLine("\n1. Сформировать словарь из случайных объектов\n" +
                "2. Вывести содержимое словаря на экран\n" +
                "3. Добавить случайные объекты в словарь\n" +
                "4. Удаление объекта из словаря по ключу\n" +
                "5. Запросы объектов определённого типа\n" +
                "6. Самое молодое животное в словаре\n" +
                "7. Найти объект в словаре по ключу\n" +
                "8. Выполнить клонирование словаря\n" +
                "9. Очистить словарь\n\n" +
                "10. Вернуться в главное меню\n");

        }

        //главное меню первой части работы
        public static void SPMenu(ref SortedDictionary<int, Animal> animalDict)
        {
            bool isRunning = true;
            do
            {
                Dialog.PrintHeader("Вторая часть работы (словарь)");

                //максимальная ёмкость словаря - константа MAX_CAPACITY
                Console.WriteLine($"Максимальная вместительность словаря - {MAX_CAPACITY}");
                ElementCounter(animalDict.Count, "Уровень заполнения словаря: ", $"/{MAX_CAPACITY}");
                Console.WriteLine();

                SPMainPage(); //печать основного меню второй части
                int choice = Dialog.EnterNumber("Выберите пункт меню:", 1, 10);

                Console.WriteLine();
                switch (choice)
                {
                    case 1:
                        MakeDictRandom(ref animalDict);
                        break;
                    case 2:
                        PrintDict(animalDict);
                        break;
                    case 3:
                        AddElements(ref animalDict);
                        break;
                    case 4:
                        DeleteElement(ref animalDict);
                        break;
                    case 5:
                        TypeRequests(animalDict);
                        break;
                    case 6:
                        YoungestRequest(animalDict);
                        break;
                    case 7:
                        FindKeyObject(animalDict);
                        break;
                    case 8:
                        CloneDict(animalDict);
                        break;
                    case 9:
                        ClearDict(ref animalDict);
                        break;
                    case 10: //выход в самое первое меню
                        isRunning = false;
                        break;

                }
            } while (isRunning);
            return;
        }

        //цветовая индикация заполненности словаря
        //к сожалению, в си шарпе нельзя юзать константы в параметрах,
        //а кейсы требуют постоянного значения, поэтому пишем метод заново
        public static void ElementCounter(int count, string startMessage, string endMessage)
        {
            Console.Write(startMessage);
            switch (count)
            {
                case <= MAX_CAPACITY / 2: //словарь заполнен на менее, чем 50 процентов
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case <= MAX_CAPACITY / 4 * 3: //словарь заполнен на 51-75 процентов
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case <= MAX_CAPACITY: //словарь заполнен на 76-100 процентов
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
            }
            Console.Write($"{count}" + endMessage);
            Console.ResetColor();
        }

        //создание словаря из элементов коллекции с помощью ДСЧ
        public static void MakeDictRandom(ref SortedDictionary<int, Animal> animalDict)
        {
            Dialog.PrintHeader("Создание словаря с помощью ДСЧ");

            int length = Dialog.EnterNumber("Введите размер словаря:", 0, MAX_CAPACITY);

            if (length == 0)
            {
                Dialog.ColorText("\nПустой словарь успешно создан", "green");
                Dialog.BackMessage();
                return;
            }

            //словарь очищен (если в нём были элементы)
            SPMethods.ClearDict(ref animalDict);

            //заполнение элементами словарь
            SPMethods.AddRandomToDict(ref animalDict, length);
            Dialog.ColorText($"\nСловарь случайных объектов успешно создан," +
                $" его длина - {length}", "green");
            Dialog.BackMessage();
            return;
        }

        //метод вывода объектов словаря на печать
        public static void PrintDict(SortedDictionary<int, Animal> animalDict)
        {
            Dialog.PrintHeader("Вывод содержимого словаря на печать");

            if (animalDict.Count == 0)
            {
                Dialog.ColorText("На данный момент словарь абсолютно пуст", "green");
                Dialog.BackMessage();
                return;
            }

            int elementNumber = 0;
            foreach(KeyValuePair<int, Animal> animal in animalDict)
            {
                elementNumber++;
                ElementCounter(elementNumber, $"Объект словаря № ", "");
                Console.Write(":\n\t");
                Console.Write($"Ключ: {animal.Key} - ");
                animal.Value.Show();
            }
            Dialog.BackMessage();
            return;
        }

        //метод удаления объекта из словаря
        public static void DeleteElement(ref SortedDictionary<int, Animal> animalDict)
        {
            Dialog.PrintHeader("Удаление объекта");
            if (animalDict.Count == 0)
            {
                Dialog.ColorText("В пустом словаре удалять нечего." +
                    " Как только он обзаведётся объектами, обязательно приходите!");
                Dialog.BackMessage();
                return;
            }
            int key = Dialog.EnterNumber("Введите ключ удаляемого объекта:", 1, 5000);
            var animal = new Animal();
            Console.WriteLine();
            try
            {
                animal = animalDict[key];
                animalDict.Remove(key);
                Dialog.ColorText($"Из словаря удалён объект с ключом {key}:", "green");
                animal.Show();

            }
            catch (KeyNotFoundException)
            {
                Dialog.ColorText("В словаре нет объекта, соответствующего заданному ключу");
            }
            Dialog.BackMessage();
            return;

        }

        //метод добавления объектов в словарь
        public static void AddElements(ref SortedDictionary<int, Animal> animalDict)
        {
            Dialog.PrintHeader("Добавление случайных пар объектов в словарь");
            ElementCounter(animalDict.Count, "Учтите, что словарь заполнена на ", $"/{MAX_CAPACITY}\n");
            Console.WriteLine("Если словарь заполнен на 100%, укажите значение 0\n");

            int elementAmount = Dialog.EnterNumber("Введите количество добавляемых объектов:", 0, MAX_CAPACITY - animalDict.Count);
            switch (elementAmount)
            {
                case 0:
                    Dialog.ColorText("Словарь остался прежним, элементов не прибавилось", "green");
                    break;
                default:
                    SPMethods.AddRandomToDict(ref animalDict, elementAmount);
                    Dialog.ColorText($"Словарь пополнился на {elementAmount} элемент(-ов)", "green");
                    Console.WriteLine("Для просмотра изменений, выведите словарь на экран (пункт 2)");
                    break;
            }
            Dialog.BackMessage();
            return;
        }

        //запрос на объекты определённого типа
        public static void TypeRequests(SortedDictionary<int, Animal> animalDict)
        {
            Dialog.PrintHeader("Объекты определённого типа");

            if (animalDict.Count == 0)
            {
                Dialog.ColorText("Для пустой очереди операция недоступна");
                Dialog.BackMessage();
                return;
            }

            bool isRunning = true;
            do
            {
                Dialog.PrintHeader("Объекты определённого типа");
                Console.WriteLine("1. Млекопитающие (Mammal)\n" +
                    "2. Птицы (Bird)\n" +
                    "3. Парнокопытные (Artiodactyl)\n\n" +
                    "4. Назад\n");
                int choice = Dialog.EnterNumber("Выберите один из типов:", 1, 4);

                if (choice == 4)
                {
                    //выход из меню
                    isRunning = false;
                    break;
                }

                Dialog.PrintHeader("Объекты определённого типа");
                List<Animal> res = SPMethods.GetTypeRequest(choice, animalDict);
                switch (res.Count)
                {
                    case 0:
                        Console.WriteLine("В словаре нет объектов выбранного типа");
                        break;
                    default:
                        Dialog.ColorText($"В словаре найден(-о) {res.Count} подходящий(-их) элемент(-ов):\n", "green");
                        foreach (Animal animal in res) //перебор в списке
                        {
                            Console.Write($"Ключ: {animal.id.number} - ");
                            animal.Show();
                        }
                        break;
                }
                Dialog.BackMessage();
            } while (isRunning);
            return;
        }

        //самое младшее животное словаря
        public static void YoungestRequest(SortedDictionary<int, Animal> animalDict)
        {
            Dialog.PrintHeader("самое молодое животное");

            if (animalDict.Count == 0)
            {
                Dialog.ColorText("Для пустого словаря операция недоступна");
                Dialog.BackMessage();
                return;
            }

            Dialog.PrintHeader("самое молодое животное");
            Animal animal = SPMethods.YoungestAnimal(animalDict);
            Console.WriteLine("Самое молодое животное словаря:\n");
            animal.Show();
            Dialog.BackMessage();
            return;
        }

        //поиск элемента по ключу
        public static void FindKeyObject(SortedDictionary<int, Animal> animalDict)
        {
            Dialog.PrintHeader("поиск объекта по ключу");
            if (animalDict.Count == 0)
            {
                Dialog.ColorText("Для пустого словаря операция недоступна");
                Dialog.BackMessage();
                return;
            }

            Dialog.PrintHeader("поиск объекта по ключу");
            int key = Dialog.EnterNumber("Введите ключ искомого объекта:", 1, 5000);
            var animal = new Animal();
            Console.WriteLine();
            try
            {
                animal = animalDict[key];
                Dialog.ColorText($"Найден объект с ключом {key}:", "green");
                animal.Show();

            }
            catch (KeyNotFoundException)
            {
                Dialog.ColorText("В словаре нет объекта, соответствующего заданному ключу");
            }
            Dialog.BackMessage();
            return;
        }

        //создание клона словаря и демонстрация работы
        public static void CloneDict(SortedDictionary<int, Animal> animalDict)
        {
            Dialog.PrintHeader("клонирование очереди");
            if (animalDict.Count == 0)
            { //проверка на пустоту словаря
                Dialog.ColorText("Для пустой очереди операция недоступна");
                Dialog.BackMessage();
                return;
            }

            if (animalDict.Count == 100)
            {
                //проверка на макс заполненность словаря
                Dialog.ColorText("Клонирование проверить не получится! Необходимо, чтобы в очереди был" +
                    "хотя бы одно свободное место под элемент");
                Dialog.BackMessage();
                return;
            }

            //глубокое копирование исходной очереди
            SortedDictionary<int, Animal> clone = SPMethods.CloneDict(animalDict);
            Dialog.ColorText("Словарь-клон успешно создан", "green");
            Console.WriteLine("Для демонстрации работы клонирования, добавим элемент в исходный словарь");

            Console.WriteLine("Нажмите Enter, чтобы продолжить...");
            Console.ReadLine();

            SPMethods.AddRandomToDict(ref animalDict, 1);
            Dialog.ColorText("\nЭлемент успешно добавлен\n", "yellow");

            //вывод словарей и их сравнение
            Console.WriteLine("Сравним словари");
            Dialog.ColorText("\nИсходная очередь\n", "green");
            foreach (KeyValuePair<int, Animal> animal in animalDict)
            {
                Console.Write($"Ключ: {animal.Key} - ");
                animal.Value.Show();
            }

            //вывод словаря-клона
            Dialog.ColorText("\nСловарь-клон\n", "red");
            foreach (KeyValuePair<int, Animal> animal in clone)
            {
                Console.Write($"Ключ: {animal.Key} - ");
                animal.Value.Show();
            }
            Dialog.BackMessage();
            return;
        }

        //вызов метода по очистке словаря
        public static void ClearDict(ref SortedDictionary<int, Animal> animalDict)
        {
            Dialog.PrintHeader("Очистка словаря");

            switch (animalDict.Count)
            {
                case 0: //случай, если словарь изначально пуста
                    Dialog.ColorText("Словарь уже пуст, изменений не произошло", "green");
                    break;
                default:
                    SPMethods.ClearDict(ref animalDict);
                    Dialog.ColorText("Словарь успешно очищен, все его объекты удалены", "green");
                    break;
            }
            Dialog.BackMessage();
            return;
        }
    }
}
