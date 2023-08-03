using ClassLibrary1.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
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
							 select new BlogDetailDto { BlogID=p.BlogID, CategoryID=c.CategoryID,BlogTitle=p.BlogTitle };
                return result.ToList();
            }
			
        }
	}
}
