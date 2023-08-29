using CoreL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class AboutImage:IEntity
    {
        public int Id { get; set; }
        public string? AboutImageFolder { get; set; }
        public DateTime Date { get; set; }
        public int AboutId { get; set; }
    }
}
