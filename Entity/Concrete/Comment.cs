﻿using CoreL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Comment : IEntity
    {
        [Key]
        public int CommentID { get; set; }
        [StringLength(50)]

        public string UserName { get; set; }
        [StringLength(50)]

        public string Mail { get; set; }
        [StringLength(500)]
        public string CommentText { get; set; }
        public DateTime CommentDate { get; set; }
        public bool CommentStatus { get; set; }

        public int BlogID { get; set; }
        public virtual Blog Blogs { get; set; }
    }
}
