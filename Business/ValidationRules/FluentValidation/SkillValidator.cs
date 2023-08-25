using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class SkillValidator : AbstractValidator<Skill>
    {
        public SkillValidator()
        {
            RuleFor(x=>x.SkillName).MaximumLength(50).NotEmpty().MinimumLength(3).WithMessage("Max 50 min 3 olmalı");

            RuleFor(x => x.SkillRating).LessThanOrEqualTo(10).NotEmpty().GreaterThanOrEqualTo(0).WithMessage("0-10 aralığında olmalıdır.");
        }
    }
}
