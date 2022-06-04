using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TaskManager tm = new TaskManager();

            //while (true)
            //{
                tm.show();
                Console.WriteLine("введите id или имя процесса для завершения:");
                string input = Console.ReadLine();
                //bool is_int = (int.TryParse/*(*/input, out int id));

                if (int.TryParse(input, out int id))
                {
                    tm.kill(id);
                }
                else tm.kill(input);
            //}
        }
    }
}
