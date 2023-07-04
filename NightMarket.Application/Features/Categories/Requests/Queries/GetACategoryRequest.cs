using MediatR;
using NightMarket.Application.DTOs.Catalogs.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Features.Categories.Requests.Queries
{
	public class GetACategoryRequest : IRequest<GetACategoryDto>
	{
        public int CategoryId { get; set; }
    }
}
