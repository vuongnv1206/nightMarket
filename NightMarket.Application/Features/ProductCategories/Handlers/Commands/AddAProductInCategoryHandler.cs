using AutoMapper;
using MediatR;
using NightMarket.Application.DTOs.Catalogs.CategoryDto.Validators;
using NightMarket.Application.Features.ProductCategories.Requests.Commands;
using NightMarket.Application.Interfaces.Persistence;
using NightMarket.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Features.ProductCategories.Handlers.Commands
{
	public class AddAProductInCategoryHandler : IRequestHandler<AddAProductInCategoryRequest, BaseCommandResponse>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		public AddAProductInCategoryHandler(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
		public async Task<BaseCommandResponse> Handle(AddAProductInCategoryRequest request, CancellationToken cancellationToken)
		{
			var response = new BaseCommandResponse();

			var productCategory = _mapper.Map<Domain.Entities.ProductBundles.ProductCategories>(request.ProductCategoryDto);

			productCategory = await _unitOfWork.ProductCategoryRepository.AddAsync(productCategory);
			await _unitOfWork.Save();

			response.IsSuccess = true;
			response.Message = "Creation Successful";
			response.Id = productCategory.Id;


			return response;
		}
	}
}
