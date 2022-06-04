using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6
{
    internal class TaskManager    
    {   
        /// <summary>
        /// без аргументов - показывает все процессы, сделал фильтр на прогу chrom
        /// </summary>
        public void show()
        {
            Process[] processes = Process.GetProcesses();
            foreach (Process process in processes)
            {
                if (process.ProcessName.IndexOf("chrom") > -1)
                    //Console.WriteLine($" id={process.Id}, name={process.ProcessName}, start info={process.StartInfo.FileName}" +
                    //    $", {process.StartInfo.UserName} , {process.StartInfo.WorkingDirectory}");
                    show(process);
            }
        }
        /// <summary>
        /// показывает инфо одного процесса
        /// </summary>
        /// <param name="process"></param>
        public void show(Process process)
        {Console.WriteLine($" id={process.Id}, name={process.ProcessName}, start info={process.StartInfo.FileName}" + 
                            $", {process.StartInfo.UserName} , {process.StartInfo.WorkingDirectory}");
        }
        /// <summary>
        /// kill через номер процесса
        /// </summary>
        /// <param name="id"></param>
        public void kill(int id)
        {
            Process process = Process.GetProcessById(id);
            Console.Write("process  ");
            show(process);
            Console.WriteLine("has been killed");
            process.Kill();
        }
        /// <summary>
        /// kill через имя процесса
        /// </summary>
        /// <param name="name"></param>
        public void kill(string  name)
        {
            Process[] processes = Process.GetProcessesByName(name);
            foreach (Process process in processes)
            {
                Console.Write("process  ");
                show(process);
                Console.WriteLine("has been killed");
                process.Kill();
            }
        }


    }
}
