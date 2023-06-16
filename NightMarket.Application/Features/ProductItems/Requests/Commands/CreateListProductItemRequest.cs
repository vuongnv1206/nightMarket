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
    public class CreateListProductItemRequest : IRequest<BaseCommandResponse>
	{
		public  IEnumerable<CreateAProductItemDto> ProductItemDtos { get; set; }
	}
}
