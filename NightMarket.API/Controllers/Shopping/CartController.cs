using MediatR;
using Microsoft.AspNetCore.Mvc;
using NightMarket.Application.DTOs.ShoppingBundles.CartDto;
using NightMarket.Application.Features.ShoppingCarts.Carts.Requests.Queries;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NightMarket.API.Controllers.Shopping
{
	[Route("api/[controller]")]
	[ApiController]
	public class CartController : BaseApiController
	{
		public CartController(IMediator mediator) : base(mediator)
		{
		}

		[HttpGet]
		public async Task<ApiResponse<GetCartDto>> GetCart(int cartId)
		{
			var cart = await _mediator.Send(new GetCartRequest { CartId = cartId });
			return ApiResponse<GetCartDto>.Success(cart);
		}
	}


}
