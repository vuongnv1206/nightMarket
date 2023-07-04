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
    public class GetAProductHandler : IRequestHandler<GetAProductRequest, GetAProductDto>
	{	
		private readonly IProductRepository _productRepository;
		private readonly IMapper _mapper;
        public GetAProductHandler(IMapper mapper,IProductRepository productRepository)
        {
			_mapper = mapper;
			_productRepository = productRepository;
        }
        public async Task<GetAProductDto> Handle(GetAProductRequest request, CancellationToken cancellationToken)
		{
			var product = await _productRepository.GetProductByIdAsync(request.ProductId);

			return _mapper.Map<GetAProductDto>(product);
		}
	}
}
