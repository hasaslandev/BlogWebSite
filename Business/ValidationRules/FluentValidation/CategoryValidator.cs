using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator() 
        {
            RuleFor(x=>x.CategoryName)
                .NotEmpty().MaximumLength(20).WithMessage("Categori maximum 20 karakterdir");

            RuleFor(x => x.CategoryName)
            .MinimumLength(4).WithMessage("Categori minimum sınırı 4 karakterdir");


        }
    }
}
