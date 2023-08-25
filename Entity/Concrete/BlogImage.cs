using CoreL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class BlogImage:IEntity
    {
        public int Id { get; set; }
        public string BlogImageFolder { get; set; }
        public DateTime Date { get; set; }
        public int BlogId { get; set; }
    }
}
