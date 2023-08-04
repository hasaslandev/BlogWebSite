using CoreL.DataAccess;
using CoreL.Entities.Concrete;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IAdminDal : IEntityRepository<Admin>
    {
        List<OperationClaim> GetClaims(Admin admin);
    }
}
