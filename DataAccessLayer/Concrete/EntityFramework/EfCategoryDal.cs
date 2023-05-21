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
	public class EfCategoryDal : EfEntityRepositoryBase<About, LocalContext>, ICategoryDal
	{
		public int Delete(Category p)
		{
			throw new NotImplementedException();
		}

		public Category Find(Expression<Func<Category, bool>> where)
		{
			throw new NotImplementedException();
		}

		public Category GetByID(int id)
		{
			throw new NotImplementedException();
		}

		public int Insert(Category p)
		{
			throw new NotImplementedException();
		}

		public List<Category> List()
		{
			throw new NotImplementedException();
		}

		public List<Category> List(Expression<Func<Category, bool>> filter = null)
		{
			throw new NotImplementedException();
		}

		public int Update(Category p)
		{
			throw new NotImplementedException();
		}
	}
}
