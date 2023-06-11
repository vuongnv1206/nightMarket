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
	public class GetAllCategoryHandler : IRequestHandler<GetAllCategoryRequest, List<GetAllCategoriesDto>>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
        public GetAllCategoryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
			_mapper = mapper;
        }
        public async Task<List<GetAllCategoriesDto>> Handle(GetAllCategoryRequest request, CancellationToken cancellationToken)
		{
			var categories = await _unitOfWork.CategoryRepository.ListAsync();
			return _mapper.Map<List<GetAllCategoriesDto>>(categories);
		}
	}
}
