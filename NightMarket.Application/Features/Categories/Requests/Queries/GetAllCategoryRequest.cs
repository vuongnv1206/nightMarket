using MediatR;
using NightMarket.Application.DTOs.Catalogs.Categories;
using NightMarket.Application.Helpers;
using NightMarket.Application.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Features.Categories.Requests.Queries
{
    public class GetAllCategoryRequest : IRequest<PagedList<GetAllCategoriesDto>>
	{
		public CategoryParameters Parameters { get; set; }
		public GetAllCategoryRequest(CategoryParameters parameters)
        {
            Parameters = parameters;
        }
    }
}
