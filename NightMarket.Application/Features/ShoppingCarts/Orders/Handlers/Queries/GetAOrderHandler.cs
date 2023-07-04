using AutoMapper;
using MediatR;
using NightMarket.Application.DTOs.ShoppingBundles.OrderDto;
using NightMarket.Application.Features.ShoppingCarts.Orders.Request.Queries;
using NightMarket.Application.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Features.ShoppingCarts.Orders.Handlers.Queries
{
	public class GetAOrderHandler : IRequestHandler<GetAOrderRequest, GetAOrderDto>
	{	
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
        public GetAOrderHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
        public async Task<GetAOrderDto> Handle(GetAOrderRequest request, CancellationToken cancellationToken)
		{
			var order = await _unitOfWork.OrderRepository.GetOrdersByIdAsync(request.OrderId);
			return _mapper.Map<GetAOrderDto>(order);	
		}
	}
}
