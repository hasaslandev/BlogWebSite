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
            RuleFor(p=>p.BlogTitle).NotEmpty().MinimumLength(5).WithMessage("Blog başlığı en az 5 karakter içermeli!!! ");
            RuleFor(p=>p.BlogTitle).MaximumLength(100).WithMessage("Blog başlığı en fazla 100 karakter sınırı aşıldı!!! ");
            RuleFor(p => p.BlogContent).NotEmpty().MinimumLength(15).WithMessage("Blog içeriği en az 15 karakter içermeli!!! ");
            RuleFor(p => p.BlogImage).NotEmpty().MaximumLength(100).WithMessage("Blog mesaj yolu 100 karakteri geçti!!! ");
            //RuleFor(p => p.CategoryID).NotEmpty().WithMessage("Category alanı boş bırakılamaz!!! ");
           // RuleFor(p => p.BlogRating).LessThan(11).WithMessage("Blog rating sınırı aşıldı max 10 olabilir!!!");
            //RuleFor(p => p.AuthorID).GreaterThanOrEqualTo(10).When(p => p.CategoryID == 1);
            //RuleFor(p => p.BlogTitle).Must(StartWithA).WithMessage("Blog A harfini i.ermeli");

        }
        //arg string fonksiyon
        //private bool StartWithA(string arg)
        //{
        //    return arg.StartsWith("A");
        //}
    }
}
