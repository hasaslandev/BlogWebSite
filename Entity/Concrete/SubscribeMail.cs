using CoreL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class SubscribeMail : IEntity
    {
        [Key]
        public int MailID { get; set; }
        public string Mail { get; set; }
    }
}
