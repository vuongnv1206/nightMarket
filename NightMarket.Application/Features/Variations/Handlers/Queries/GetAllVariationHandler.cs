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
	public class GetAllVariationHandler : IRequestHandler<GetAllVariationRequest, List<GetAllVariationDto>>
	{	
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

        public GetAllVariationHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
        public async Task<List<GetAllVariationDto>> Handle(GetAllVariationRequest request, CancellationToken cancellationToken)
		{
			var variations = await _unitOfWork.VariationRepository.GetVariationsOfProduct(request.ProductId,x => x.VariationOptions);
			return _mapper.Map<List<GetAllVariationDto>>(variations);
		}
	}
}
