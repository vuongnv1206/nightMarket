using AutoMapper;
using MediatR;
using NightMarket.Application.DTOs.Catalogs.VariationOptionDto;
using NightMarket.Application.DTOs.Catalogs.VariationOptionDto.Validators;
using NightMarket.Application.DTOs.Catalogs.Variations.Validators;
using NightMarket.Application.Exceptions;
using NightMarket.Application.Features.VariationOptions.Requests.Commands;
using NightMarket.Application.Interfaces.Persistence;
using NightMarket.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Features.VariationOptions.Handlers.Commands
{
	public class UpdateAVariationOptionHandler : IRequestHandler<UpdateAVariationOptionRequest, BaseCommandResponse>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
        public UpdateAVariationOptionHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
        public async Task<BaseCommandResponse> Handle(UpdateAVariationOptionRequest request, CancellationToken cancellationToken)
		{
			var response = new BaseCommandResponse();
			var validator = new UpdateAVariationOptionDtoValidator();
			var validationResult = await validator.ValidateAsync(request.VariationOptionDto);

			if (validationResult.IsValid == false)
			{
				response.IsSuccess = false;
				response.Message = "Update Failed";
				response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
			}
			else
			{

				var variationOption = await _unitOfWork.VariationOptionRepository.GetByIdAsync(request.VariationOptionDto.Id);

				if (variationOption is null)
					throw new NotFoundException(nameof(variationOption), request.VariationOptionDto.Id);



				_mapper.Map(request.VariationOptionDto, variationOption);

				await _unitOfWork.VariationOptionRepository.UpdateAsync(variationOption);
				await _unitOfWork.Save();

				response.IsSuccess = true;
				response.Message = "Updated Successful";
				response.Id = variationOption.Id;
			}
			return response;
		}
	}
}
