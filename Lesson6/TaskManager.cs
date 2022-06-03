﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6
{
    internal class TaskManager    
    {        
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

        public void show(Process process)
        {Console.WriteLine($" id={process.Id}, name={process.ProcessName}, start info={process.StartInfo.FileName}" + 
                            $", {process.StartInfo.UserName} , {process.StartInfo.WorkingDirectory}");
        }

        public void kill(int id)
        {
            Process process = Process.GetProcessById(id);
            Console.Write("process  ");
            show(process);
            Console.WriteLine("has been killed");
            process.Kill();
        }


    }
}
