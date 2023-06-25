using AutoMapper;
using MediatR;
using NightMarket.Application.DTOs.Catalogs.CategoryDto.Validators;
using NightMarket.Application.DTOs.Catalogs.ProductItemDto.Validators;
using NightMarket.Application.Features.Categories.Requests.Commands;
using NightMarket.Application.Features.ProductItems.Requests.Commands;
using NightMarket.Application.Interfaces.Persistence;
using NightMarket.Application.Responses;
using NightMarket.Domain.Entities.Catalogs;
using NightMarket.Domain.Entities.ProductBundles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Features.ProductItems.Handlers.Commands
{
	public class CreateAProductItemHandler : IRequestHandler<CreateAProductItemRequest, BaseCommandResponse>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		public CreateAProductItemHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
		public async Task<BaseCommandResponse> Handle(CreateAProductItemRequest request, CancellationToken cancellationToken)
		{
			var response = new BaseCommandResponse();

			var productItem = _mapper.Map<Domain.Entities.ProductBundles.ProductItems>(request.ProductItemDto);

			productItem = await _unitOfWork.ProductItemRepository.AddAsync(productItem);

			await _unitOfWork.Save();

			response.IsSuccess = true;
			response.Message = $"Creation Successful productItems";
			response.Id = productItem.Id;


			if (request.ProductItemDto.ProductCombinationDtos != null && request.ProductItemDto.ProductCombinationDtos.Any())
			{
				foreach (var productCombination in request.ProductItemDto.ProductCombinationDtos)
				{
					productCombination.ProductItemId = productItem.Id;
					await _unitOfWork.ProductCombinationRepository.AddAsync(_mapper.Map<ProductCombinations>(productCombination));

					await _unitOfWork.Save();
				}
			}

			return response;
		}



	}
}
