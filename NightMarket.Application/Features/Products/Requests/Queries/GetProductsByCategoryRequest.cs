using MediatR;
using NightMarket.Application.DTOs.Catalogs.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Features.Products.Requests.Queries
{
	public class GetProductsByCategoryRequest : IRequest<List<GetAllProductsDto>>
	{
        public int CategoryId { get; set; }

    }
}
