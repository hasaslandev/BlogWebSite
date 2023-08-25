using CoreL.Utilities.Results;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISkillService
    {
        IDataResult<List<Skill>> GetAll();
        IResult Add(Skill skill);
        IDataResult<List<Skill>> GetBlogByAdmin(int id);
        IResult Delete (int skillId);
        IResult Update (Skill skill);
    }
}
