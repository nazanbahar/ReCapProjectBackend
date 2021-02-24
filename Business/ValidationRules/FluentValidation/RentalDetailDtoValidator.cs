using Entities.DTOs;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalDetailDtoValidator : AbstractValidator<RentalDetailDto>
    {
        public RentalDetailDtoValidator()
        {
            //CarDetailDto
            RuleFor(rd => rd.CarName).NotEmpty();
            RuleFor(rd => rd.Description).NotEmpty();
            RuleFor(rd => rd.ModelYear).NotEmpty();
            RuleFor(rd => rd.DailyPrice).NotEmpty();
            RuleFor(rd => rd.CompanyName).NotEmpty();
            RuleFor(rd => rd.RentDate).NotEmpty();
            RuleFor(rd => rd.ReturnDate).NotEmpty();

        }

    }

}

