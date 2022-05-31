using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5
{
    public class ToDo
    {

        public string Title { get; set; }
        public bool isDone { get; set; }
        public ToDo(string title, bool isDone)
        {
            Title = title;
            this.isDone = isDone;
        }

        public ToDo()
        { }
    }
}
