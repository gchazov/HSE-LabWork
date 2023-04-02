using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AnimalLibrary
{
    //класс для работы с пользовательским интерфейсом и вводом-выводом
    //класс создан только для упрощения ввода-вывода, не больше
    public class Dialog
    {
        //ввод числа
        public static int EnterNumber(string welcomeString, int left, int right)
        {
            int number = 0;
            bool isParsed = false;
            do
            {
                Console.WriteLine(welcomeString);
                try
                {
                    number = int.Parse(Console.ReadLine());
                    if (number >= left && number <= right)
                    {
                        isParsed = true;
                    }
                    else
                    {
                        ColorText("Вы ввели некорректное значение! Попробуйте ещё раз...");
                    }
                }

                catch (OverflowException)
                {
                    ColorText("Вы ввели слишком большое значение! Попробуйте ещё раз...");
                }

                catch (FormatException)
                {
                    ColorText("Введённое значение имеет неверный формат данных! Попробуйте ещё раз...");
                }

                catch (ArgumentNullException)
                {
                    ColorText("Введённая строка не может быть нулевой! Попробуйте ещё раз...");
                }
            } while (!isParsed);
            return number;
        }
        
        //ввод строки
        public static string EnterString(string welcomeString, bool notEmpty)
        {
            Console.WriteLine(welcomeString);
            string str = "";
            bool isParsed = false;
            do
            {
                bool isNotEmpty = true;
                str = Console.ReadLine();

                if (str == "")
                {
                    isNotEmpty = false;
                }

                if (notEmpty == isNotEmpty )
                {
                    isParsed = true;
                }
                else
                {
                    ColorText("Строка введена некорректно!");
                }
            } while (!isParsed);
            return str;
        }

        //ввод булевой переменной
        public static bool EnterBool(string welcomeString)
        {
            bool result = false;
            bool isParsed = false;
            do
            {
                Console.WriteLine(welcomeString);
                string buf = Console.ReadLine();
                isParsed = bool.TryParse(buf, out result);
                if (!isParsed)
                {
                    switch (buf.ToLower())
                    {
                        case "да":
                            result = true;
                            isParsed = true;
                            break;
                        case "нет":
                            result = false;
                            isParsed = true;
                            break;
                        case "yes":
                            result = true;
                            isParsed = true;
                            break;
                        case "no":
                            result = false;
                            isParsed = true;
                            break;
                        default:
                            ColorText("Введённое значение не является логическим! Попробуйте ещё раз...");
                            break;

                    }
                }
            } while (!isParsed);
            return result;
        }

        //для красивого заголовка
        public static string PrintSpace(int amount)
        {
            string str = "";
            for (int i = 0; i < amount; i++)
            {
                str += " ";
            }
            return str;
        }

        //печать красивого заголовка
        public static void PrintHeader(string header)
        {
            Console.Clear();
            ColorText("__________/" + header.ToUpper() + @"\__________" + "\n", "cyan");
        }

        //печать цветного текста
        public static void ColorText(string text, string colorizing = "red")
        {
            string color = colorizing.ToLower();
            switch (color)
            {
                case "red":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case "black":
                    Console.ForegroundColor = ConsoleColor.Black;
                    break;
                case "cyan":
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case "green":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "yellow":
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
            }
            Console.WriteLine(text);
            Console.ResetColor();
        }

        //сообщение о возвращении в меню
        public static void BackMessage()
        {
            Console.WriteLine("\nНажмите Enter для возвращения в предыдущее меню...");
            Console.ReadLine();
            Console.Clear();
        }



    }
}
