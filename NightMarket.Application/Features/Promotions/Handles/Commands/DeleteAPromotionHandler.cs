using AutoMapper;
using MediatR;
using NightMarket.Application.Exceptions;
using NightMarket.Application.Features.Promotions.Requests.Commands;
using NightMarket.Application.Interfaces.Persistence;
using NightMarket.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Features.Promotions.Handles.Commands
{
	public class DeleteAPromotionHandler : IRequestHandler<DeleteAPromotionRequest, BaseCommandResponse>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
        public DeleteAPromotionHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
        public async Task<BaseCommandResponse> Handle(DeleteAPromotionRequest request, CancellationToken cancellationToken)
		{
			var response = new BaseCommandResponse();
			var promotion = await _unitOfWork.PromotionRepository.GetByIdAsync(request.PromotionId,
				x => x.CategoryPromotions.Where(cp => cp.DeleteAt == null),
				x => x.ProductPromotions.Where(pp => pp.DeleteAt == null),
				x => x.UserPromotions.Where(up => up.DeleteAt == null));

			if (promotion == null) throw new NotFoundException(nameof(Domain.Entities.ProductBundles.Promotions), request.PromotionId);

			await _unitOfWork.PromotionRepository.DeleteAsync(promotion);

			// Xóa các liên kết giữa sản phẩm , danh mục,or người dùng với promotion
			await _unitOfWork.ProductPromotionRepository.DeleteRangeAsync(promotion.ProductPromotions);
			await _unitOfWork.CategoryPromotionRepository.DeleteRangeAsync(promotion.CategoryPromotions);
			await _unitOfWork.UserPromotionRepository.DeleteRangeAsync(promotion.UserPromotions);
			await _unitOfWork.Save();

			response.IsSuccess = true;
			response.Message = "Delete Successful";
			response.Id = promotion.Id;

			return response;
		}
	}
}
