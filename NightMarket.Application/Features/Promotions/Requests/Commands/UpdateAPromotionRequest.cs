using MediatR;
using NightMarket.Application.DTOs.Catalogs.PromotionDto;
using NightMarket.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Features.Promotions.Requests.Commands
{
	public class UpdateAPromotionRequest : IRequest<BaseCommandResponse>
	{
        public UpdateAPromotionDto PromotionDto { get; set; }
    }
}
