using AutoMapper;
using MediatR;
using NightMarket.Application.DTOs.Catalogs.Categories;
using NightMarket.Application.DTOs.Catalogs.PromotionDto;
using NightMarket.Application.Features.Promotions.Requests.Queries;
using NightMarket.Application.Helpers;
using NightMarket.Application.Interfaces.Persistence;
using NightMarket.Application.Interfaces.Persistence.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Features.Promotions.Handles.Queries
{
	public class GetAllPromotionsHandler : IRequestHandler<GetAllPromotionsRequest, PagedList<GetPromotionsDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
        public GetAllPromotionsHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
        public async Task<PagedList<GetPromotionsDto>> Handle(GetAllPromotionsRequest request, CancellationToken cancellationToken)
		{
			var promotions = await _unitOfWork.PromotionRepository.ListAsync(request.Parameters);
			return _mapper.Map<PagedList<GetPromotionsDto>>(promotions);
		}
	}
}
