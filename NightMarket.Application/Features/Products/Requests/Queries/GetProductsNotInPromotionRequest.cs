using MediatR;
using NightMarket.Application.DTOs.Catalogs.Products;
using NightMarket.Application.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Features.Products.Requests.Queries
{
    public class GetProductsNotInPromotionRequest : IRequest<List<GetAllProductsDto>>
	{
		public ProductParameters Parameters { get; set; }
	}
}
