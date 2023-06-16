using AutoMapper;
using MediatR;
using NightMarket.Application.DTOs.Catalogs.Categories;
using NightMarket.Application.DTOs.Catalogs.ProductItemDto;
using NightMarket.Application.Features.ProductItems.Requests.Queries;
using NightMarket.Application.Interfaces.Persistence;
using NightMarket.Application.Interfaces.Persistence.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Features.ProductItems.Handlers.Queries
{
    public class GetAllProductItemsHandler : IRequestHandler<GetAllProductItemsRequest, List<GetAllProductItemsDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
        public GetAllProductItemsHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
        public async Task<List<GetAllProductItemsDto>> Handle(GetAllProductItemsRequest request, CancellationToken cancellationToken)
		{
			var productItems = await _unitOfWork.ProductItemRepository.ListAsync();
			return _mapper.Map<List<GetAllProductItemsDto>>(productItems);
		}
	}
}
