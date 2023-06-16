using AutoMapper;
using MediatR;
using NightMarket.Application.DTOs.Catalogs.ProductItemDto;
using NightMarket.Application.Features.ProductItems.Requests.Queries;
using NightMarket.Application.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Features.ProductItems.Handlers.Queries
{
    public class GetAProductItemHandler : IRequestHandler<GetAProductItemRequest, GetAProductItemDto>
	{	
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
        public GetAProductItemHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
			_unitOfWork = unitOfWork;
			_mapper = mapper;
        }
        public async Task<GetAProductItemDto> Handle(GetAProductItemRequest request, CancellationToken cancellationToken)
		{
			var productItem = await _unitOfWork.ProductItemRepository.GetByIdAsync(request.ProductItemId);
			return _mapper.Map<GetAProductItemDto>(productItem);
		}
	}
}
