using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class AboutValidator:AbstractValidator<About>
    {
        public AboutValidator()
        {
            RuleFor(p => p.AboutID).NotEmpty();
            RuleFor(p => p.AboutContent1).MaximumLength(2000).WithMessage("AboutContent1'in max limiti aştın");
            RuleFor(p => p.AboutContent2).MaximumLength(2000).WithMessage("AboutContent2'in max limiti aştın");
            RuleFor(p => p.AboutImage1).MaximumLength(100).WithMessage("AboutImage1'in max limiti aştın");
            RuleFor(p => p.AboutImage2).MaximumLength(100).WithMessage("AboutImage2'in max limiti aştın");
        }
        
    }
}
