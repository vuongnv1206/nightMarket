using AutoMapper;
using MediatR;
using NightMarket.Application.DTOs.Catalogs.CategoryDto.Validators;
using NightMarket.Application.DTOs.Catalogs.Variations.Validators;
using NightMarket.Application.Features.Categories.Requests.Commands;
using NightMarket.Application.Features.Products.Requests.Commands;
using NightMarket.Application.Interfaces.Persistence;
using NightMarket.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Features.Products.Handles.Commands
{
	public class CreateACategoryHandler : IRequestHandler<CreateACategoryRequest, BaseCommandResponse>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
        public CreateACategoryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
        public async Task<BaseCommandResponse> Handle(CreateACategoryRequest request, CancellationToken cancellationToken)
		{
			var response = new BaseCommandResponse();
			var validator = new CreateACategoryDtoValidator(_unitOfWork);
			var validationResult = await validator.ValidateAsync(request.CategoryDto);

			if (validationResult.IsValid == false)
			{
				response.IsSuccess = false;
				response.Message = "Creation Failed";
				response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
			}
			else
			{

				if (request.CategoryDto.Status == Domain.Enums.CategoryStatus.Published)
				{
					request.CategoryDto.PublishDate = DateTime.Now;
				}

				var category = _mapper.Map<Domain.Entities.ProductBundles.Categories>(request.CategoryDto);

				category = await _unitOfWork.CategoryRepository.AddAsync(category);
				await _unitOfWork.Save();

				response.IsSuccess = true;
				response.Message = "Creation Successful";
				response.Id = category.Id;
			}

			return response;
		}
	}
}
