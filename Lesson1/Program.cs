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
 Start:           
            Console.WriteLine("введите номер задачи:");
            Console.WriteLine("0 - Выход из приложения");
            Console.WriteLine("1 - задание 1");
            Console.WriteLine("2 - задание 2");
            Console.WriteLine("3 - задание 3");
            Console.WriteLine("4 - задание 4");
            Console.WriteLine("5 - задание 5");
            Console.WriteLine("6 - задание 6");
            int task = int.Parse(Console.ReadLine());
            //int task = 1;

            switch (task)
            {
                case 0: return;
                case 1: Console.WriteLine($"средняя температура {Task1()} ");  break;
                case 2: Console.WriteLine($"текущий месяц {Task2()}"); ; break;
                case 3: Task3(); break;
                case 4: Task4("Лента", 199, DateTime.Now); break;
                case 5: Task5(); break;
                case 6: Task6(0b_01101101); break;
                default: Console.WriteLine("Задача не выбрана!"); break;
            }
            //Console.ReadLine();
            goto Start;
        }

        /// <summary>
        /// Задание 1 - подсчет среднесуточной температуры
        /// </summary>
        /// <returns>среднесуточная температура</returns>
        static double  Task1()
        {
            Console.WriteLine("введите минимальную температуру дня");
            double minT = Double.Parse(Console.ReadLine());
            Console.WriteLine("введите максимальную температуру дня");
            double maxT = Double.Parse(Console.ReadLine());
            return (maxT + minT) / 2;
        }

        /// <summary>
        /// Задание 2 - порядковый номер текущего месяца и вывести его название.
        /// </summary>
        /// <returns>название месяца</returns>
        static string Task2()
        {
            Console.WriteLine("введите порядковый номер текущего месяца:");
            int i= int.Parse(Console.ReadLine());
            string month;
            switch(i)
            {
                case 1: month = "Январь"; break;
                case 2: month = "Февраль"; break;
                case 3: month = "Март"; break;
                case 4: month = "Апрель"; break;
                case 5: month = "Май"; break;
                case 6: month = "Июнь"; break;
                case 7: month = "Июль"; break;
                case 8: month = "Август"; break;
                case 9: month = "Сентябрь"; break;
                case 10: month = "Октябрь"; break;
                case 11: month = "Ноябрь"; break;
                case 12: month = "Декабрь"; break;
                default: month = "неопределён"; break;
            }
            return month;
        }

        /// <summary>
        /// Задание 3 - Определить, является ли введённое пользователем число чётным.
        /// </summary>
        static void Task3()
        {
            Console.WriteLine("введите целое число");
            int i = int.Parse(Console.ReadLine());
            if (i % 2 == 0)  Console.WriteLine("число четное"); 
            else Console.WriteLine("число нечётное");
        }
        /// <summary>
        /// Задание 4 - Чек из магазина - на входе параметры чека
        /// </summary>
        /// <param name="shop"></param>
        /// <param name="sum"></param>
        /// <param name="day"></param>
        static void Task4(string shop, int sum, DateTime day)
        {
            Console.WriteLine("----------------------CHECK--------------------");
            Console.WriteLine($"-- магазин: {shop}-------------------");
            Console.WriteLine($"-- сумма: {sum}  руб--------------------------");
            Console.WriteLine($"-- дата покупки: {day.ToString("F")}----------");
            Console.WriteLine($"----------------------------------------------");

        }

        /// <summary>
        /// Задание 5 -  если месяц из зимнего периода, а средняя температура > 0, вывести сообщение «Дождливая зима».
        /// </summary>
        static void Task5()
        {
            double avg = Task1();
            string mnth=Task2();
            if ((mnth == "Декабрь" || mnth == "Январь" || mnth == "Февраль") && (avg > 0))
            { Console.WriteLine("Дождливая зима"); }
            else Console.WriteLine("Холодная зима");
        }
        enum weekDays { Monday = 0b_01000000, Tuesday = 0b_00100000, Wednesday = 0b_00010000, Thirthday = 0b_00001000, Friday = 0b_00000100, Satuday = 0b_00000010, Sunday = 0b_00000001 }
        
        /// <summary>
        /// Задание 6 - параметр - битовая маска расписания, выводятся дни недели где в маске 1
        /// </summary>
        /// <param name="office"></param>
        static void Task6(int office)
        {
            string workingDays = "";

            if (((int)weekDays.Monday & office) == (int)weekDays.Monday) workingDays += weekDays.Monday + " ";  // так даже понятней что происходит
            if ((weekDays.Tuesday & (weekDays)office) == weekDays.Tuesday) workingDays += weekDays.Tuesday + " "; // видимо неявно прошло преобразование в int, а потом побитная операция
            if ((weekDays.Wednesday & (weekDays)office) == weekDays.Wednesday) workingDays += weekDays.Wednesday + " ";
            if ((weekDays.Thirthday & (weekDays)office) == weekDays.Thirthday) workingDays += weekDays.Thirthday + " ";
            if ((weekDays.Friday & (weekDays)office) == weekDays.Friday) workingDays += weekDays.Friday+" ";
            if ((weekDays.Satuday & (weekDays)office) == weekDays.Satuday) workingDays = workingDays + weekDays.Satuday + " ";
            if ((weekDays.Sunday & (weekDays)office) == weekDays.Sunday) workingDays = workingDays + weekDays.Sunday + " ";

            Console.WriteLine($"офис с маской {Convert.ToString(office, 2)} работает в {workingDays}");
        }
    }
}
