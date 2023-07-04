using AutoMapper;
using MediatR;
using NightMarket.Application.DTOs.ShoppingBundles.OrderDto;
using NightMarket.Application.Features.ShoppingCarts.Orders.Request.Queries;
using NightMarket.Application.Helpers;
using NightMarket.Application.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Features.ShoppingCarts.Orders.Handlers.Queries
{
	public class GetAllOrdersHandler : IRequestHandler<GetAllOrdersRequest, PagedList<GetOrdersDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
        public GetAllOrdersHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
        public async Task<PagedList<GetOrdersDto>> Handle(GetAllOrdersRequest request, CancellationToken cancellationToken)
		{
			var orders = await _unitOfWork.OrderRepository.ListAsync(request.Parameters);
			return _mapper.Map<PagedList<GetOrdersDto>>(orders);
		}
	}
}
