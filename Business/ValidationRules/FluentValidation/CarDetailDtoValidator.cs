using Entities.DTOs;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarDetailDtoValidator : AbstractValidator<CarDetailDto>
    {
        public CarDetailDtoValidator()
        {
            //CarDetailDto
            RuleFor(cd => cd.CarName).NotEmpty();
            RuleFor(cd => cd.BrandName).NotEmpty();
            RuleFor(cd => cd.ColorName).NotEmpty();
            RuleFor(cd => cd.DailyPrice).NotEmpty();

        }

    }

}

