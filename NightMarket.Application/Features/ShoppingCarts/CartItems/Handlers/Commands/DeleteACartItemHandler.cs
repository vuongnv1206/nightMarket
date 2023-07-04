using AutoMapper;
using MediatR;
using NightMarket.Application.Exceptions;
using NightMarket.Application.Features.ShoppingCarts.CartItems.Requests.Commands;
using NightMarket.Application.Interfaces.Persistence;
using NightMarket.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Features.ShoppingCarts.CartItems.Handlers.Commands
{
	public class DeleteACartItemHandler : IRequestHandler<DeleteACartItemRequest, BaseCommandResponse>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
        public DeleteACartItemHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
        public async Task<BaseCommandResponse> Handle(DeleteACartItemRequest request, CancellationToken cancellationToken)
		{
			var response = new BaseCommandResponse();
			var cartItem = await _unitOfWork.CartItemRepository.GetByIdAsync(request.CartItemId);

			if (cartItem == null) throw new NotFoundException(nameof(Domain.Entities.ShoppingBundles.CartItems), request.CartItemId);

			await _unitOfWork.CartItemRepository.DeleteAsync(cartItem);

			

			await _unitOfWork.Save();

			response.IsSuccess = true;
			response.Message = "Delete Successful";
			response.Id = cartItem.Id;

			return response;
		}
	}
}
