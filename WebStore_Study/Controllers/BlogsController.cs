using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore_Study.Infrastructure.Interfaces;
using WebStore_Study.ViewModels;

namespace WebStore_Study.Controllers
{
    public class BlogsController : Controller
    {
        private readonly IBlogService blogService;
        private readonly int blogsPerPage = 3;
        public BlogsController(IBlogService blogService)
        {
            this.blogService = blogService;
        }
        public IActionResult Index()
        {
            var numberOfBlogs = blogService.LoadBlogs().Count();

            BlogsViewModel blogsViewModel = new BlogsViewModel()
            {
                Blogs = blogService.LoadBlogsForPage(1, blogsPerPage).ToList(),
                NumberOfPages = numberOfBlogs % blogsPerPage > 0? numberOfBlogs / blogsPerPage+1: numberOfBlogs / blogsPerPage,
                CurrentPage = 1
            };
            
            return View(blogsViewModel);

        }
        public IActionResult Page(int id)
        {
            var blogs = blogService.LoadBlogsForPage(1, blogsPerPage);
            return View(blogs);
        }
        public IActionResult BlogSingle()
        {
            return View();
        }
    }
}
