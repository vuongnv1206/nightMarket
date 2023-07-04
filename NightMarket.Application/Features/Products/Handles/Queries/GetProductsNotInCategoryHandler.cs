using AutoMapper;
using MediatR;
using NightMarket.Application.DTOs.Catalogs.Products;
using NightMarket.Application.Features.Products.Requests.Queries;
using NightMarket.Application.Helpers;
using NightMarket.Application.Interfaces.Persistence;
using NightMarket.Application.Interfaces.Persistence.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Features.Products.Handles.Queries
{
	public class GetProductsNotInCategoryHandler : IRequestHandler<GetProductsNotInCategoryRequest, List<GetAllProductsDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
        public GetProductsNotInCategoryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
			_unitOfWork = unitOfWork;
			_mapper = mapper;
        }
        public async Task<List<GetAllProductsDto>> Handle(GetProductsNotInCategoryRequest request, CancellationToken cancellationToken)
		{
			var products = await _unitOfWork.ProductRepository.GetProductsNotInCategory(request.Parameters);
			return _mapper.Map<List<GetAllProductsDto>>(products);
		}
	}
}
