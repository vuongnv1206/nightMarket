using AutoMapper;
using MediatR;
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
	public class DeleteAVariationHandler : IRequestHandler<DeleteAVariationRequest, BaseCommandResponse>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
        public DeleteAVariationHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
        public async Task<BaseCommandResponse> Handle(DeleteAVariationRequest request, CancellationToken cancellationToken)
		{
			var response = new BaseCommandResponse();
			var variation = await _unitOfWork.VariationRepository.GetByIdAsync(request.VariationId,x => x.VariationOptions);

			if (variation == null) throw new NotFoundException(nameof(Domain.Entities.ProductBundles.Variations), request.VariationId);

			await _unitOfWork.VariationRepository.DeleteAsync(variation);

			await _unitOfWork.VariationOptionRepository.DeleteRangeAsync(variation.VariationOptions);
			await _unitOfWork.Save();

			response.IsSuccess = true;
			response.Message = "Delete Successful";
			response.Id = variation.Id;

			return response;
		}
	}
}
