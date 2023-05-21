using ClassLibrary1.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
	public class EfBlogDal : EfEntityRepositoryBase<About, LocalContext>, IBlogDal
	{
		public int Delete(Blog p)
		{
			throw new NotImplementedException();
		}

		public Blog Find(Expression<Func<Blog, bool>> where)
		{
			throw new NotImplementedException();
		}

		public Blog GetByID(int id)
		{
			throw new NotImplementedException();
		}

		public int Insert(Blog p)
		{
			throw new NotImplementedException();
		}

		public List<Blog> List()
		{
			throw new NotImplementedException();
		}

		public List<Blog> List(Expression<Func<Blog, bool>> filter = null)
		{
			throw new NotImplementedException();
		}

		public int Update(Blog p)
		{
			throw new NotImplementedException();
		}
	}
}
