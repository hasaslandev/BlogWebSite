using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
	public interface IContackService
	{
		 int BLContactAdd(Contact c);
		 List<Contact> GetAll();
		Contact GetContactDetails(int id);


	}
}
