using MediatR;
using NightMarket.Application.DTOs.Catalogs.Variations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Features.Variations.Requests.Queries
{
	public class GetAVariationRequest : IRequest<GetAVariationDto>
	{
        public int VariationId { get; set; }
    }
}
