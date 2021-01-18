using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebStore_Study.Domain;
using WebStore_Study.Domain.ViewModels;
using WebStore_Study.Interfaces.Services;

namespace WebStore_Study.Controllers
{
    public class BlogsController : Controller
    {
        private readonly IBlogService blogService;
        private readonly int blogsPerPage = 3;
        private int numberOfPages;
        public BlogsController(IBlogService blogService)
        {
            this.blogService = blogService;
        }


        public IActionResult Index(int? page = null)
        {
            var filter = new BlogFilter { BlogsPerPage = blogsPerPage };

            if (numberOfPages == 0)
                numberOfPages = CountNumberOfPages();

            if (page == null)
            {
                var blogs = blogService.LoadBlogs(filter);
                var viewModel = new BlogsViewModel() { Blogs = blogs.ToList(), CurrentPage = 1, NumberOfPages=numberOfPages};
                return View(viewModel);
            }
            else
            {
                filter.CurrentPage = page;
                var blogs = blogService.LoadBlogs(filter);
                var viewModel=new BlogsViewModel() { Blogs = blogs.ToList(), CurrentPage = (int)page, NumberOfPages = numberOfPages };
                return View(viewModel);
            }

        }

        private int CountNumberOfPages()
        {
            var numberOfBlogs = blogService.CountBlogs();
            
            return numberOfBlogs % blogsPerPage > 0 ? numberOfBlogs / blogsPerPage + 1 : numberOfBlogs / blogsPerPage;
        }


        public IActionResult BlogSingle()
        {
            return View();
        }
    }
}
