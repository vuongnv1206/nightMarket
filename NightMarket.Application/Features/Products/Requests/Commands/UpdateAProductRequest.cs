using MediatR;
using NightMarket.Application.DTOs.Catalogs.Products;
using NightMarket.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Features.Products.Requests.Commands
{
	public class UpdateAProductRequest : IRequest<BaseCommandResponse>
	{	
        public UpdateAProductDto ProductDto { get; set; }
    }
}
