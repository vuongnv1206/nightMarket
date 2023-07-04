using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NightMarket.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BaseApiController : ControllerBase
	{
		public readonly IMediator _mediator;
        public BaseApiController(IMediator mediator)
        {
			_mediator = mediator;
        }
    }
}
