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
	public class EfSkillDal : EfEntityRepositoryBase<About, LocalContext>, ISkillDal
	{
		public int Delete(Skill p)
		{
			throw new NotImplementedException();
		}

		public Skill Find(Expression<Func<Skill, bool>> where)
		{
			throw new NotImplementedException();
		}

		public Skill GetByID(int id)
		{
			throw new NotImplementedException();
		}

		public int Insert(Skill p)
		{
			throw new NotImplementedException();
		}

		public List<Skill> List()
		{
			throw new NotImplementedException();
		}

		public List<Skill> List(Expression<Func<Skill, bool>> filter = null)
		{
			throw new NotImplementedException();
		}

		public int Update(Skill p)
		{
			throw new NotImplementedException();
		}
	}
}
