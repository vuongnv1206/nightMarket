using MediatR;
using Microsoft.AspNetCore.Mvc;
using NightMarket.Application.DTOs.ShoppingBundles.CartItemDto;
using NightMarket.Application.Features.ShoppingCarts.CartItems.Requests.Commands;
using NightMarket.Application.Responses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NightMarket.API.Controllers.Shopping
{
	[Route("api/[controller]")]
	[ApiController]
	public class CartItemController : BaseApiController
	{
		public CartItemController(IMediator mediator) : base(mediator)
		{
		}

		[HttpPost()]
		public async Task<ActionResult<BaseCommandResponse>> CreateACartItem([FromBody] CreateACartItemDto cartItemDto)
		{
			var command = new CreateCartItemRequest { CartItemDto = cartItemDto };
			var response = await _mediator.Send(command);
			return Ok(response);
		}

		[HttpPut("/cartItemId")]
		public async Task<ActionResult<BaseCommandResponse>> UpdateACartItem([FromBody] UpdateCartItemDto cartItemDto)
		{
			var command = new UpdateCartItemRequest { CartItemDto = cartItemDto };
			var response = await _mediator.Send(command);
			return Ok(response);
		}

		[HttpDelete("/cartItemId")]
		public async Task<ActionResult<BaseCommandResponse>> DeleteACartItem(int cartItemId)
		{
			var command = new DeleteACartItemRequest { CartItemId = cartItemId };
			var response = await _mediator.Send(command);
			return Ok(response);
		}
	}
}
