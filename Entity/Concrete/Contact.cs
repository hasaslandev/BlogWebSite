using CoreL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Contact : IEntity
    {
        [Key]
        public int ContactID { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]

        public string SurName { get; set; }
        [StringLength(50)]

        public string Mail { get; set; }
        [StringLength(50)]

        public string Subject { get; set; }
        [StringLength(2000)]
        public string Message { get; set; }
        public DateTime MessageDate { get; set; }

    }
}
