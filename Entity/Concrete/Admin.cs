using CoreL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Admin : IEntity
    {
        [Key]
        public int AdminID { get; set; }
        [StringLength(25)]
        public string UserName { get; set; }
        [StringLength(25)]
        public string Password { get; set; }
        [StringLength(25)]
        public string Degree { get; set; }
        public DateTime Birthday { get; set; }
        [StringLength(27)]
        public string Mail { get; set; }
        public bool FreelanceEnable { get; set; }
        [StringLength(27)]
        public string City { get; set; }
        [StringLength(11)]
        public string Phone { get; set; }

        public ICollection<Resume> Resumes { get; set; }

        public ICollection<Job> Jobs { get; set; }

        public ICollection<Skill> Skills { get; set; }


    }
}
