using MediatR;
using NightMarket.Application.DTOs.Catalogs.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Features.Categories.Requests.Queries
{
	public class GetCategoriesOfProductRequest : IRequest<List<GetAllCategoriesDto>>
	{
        public int ProductId { get; set; }
    }
}
