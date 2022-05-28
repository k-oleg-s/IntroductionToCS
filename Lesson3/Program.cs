using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
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
                    case 1: Task1(); break;
                    case 2: Task2(); break;
                    case 3: Task3(); break;
                    case 4: Task4(); break;
                    default: Console.WriteLine("Задача не выбрана!"); break;
                }
            }
            //do
            //{ Task1(); } while (true);
            //Task4();

        }

        static void Task1()
        {
            GetFullName("Иванов", "Иван", "Иванович");
            GetFullName("Качановская", "Алёна", "Олеговна");
            GetFullName("Качановский", "Олег", "Станиславович");
        }
        static void GetFullName(string firstName, string lastName, string patronymic)
        {            Console.WriteLine($" {lastName} {firstName} {patronymic} ");        }

        static void Task2()
        {
            Console.WriteLine("введите числа через пробел:");
            char[] chars = {' ',',' };
            string input = Console.ReadLine();
            string [] nums = input.Split( chars, StringSplitOptions.RemoveEmptyEntries);
            int sum=0, i_int, add_int;
            foreach ( string i in nums)
            {
                add_int =  int.TryParse(i, out i_int) ? i_int : 0;
                sum = sum + add_int;
            }
            Console.WriteLine($"сумма чисел = {sum}");
        }



        /// <summary>
        ///  метод по определению времени года. На вход подаётся число – порядковый номер
        //        месяца.На выходе — значение из перечисления(enum) — Winter, Spring, Summer,
        //Autumn.Написать метод, принимающий на вход значение из этого перечисления и
        //возвращающий название времени года(зима, весна, лето, осень). Используя эти методы,
        //ввести с клавиатуры номер месяца и вывести название времени года.Если введено
        //некорректное число, вывести в консоль текст «Ошибка: введите число от 1 до 12».
        /// </summary>
        static void Task3()
        {         
            Console.WriteLine("введите номер месяца:");
            string input;
            input = Console.ReadLine();
            if (int.TryParse(input,out int month) && month>0 && month<13)
            {
                Seasons season = getSeasonNum(month);
                Console.WriteLine($" сезон месяца {getSeasonName(season)} ");
            }
            else Console.WriteLine("введите число от 1 до 12");
           
        }
        enum Seasons { Winter, Spring, Summer, Autumn , noSeason};
        enum SeasonsName { Зима, Весна, Лето, Осень };
        static Seasons getSeasonNum(int month)
        {
            Seasons r;
            r = (month == 12 || month < 3) ? Seasons.Winter : 
             (month >= 3 && month < 6) ? Seasons.Spring : 
             (month >= 6 && month < 9) ? Seasons.Summer : 
             (month >= 9 && month < 12) ? Seasons.Autumn : Seasons.noSeason;
            return r;
        }
        static SeasonsName getSeasonName(Seasons seasons)
        {
            return (SeasonsName)seasons;
        }

        static void Task4()
        {
            Console.WriteLine("введите число n последовательности фибоначчи");
            int x = int.Parse(Console.ReadLine());
            Console.WriteLine($" Фибоначчи({x})={getFidonachi(x)} ");
        }

        static int getFidonachi(int x)
        {
            //int f1=0, f2=1;
            int f = 0;

            switch (x)
            { 
            case 0: 
                f = 0; break;
            case 1:
                f = 1; break;
            case 2:
                f = 1; break;
            case 3:
                f = 2; break;
            default: f = getFidonachi(x - 1) + getFidonachi(x - 2); break;
            }

             return f;
            }

        }
}
