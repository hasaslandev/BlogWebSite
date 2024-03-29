﻿using CoreL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Blog : IEntity
    {
        [Key]
        public int BlogID { get; set; }
        public string BlogTitle { get; set; }
        public string BlogImage { get; set; }
        public DateTime BlogDate { get; set; }
        public string BlogContent { get; set; }
        public int BlogRating { get; set; }
        public int CategoryID { get; set; }
        public virtual Category? Category { get; set; }
        public ICollection<Comment>? Comments { get; set; }
    }
}
