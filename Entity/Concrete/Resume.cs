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
        public string ResumeJobs { get; set; }
        public string ResumeStatement { get; set; }
    }
}
