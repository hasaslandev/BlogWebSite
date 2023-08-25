using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class JobValidator:AbstractValidator<Job>
    {
        public JobValidator()
        {
            RuleFor(x=>x.JobName).NotEmpty().MaximumLength(30).MinimumLength(3).WithMessage("Max 30 min 3 karakter içemeli");   
        }
    }
}
