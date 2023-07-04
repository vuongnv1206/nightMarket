using MediatR;
using NightMarket.Application.DTOs.Catalogs.ProductItemDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Features.ProductItems.Requests.Queries
{
    public class GetAProductItemRequest : IRequest<GetAProductItemDto>
	{
        public int ProductItemId { get; set; }
      
	}
}
