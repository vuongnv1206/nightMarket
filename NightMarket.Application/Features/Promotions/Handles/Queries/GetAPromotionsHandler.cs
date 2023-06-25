using AutoMapper;
using MediatR;
using NightMarket.Application.DTOs.Catalogs.Categories;
using NightMarket.Application.DTOs.Catalogs.PromotionDto;
using NightMarket.Application.Features.Promotions.Requests.Queries;
using NightMarket.Application.Interfaces.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Features.Promotions.Handles.Queries
{
	public class GetAPromotionsHandler : IRequestHandler<GetAPromotionsRequest, GetAPromotionDto>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
        public GetAPromotionsHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
        public async Task<GetAPromotionDto> Handle(GetAPromotionsRequest request, CancellationToken cancellationToken)
		{
			var promotion = await _unitOfWork.PromotionRepository.GetByIdAsync(request.PromotionId);
			return _mapper.Map<GetAPromotionDto>(promotion);
		}
	}
}
