using CoreL.Entities;
using CoreL.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Skill : IEntity
    {
        [Key]
        public int SkillID { get; set; }
        [StringLength(50)]
        public string SkillName { get; set; }
        public int SkillRating { get; set; }
    }
}
