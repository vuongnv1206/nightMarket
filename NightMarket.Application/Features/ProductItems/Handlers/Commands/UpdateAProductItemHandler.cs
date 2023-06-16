using AutoMapper;
using MediatR;
using NightMarket.Application.DTOs.Catalogs.CategoryDto.Validators;
using NightMarket.Application.DTOs.Catalogs.ProductItemDto.Validators;
using NightMarket.Application.Exceptions;
using NightMarket.Application.Features.Categories.Requests.Commands;
using NightMarket.Application.Features.ProductItems.Requests.Commands;
using NightMarket.Application.Interfaces.Persistence;
using NightMarket.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Features.ProductItems.Handlers.Commands
{
	public class UpdateAProductItemHandler : IRequestHandler<UpdateAProductItemRequest, BaseCommandResponse>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
        public UpdateAProductItemHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
        public async Task<BaseCommandResponse> Handle(UpdateAProductItemRequest request, CancellationToken cancellationToken)
		{
			var response = new BaseCommandResponse();
			var validator = new UpdateAProductItemDtoValidator();
			var validationResult = await validator.ValidateAsync(request.ProductItemDto);

			if (validationResult.IsValid == false)
			{
				response.IsSuccess = false;
				response.Message = "Update Failed";
				response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
			}
			else
			{

				var propductItem = await _unitOfWork.CategoryRepository.GetByIdAsync(request.ProductItemDto.Id);

				if (propductItem is null)
					throw new NotFoundException(nameof(propductItem), request.ProductItemDto.Id);

				

				_mapper.Map(request.ProductItemDto, propductItem);

				await _unitOfWork.CategoryRepository.UpdateAsync(propductItem);
				await _unitOfWork.Save();

				response.IsSuccess = true;
				response.Message = "Updated Successful";
				response.Id = propductItem.Id;
			}
			return response;
		}
	}
}
