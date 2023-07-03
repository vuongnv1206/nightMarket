using MediatR;
using NightMarket.Application.DTOs.ShoppingBundles.OrderDto;
using NightMarket.Application.Helpers;
using NightMarket.Application.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Features.ShoppingCarts.Orders.Request.Queries
{
	public class GetAllOrdersRequest : IRequest<PagedList<GetOrdersDto>>
	{
        public OrderParameters Parameters { get; set; }

    }
}
