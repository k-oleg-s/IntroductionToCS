using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Lesson2Task1(); 
            Lesson2Task1();
            Lesson2Task1();
            Lesson2Task1();
            Lesson2Task1();
            Lesson2Task1();
        }


        static void Lesson2Task1()
        {
            Console.WriteLine("введите минимальную температуру дня");

        }

        static void Lesson2Task2()
        {
            Console.WriteLine("введите минимальную температуру дня");
            double minT = Double.Parse(Console.ReadLine());
            Console.WriteLine("введите максимальную температуру дня");
            double maxT = Double.Parse(Console.ReadLine());
            Console.WriteLine($"средняя температура {(maxT + minT) / 2} ");

        }
        static void Lesson2Task3()
        {
            Console.WriteLine("введите минимальную температуру дня");

        }
        static void Lesson2Task4()
        {
            Console.WriteLine("введите минимальную температуру дня");

        }
        static void Lesson2Task5()
        {
            Console.WriteLine("введите минимальную температуру дня");

        }
        static void Lesson2Task6()
        {
            Console.WriteLine("введите минимальную температуру дня");

        }
        void Lesson1()
        {
            DateTime today = DateTime.Now;

            Console.Write("Please, enter your name: ");
            String name = Console.ReadLine();
            Console.WriteLine($"Привет  {name}, сегодня {today.ToString("D")}");
            Console.ReadLine();
        }
    }
}
