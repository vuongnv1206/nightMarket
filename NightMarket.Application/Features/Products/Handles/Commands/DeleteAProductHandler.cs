using AutoMapper;
using MediatR;
using NightMarket.Application.Exceptions;
using NightMarket.Application.Features.Products.Requests.Commands;
using NightMarket.Application.Interfaces.Persistence;
using NightMarket.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Features.Products.Handles.Commands
{
	public class DeleteAProductHandler : IRequestHandler<DeleteAProductRequest, BaseCommandResponse>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
        public DeleteAProductHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
        public async Task<BaseCommandResponse> Handle(DeleteAProductRequest request, CancellationToken cancellationToken)
		{
			var response = new BaseCommandResponse();
			var product = await _unitOfWork.CategoryRepository.GetByIdAsync(request.ProductId,p => p.ProductCategories);

			if (product == null) throw new NotFoundException(nameof(Domain.Entities.ProductBundles.Products), request.ProductId);

			await _unitOfWork.CategoryRepository.DeleteAsync(product);


			// Xóa các liên kết giữa sản phẩm và danh mục
			await _unitOfWork.ProductCategoryRepository.DeleteRangeAsync(product.ProductCategories);

			await _unitOfWork.Save();

			response.IsSuccess = true;
			response.Message = "Delete Successful";
			response.Id = product.Id;

			return response;
		}
	}
}
