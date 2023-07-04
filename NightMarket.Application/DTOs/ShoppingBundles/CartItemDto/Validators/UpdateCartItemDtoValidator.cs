using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.DTOs.ShoppingBundles.CartItemDto.Validators
{
	public class UpdateCartItemDtoValidator : AbstractValidator<UpdateCartItemDto>
	{
		public UpdateCartItemDtoValidator()
		{
		}
	}
}
