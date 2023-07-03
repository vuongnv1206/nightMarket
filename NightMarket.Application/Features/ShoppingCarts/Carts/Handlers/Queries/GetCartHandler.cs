using AutoMapper;
using MediatR;
using NightMarket.Application.DTOs.Catalogs.Categories;
using NightMarket.Application.DTOs.ShoppingBundles.CartDto;
using NightMarket.Application.Features.ShoppingCarts.Carts.Requests.Queries;
using NightMarket.Application.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Features.ShoppingCarts.Carts.Handlers.Queries
{
	public class GetCartHandler : IRequestHandler<GetCartRequest, GetCartDto>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
        public GetCartHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
        public async Task<GetCartDto> Handle(GetCartRequest request, CancellationToken cancellationToken)
		{
			var cart = await _unitOfWork.CartRepository.GetCartInclude(request.CartId);
			return _mapper.Map<GetCartDto>(cart);
		}
	}
}
