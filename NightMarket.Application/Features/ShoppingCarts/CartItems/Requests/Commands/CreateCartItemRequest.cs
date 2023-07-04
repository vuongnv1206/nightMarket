using MediatR;
using NightMarket.Application.DTOs.ShoppingBundles.CartItemDto;
using NightMarket.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Features.ShoppingCarts.CartItems.Requests.Commands
{
	public class CreateCartItemRequest : IRequest<BaseCommandResponse>
	{
        public CreateACartItemDto CartItemDto { get; set; }
    }
}
