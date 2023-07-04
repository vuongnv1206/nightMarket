using AutoMapper;
using MediatR;
using NightMarket.Application.DTOs.Catalogs.Variations.Validators;
using NightMarket.Application.Features.Variations.Requests.Commands;
using NightMarket.Application.Interfaces.Persistence;
using NightMarket.Application.Responses;
using NightMarket.Domain.Entities.ProductBundles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Features.Variations.Handlers.Commands
{
	public class CreateAVariationHandler : IRequestHandler<CreateAVariationRequest, BaseCommandResponse>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
        public CreateAVariationHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
        public async Task<BaseCommandResponse> Handle(CreateAVariationRequest request, CancellationToken cancellationToken)
		{
			var response = new BaseCommandResponse();
			var validator = new CreateAVariationDtoValidator();
			var validationResult = await validator.ValidateAsync(request.VariationDto);

			if (validationResult.IsValid == false)
			{
				response.IsSuccess = false;
				response.Message = "Creation Failed";
				response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
			}
			else
			{
				var variation = _mapper.Map<Domain.Entities.ProductBundles.Variations>(request.VariationDto);

				variation = await _unitOfWork.VariationRepository.AddAsync(variation);
				await _unitOfWork.Save();

				response.IsSuccess = true;
				response.Message = "Creation Successful";
				response.Id = variation.Id;
			}

			return response;
		}
	}
}
