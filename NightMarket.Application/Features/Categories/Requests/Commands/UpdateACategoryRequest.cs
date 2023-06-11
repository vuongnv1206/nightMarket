using MediatR;
using NightMarket.Application.DTOs.Catalogs.Categories;
using NightMarket.Application.DTOs.Catalogs.Products;
using NightMarket.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Features.Categories.Requests.Commands
{
	public class UpdateACategoryRequest : IRequest<BaseCommandResponse>
	{	
        public UpdateACategoryDto CategoryDto { get; set; }
    }
}
