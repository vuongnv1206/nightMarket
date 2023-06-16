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
	public class CreateListProductItemHandler : IRequestHandler<CreateListProductItemRequest, BaseCommandResponse>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		public CreateListProductItemHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
		public async Task<BaseCommandResponse> Handle(CreateListProductItemRequest request, CancellationToken cancellationToken)
		{
			var response = new BaseCommandResponse();

			var productItems = _mapper.Map<IEnumerable<Domain.Entities.ProductBundles.ProductItems>>(request.ProductItemDtos);

			var productId = request.ProductItemDtos.First().ProductId;

			var product = await _unitOfWork.ProductRepository.GetByIdAsync(productId);

			productItems = await _unitOfWork.ProductItemRepository.AddRangeAsync(productItems);


			
			await _unitOfWork.Save();

			response.IsSuccess = true;
			response.Message = $"Creation Successful {productItems.Count()} productItems";
			response.Id = 0;

			return response;
		}



	}
}
