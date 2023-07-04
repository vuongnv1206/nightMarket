using MediatR;
using NightMarket.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Features.ShoppingCarts.CartItems.Requests.Commands
{
	public class DeleteACartItemRequest : IRequest<BaseCommandResponse>
	{
        public int CartItemId { get; set; }
    }
}
