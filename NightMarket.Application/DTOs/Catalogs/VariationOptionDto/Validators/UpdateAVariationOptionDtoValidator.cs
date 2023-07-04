using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.DTOs.Catalogs.VariationOptionDto.Validators
{
	public class UpdateAVariationOptionDtoValidator : AbstractValidator<UpdateAVariationOptionDto>
	{
        public UpdateAVariationOptionDtoValidator()
        {
			RuleFor(dto => dto.Value).NotEmpty().WithMessage("Value is required.");
			RuleFor(dto => dto.Id).NotEmpty().WithMessage("Id is required.");
		}
    }
}
