using MediatR;
using Microsoft.AspNetCore.Mvc;
using NightMarket.Application.DTOs.Catalogs.Categories;
using NightMarket.Application.DTOs.Catalogs.Products;
using NightMarket.Application.Features.Categories.Requests.Commands;
using NightMarket.Application.Features.Categories.Requests.Queries;
using NightMarket.Application.Features.Products.Requests.Commands;
using NightMarket.Application.Features.Products.Requests.Queries;
using NightMarket.Application.Responses;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NightMarket.API.Controllers.Catalog
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : BaseApiController
	{
		public CategoryController(IMediator mediator) : base(mediator)
		{

		}

		[HttpGet]
		public async Task<ApiResponse<List<GetAllCategoriesDto>>> GetCategories()
		{
			var categories = await _mediator.Send(new GetAllCategoryRequest());
			return ApiResponse<List<GetAllCategoriesDto>>.Success(categories);
		}


		[HttpGet("/categoryId")]
		public async Task<ApiResponse<GetACategoryDto>> GetACategory(int categoryId)
		{
			var category = await _mediator.Send(new GetACategoryRequest { CategoryId = categoryId});
			return ApiResponse<GetACategoryDto>.Success(category);
		}


		[HttpPost]
		public async Task<ActionResult<BaseCommandResponse>> CreateACategory([FromBody] CreateACategoryDto categoryDto)
		{
			var command = new CreateACategoryRequest { CategoryDto = categoryDto };
			var response = await _mediator.Send(command);
			return Ok(response);
		}


		[HttpPut("/categoryId")]
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
	}
}
