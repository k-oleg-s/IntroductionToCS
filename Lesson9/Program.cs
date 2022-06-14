using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileManager fileManager = new FileManager();
            fileManager.UpdateConsole();

            Console.ReadLine();
        }
    }
}
