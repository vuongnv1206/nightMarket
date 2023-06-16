using FluentValidation;
using NightMarket.Application.DTOs.Catalogs.Categories;
using NightMarket.Application.Interfaces.Persistence;
using NightMarket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.DTOs.Catalogs.CategoryDto.Validators
{
	public class CreateACategoryDtoValidator : AbstractValidator<CreateACategoryDto>
	{	
		private readonly IUnitOfWork _unitOfWork;
        public CreateACategoryDtoValidator(IUnitOfWork unitOfWork) 
        {	
			_unitOfWork = unitOfWork;

			RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("{PropertyName} can not be null or empty");
			RuleFor(x => x.Slug).NotNull().NotEmpty().WithMessage("{PropertyName} can not be null or empty");
			RuleFor(x => x.Description).MaximumLength(500).WithMessage("Description should be less than 500 characters");


			When(x => x.PublishDate.HasValue, () =>
			{
				RuleFor(x => x.PublishDate).GreaterThanOrEqualTo(DateTime.UtcNow).WithMessage("Publish date must to greater than current date/time");
			});

			RuleFor(x => x.ParentId).MustAsync(async (id, token) =>
			{
				var parentIdExists = await _unitOfWork.CategoryRepository.AnyAsync(id);
				return parentIdExists;
			})
			.WithMessage("{PropertyName} does not exist.")
			.When(x => x.ParentId.HasValue)
			.Unless(x => x.PublishDate == null); ;

		}
    }
}
