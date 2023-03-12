using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContactManager
    {
        Repository<Contact> repocontact = new Repository<Contact>();

        public int BLContactAdd(Contact c)
        {
            if (c.Mail.Length <= 4 || c.Mail.Length >= 50
                || c.SurName == "" || c.Mail == "" || c.SurName.Length <= 3)
            {
                return -1;
            }
            return repocontact.Insert(c);
        }
    }
}
