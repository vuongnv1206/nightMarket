using MediatR;
using NightMarket.Application.DTOs.ShoppingBundles.OrderDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Features.ShoppingCarts.Orders.Request.Queries
{
	public class GetAOrderRequest : IRequest<GetAOrderDto>
	{
        public int OrderId { get; set; }
    }
}
