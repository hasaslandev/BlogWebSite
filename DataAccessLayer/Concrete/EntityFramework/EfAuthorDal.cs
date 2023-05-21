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
	internal class EfAuthorDal : EfEntityRepositoryBase<About, LocalContext>, IAuthorDal
	{
		public int Delete(Author p)
		{
			throw new NotImplementedException();
		}

		public Author Find(Expression<Func<Author, bool>> where)
		{
			throw new NotImplementedException();
		}

		public Author GetByID(int id)
		{
			throw new NotImplementedException();
		}

		public int Insert(Author p)
		{
			throw new NotImplementedException();
		}

		public List<Author> List()
		{
			throw new NotImplementedException();
		}

		public List<Author> List(Expression<Func<Author, bool>> filter = null)
		{
			throw new NotImplementedException();
		}

		public int Update(Author p)
		{
			throw new NotImplementedException();
		}
	}
}
