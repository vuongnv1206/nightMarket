using MediatR;
using NightMarket.Application.DTOs.Catalogs.VariationOptionDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Features.VariationOptions.Requests.Queries
{
	public class GetAllVariationOptionRequest : IRequest<List<GetVariationOptionDto>>
	{
	}
}
