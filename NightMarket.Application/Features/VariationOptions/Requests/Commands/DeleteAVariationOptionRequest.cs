using MediatR;
using NightMarket.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Features.VariationOptions.Requests.Commands
{
	public class DeleteAVariationOptionRequest : IRequest<BaseCommandResponse>
	{
		public int VariationOptionId { get; set; }
	}
}
