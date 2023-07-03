using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NightMarket.Application.DTOs.Catalogs.Categories;
using NightMarket.Application.DTOs.Catalogs.ProductCategoryDto;
using NightMarket.Application.DTOs.Catalogs.Products;
using NightMarket.Application.Features.Categories.Requests.Commands;
using NightMarket.Application.Features.Categories.Requests.Queries;
using NightMarket.Application.Features.ProductCategories.Requests.Commands;
using NightMarket.Application.Features.Products.Requests.Queries;
using NightMarket.Application.Helpers;
using NightMarket.Application.Parameters;
using NightMarket.Application.Responses;
using NightMarket.Domain.Entities.ShoppingBundles;
using NightMarket.Infrastructure.Logger.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NightMarket.API.Controllers.Catalog
{
    [Route("api/[controller]")]
	[ApiController]
	public class CategoryController : BaseApiController
	{
		private readonly ILoggerManager _logger;
		public CategoryController(IMediator mediator, ILoggerManager logger) : base(mediator)
		{
			_logger = logger;
		}

		[HttpGet]
		public async Task<ApiResponse<PagedList<GetAllCategoriesDto>>> GetCategories([FromQuery] CategoryParameters parameters)
		{
			_logger.LogInfo("Here is info message from the controller.");
			_logger.LogDebug("Here is debug message from the controller.");
			_logger.LogWarn("Here is warn message from the controller.");
			_logger.LogError("Here is error message from the controller.");
			var categories = await _mediator.Send(new GetAllCategoryRequest(parameters));
			var metadata = new
			{
				categories.TotalCount,
				categories.PageSize,
				categories.CurrentPage,
				categories.TotalPages,
				categories.HasNext,
				categories.HasPrevious
			};
			Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

			return ApiResponse<PagedList<GetAllCategoriesDto>>.Success(categories);
		}


		[HttpGet("/categoryId")]
		public async Task<ApiResponse<GetACategoryDto>> GetACategory(int categoryId)
		{
			var category = await _mediator.Send(new GetACategoryRequest { CategoryId = categoryId});
			return ApiResponse<GetACategoryDto>.Success(category);
		}

		[HttpGet("/GetCategoriesOfProduct")]
		public async Task<ApiResponse<List<GetAllCategoriesDto>>> GetCategoriesOfProduct(int productId)
		{
			var categories = await _mediator.Send(new GetCategoriesOfProductRequest { ProductId = productId });
			return ApiResponse<List<GetAllCategoriesDto>>.Success(categories);
		}

		[HttpGet("/GetCategoriesNotInProduct")]
		public async Task<ApiResponse<List<GetAllCategoriesDto>>> GetCategoriesNotInProduct([FromQuery] CategoryParameters parameters)
		{
			var categories = await _mediator.Send(new GetCategoriesNotInProductRequest { Parameters = parameters });
			return ApiResponse<List<GetAllCategoriesDto>>.Success(categories);
		}

		[HttpGet("/GetCategoriesByPromotion")]
		public async Task<ApiResponse<List<GetAllCategoriesDto>>> GetCategoriesByPromotion([FromQuery] int promotionId)
		{
			var categories = await _mediator.Send(new GetCategoriesByPromotionRequest { PromotionId = promotionId });
			return ApiResponse<List<GetAllCategoriesDto>>.Success(categories);
		}

		[HttpGet("/GetCategoriesNotInPromotion")]
		public async Task<ApiResponse<List<GetAllCategoriesDto>>> GetCategoriesNotInPromotion([FromQuery] CategoryParameters parameters)
		{
			var categories = await _mediator.Send(new GetCategoriesNotInPromotionRequest { Parameters = parameters });
			return ApiResponse<List<GetAllCategoriesDto>>.Success(categories);
		}



		[HttpPost("create")]
		public async Task<ActionResult<BaseCommandResponse>> CreateACategory([FromBody] CreateACategoryDto categoryDto)
		{
			var command = new CreateACategoryRequest { CategoryDto = categoryDto };
		
			var response = await _mediator.Send(command);
			return Ok(response);
		}

		[HttpPost("product-category")]
		public async Task<ActionResult<BaseCommandResponse>> AddProductCategory([FromBody] GetProductCategoryDto dto)
		{
			var command = new AddAProductInCategoryRequest { ProductCategoryDto = dto };
			var response = await _mediator.Send(command);
			return Ok(response);
		}



		[HttpPatch("/categoryId")]
		public async Task<ActionResult<BaseCommandResponse>> UpdateACategory([FromBody] UpdateACategoryDto categoryDto)
		{
			var command = new UpdateACategoryRequest { CategoryDto = categoryDto };
			var response = await _mediator.Send(command);
			return Ok(response);
		}

		[HttpDelete("/categoryId")]
		public async Task<ActionResult<BaseCommandResponse>> DeleteACategory(int categoryId)
		{
			var command = new DeleteACategoryRequest { CategoryId = categoryId };
			var response = await _mediator.Send(command);
			return Ok(response);
		}

		[HttpDelete("product-category")]
		public async Task<ActionResult<BaseCommandResponse>> DeleteProductCategory([FromBody] GetProductCategoryDto dto)
		{
			var command = new AddAProductInCategoryRequest { ProductCategoryDto = dto };
			var response = await _mediator.Send(command);
			return Ok(response);
		}
	}
}
