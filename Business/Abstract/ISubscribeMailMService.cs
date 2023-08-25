using CoreL.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISubscribeMailMService
    {
        IDataResult<List<SubscribeMail>> GetAll();
        IResult Add(SubscribeMail subscribeMail);
        IResult Delete(int subscribeMailId);
    }
}
