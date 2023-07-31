using EntityLayer.Concrete;
using FluentValidation;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AuthorValidator : AbstractValidator<Author>
    {
        public AuthorValidator()
        {
            RuleFor(x => x.AuthorName).NotEmpty().WithMessage("Yazar adı soyadı kısmı boş geçilemez.");
            RuleFor(x => x.AuthorMail).NotEmpty().WithMessage("Mail adresi boş geçilemez");
            RuleFor(x => x.AuthorName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişi yapın");
            RuleFor(x => x.AuthorPassword).NotEmpty().WithMessage("Şifre Boş geçilemez");
            RuleFor(p => p.AuthorPassword).Matches(@"[A-Z]+").WithMessage("Sifre en azı bir büyük harfden ibaret olmalıdır.");
            RuleFor(x => x.AuthorPassword).Matches(@"[a-z]+").WithMessage("Sifre en azı bir kicik harfden ibaret olmalıdır.");
        }
    }
}
