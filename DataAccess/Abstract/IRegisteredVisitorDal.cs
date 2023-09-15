using CoreL.Concrete;
using CoreL.DataAccess;
using CoreL.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IRegisteredVisitorDal:IEntityRepository<RegisteredVisitor>
    {
        List<OperationClaim> GetClaims(RegisteredVisitor registeredVisitor);

    }
}
