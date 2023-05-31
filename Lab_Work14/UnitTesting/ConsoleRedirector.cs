using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTesting
{
    //Класс для тестирования вывода на консоль
    public class ConsoleRedirector
    {
        private StringWriter _consoleOutput = new StringWriter();
        private TextWriter _originalConsoleOutput;
        public ConsoleRedirector()
        {
            this._originalConsoleOutput = Console.Out;
            Console.SetOut(_consoleOutput);
        }

        public override string ToString()
        {
            return this._consoleOutput.ToString();
        }
    }
}