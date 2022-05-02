using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DateTime today = DateTime.Now;

            Console.Write("Please, enter your name: ");
            String name = Console.ReadLine();
            Console.WriteLine($"Привет  {name}, сегодня {today.ToString("D")}");
            Console.ReadLine();
        }
    }
}
