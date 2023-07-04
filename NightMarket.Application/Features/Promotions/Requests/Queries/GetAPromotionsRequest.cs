using MediatR;
using NightMarket.Application.DTOs.Catalogs.PromotionDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Features.Promotions.Requests.Queries
{
	public class GetAPromotionsRequest : IRequest<GetAPromotionDto>
	{
        public int PromotionId { get; set; }
    }
}
