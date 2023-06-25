using AutoMapper;
using MediatR;
using NightMarket.Application.DTOs.Catalogs.CategoryDto.Validators;
using NightMarket.Application.DTOs.Catalogs.PromotionDto.Validators;
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
	public class CreateAPromotionHandler : IRequestHandler<CreateAPromotionRequest, BaseCommandResponse>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
        public CreateAPromotionHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
        public async Task<BaseCommandResponse> Handle(CreateAPromotionRequest request, CancellationToken cancellationToken)
		{
			var response = new BaseCommandResponse();
			var validator = new CreateAPromoDtoValidator();
			var validationResult = await validator.ValidateAsync(request.PromotionDto);

			if (validationResult.IsValid == false)
			{
				response.IsSuccess = false;
				response.Message = "Creation Failed";
				response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
			}
			else
			{

				

				var promotion = _mapper.Map<Domain.Entities.ProductBundles.Promotions>(request.PromotionDto);

				promotion = await _unitOfWork.PromotionRepository.AddAsync(promotion);
				await _unitOfWork.Save();

				response.IsSuccess = true;
				response.Message = "Creation Successful";
				response.Id = promotion.Id;
			}

			return response;
		}
	}
}
