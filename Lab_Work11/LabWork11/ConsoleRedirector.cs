using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork11
{
    //Класс для тестирования вывода на консоль
    public class ConsoleRedirector
    {
        private StringWriter consoleOutput = new StringWriter();
        private TextWriter originalConsoleOutput;
        public ConsoleRedirector()
        {
            this.originalConsoleOutput = Console.Out;
            Console.SetOut(consoleOutput);
        }

        //переопределение метода ToString
        public override string ToString()
        {
            return this.consoleOutput.ToString();
        }
    }
}
