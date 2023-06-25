
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NightMarket.Application.DTOs.Catalogs.Products;
using NightMarket.Application.Features.Products.Requests.Commands;
using NightMarket.Application.Features.Products.Requests.Queries;
using NightMarket.Application.Helpers;
using NightMarket.Application.Models.Parameters;
using NightMarket.Application.Responses;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NightMarket.API.Controllers.Catalog
{
    [Route("api/[controller]")]
	[ApiController]
	public class ProductController : BaseApiController
	{
		public ProductController(IMediator mediator) : base(mediator)
		{
		}

		[HttpGet("all")]
		public async Task<ApiResponse<PagedList<GetAllProductsDto>>> GetProducts([FromQuery] ProductParameters parameters)
		{
			var products = await _mediator.Send(new GetAllProductRequest(parameters));
			var metadata = new
			{
				products.TotalCount,
				products.PageSize,
				products.CurrentPage,
				products.TotalPages,
				products.HasNext,
				products.HasPrevious
			};
			Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
			return ApiResponse<PagedList<GetAllProductsDto>>.Success(products);
		}


		[HttpGet("/productId")]
		public async Task<ApiResponse<GetAProductDto>> GetAProduct(int productId)
		{
			var product = await _mediator.Send(new GetAProductRequest { ProductId = productId});
			return ApiResponse<GetAProductDto>.Success(product);
		}

		[HttpGet("/category")]
		public async Task<ApiResponse<List<GetAllProductsDto>>> GetProductsByCategory([FromQuery]int categoryId)
		{
			var product = await _mediator.Send(new GetProductsByCategoryRequest { CategoryId = categoryId });
			return ApiResponse<List<GetAllProductsDto>>.Success(product);
		}

		[HttpGet("/promotion")]
		public async Task<ApiResponse<List<GetAllProductsDto>>> GetProductsByPromotion([FromQuery] int promotionId)
		{
			var product = await _mediator.Send(new GetProductsByPromotionRequest { PromotionId = promotionId });
			return ApiResponse<List<GetAllProductsDto>>.Success(product);
		}

		[HttpGet("/not-in-category")]
		public async Task<ApiResponse<List<GetAllProductsDto>>> GetProductsNotInCategory([FromQuery]ProductParameters parameters)
		{
			var product = await _mediator.Send(new GetProductsNotInCategoryRequest { Parameters = parameters });
			return ApiResponse<List<GetAllProductsDto>>.Success(product);
		}


		[HttpGet("/not-in-promotion")]
		public async Task<ApiResponse<List<GetAllProductsDto>>> GetProductsNotInPromotion([FromQuery] ProductParameters parameters)
		{
			var product = await _mediator.Send(new GetProductsNotInCategoryRequest { Parameters = parameters });
			return ApiResponse<List<GetAllProductsDto>>.Success(product);
		}



		[HttpPost("Create")]
		public async Task<ActionResult<BaseCommandResponse>> CreateAProduct([FromBody] CreateAProductDto productDto)
		{
			var command = new CreateAProductRequest { ProductDto = productDto };
			var response = await _mediator.Send(command);
			return Ok(response);
		}

		

		[HttpPut("/productId")]
		public async Task<ActionResult<BaseCommandResponse>> UpdateAProduct([FromBody] UpdateAProductDto productDto)
		{
			var command = new UpdateAProductRequest { ProductDto = productDto };
			var response = await _mediator.Send(command);
			return Ok(response);
		}

		[HttpDelete("/productId")]
		public async Task<ActionResult<BaseCommandResponse>> DeleteAProduct(int productId)
		{
			var command = new DeleteAProductRequest { ProductId = productId };
			var response = await _mediator.Send(command);
			return Ok(response);
		}
	}
}
