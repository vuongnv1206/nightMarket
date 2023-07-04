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
		public readonly IMapper _mapper;
        public BaseApiController(IMediator mediator,IMapper mapper)
        {
			_mediator = mediator;
			_mapper = mapper;
        }
    }
}
