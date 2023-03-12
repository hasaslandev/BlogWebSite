using System;
using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }
        [StringLength(50)]

        public string UserName { get; set; }
        [StringLength(50)]

        public string Mail { get; set; }
        [StringLength(500)]
        public string CommentText { get; set; }
        public DateTime  CommentDate { get; set; }

        public int BlogID { get; set; }
        public virtual Blog Blogs { get; set; }
    }
}
