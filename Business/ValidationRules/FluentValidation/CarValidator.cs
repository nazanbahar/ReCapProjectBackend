using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            //car
            RuleFor(c => c.CarName).NotEmpty();
            RuleFor(c => c.CarName).MinimumLength(2);
            RuleFor(c => c.Description).MinimumLength(200);
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(999).When(c => c.ModelYear == 2021);
            RuleFor(c => c.CarName).Must(StartWith).WithMessage("Araba isimleri B harfi ile başlamalı");

        }

        private bool StartWith(string arg)
        {
            return arg.StartsWith("B");
        }
 
    }
}

