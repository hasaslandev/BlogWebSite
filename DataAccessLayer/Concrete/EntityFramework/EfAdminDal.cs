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
	public class EfAdminDal : EfEntityRepositoryBase<About, LocalContext>,IAdminDal
	{
		public int Delete(Admin p)
		{
			throw new NotImplementedException();
		}

		public Admin Find(Expression<Func<Admin, bool>> where)
		{
			throw new NotImplementedException();
		}

		public Admin GetByID(int id)
		{
			throw new NotImplementedException();
		}

		public int Insert(Admin p)
		{
			throw new NotImplementedException();
		}

		public List<Admin> List()
		{
			throw new NotImplementedException();
		}

		public List<Admin> List(Expression<Func<Admin, bool>> filter = null)
		{
			throw new NotImplementedException();
		}

		public int Update(Admin p)
		{
			throw new NotImplementedException();
		}
	}
}
