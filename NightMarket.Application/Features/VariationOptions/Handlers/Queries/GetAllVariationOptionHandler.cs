using AutoMapper;
using MediatR;
using NightMarket.Application.DTOs.Catalogs.Products;
using NightMarket.Application.DTOs.Catalogs.VariationOptionDto;
using NightMarket.Application.Features.VariationOptions.Requests.Queries;
using NightMarket.Application.Interfaces.Persistence;
using NightMarket.Application.Interfaces.Persistence.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Features.VariationOptions.Handlers.Queries
{
	public class GetAllVariationOptionHandler : IRequestHandler<GetAllVariationOptionRequest, List<GetVariationOptionDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
        public GetAllVariationOptionHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
        }
        public async Task<List<GetVariationOptionDto>> Handle(GetAllVariationOptionRequest request, CancellationToken cancellationToken)
		{
			var variationOptions = await _unitOfWork.VariationOptionRepository.ListAsync();
			return _mapper.Map<List<GetVariationOptionDto>>(variationOptions);
		}
	}
}
