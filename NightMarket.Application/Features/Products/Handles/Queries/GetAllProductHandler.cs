using AutoMapper;
using MediatR;
using NightMarket.Application.DTOs.Catalogs.Products;
using NightMarket.Application.Features.Products.Requests.Queries;
using NightMarket.Application.Interfaces.Persistence.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Features.Products.Handles.Queries
{
    public class GetAllProductHandler : IRequestHandler<GetAllProductRequest, List<GetAllProductsDto>>
	{	
		private readonly IProductRepository _productRepository;
		private readonly IMapper _mapper;

        public GetAllProductHandler(IProductRepository productRepository, IMapper mapper )
        {
			_productRepository = productRepository;
			_mapper = mapper;
        }
        public async Task<List<GetAllProductsDto>> Handle(GetAllProductRequest request, CancellationToken cancellationToken)
		{
			var products = await _productRepository.ListAsync();
			return _mapper.Map<List<GetAllProductsDto>>(products);
		}
	}


}
