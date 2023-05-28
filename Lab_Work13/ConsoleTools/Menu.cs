using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleTools
{
    public class Menu
    {
        private int selectIndex;
        private string[]? Options { get; set; }
        private string? Prompt { get; set; }

        public int SelectIndex //свойство для кругового меню
        {
            get { return selectIndex; }
            set
            {
                if (value < 0) selectIndex = Options.Length - 1;
                else if (value > Options.Length - 1) selectIndex = 0;
                else selectIndex = value;
            }
        }

        public Menu(string prompt, string[] options)
        {
            Prompt = prompt;
            Options = options;
            SelectIndex = 0;
        }

        private void DisplayOptions()
        {
            Dialog.PrintHeader(Prompt);
            for (int i = 0; i < Options.Length; ++i)
            {
                if (i == SelectIndex)
                {
                    ForegroundColor = ConsoleColor.Black;
                    BackgroundColor = ConsoleColor.White;
                    WriteLine($">> {Options[i]} <<");
                }
                else
                {
                    ForegroundColor = ConsoleColor.White;
                    BackgroundColor = ConsoleColor.Black;
                    WriteLine($"   {Options[i]}   ");
                }

            }
            ResetColor();
        }

        public int Run()
        {
            ConsoleKey keyPressed;
            do
            {
                DisplayOptions();
                ConsoleKeyInfo keyInfo = ReadKey(true);
                keyPressed = keyInfo.Key;
                //обновление SelectedIndex
                switch (keyPressed)
                {
                    case ConsoleKey.UpArrow:
                        SelectIndex--;
                        break;
                    case ConsoleKey.DownArrow:
                        SelectIndex++;
                        break;
                }
            }while(keyPressed != ConsoleKey.Enter);
            return SelectIndex;
        }
    }
}
