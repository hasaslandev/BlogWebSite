using CoreL.DataAccess.EntityFramework;
using CoreL.Entities.Concrete;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfAdminDal : EfEntityRepositoryBase<Admin, LocalContext>, IAdminDal
    {
        public List<OperationClaim> GetClaims(Admin admin)
        {
            using (var context = new LocalContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join adminOperationClaims in context.AdminOperationClaims
                                 on operationClaim.Id equals adminOperationClaims.OperationClaimId
                             where adminOperationClaims.AdminId == admin.AdminID
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }
    }
}
   

