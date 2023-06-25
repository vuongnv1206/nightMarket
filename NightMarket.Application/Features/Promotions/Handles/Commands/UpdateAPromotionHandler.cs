using AutoMapper;
using MediatR;
using NightMarket.Application.DTOs.Catalogs.CategoryDto.Validators;
using NightMarket.Application.DTOs.Catalogs.PromotionDto.Validators;
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
	public class UpdateAPromotionHandler : IRequestHandler<UpdateAPromotionRequest, BaseCommandResponse>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
        public UpdateAPromotionHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
        public async Task<BaseCommandResponse> Handle(UpdateAPromotionRequest request, CancellationToken cancellationToken)
		{
			var response = new BaseCommandResponse();
			var validator = new UpdateAPromotionDtoValidator();
			var validationResult = await validator.ValidateAsync(request.PromotionDto);

			if (validationResult.IsValid == false)
			{
				response.IsSuccess = false;
				response.Message = "Update Failed";
				response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
			}
			else
			{

				var promotion = await _unitOfWork.PromotionRepository.GetByIdAsync(request.PromotionDto.Id);

				if (promotion is null)
					throw new NotFoundException(nameof(promotion), request.PromotionDto.Id);

				_mapper.Map(request.PromotionDto, promotion);
				await _unitOfWork.PromotionRepository.UpdateAsync(promotion);
				await _unitOfWork.Save();

				response.IsSuccess = true;
				response.Message = "Updated Successful";
				response.Id = promotion.Id;
			}
			return response;
		}
	}
}
