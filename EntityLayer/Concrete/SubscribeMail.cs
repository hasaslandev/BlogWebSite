using CoreLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class SubscribeMail: IEntity
	{
        [Key]
        public int MailID { get; set; }
        [StringLength(50)]
        public string Mail { get; set; }
    }
}
