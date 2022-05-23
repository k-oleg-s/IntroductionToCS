﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("введите номер задачи:");
                Console.WriteLine("0 - Выход из приложения");
                Console.WriteLine("1 - элементы двумерного массива по диагонали");
                Console.WriteLine("2 - программа «Телефонный справочник»");
                Console.WriteLine("3 - строка в обратном порядке");
                int task = int.Parse(Console.ReadLine());
                //int task = 1;

                switch (task)
                {
                    case 0: return;
                    case 1: Task1(); break;
                    case 2: Task2(); break;
                    case 3: Task3(); break;
                    default: Console.WriteLine("Задача не выбрана!"); break;
                }
            }

            ////4.«Морской бой»: вывести на экран массив 10х10, состоящий из символов X и O, где Х — элементы кораблей, а О — свободные клетки.
            // Task4();     Не сделано
        }

        /// <summary>
        /// программа, выводящую элементы двумерного массива по диагонали.
        /// </summary>
        static void Task1()
        {
            int dimArr = 4;
            Random rnd= new Random();
            int[,] arr = new int[dimArr,dimArr]; 

            for (int i = 0; i < dimArr; i++)    // Заполним массив случайными числами
            {
                for (int j = 0; j < dimArr; j++)
                {
                    arr[i, j] = rnd.Next(0, 100);
                }
            }

            int counter = 0;

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1);  j++  )
                {
                    for (int k = 0; k < counter; k++) Console.Write("   ");
                    Console.WriteLine( $" {arr[i, j].ToString("000")}  "  ) ;
                    counter++;
                }
            }
        }
        /// <summary>
        /// программа «Телефонный справочник»: двумерный массив 5х2, хранящий список телефонных контактов: первый элемент хранит имя контакта, второй — номер телефона/email
        /// </summary>
        static void Task2()
        {
            string[,] spravochnik = 
            {
                { "Олег", "oleg@a.com"},
                { "Пётр", "peter@a.com"},
                { "Сергей", "serg@a.com"},
                { "Стёпа", "step@a.com"},
                { "Федя", "fedr@a.com"}
             };

            for (int i = 0; i < spravochnik.GetLength(0); i++)
            {
                    Console.WriteLine($" имя:{spravochnik[i,0]} \t e-mail:{spravochnik[i,1]}");
            }
        }
        /// <summary>
        ///  программа, выводящая введённую пользователем строку в обратном порядке
        /// </summary>
        static void Task3()
        {
            Console.WriteLine("введите строку:");
            Console.WriteLine("Обратный текст:");
            string stroka = Console.ReadLine();
            for (int i= stroka.Length-1; i >= 0; i--)
            {
                Console.Write($"{stroka[i]}");
            }
            Console.WriteLine("");
        }
        static void Task4()
        {
            int[,] arr = new int[10,10];
            Random rnd = new Random();

        //static void Task4()
        //{
        //    int[,] arr = new int[10,10];
        //    Random rnd = new Random();

        //    //int[] ship2 = { 3, 2 };
        //    //int[] ship1 = {4,1};


            int xFst_empty = -1;
            int ye = 0;
            int x_empty_space=0;

        //    int xFst_empty = -1;
        //    int ye = 0;
        //    int x_empty_space=0;



            for (int x = 0; x < arr.GetLength(0); x++)
            {
                for (int y = 0; y < arr.GetLength(1); y++)
                {
                    if (arr[x, y] == 0) { x_empty_space++; if (xFst_empty == -1) xFst_empty = x; }
                    if (arr[x, y] != 0) { x_empty_space = 0; xFst_empty = -1; }



            //        }






    }
}
