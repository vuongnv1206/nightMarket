using FluentValidation;
using NightMarket.Application.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.DTOs.Catalogs.Products.Validators
{
	public class UpdateAProductValidator : AbstractValidator<UpdateAProductDto>
	{
		private readonly IUnitOfWork _unitOfWork;
		public UpdateAProductValidator(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
			Include(new IProductDtoValidator(unitOfWork));
		}
	}
}
