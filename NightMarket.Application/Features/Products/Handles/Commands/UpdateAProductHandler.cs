using AutoMapper;
using MediatR;
using NightMarket.Application.DTOs.Catalogs.CategoryDto.Validators;
using NightMarket.Application.DTOs.Catalogs.Products.Validators;
using NightMarket.Application.Exceptions;
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
	public class UpdateAProductHandler : IRequestHandler<UpdateAProductRequest, BaseCommandResponse>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
        public UpdateAProductHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
        public async Task<BaseCommandResponse> Handle(UpdateAProductRequest request, CancellationToken cancellationToken)
		{
			var response = new BaseCommandResponse();
			var validator = new UpdateAProductValidator(_unitOfWork);
			var validationResult = await validator.ValidateAsync(request.ProductDto);

			if (validationResult.IsValid == false)
			{
				response.IsSuccess = false;
				response.Message = "Update Failed";
				response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
			}
			else
			{

				var product = await _unitOfWork.ProductRepository.GetByIdAsync(request.ProductDto.Id);

				if (product is null)
					throw new NotFoundException(nameof(product), request.ProductDto.Id);

				if (request.ProductDto.Status == Domain.Enums.ProductStatus.Published)
				{
					request.ProductDto.PublishDate = DateTime.Now;
				}

				_mapper.Map(request.ProductDto, product);

				await _unitOfWork.ProductRepository.UpdateAsync(product);
				await _unitOfWork.Save();

				response.IsSuccess = true;
				response.Message = "Updated Successful";
				response.Id = product.Id;
			}
			return response;
		}
	}
}
