using MediatR;
using NightMarket.Application.DTOs.Catalogs.ProductCategoryDto;
using NightMarket.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Features.ProductCategories.Requests.Commands
{
	public class DeleteProductCategoryRequest : IRequest<BaseCommandResponse>
	{
        public GetProductCategoryDto ProductCategoryDto { get; set; }
    }
}
