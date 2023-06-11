using MediatR;
using NightMarket.Application.DTOs.Catalogs.Products;
using NightMarket.Application.DTOs.Catalogs.Variations;
using NightMarket.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Features.Variations.Requests.Commands
{
	public class CreateAVariationRequest : IRequest<BaseCommandResponse>
	{
        public CreateAVariationDto VariationDto { get; set; }
    }
}
