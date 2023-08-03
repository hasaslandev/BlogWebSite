using CoreL.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBlogDal : EfEntityRepositoryBase<Blog, LocalContext>, IBlogDal
    {
        public List<BlogDetailDto> GetBlogDetails()
        {
            using (LocalContext context = new LocalContext())
            {
                var result = from p in context.Blogs
                             join c in context.Categories
                             on p.CategoryID equals c.CategoryID
                             select new BlogDetailDto { BlogID = p.BlogID, CategoryID = c.CategoryID, BlogTitle = p.BlogTitle };
                return result.ToList();
            }

        }
    }
}
