using AutoMapper;
using MediatR;

using NightMarket.Application.DTOs.Catalogs.Products.Validators;
using NightMarket.Application.Features.Products.Requests.Commands;
using NightMarket.Application.Features.Variations.Requests.Commands;
using NightMarket.Application.Interfaces.Persistence;
using NightMarket.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Features.Products.Handles.Commands
{
	public class CreateAProductHandler : IRequestHandler<CreateAProductRequest, BaseCommandResponse>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IMediator _mediator;
		public CreateAProductHandler(IUnitOfWork unitOfWork, IMapper mapper, IMediator mediator)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_mediator = mediator;
		}
		public async Task<BaseCommandResponse> Handle(CreateAProductRequest request, CancellationToken cancellationToken)
		{
			var response = new BaseCommandResponse();
			var validator = new CreateAProductDtoValidator(_unitOfWork);
			var validationResult = await validator.ValidateAsync(request.ProductDto);

			if (validationResult.IsValid == false)
			{
				response.IsSuccess = false;
				response.Message = "Creation Failed";
				response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
			}
			else
			{
				if (request.ProductDto.Status == Domain.Enums.ProductStatus.Published)
				{
					request.ProductDto.PublishDate = DateTime.Now;
				}

				var product = _mapper.Map<Domain.Entities.ProductBundles.Products>(request.ProductDto);

				product = await _unitOfWork.ProductRepository.AddAsync(product);
				await _unitOfWork.Save();

				response.IsSuccess = true;
				response.Message = "Creation Successful";
				response.Id = product.Id;


				// Kiểm tra xem có biến thể trong sản phẩm hay không
				if (request.ProductDto.VariationDtos != null && request.ProductDto.VariationDtos.Any())
				{
					foreach (var variationDto in request.ProductDto.VariationDtos)
					{
						variationDto.ProductId = product.Id;
						var createVariationRequest = new CreateAVariationRequest
						{	
							VariationDto = variationDto,
						};
						var variationResponse = await _mediator.Send(createVariationRequest);

						if (!variationResponse.IsSuccess)
						{
							response.IsSuccess = false;
							response.Message = "Creation Failed";
							response.Errors.Add($"Failed to create variation: {variationDto.Name}");
							break;
						}
					}
				}
			}
			return response;
		}
	}
}
