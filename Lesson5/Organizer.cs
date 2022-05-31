using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lesson5
{
    internal class Organizer
    {
        string fileName;

        public Organizer(string fileName)
        {
            this.fileName = fileName;
        }

        public ToDo[] LoadTasksFromXml()
        {
            //BinaryFormatter
            //JsonSerializer
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ToDo[]));
            FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            ToDo[] tasks = (ToDo[])xmlSerializer.Deserialize(fileStream);
            fileStream.Close();
            PrintTasks(tasks);
            return tasks;
        }

        public void SaveTasksToXml( ToDo[] tasks)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ToDo[]));
            FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            xmlSerializer.Serialize(fileStream, tasks);
            fileStream.Close();
        }

        public void PrintTasks(ToDo[] tasks)
        {
            for (int i= 0; i < tasks.Length; i++)
            {
                Console.WriteLine(  i + "  " + (tasks[i].isDone?"[x]  ":"[]  ")  + tasks[i].Title);
            }

            Console.WriteLine(" введите номер выполненной задачи:");
            tasks[int.Parse(Console.ReadLine())].isDone = true;
            SaveTasksToXml(tasks);
        }


    }
}
