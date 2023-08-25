﻿using CoreL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class About : IEntity
    {
        [Key]
        public int AboutID { get; set; }
        public string AboutContent1 { get; set; }
        public string AboutContent2 { get; set; }
        public string AboutImage1 { get; set; }
        public string AboutImage2 { get; set; }
    }
}
