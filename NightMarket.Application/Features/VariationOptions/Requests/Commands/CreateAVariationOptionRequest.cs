using MediatR;
using NightMarket.Application.DTOs.Catalogs.VariationOptionDto;
using NightMarket.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Features.VariationOptions.Requests.Commands
{
	public class CreateAVariationOptionRequest : IRequest<BaseCommandResponse>
	{
        public CreateAVariationOptionDto VariationOptionDto { get; set; }
    }
}
