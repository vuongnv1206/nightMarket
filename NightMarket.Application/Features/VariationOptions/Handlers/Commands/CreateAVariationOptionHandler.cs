using AutoMapper;
using MediatR;
using NightMarket.Application.DTOs.Catalogs.ProductItemDto;
using NightMarket.Application.DTOs.Catalogs.VariationOptionDto.Validators;
using NightMarket.Application.DTOs.Catalogs.Variations.Validators;
using NightMarket.Application.Features.ProductItems.Requests.Commands;
using NightMarket.Application.Features.VariationOptions.Requests.Commands;
using NightMarket.Application.Features.Variations.Requests.Commands;
using NightMarket.Application.Interfaces.Persistence;
using NightMarket.Application.Responses;
using NightMarket.Domain.Entities.Catalogs;
using NightMarket.Domain.Entities.ProductBundles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Features.VariationOptions.Handlers.Commands
{
	public class CreateAVariationOptionHandler : IRequestHandler<CreateAVariationOptionRequest, BaseCommandResponse>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IMediator _mediator;
        public CreateAVariationOptionHandler(IUnitOfWork unitOfWork, IMapper mapper,IMediator mediator)
        {
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_mediator = mediator;
		}
        public async Task<BaseCommandResponse> Handle(CreateAVariationOptionRequest request, CancellationToken cancellationToken)
		{
			var response = new BaseCommandResponse();
			var validator = new CreateAVariationOptionDtoValidator();
			var validationResult = await validator.ValidateAsync(request.VariationOptionDto);

			if (validationResult.IsValid == false)
			{
				response.IsSuccess = false;
				response.Message = "Creation Failed";
				response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
			}
			else
			{
				var variationOption = _mapper.Map<Domain.Entities.ProductBundles.VariationOptions>(request.VariationOptionDto);
				variationOption = await _unitOfWork.VariationOptionRepository.AddAsync(variationOption);

				await _unitOfWork.Save();

				response.IsSuccess = true;
				response.Message = "Creation Successful";
				response.Id = variationOption.Id;

			}

			return response;
		}
	}
}
