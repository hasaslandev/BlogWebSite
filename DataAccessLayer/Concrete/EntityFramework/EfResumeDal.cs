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
	public class EfResumeDal : EfEntityRepositoryBase<About, LocalContext>, IResumeDal
	{
		public int Delete(Resume p)
		{
			throw new NotImplementedException();
		}

		public Resume Find(Expression<Func<Resume, bool>> where)
		{
			throw new NotImplementedException();
		}

		public Resume GetByID(int id)
		{
			throw new NotImplementedException();
		}

		public int Insert(Resume p)
		{
			throw new NotImplementedException();
		}

		public List<Resume> List()
		{
			throw new NotImplementedException();
		}

		public List<Resume> List(Expression<Func<Resume, bool>> filter = null)
		{
			throw new NotImplementedException();
		}

		public int Update(Resume p)
		{
			throw new NotImplementedException();
		}
	}
}
