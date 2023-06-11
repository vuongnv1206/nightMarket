using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.DTOs.Catalogs.Products.Validators
{
    public class IProductDtoValidator : AbstractValidator<IProductDto>
	{
        public IProductDtoValidator()
        {
            
        }
    }
}
