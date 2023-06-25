using AutoMapper;
using MediatR;
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
	public class DeleteProductCategoryHandler : IRequestHandler<DeleteProductCategoryRequest, BaseCommandResponse>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
        public DeleteProductCategoryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
        public async Task<BaseCommandResponse> Handle(DeleteProductCategoryRequest request, CancellationToken cancellationToken)
		{
			var response = new BaseCommandResponse();
			var productCategory = await _unitOfWork.ProductCategoryRepository.FindAsync(request.ProductCategoryDto.ProductId, request.ProductCategoryDto.CategoryId);

			_unitOfWork.ProductCategoryRepository.DeleteAsync(productCategory);

			await _unitOfWork.Save();
			response.IsSuccess = true;
			response.Message = "Deleted Successful";
			response.Id = productCategory.Id;

			return response;
		}
	}
}
