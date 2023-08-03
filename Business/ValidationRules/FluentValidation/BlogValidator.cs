using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class BlogValidator:AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(p=>p.BlogTitle).NotEmpty();
            RuleFor(p=>p.BlogTitle).MinimumLength(2);
            RuleFor(p => p.BlogContent).NotEmpty();
            //RuleFor(p => p.AuthorID).GreaterThanOrEqualTo(10).When(p => p.CategoryID == 1);
            RuleFor(p => p.BlogTitle).Must(StartWithA);

        }
        //arg string fonksiyon
        private bool StartWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
