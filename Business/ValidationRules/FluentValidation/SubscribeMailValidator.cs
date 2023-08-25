using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class SubscribeMailValidator : AbstractValidator<SubscribeMail>
    {
        public SubscribeMailValidator()
        {
            RuleFor(x=>x.Mail).MaximumLength(50).NotEmpty().WithMessage("Geçersiz Mail");
        }
    }
}
