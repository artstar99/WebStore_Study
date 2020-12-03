using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore_Study.Models
{
    public class BlogFile
    {
        
        public int Id { get; set; }
        /// <summary> Имя файла </summary>
        public string Name { get; set; }
        /// <summary> Путь к файлу </summary>
        public string Path { get; set; }
    }
}
