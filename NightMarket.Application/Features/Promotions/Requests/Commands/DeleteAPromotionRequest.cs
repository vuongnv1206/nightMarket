using MediatR;
using NightMarket.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Features.Promotions.Requests.Commands
{
	public class DeleteAPromotionRequest : IRequest<BaseCommandResponse>
	{
        public int PromotionId { get; set; }
    }
}
