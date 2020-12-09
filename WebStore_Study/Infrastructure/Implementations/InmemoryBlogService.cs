using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore_Study.Data;
using WebStore_Study.Infrastructure.Interfaces;
using WebStore_Study.Models;

namespace WebStore_Study.Infrastructure.Implementations
{
    public class InmemoryBlogService : IBlogService
    {
        private readonly List<Blog> blogList = TestData.Blogs;
        public IEnumerable<Blog> LoadBlogs() => blogList;
        public Blog GetBlog(int id) => blogList.FirstOrDefault(b => b.Id == id);

        public void DeleteBlog(int id) => blogList.Remove(GetBlog(id));



        public int CreateBlog(Blog blog)
        {
            if (blog is null)
                return 0;
            blog.Id = blogList.Max(b => b.Id) + 1;
            blogList.Add(blog);
            return blog.Id;
        }

        /// <summary>
        /// Метод для выдачи блогов на страницу начиная с самого последнего
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        public IEnumerable<Blog> LoadBlogsForPage(int page, int blogsPerPage)
        {            
            if (blogList.Count < 1)
                return null;

            int lastIndex = blogList.Count - page * blogsPerPage;
            while (lastIndex < 0)
            {
                lastIndex++;
                blogsPerPage--;
            }
            var list= blogList.GetRange(lastIndex, blogsPerPage);
            list.Reverse();
            return list;
        }

        public bool UpdateBlog(Blog blog)
        {
            throw new NotImplementedException();
        }
    }
}
