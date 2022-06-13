using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lesson8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Создать консольное приложение, которое при старте выводит приветствие, записанное в настройках
            //приложения(application - scope).Запросить у пользователя имя, возраст и род деятельности, а затем
            //сохранить данные в настройках.При следующем запуске отобразить эти сведения. Задать
            //приложению версию и описание.

            Console.WriteLine("1 - Показать данные пользователя ");
            Console.WriteLine("2 - Ввести данные пользователя ");

            int menu;
            if (int.TryParse(Console.ReadLine(), out menu) )
            {   switch (menu)
                {
                    case 1: ShowData(); break;
                    case 2: ReadData(); break;
                    default: Console.WriteLine("неверный номер меню");break;                        
                }           
            }
            Console.ReadLine();
        }

        static void ShowData()
        {
            Console.Write("Ваши данные: ");
            Console.WriteLine($" Имя: {Properties.Settings.Default.Name}  Возраст: {Properties.Settings.Default.Age}  Род деятельности: {Properties.Settings.Default.JobType} ");
        }

        static void ReadData()
        {
            Console.WriteLine("Введите имя");
            Properties.Settings.Default.Name = Console.ReadLine();

            Console.WriteLine("Введите возраст ");
            Properties.Settings.Default.Age = int.Parse(Console.ReadLine());

            Console.WriteLine("Введите род деятельности");
            Properties.Settings.Default.JobType = Console.ReadLine();

            Properties.Settings.Default.Save();
        }

    }
}
