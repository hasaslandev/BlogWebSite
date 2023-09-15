
using CoreL.Concrete;
using CoreL.DataAccess.EntityFramework;
using CoreL.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRegisteredVisitorDal: EfEntityRepositoryBase<RegisteredVisitor, LocalContext>, IRegisteredVisitorDal
    {
        public List<OperationClaim> GetClaims(RegisteredVisitor registeredVisitor)
        {
            using (var context = new LocalContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join registeredVisitorOperationClaims in context.RegisteredVisitorOperationClaims
                                 on operationClaim.Id equals registeredVisitorOperationClaims.OperationClaimId
                             where registeredVisitorOperationClaims.RegisteredVisitorId == registeredVisitor.RegisteredVisitorId
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }
    }
}
