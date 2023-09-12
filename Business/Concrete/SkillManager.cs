using Business.Abstract;
using Business.Constants;
using CoreL.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class SkillManager : ISkillService
    {
        ISkillDal _skillDal;

        public SkillManager(ISkillDal skillDal)
        {
            _skillDal = skillDal;
        }

        public IResult Add(Skill skill)
        {
            _skillDal.AddAsync(skill);
            return new SuccessResult(Messages.BlogAdded);

        }

        public IResult Delete(int skillId)
        {
            Skill skill = _skillDal.Find(x => x.SkillID == skillId);
            _skillDal.DeleteAsync(skill);
            return new SuccessResult(Messages.AboutDelete);
        }

        public IDataResult<List<Skill>> GetAll()
        {
            return new SuccessDataResult<List<Skill>>(_skillDal.GetAll(), Messages.BlogsListed);
        }
        public IDataResult<List<Skill>> GetBlogByAdmin(int id)
        {
            return new SuccessDataResult<List<Skill>>(_skillDal.GetAll(x => x.SkillID == id));
        }

        public IResult Update(Skill skill)
        {
            Skill updateIsSkill = _skillDal.Find(u => u.SkillID == skill.SkillID);

            updateIsSkill.SkillName = skill.SkillName;
            updateIsSkill.SkillRating = skill.SkillRating;
            _skillDal.UpdateAsync(updateIsSkill);
            return new SuccessResult(Messages.CommentUpdate);

        }
    }
}
