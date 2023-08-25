using Business.Abstract;
using Business.Constants;
using CoreL.Entities.Concrete;
using CoreL.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;

        public AdminManager(IAdminDal userDal)
        {
            _adminDal = userDal;
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

        public void Update(Admin admin)
        {
            _adminDal.UpdateAsync(admin);
        }

        public void Delete(Admin admin)
        {
            _adminDal.DeleteAsync(admin);
        }
    }
}
