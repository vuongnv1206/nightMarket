using AutoMapper;
using MediatR;
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
	public class DeleteAVariationOptionHandler : IRequestHandler<DeleteAVariationOptionRequest, BaseCommandResponse>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
        public DeleteAVariationOptionHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
        public async Task<BaseCommandResponse> Handle(DeleteAVariationOptionRequest request, CancellationToken cancellationToken)
		{
			var response = new BaseCommandResponse();
			var variationOption = await _unitOfWork.VariationOptionRepository.GetByIdAsync(request.VariationOptionId);

			if (variationOption == null) throw new NotFoundException(nameof(Domain.Entities.ProductBundles.VariationOptions), request.VariationOptionId);

			await _unitOfWork.VariationOptionRepository.DeleteAsync(variationOption);
			await _unitOfWork.Save();

			response.IsSuccess = true;
			response.Message = "Delete Successful";
			response.Id = variationOption.Id;

			return response;
		}
	}
}
