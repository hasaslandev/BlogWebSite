using Business.Abstract;
using Business.Constants;
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
    public class ContactManager : IContackService
    {
        IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public IResult Add(Contact c)
        {
            _contactDal.AddAsync(c);
            return new SuccessResult(Messages.BlogAdded);
        }
        public IDataResult<List<Contact>> GetAll()
        {
            return new SuccessDataResult<List<Contact>>(_contactDal.GetAll(), Messages.BlogsListed);

        }
        public IDataResult<Contact> GetContactDetails(int id)
        {
            return new SuccessDataResult<Contact>(_contactDal.Get(p => p.ContactID == id));

        }
    }
}
