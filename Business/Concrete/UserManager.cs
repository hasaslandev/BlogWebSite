using Business.Abstract;
using CoreL.Entities.Concrete;
using CoreL.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IAdminService
    {
        IAdminDal _adminDal;

        public UserManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public List<OperationClaim> GetClaims(Admin admin)
        {
            return _adminDal.GetClaims(admin);
        }

        public void Add(Admin admin)
        {
            _adminDal.AddAsync(admin);
        }

        public Admin GetByMail(string email)
        {
            return _adminDal.Get(u => u.Email == email);
        }

        public IDataResult<List<Admin>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Admin>> GetBlogByAdmin(int id)
        {
            throw new NotImplementedException();
        }
    }
}
