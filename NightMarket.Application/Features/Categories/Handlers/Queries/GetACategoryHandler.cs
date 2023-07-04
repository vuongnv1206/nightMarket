using AutoMapper;
using MediatR;
using NightMarket.Application.DTOs.Catalogs.Categories;
using NightMarket.Application.DTOs.Catalogs.Products;
using NightMarket.Application.Features.Categories.Requests.Queries;
using NightMarket.Application.Interfaces.Persistence;
using NightMarket.Application.Interfaces.Persistence.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Features.Categories.Handlers.Queries
{
	public class GetACategoryHandler : IRequestHandler<GetACategoryRequest, GetACategoryDto>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
        public GetACategoryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
        public async Task<GetACategoryDto> Handle(GetACategoryRequest request, CancellationToken cancellationToken)
		{
			var category = await _unitOfWork.CategoryRepository.GetByIdAsync(request.CategoryId);
			return _mapper.Map<GetACategoryDto>(category);
		}
	}
}
