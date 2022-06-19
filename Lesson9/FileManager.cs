using FileManagerUtils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson9
{
    /// <summary>
    /// Основной класс 
    /// </summary>
    internal class FileManager
    {
        private int WindowHeight;
        private int WindowWidth;
        private string currentDir = Directory.GetCurrentDirectory();
        private string applicationErrorsDir;
        private StringBuilder infoString = new StringBuilder();

        /// <summary>
        /// переменные для реализации истории команд
        /// </summary>
        private string[] history = new string[10];  // массив истории команд.  Возьмем к примеру буфер на 10 команд
        private int hC=0;   // history counter - текущий номер последней команды
        private int hCmax=0;  // max кол-во команд в истории
        int hRL = 0; 
        bool GetLastStarted=false;


        public FileManager()
        {
            applicationErrorsDir = Directory.GetCurrentDirectory() + "/errors";
            Directory.CreateDirectory(applicationErrorsDir);
            ReadSettings();
            Console.Title = "FileManager";
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.SetWindowSize(WindowWidth, WindowHeight);
            Console.SetBufferSize(WindowWidth, WindowHeight);
            

            DrawWindow(0, 0, WindowWidth, 18);  // окно файлов
            DrawWindow(0, 18, WindowWidth, 8);  // окно инфо

            infoString.Clear();
            infoString.AppendLine(DateTime.Now.ToString());
        }


        /// <summary>
        /// Вспомогательный метод, получить текущую позицию курсора
        /// </summary>
        /// <returns></returns>
         (int left, int top) GetCursorPosition()
        {
            return (Console.CursorLeft, Console.CursorTop);
        }

        /// <summary>
        /// Обработка процесса ввода данных с консоли
        /// </summary>
        /// <param name="width">Длина строки ввода</param>
         void ProcessEnterCommand(int width)
        {
            (int left, int top) = GetCursorPosition();
            StringBuilder command = new StringBuilder();
            ConsoleKeyInfo keyInfo;
            char key;

            do
            {
                keyInfo = Console.ReadKey();
                key = keyInfo.KeyChar;

                if (keyInfo.Key != ConsoleKey.Enter && keyInfo.Key != ConsoleKey.Backspace &&
                    keyInfo.Key != ConsoleKey.UpArrow && keyInfo.Key!=ConsoleKey.DownArrow )
                    command.Append(key);

                (int currentLeft, int currentTop) = GetCursorPosition();

                if (currentLeft == width - 2)
                {
                    Console.SetCursorPosition(currentLeft - 1, top);
                    Console.Write(" ");
                    Console.SetCursorPosition(currentLeft - 1, top);
                }

                if (keyInfo.Key == ConsoleKey.Backspace)
                {
                    if (command.Length > 0)
                        command.Remove(command.Length - 1, 1);
                    if (currentLeft >= left)
                    {
                        Console.SetCursorPosition(currentLeft, top);
                        Console.Write(" ");
                        Console.SetCursorPosition(currentLeft, top);
                    }
                    else
                    {
                        command.Clear();
                        Console.SetCursorPosition(left, top);
                    }
                }

                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    // Затираем командную строку
                    command.Clear();
                    Console.SetCursorPosition(left, top);
                    Console.Write("                                ");
                    Console.SetCursorPosition(left, top);


                    command.Append( historyGetNext());
                    Console.Write(command.ToString());
             
                }
                if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    // Затираем командную строку
                    command.Clear();
                    Console.SetCursorPosition(left, top);
                    Console.Write("                                ");
                    Console.SetCursorPosition(left, top);
                    
                    
                    command.Append(historyGetLast());
                    Console.Write(command.ToString());
                }

            }
            while (keyInfo.Key != ConsoleKey.Enter);
            ParseCommandString(command.ToString());
        }

         void ParseCommandString(string command)
        {
            string[] commandParams = command.ToLower().Split(' ');
            if (commandParams.Length > 0)
            {
                historyAdd(command);    // для упрощения запоминаем  в историю все комманды, даже кривые
                GetLastStarted = false;

                // Оборачиваем в try/catch этот error prone участок
                try
                {
                    switch (commandParams[0])
                    {
                        case "cd":
                            if (commandParams.Length > 1)
                                if (Directory.Exists(commandParams[1]))
                                {
                                    currentDir = commandParams[1];
                                    DrawTree(new DirectoryInfo(currentDir), 1);


                                    Properties.Settings.Default.LastDir = currentDir;
                                    Properties.Settings.Default.Save();
                                }
                            infoString.Clear();
                            infoString.AppendLine(DateTime.Now.ToString());
                            break;
                        case "ls":
                            if (commandParams.Length > 1 && Directory.Exists(commandParams[1]))
                                if (commandParams.Length > 3 && commandParams[2] == "-p" && int.TryParse(commandParams[3], out int n))
                                {
                                    DrawTree(new DirectoryInfo(commandParams[1]), n);
                                }
                                else
                                {
                                    DrawTree(new DirectoryInfo(commandParams[1]), 1);
                                }
                            if (commandParams.Length == 1)   // ls без параметров = ls текущей дирректории
                            {
                                DrawTree(new DirectoryInfo(currentDir), 1);
                            }
                            infoString.Clear();
                            infoString.AppendLine(DateTime.Now.ToString());
                            break;
                        case "copy":
                            if (commandParams.Length == 3)
                            {
                                if (Directory.Exists(commandParams[1]) && Directory.Exists(commandParams[2]))
                                {
                                    DirectoryInfo src = new DirectoryInfo(commandParams[1]);
                                    DirectoryInfo dst = new DirectoryInfo(commandParams[2]);
                                    CopyFilesRecursively(src, dst);
                                }
                                if (File.Exists(commandParams[1]) && File.Exists(commandParams[2]))
                                {
                                    FileInfo src = new FileInfo(commandParams[1]);
                                    FileInfo dst = new FileInfo(commandParams[2]);
                                    File.Copy(src.FullName, dst.FullName);
                                }
                                infoString.Clear();
                                infoString.AppendLine(DateTime.Now.ToString());
                            }
                            break;
                        case "rm":
                            if (commandParams.Length == 2)
                            {
                                if (Directory.Exists(commandParams[1]))
                                {
                                    DirectoryInfo dir = new DirectoryInfo(commandParams[1]);
                                    dir.Delete(true);
                                }
                                if (File.Exists(commandParams[1]))
                                {
                                    FileInfo file = new FileInfo(commandParams[1]);
                                    file.Delete();
                                }
                                infoString.Clear();
                                infoString.AppendLine(DateTime.Now.ToString());
                            }
                            break;
                        case "file":
                            if (commandParams.Length == 2)
                            {
                                infoString.Clear();
                                infoString.AppendLine(DateTime.Now.ToString());
                                if (Directory.Exists(commandParams[1]))
                                {
                                    DirectoryInfo dir = new DirectoryInfo(commandParams[1]);
                                    infoString.AppendLine($"      директория {dir.Name} вложена в {dir.Parent.FullName} ");
                                }
                                else
                                if (File.Exists(commandParams[1]))
                                {
                                    FileInfo fileInfo = new FileInfo(commandParams[1]);
                                    infoString.AppendLine($"      файл {fileInfo.FullName} находится в {fileInfo.Directory.FullName} ");
                                }
                                else { infoString.AppendLine($"         параметр {commandParams[1]} не файл и не директория"); }
                            }
                            break;
                        default:
                            {
                                infoString.Clear();
                                infoString.AppendLine(DateTime.Now.ToString());
                                infoString.AppendLine($"      данная комманда : {commandParams[0]} не обрабатывается");
                            }
                            break;
                    }
                }
                catch (Exception ex)
                {
                    logError(ex);
                }
            }      
            
            UpdateConsole();
        }

        /// <summary>
        /// Логирование ошибок. 
        /// </summary>
        /// <param name="exception"></param>
        void logError(Exception exception )
        {
            var file = Path.Combine(applicationErrorsDir, "log_exceptions.txt");
            File.AppendAllLines(file, new[] { DateTime.Now +" " + exception.Message.ToString() , "call stack: " + exception.StackTrace });
        }
        
        /// <summary>
        /// Добавляем в массив истории команд
        /// </summary>
        /// <param name="command"></param>
        void   historyAdd(string command)
        { 
            history[hC] = command;
            hC++;           
           if (hC==10) hC= 0;  // пошли записывать по кругу 
           if (hC > hCmax) hCmax = hC;
        }
        /// <summary>
        /// Вызывается при нажатии стрелка вниз
        /// </summary>
        /// <returns></returns>
        string  historyGetLast()
        {
            if (GetLastStarted == false)
            {
                if (hC>0) hRL = hC - 1;
                    else hRL = hC;
                GetLastStarted = true;
            }

            if (GetLastStarted == true)
            {
                if (hRL == 0) hRL = hCmax;  // пошли по кругу
                else hRL--;
            }
 
            return history[hRL];
        }
        /// <summary>
        /// Вызывается при нажатии стрелка вверх
        /// </summary>
        /// <returns></returns>
        string historyGetNext()
        {
            if (GetLastStarted == true)
            {
                if (hRL == hCmax) hRL = 0;  // пошли по кругу
                else if (history.Length-1 > hRL ) hRL++;
            }
            else hRL = hC;

            return history[hRL];
        }
        
        void CopyFilesRecursively(DirectoryInfo source, DirectoryInfo target)
        {
            foreach (DirectoryInfo dir in source.GetDirectories())
                CopyFilesRecursively(dir, target.CreateSubdirectory(dir.Name));
            foreach (FileInfo file in source.GetFiles())
                file.CopyTo(Path.Combine(target.FullName, file.Name));
        }

        void DeleteDirRecursively(DirectoryInfo directory)
        {
            foreach (DirectoryInfo dir in directory.GetDirectories())
            {
                foreach(FileInfo file in dir.GetFiles()) file.Delete();
                if (!dir.GetDirectories().Any()) dir.Delete();
                    else DeleteDirRecursively(dir);
            }
        }

        string GetShortPath(string path)
        {
            StringBuilder shortPathName = new StringBuilder((int)API.MAX_PATH);
            API.GetShortPathName(path, shortPathName, API.MAX_PATH);
            return shortPathName.ToString();
        }



        /// <summary>
        /// Обновление ввода с консоли
        /// </summary>
        public  void UpdateConsole()
        {
            PrintInfo(infoString);
            DrawConsole(GetShortPath(currentDir), 0, 26, WindowWidth, 3);
            ProcessEnterCommand(WindowWidth);
        }


        /// <summary>
        /// Отрисовка консоли
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
         void DrawConsole(string dir, int x, int y, int width, int height)
        {
            DrawWindow(x, y, width, height);
            Console.SetCursorPosition(x + 1, y + height / 2);
            Console.Write($"{dir}>");
        }

        /// <summary>
        /// Отрисовка окна
        /// </summary>
        /// <param name="x">Начальная позиция по оси X</param>
        /// <param name="y">Начальная позиция по оси Y</param>
        /// <param name="width">Ширина окна</param>
        /// <param name="height">Высота окна</param>
         void DrawWindow(int x, int y, int width, int height)
        {
            // header - шапка
            Console.SetCursorPosition(x, y);
            Console.Write("╔");
            for (int i = 0; i < width - 2; i++)
                Console.Write("═");
            Console.Write("╗");


            // window - окно
            Console.SetCursorPosition(x, y + 1);
            for (int i = 0; i < height - 2; i++)
            {
                Console.Write("║");

                for (int j = x + 1; j < x + width - 1; j++)
                    Console.Write(" ");

                Console.Write("║");
            }

            // footer - подвал
            Console.Write("╚");
            for (int i = 0; i < width - 2; i++)
                Console.Write("═");
            Console.Write("╝");
            Console.SetCursorPosition(x, y);

        }

        /// <summary>
        /// Отрисовать дерево каталогов
        /// </summary>
        /// <param name="dir">Директория</param>
        /// <param name="page">Страница</param>
         void DrawTree(DirectoryInfo dir, int page)
        {
            StringBuilder tree = new StringBuilder();
            GetTree(tree, dir, "", true);
            DrawWindow(0, 0, WindowWidth, 18);
            (int currentLeft, int currentTop) = GetCursorPosition();
            int pageLines = 16;
            string[] lines = tree.ToString().Split('\n');
            int pageTotal = (lines.Length + pageLines - 1) / pageLines;
            if (page > pageTotal)
                page = pageTotal;

            for (int i = (page - 1) * pageLines, counter = 0; i < page * pageLines; i++, counter++)
            {
                if (lines.Length - 1 > i)
                {
                    Console.SetCursorPosition(currentLeft + 1, currentTop + 1 + counter);
                    Console.WriteLine(lines[i]);
                }
            }

            // Отрисуем footer
            string footer = $"╡ {page} of {pageTotal} ╞";
            Console.SetCursorPosition(WindowWidth / 2 - footer.Length / 2, 17);
            Console.WriteLine(footer);

        }

         void GetTree(StringBuilder tree, DirectoryInfo dir, string indent, bool lastDirectory)
        {
            tree.Append(indent);
            if (lastDirectory)
            {
                tree.Append("└─");
                indent += "  ";
            }
            else
            {
                tree.Append("├─");
                indent += "│ ";
            }

            tree.Append($"{dir.Name}\n");


            FileInfo[] subFiles = dir.GetFiles();
            for (int i = 0; i < subFiles.Length; i++)
            {
                if (i == subFiles.Length - 1)
                {
                    tree.Append($"{indent}└─{subFiles[i].Name}\n");
                }
                else
                {
                    tree.Append($"{indent}├─{subFiles[i].Name}\n");
                }
            }


            DirectoryInfo[] subDirects = dir.GetDirectories();
            for (int i = 0; i < subDirects.Length; i++)
                GetTree(tree, subDirects[i], indent, i == subDirects.Length - 1);
        }


        void PrintInfo(StringBuilder stringBuilder)
        {
            DrawWindow(0, 18, WindowWidth, 8);  // окно инфо
            (int currentLeft, int currentTop) = GetCursorPosition();

            string[] lines = stringBuilder.ToString().Split('\n');

            for (int i = 0; i < lines.Length && i<8; i++)
            { 
            Console.SetCursorPosition(currentLeft + 1, currentTop + 1+i);
            Console.Write(lines[i]);                
            }
            
        }
        void ReadSettings()
        {
            WindowHeight = Properties.Settings.Default.WindowH;
            WindowWidth = Properties.Settings.Default.WindowW;

            if (Directory.Exists(Properties.Settings.Default.LastDir))
                { currentDir = Properties.Settings.Default.LastDir; }
            else { currentDir = Directory.GetCurrentDirectory(); }
        }

    }
}
