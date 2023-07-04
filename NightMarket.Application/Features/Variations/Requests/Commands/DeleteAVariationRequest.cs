using MediatR;
using NightMarket.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Features.Variations.Requests.Commands
{
	public class DeleteAVariationRequest : IRequest<BaseCommandResponse>
	{
        public int VariationId { get; set; }

    }
	
	
}
