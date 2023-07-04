using AutoMapper;
using MediatR;
using NightMarket.Application.DTOs.Catalogs.Products;
using NightMarket.Application.Features.Products.Requests.Queries;
using NightMarket.Application.Helpers;
using NightMarket.Application.Interfaces.Persistence.Catalog;
using NightMarket.Application.Models.Parameters.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Features.Products.Handles.Queries
{
    public class GetAllProductHandler : IRequestHandler<GetAllProductRequest, PagedList<GetAllProductsDto>>
	{	
		private readonly IProductRepository _productRepository;
		private readonly IMapper _mapper;

        public GetAllProductHandler(IProductRepository productRepository, IMapper mapper )
        {
			_productRepository = productRepository;
			_mapper = mapper;
        }
        public async Task<PagedList<GetAllProductsDto>> Handle(GetAllProductRequest request, CancellationToken cancellationToken)
		{
			var products = await _productRepository.ListAsync(request.Parameters);
			return _mapper.Map<PagedList<GetAllProductsDto>>(products);
		}
	}


}
