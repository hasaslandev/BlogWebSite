using CoreL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Job : IEntity
    {
        [Key]
        public int JobID { get; set; }
        public string JobName { get; set; }
    }
}
