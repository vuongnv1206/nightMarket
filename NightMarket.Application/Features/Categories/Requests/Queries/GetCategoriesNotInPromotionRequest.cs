using MediatR;
using NightMarket.Application.DTOs.Catalogs.Categories;
using NightMarket.Application.Models.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Features.Categories.Requests.Queries
{
	public class GetCategoriesNotInPromotionRequest : IRequest<List<GetAllCategoriesDto>>
	{
		public CategoryParameters Parameters { get; set; }
	}
}
