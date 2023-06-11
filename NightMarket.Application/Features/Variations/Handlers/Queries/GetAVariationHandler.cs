using AutoMapper;
using MediatR;
using NightMarket.Application.DTOs.Catalogs.Variations;
using NightMarket.Application.Features.Variations.Requests.Queries;
using NightMarket.Application.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Features.Variations.Handlers.Queries
{
	public class GetAVariationHandler : IRequestHandler<GetAVariationRequest, GetAVariationDto>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
        public GetAVariationHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
        public async Task<GetAVariationDto> Handle(GetAVariationRequest request, CancellationToken cancellationToken)
		{
			var variation = await _unitOfWork.VariationRepository.GetByIdAsync(request.VariationId);
			return _mapper.Map<GetAVariationDto>(variation);
		}
	}
}
