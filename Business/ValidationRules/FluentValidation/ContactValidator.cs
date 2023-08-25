using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().MaximumLength(50).MinimumLength(3);
            RuleFor(x => x.SurName).NotEmpty().MaximumLength(50).MinimumLength(3);
            RuleFor(x => x.Mail).NotEmpty().MaximumLength(50).MinimumLength(3);
            RuleFor(x => x.Subject).NotEmpty().MaximumLength(50).MinimumLength(3);
            RuleFor(x => x.Message).NotEmpty().MaximumLength(50).MinimumLength(3);
            RuleFor(x => x.MessageDate).NotEmpty()/*.GetType()*/;
        }
    }
}
