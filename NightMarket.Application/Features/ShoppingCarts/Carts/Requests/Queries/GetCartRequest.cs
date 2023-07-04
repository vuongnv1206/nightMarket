using MediatR;
using NightMarket.Application.DTOs.ShoppingBundles.CartDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Features.ShoppingCarts.Carts.Requests.Queries
{
    public class GetCartRequest : IRequest<GetCartDto>
    {
        public int CartId { get; set; }
    }
}
