using Business.Abstract;
using Business.Constants;
using CoreL.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class SubscribeMailManager : ISubscribeMailMService
    {
        ISubscribeMailDal _subscribeMailDal;

        public SubscribeMailManager(ISubscribeMailDal subscribeMailDal)
        {
            _subscribeMailDal = subscribeMailDal;
        }

        public IResult Add(SubscribeMail p)
        {
            _subscribeMailDal.AddAsync(p);
            return new SuccessResult(Messages.BlogAdded);

        }

        public IResult Delete(int subscribeMailId)
        {
            SubscribeMail subscribeMail = _subscribeMailDal.Find(x => x.MailID == subscribeMailId);
            _subscribeMailDal.DeleteAsync(subscribeMail);
            return new SuccessResult(Messages.AboutDelete);
        }

        public IDataResult<List<SubscribeMail>> GetAll()
        {
            return new SuccessDataResult<List<SubscribeMail>>(_subscribeMailDal.GetAll());
        }
    }
}
