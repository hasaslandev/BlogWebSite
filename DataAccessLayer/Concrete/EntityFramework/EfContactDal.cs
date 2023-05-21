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
	public class EfContactDal : EfEntityRepositoryBase<About, LocalContext>, IContactDal
	{
		public int Delete(Contact p)
		{
			throw new NotImplementedException();
		}

		public Contact Find(Expression<Func<Contact, bool>> where)
		{
			throw new NotImplementedException();
		}

		public Contact GetByID(int id)
		{
			throw new NotImplementedException();
		}

		public int Insert(Contact p)
		{
			throw new NotImplementedException();
		}

		public List<Contact> List()
		{
			throw new NotImplementedException();
		}

		public List<Contact> List(Expression<Func<Contact, bool>> filter = null)
		{
			throw new NotImplementedException();
		}

		public int Update(Contact p)
		{
			throw new NotImplementedException();
		}
	}
}
