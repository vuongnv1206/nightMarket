using MediatR;
using NightMarket.Application.DTOs.Catalogs.ProductItemDto;
using NightMarket.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Features.ProductItems.Requests.Commands
{
    public class CreateAProductItemRequest : IRequest<BaseCommandResponse>
	{
		public  CreateAProductItemDto ProductItemDto { get; set; }
	}
}
