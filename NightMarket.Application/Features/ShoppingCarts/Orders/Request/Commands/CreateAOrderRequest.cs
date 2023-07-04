using MediatR;
using NightMarket.Application.DTOs.ShoppingBundles.OrderDto;
using NightMarket.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Features.ShoppingCarts.Orders.Request.Commands
{
	public class CreateAOrderRequest : IRequest<BaseCommandResponse>
	{
        public CreateAOrderDto OrderDto { get; set; }
    }
}
