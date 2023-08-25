using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CommentValidator:AbstractValidator<Comment>
    {
        public CommentValidator()
        {
            RuleFor(x=>x.UserName).MaximumLength(15).MinimumLength(5);
            RuleFor(x=>x.Mail).MaximumLength(10).MaximumLength(25);
            RuleFor(x=>x.CommentText).MaximumLength(2000).MinimumLength(5).WithMessage("Min 5 Max 2000 olmalıdır");
            RuleFor(x => x.CommentDate).NotEmpty();
            RuleFor(x=>x.CommentStatus).NotEmpty();
            RuleFor(x => x.BlogID).NotEmpty();

        }
    }
}
