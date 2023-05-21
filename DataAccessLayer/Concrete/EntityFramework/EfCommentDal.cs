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
	public class EfCommentDal : EfEntityRepositoryBase<About, LocalContext>, ICommentDal
	{
		public int Delete(Comment p)
		{
			throw new NotImplementedException();
		}

		public Comment Find(Expression<Func<Comment, bool>> where)
		{
			throw new NotImplementedException();
		}

		public Comment GetByID(int id)
		{
			throw new NotImplementedException();
		}

		public int Insert(Comment p)
		{
			throw new NotImplementedException();
		}

		public List<Comment> List()
		{
			throw new NotImplementedException();
		}

		public List<Comment> List(Expression<Func<Comment, bool>> filter = null)
		{
			throw new NotImplementedException();
		}

		public int Update(Comment p)
		{
			throw new NotImplementedException();
		}
	}
}
