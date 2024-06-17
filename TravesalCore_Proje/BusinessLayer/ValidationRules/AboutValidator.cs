﻿using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AboutValidator : AbstractValidator<About>
    {

        public AboutValidator()
        {
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama Kısmını Boş Geçemezsiniz...!");
            RuleFor(x => x.Image1).NotEmpty().WithMessage("Lütfen Görsel Seçiniz...!");
            RuleFor(x => x.Image1).MinimumLength(50).WithMessage("Lütfen En Az 50 Karekterlik Açıklama Bilgisi Giriniz...!");
            RuleFor(x => x.Image1).MaximumLength(1200).WithMessage("Lütfen Açıklama Alanını Kısaltın...!");

        }

    }
}