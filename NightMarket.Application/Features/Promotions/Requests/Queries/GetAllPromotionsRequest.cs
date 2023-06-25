using MediatR;
using NightMarket.Application.DTOs.Catalogs.PromotionDto;
using NightMarket.Application.Helpers;
using NightMarket.Application.Models.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Features.Promotions.Requests.Queries
{
	public class GetAllPromotionsRequest : IRequest<PagedList<GetPromotionsDto>>
	{
        public PromotionParameters Parameters { get; set; }
    }
}
