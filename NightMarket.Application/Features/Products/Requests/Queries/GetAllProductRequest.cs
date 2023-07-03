using MediatR;
using NightMarket.Application.DTOs.Catalogs.Products;
using NightMarket.Application.Helpers;
using NightMarket.Application.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Features.Products.Requests.Queries
{
    public class GetAllProductRequest : IRequest<PagedList<GetAllProductsDto>>
	{
        public ProductParameters Parameters { get; set; }
        public GetAllProductRequest(ProductParameters parameters)
        {
            Parameters = parameters;
        }
    }
}
