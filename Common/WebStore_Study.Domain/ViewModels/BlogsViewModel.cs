using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore_Study.Domain.Entities;


namespace WebStore_Study.Domain.ViewModels
{
    public class BlogsViewModel
    {
        /// <summary> Список блогов для данной страницы </summary>
        public List<Blog> Blogs { get; set; }

        /// <summary>Кол-во страниц</summary>
        public int NumberOfPages { get; set; }

        /// <summary>Активная страница </summary>
        public int CurrentPage { get; set; }
    }
}
