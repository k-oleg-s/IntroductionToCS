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
                tm.show();
                Console.WriteLine("введите id процесса для завершения:");
                int id = int.Parse(Console.ReadLine());
                tm.kill(id);                
        }
    }
}
