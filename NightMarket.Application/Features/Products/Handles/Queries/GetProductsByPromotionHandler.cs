using AutoMapper;
using MediatR;
using NightMarket.Application.DTOs.Catalogs.Products;
using NightMarket.Application.Features.Products.Requests.Queries;
using NightMarket.Application.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Features.Products.Handles.Queries
{
	public class GetProductsByPromotionHandler : IRequestHandler<GetProductsByPromotionRequest, List<GetAllProductsDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		public GetProductsByPromotionHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
        public async Task<List<GetAllProductsDto>> Handle(GetProductsByPromotionRequest request, CancellationToken cancellationToken)
		{
			var products = await _unitOfWork.ProductRepository.GetProductsByPromotion(request.PromotionId);
			return _mapper.Map<List<GetAllProductsDto>>(products);
		}
	}
}
