using MediatR;
using NightMarket.Application.DTOs.Catalogs.Variations;
using NightMarket.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Features.Variations.Requests.Commands
{
	public class UpdateAVariationRequest : IRequest<BaseCommandResponse>
	{
        public UpdateAVariationDto VariationDto { get; set; }
    }
}
