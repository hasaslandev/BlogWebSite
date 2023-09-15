using Business.Abstract;
using CoreL.Concrete;
using CoreL.Entities.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RegisteredVisitorManager:IRegisteredVisitorService
    {
        IRegisteredVisitorDal _registeredVisitorDal;

        public RegisteredVisitorManager(IRegisteredVisitorDal registeredVisitorDal)
        {
            _registeredVisitorDal = registeredVisitorDal;
        }

        public List<OperationClaim> GetClaims(RegisteredVisitor registeredVisitor)
        {
            return _registeredVisitorDal.GetClaims(registeredVisitor);
        }

        public void Add(RegisteredVisitor registeredVisitor)
        {
            _registeredVisitorDal.AddAsync(registeredVisitor);
        }

        public RegisteredVisitor GetByMail(string email)
        {
            return _registeredVisitorDal.Get(u => u.Email == email);
        }

        public void Update(RegisteredVisitor registeredVisitor)
        {
            _registeredVisitorDal.UpdateAsync(registeredVisitor);
        }

        public void Delete(RegisteredVisitor registeredVisitor)
        {
            _registeredVisitorDal.DeleteAsync(registeredVisitor);
        }
    }
}
