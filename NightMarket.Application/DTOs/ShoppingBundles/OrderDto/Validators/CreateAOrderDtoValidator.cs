using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.DTOs.ShoppingBundles.OrderDto.Validators
{
	public class CreateAOrderDtoValidator : AbstractValidator<CreateAOrderDto>
	{
		public CreateAOrderDtoValidator()
		{
		}
	}
}
