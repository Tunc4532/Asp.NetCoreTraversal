using DTOLayer.DTOs.AnnouncementDTOs;
using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AnnouncementValidator : AbstractValidator<AnnouncementAddDto>
    {
        public AnnouncementValidator()
        {
            RuleFor(x => x.Tittle).NotEmpty().WithMessage("başık alanı boş geçilemez");
            RuleFor(x => x.Content).NotEmpty().WithMessage("duyuru içerik alanı boş geçilemez");
            RuleFor(x => x.Tittle).MinimumLength(5).WithMessage("lütfen en az 5 karakter veri girişi yapıız");
            RuleFor(x => x.Content).MinimumLength(15).WithMessage("lütfen en az 15 karakter veri girişi yapıız");
            RuleFor(x => x.Tittle).MaximumLength(50).WithMessage("lütfen en fazla 50 karakter veri girişi yapıız");
            RuleFor(x => x.Content).MaximumLength(500).WithMessage("lütfen en fazla 500 karakter veri girişi yapıız");
        }
    }
}
