using CoreL.Entities.Concrete;
using CoreL.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAdminService
    {

        List<OperationClaim> GetClaims(Admin admin);
        void Add(Admin admin);
        Admin GetByMail(string email);
        void Update(Admin admin);
        void Delete(Admin admin);
    }



}
