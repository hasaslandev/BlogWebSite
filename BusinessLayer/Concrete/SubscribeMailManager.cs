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
    public class SubscribeMailManager:ISubscribeMailMService
    {
        ISubscribeMailDal _subscribeMailDal;

        public SubscribeMailManager(ISubscribeMailDal subscribeMailDal)
        {
            _subscribeMailDal = subscribeMailDal;
        }

        public int BLAdd(SubscribeMail p) 
        {
            if (p.Mail.Length<=10 || p.Mail.Length>=50 && p.Mail.ToString()=="@.com")
            {
                return -1;
            }
            return _subscribeMailDal.Insert(p);
        }
    }
}
