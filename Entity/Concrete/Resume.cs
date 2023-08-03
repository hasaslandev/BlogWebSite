using CoreL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Resume : IEntity
    {
        [Key]
        public int ResumeID { get; set; }
        [StringLength(50)]
        public string ResumeJobs { get; set; }
        [StringLength(2000)]
        public string ResumeStatement { get; set; }
        public int AdminID { get; set; }
        public virtual Admin Admin { get; set; }


    }
}
