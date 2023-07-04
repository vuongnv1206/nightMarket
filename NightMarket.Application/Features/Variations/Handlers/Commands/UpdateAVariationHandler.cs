using AutoMapper;
using MediatR;
using NightMarket.Application.DTOs.Catalogs.Products.Validators;
using NightMarket.Application.DTOs.Catalogs.Variations.Validators;
using NightMarket.Application.Exceptions;
using NightMarket.Application.Features.Variations.Requests.Commands;
using NightMarket.Application.Interfaces.Persistence;
using NightMarket.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Features.Variations.Handlers.Commands
{
	public class UpdateAVariationHandler : IRequestHandler<UpdateAVariationRequest, BaseCommandResponse>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
        public UpdateAVariationHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
			_unitOfWork = unitOfWork;
			_mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(UpdateAVariationRequest request, CancellationToken cancellationToken)
		{
			var response = new BaseCommandResponse();
			var validator = new UpdateAVariationDtoValidator();
			var validationResult = await validator.ValidateAsync(request.VariationDto);

			if (validationResult.IsValid == false)
			{
				response.IsSuccess = false;
				response.Message = "Update Failed";
				response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
			}
			else
			{

				var variation = await _unitOfWork.ProductRepository.GetByIdAsync(request.VariationDto.Id);

				if (variation is null)
					throw new NotFoundException(nameof(variation), request.VariationDto.Id);

				

				_mapper.Map(request.VariationDto, variation);

				await _unitOfWork.ProductRepository.UpdateAsync(variation);
				await _unitOfWork.Save();

				response.IsSuccess = true;
				response.Message = "Updated Successful";
				response.Id = variation.Id;
			}
			return response;
		}
	}
}
