using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore_Study.Models;

namespace WebStore_Study.Infrastructure.Interfaces
{
    public interface IBlogService
    {
        IEnumerable<Blog> LoadBlogs();
        IEnumerable<Blog> LoadBlogsForPage(int page, int blogsPerPage);
        int CreateBlog( Blog blog);
        bool UpdateBlog(Blog blog);
        Blog GetBlog(int id);
        void DeleteBlog(int id);


    }
}
