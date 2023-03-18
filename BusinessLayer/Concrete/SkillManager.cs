using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class SkillManager
    {
        Repository<Skill> repoadmin = new Repository<Skill>();
        public List<Skill> GetAll()
        {
            return repoadmin.List();
        }
        public List<Skill> GetBlogByAdmin(int id)
        {
            return repoadmin.List(x => x.SkillID == id);
        }
    }
}
