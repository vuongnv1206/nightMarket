using FluentValidation;
using NightMarket.Application.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.DTOs.Catalogs.Products.Validators
{
    public class IProductDtoValidator : AbstractValidator<IProductDto>
	{
		private readonly IUnitOfWork _unitOfWork;
		public IProductDtoValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

			RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("{PropertyName} can not be null or empty");
			RuleFor(x => x.Slug).NotNull().NotEmpty().WithMessage("{PropertyName} can not be null or empty");
			RuleFor(x => x.Price).NotNull().NotEmpty().WithMessage("{PropertyName} can not be null or empty");
			RuleFor(x => x.ShortDesc).MaximumLength(500).WithMessage("Description should be less than 200 characters");
			RuleFor(x => x.LongDesc).MaximumLength(500).WithMessage("Description should be less than 500 characters");

			RuleFor(x => x.CompareAtPrice).GreaterThanOrEqualTo(x => x.Price).WithMessage("{PropertyName} must be greater than or equal {ComparisonValue}");
			When(x => x.PublishDate.HasValue, () =>
			{
				RuleFor(x => x.PublishDate).GreaterThanOrEqualTo(DateTime.UtcNow).WithMessage("Publish date must to greater than current date/time");
			});
		}
    }
}
