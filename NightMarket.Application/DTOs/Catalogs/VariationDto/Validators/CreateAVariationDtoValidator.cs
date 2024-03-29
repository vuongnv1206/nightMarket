﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.DTOs.Catalogs.Variations.Validators
{
	public class CreateAVariationDtoValidator : AbstractValidator<CreateAVariationDto>
	{
        public CreateAVariationDtoValidator()
        {
			RuleFor(dto => dto.VariationOptionDtos)
		   .NotEmpty()
		   .WithMessage("At least one VariationOption is required.");
		}
    }
}
