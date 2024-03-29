﻿using MediatR;
using NightMarket.Application.DTOs.Catalogs.Variations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Features.Variations.Requests.Queries
{
	public class GetAllVariationRequest : IRequest<List<GetAllVariationDto>>
	{
        public int ProductId { get; set; }
    }
}
