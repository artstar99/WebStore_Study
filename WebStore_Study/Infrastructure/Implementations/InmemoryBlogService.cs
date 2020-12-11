using System;
using System.Collections.Generic;
using System.Linq;
using WebStore_Study.Data;
using WebStore_Study.Domain;
using WebStore_Study.Domain.Entities;
using WebStore_Study.Infrastructure.Interfaces;

namespace WebStore_Study.Infrastructure.Implementations
{
    public class InmemoryBlogService : IBlogService
    {
        private readonly List<Blog> blogList = TestData.Blogs;
        public IEnumerable<Blog> LoadBlogs(BlogFilter filter = null)
        {
            if (blogList.Count == 0)
                return null;

            if (filter == null)
                return blogList;

            if (filter?.CurrentPage != null)
            {
                var blogsOnPage = filter.BlogsPerPage;
                var selectionIndex = blogList.Count - (Int32)filter.CurrentPage * filter.BlogsPerPage;
                while (selectionIndex < 0)
                {
                    selectionIndex++;
                    blogsOnPage--;
                }
                var query = blogList.GetRange(selectionIndex, blogsOnPage);
                query.Reverse();
                return query;
            }

            else
            {
                var blogsOnPage = filter.BlogsPerPage;
                var selectionIndex = blogList.Count - filter.BlogsPerPage;
                while (selectionIndex < 0)
                {
                    selectionIndex++;
                    blogsOnPage--;
                }
                var query = blogList.GetRange(selectionIndex, blogsOnPage);
                query.Reverse();
                return query;
            }

        }

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

        public bool UpdateBlog(Blog blog)
        {
            throw new NotImplementedException();
        }

        public int CountBlogs()
        {
            return blogList.Count();
        }
    }
}
