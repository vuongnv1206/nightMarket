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
	public class GetProductsByCategoryHandler : IRequestHandler<GetProductsByCategoryRequest, List<GetAllProductsDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
        public GetProductsByCategoryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
        public async Task<List<GetAllProductsDto>> Handle(GetProductsByCategoryRequest request, CancellationToken cancellationToken)
		{
			var products = await _unitOfWork.ProductRepository.GetProductsByCategory(request.CategoryId);
			return _mapper.Map<List<GetAllProductsDto>>(products);
		}
	}
}
