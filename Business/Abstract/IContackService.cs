using CoreL.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IContackService
    {
        IResult Add(Contact contact);
        IResult Delete(int contactId);
        IResult Update(Contact contact);

        IDataResult<List<Contact>> GetAll();
        IDataResult<Contact> GetContactDetails(int id);
        IResult SendEmail(Contact request);
    }
}
