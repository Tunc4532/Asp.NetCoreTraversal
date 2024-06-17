using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class GudeValidator : AbstractValidator<Guide>
    {
        public GudeValidator() 
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Litfen Rehber Adını Giriniz");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Litfen Rehber Açıklamasını Giriniz");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Litfen Rehber Resim Url Giriniz");
            RuleFor(x => x.Name).MaximumLength(30).WithMessage("Litfen 30 karakteeerden daha kısa bir isim giriniz");
            RuleFor(x => x.Name).MinimumLength(6).WithMessage("Litfen 6 karakteeerden daha uzun bir isim giriniz");
        } 
    }
}
