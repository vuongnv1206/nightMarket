using AutoMapper;
using MediatR;
using NightMarket.Application.DTOs.Catalogs.CategoryDto.Validators;
using NightMarket.Application.Exceptions;
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
	public class UpdateACategoryHandler : IRequestHandler<UpdateACategoryRequest, BaseCommandResponse>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
        public UpdateACategoryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<BaseCommandResponse> Handle(UpdateACategoryRequest request, CancellationToken cancellationToken)
		{
			var response = new BaseCommandResponse();
			var validator = new UpdateACategoryValidator();
			var validationResult = await validator.ValidateAsync(request.CategoryDto);

			if (validationResult.IsValid == false)
			{
				response.IsSuccess = false;
				response.Message = "Update Failed";
				response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
			}
			else
			{

				var category = await _unitOfWork.CategoryRepository.GetByIdAsync(request.CategoryDto.Id);

				if (category is null)
					throw new NotFoundException(nameof(category), request.CategoryDto.Id);

				_mapper.Map(request.CategoryDto, category);

				await _unitOfWork.CategoryRepository.UpdateAsync(category);
				await _unitOfWork.Save();

				response.IsSuccess = true;
				response.Message = "Updated Successful";
				response.Id = category.Id;
			}
			return response;
		}
	}
}
