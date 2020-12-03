using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore_Study.Models
{
    public class Blog
    {
        public int Id { get; set; }
        /// <summary>Заголовок</summary>
        public string Heading { get; set; }
        /// <summary>Изображение</summary>
        public BlogFile Image { get; set; }
        /// <summary>Текст блога</summary>
        public string MainText { get; set; }
        /// <summary>Автор/summary>
        public string Author { get; set; }
        /// <summary>Дата создания/summary>
        public DateTime CreationTime { get; set; }
        /// <summary>Тэги/summary>
        public List<string> Tags { get; set; }
    }
}
