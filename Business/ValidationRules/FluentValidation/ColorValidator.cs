﻿using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ColorValidator:AbstractValidator<Color>
    {

        //color
        public ColorValidator() 
        {
            RuleFor(co => co.ColorName).NotEmpty();

        }

    }
}
