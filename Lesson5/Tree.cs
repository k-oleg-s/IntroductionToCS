using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5
{
    internal class Tree
    {
        string fileResult;
        public Tree()
        {
            DirectoryInfo directoryInfoResult = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            fileResult = directoryInfoResult.FullName + "tree.txt";
            File.WriteAllText(fileResult, "----------------------------");
        }

        public void PrintDir(DirectoryInfo directoryInfo, string indent, bool lastDirectory)
        {
            File.AppendAllText(fileResult, indent);
            File.AppendAllText(fileResult, lastDirectory ? "└─" : "├─");
            indent += lastDirectory ? " " : "│ ";
            File.AppendAllText(fileResult, directoryInfo.Name+"\n");

            // TODO: Распечать наименования всех файлов
            FileInfo[] subFiles = directoryInfo.GetFiles();
            foreach(FileInfo subFile in subFiles)
            {
            File.AppendAllText(fileResult, indent + " file: " + subFile.Name + "\n");
            }

            DirectoryInfo[] subDirs = directoryInfo.GetDirectories();

            for (int i = 0; i < subDirs.Length; i++)
            {
                PrintDir(subDirs[i], indent, i == subDirs.Length - 1);
            }
        }


    }
}
