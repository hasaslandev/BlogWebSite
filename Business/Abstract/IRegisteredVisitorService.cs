using CoreL.Concrete;
using CoreL.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRegisteredVisitorService
    {
        List<OperationClaim> GetClaims(RegisteredVisitor registeredVisitor);
        void Add(RegisteredVisitor registeredVisitor);
        RegisteredVisitor GetByMail(string email);
        void Update(RegisteredVisitor registeredVisitor);
        void Delete(RegisteredVisitor registeredVisitor);
    }
}
