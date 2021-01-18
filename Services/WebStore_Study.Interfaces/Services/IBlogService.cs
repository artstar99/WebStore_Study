using System.Collections.Generic;
using WebStore_Study.Domain;
using WebStore_Study.Domain.Entities;

namespace WebStore_Study.Interfaces.Services
{
    public interface IBlogService
    {
        IEnumerable<Blog> LoadBlogs(BlogFilter filter=null);
        int CountBlogs();
        int CreateBlog( Blog blog);
        bool UpdateBlog(Blog blog);
        Blog GetBlog(int id);
        void DeleteBlog(int id);


    }
}
