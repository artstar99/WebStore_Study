using System;
using System.Collections.Generic;
using System.Linq;
using WebStore_Study.DAL.Context;
using WebStore_Study.Domain;
using WebStore_Study.Domain.Entities;
using WebStore_Study.Interfaces.Services;

namespace WebStore_Study.Infrastructure.Implementations.InSQL
{
    public class SqlBlogData : IBlogService
    {
        private readonly WebStore_StudyDb dbContext;
        private int blogsCount;

        public SqlBlogData(WebStore_StudyDb dbContext)
        {
            this.dbContext = dbContext;
        }

        public int CountBlogs()
        {
            return dbContext.Blogs.Count();
        }

        public int CreateBlog(Blog blog)
        {
            throw new NotImplementedException();
        }

        public void DeleteBlog(int id)
        {
            throw new NotImplementedException();
        }

        public Blog GetBlog(int id)
        {
            return dbContext.Blogs.FirstOrDefault(b => b.Id == id);
        }

        public IEnumerable<Blog> LoadBlogs(BlogFilter filter = null)
        {
            blogsCount = CountBlogs();
            if (blogsCount == 0)
                return null;

            if (filter == null)
                return dbContext.Blogs;

            if (filter.CurrentPage != null)
            {
                var query = dbContext.Blogs
                    .OrderByDescending(blog=>blog.Id)
                    .Skip(filter.BlogsPerPage * (int) (filter.CurrentPage - 1))
                    .Take(filter.BlogsPerPage);
                return query;
            }
            else
            {
                var query = dbContext.Blogs
                    .OrderByDescending(blog => blog.Id)
                    .Take(filter.BlogsPerPage);
                return query;
            }
        }

        public bool UpdateBlog(Blog blog)
        {
            throw new NotImplementedException();
        }
    }
}
