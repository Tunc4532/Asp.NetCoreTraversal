using DTOLayer.DTOs.AppUserDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AppUserRegisterValidator : AbstractValidator<AppUserRegisterDTOs>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("ad alanı boş geçilemez");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("soyad alanı boş geçilemez");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("mail alanı boş geçilemez");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("kullanıcı adı boş geçilemez");
            RuleFor(x => x.Password).NotEmpty().WithMessage("şifre alanı boş geçilemez");
            RuleFor(x => x.ConfrimPassword).NotEmpty().WithMessage("şifre tekrar alanı boş geçilemez");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("lütfen en az 3 karakter veri girişi yapınız");
            RuleFor(x => x.UserName).MaximumLength(20).WithMessage("lütfen en fazla 20 karakter veri girişi yapınız");
            RuleFor(x => x.Password).Equal(y => y.ConfrimPassword).WithMessage("Şifreler biribirleri ile uyuşmuyor");

        }
    }
}
