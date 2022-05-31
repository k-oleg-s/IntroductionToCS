using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lesson5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (false)
            {
                Console.WriteLine();
                Console.WriteLine("введите номер задачи:");
                Console.WriteLine("0 - Выход из приложения");
                Console.WriteLine("1 - вывод ФИО через GetFullName метод");
                Console.WriteLine("2 - сумма чисел в строке");
                Console.WriteLine("3 - время года по номеру месяца");
                Console.WriteLine("4 - число Фибоначи");
                int task = int.Parse(Console.ReadLine());
                //int task = 1;

                switch (task)
                {
                    case 0: return;
                    //case 1: Task1(); break;
                    //case 2: Task2(); break;
                    //case 3: Task3(); break;
                    //case 4: Task4(); break;
                    default: Console.WriteLine("Задача не выбрана!"); break;
                }
            };

            Task5();
        }

        static void Task1()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            File.WriteAllText(directoryInfo.FullName+"my_input.txt", Console.ReadLine());
        }
        static void Task2()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            DateTime dt = DateTime.Now;
            //Console.WriteLine($" {dt.ToShortTimeString()}");
            File.AppendAllText(directoryInfo.FullName + "startup.txt", " current time "+dt.ToShortTimeString()+" ");
        }
        static void Task3()
        {
            Console.WriteLine("введите числа через пробел:");
            char[] chars = { ' ', ',' };
            string input = Console.ReadLine();
            string[] nums = input.Split(chars, StringSplitOptions.RemoveEmptyEntries);
            byte[] i_int = new byte[nums.Length];
            byte i_int_out;

            for (int i=0; i < nums.Length; i++)
            {
                i_int[i] = (byte)(byte.TryParse(nums[i], out i_int_out) ? i_int_out : 0);
            }

            DirectoryInfo directoryInfo = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            File.WriteAllBytes(directoryInfo + "numbers_in_binary_format.bin", i_int);
            // checks
            i_int[0] = 44;
            i_int = File.ReadAllBytes(directoryInfo + "numbers_in_binary_format.bin"); 
        }
        static void Task4()
        {
            string directory = @"C:\Users\koleg\OneDrive\GeekBrains\VisualStudioRepo\IntroductionToC\Lesson5\";
            Tree tree = new Tree();
            tree.PrintDir(new DirectoryInfo(directory), "~", false);
        }
        static void Task5()
        {
            
            DirectoryInfo directoryInfo = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            string file = @"C:\T\" + "tasks.xml";
            Console.WriteLine(file);

            ToDo[] tasks=new ToDo[4];
            tasks[0] = new ToDo("task1", false);
            tasks[1] = new ToDo("task2", true);
            tasks[2] = new ToDo("task3", false);
            tasks[3] = new ToDo("task4", true);
            Organizer organizer=new Organizer(file);

            organizer.SaveTasksToXml(tasks);
            organizer.LoadTasksFromXml();
        }
    }
}
