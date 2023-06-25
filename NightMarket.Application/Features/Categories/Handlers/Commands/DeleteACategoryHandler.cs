using AutoMapper;
using MediatR;
using NightMarket.Application.Exceptions;
using NightMarket.Application.Features.Categories.Requests.Commands;
using NightMarket.Application.Features.Products.Requests.Commands;
using NightMarket.Application.Interfaces.Persistence;
using NightMarket.Application.Interfaces.Persistence.Catalog;
using NightMarket.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Features.Products.Handles.Commands
{
	public class DeleteACategoryHandler : IRequestHandler<DeleteACategoryRequest, BaseCommandResponse>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
        public DeleteACategoryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
			_unitOfWork = unitOfWork;
			_mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(DeleteACategoryRequest request, CancellationToken cancellationToken)
		{
			var response = new BaseCommandResponse();
			var category = await _unitOfWork.CategoryRepository.GetByIdAsync(request.CategoryId,x => x.CategoryPromotions);

			if (category == null) throw new NotFoundException(nameof(Domain.Entities.ProductBundles.Categories), request.CategoryId);

			await _unitOfWork.CategoryRepository.DeleteAsync(category);

			// Xóa các liên kết giữa sản phẩm và danh mục
			await _unitOfWork.ProductCategoryRepository.DeleteRangeAsync(category.ProductCategories);

			await _unitOfWork.Save();

			response.IsSuccess = true;
			response.Message = "Delete Successful";
			response.Id = category.Id;

			return response;
		}
	}
}
