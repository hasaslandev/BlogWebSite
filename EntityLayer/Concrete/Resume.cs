﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Resume
    {
        [Key]
        public int ResumeID { get; set; }
        [StringLength(50)]
        public string ResumeJobs { get; set; }
        [StringLength(2000)]
        public string ResumeStatement { get; set; }
        public ICollection<Admin> Admins { get; set; }

    }
}
