using FluentValidation;
using NightMarket.Application.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.DTOs.Catalogs.Products.Validators
{
	public class CreateAProductDtoValidator : AbstractValidator<CreateAProductDto>
	{
        private readonly IUnitOfWork _unitOfWork;
        public CreateAProductDtoValidator(IUnitOfWork unitOfWork)
        {   
            _unitOfWork = unitOfWork;
            Include(new IProductDtoValidator(unitOfWork));
        }
    }
}
