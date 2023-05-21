using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	internal interface IBlogService
	{
		List<Blog> GetAll();
		List<Blog> GetBlogById(int id);
		List<Blog> GetBlogByAuthor(int id);
		List<Blog> GetBlogByCategory(int id);
		int BlogAddBL(Blog p);
		int DeleteBlogBL(int p);
		Blog FindBlog(int id);
		int UpdateBlog(Blog p);
	}
}
