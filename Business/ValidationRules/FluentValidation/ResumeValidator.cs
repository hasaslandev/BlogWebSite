using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ResumeValidator:AbstractValidator<Resume>
    {
        public ResumeValidator()
        {
            RuleFor(x=>x.ResumeJobs).NotEmpty().MaximumLength(50).MinimumLength(3).WithMessage("En az 3 karakter en fazla 50 karakter olmalıdır.");
            RuleFor(x => x.ResumeStatement).NotEmpty().MaximumLength(2000).MinimumLength(5).WithMessage("En fazla 2000 en az 5 karakter içermeli");

        }
    }
}
