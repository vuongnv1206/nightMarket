using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.DTOs.Catalogs.ProductItemDto.Validators
{
    public class UpdateAProductItemDtoValidator : AbstractValidator<UpdateAProductItemDto>
	{
        public UpdateAProductItemDtoValidator()
        {
			RuleFor(x => x.Price).NotNull().NotEmpty().WithMessage("{PropertyName} can not be null or empty");
			RuleFor(x => x.Quantity).NotNull().NotEmpty().WithMessage("{PropertyName} can not be null or empty");
			
		}
	}
}
