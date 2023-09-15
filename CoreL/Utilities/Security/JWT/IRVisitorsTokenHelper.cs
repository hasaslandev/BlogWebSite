using CoreL.Concrete;
using CoreL.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreL.Utilities.Security.JWT
{
    public interface IRVisitorsTokenHelper
    {
        AccessToken CreateToken(RegisteredVisitor registeredVisitor,List<OperationClaim> operationClaims);
    }
}
