using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContactManager:IContackService
    {
        IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public int BLContactAdd(Contact c)
        {
            if (c.Mail.Length <= 4 || c.Mail.Length >= 50
                || c.SurName == "" || c.Mail == "" || c.SurName.Length <= 3)
            {
                return -1;
            }
            return _contactDal.Insert(c);
        }
        public List<Contact> GetAll()
        {
            return _contactDal.List();
        }
        public Contact GetContactDetails(int id)
        {
            return _contactDal.Find(x => x.ContactID == id);
        }
    }
}
