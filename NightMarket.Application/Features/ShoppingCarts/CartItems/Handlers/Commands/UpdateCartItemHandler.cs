using AutoMapper;
using MediatR;
using NightMarket.Application.DTOs.Catalogs.CategoryDto.Validators;
using NightMarket.Application.DTOs.ShoppingBundles.CartItemDto.Validators;
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
	public class UpdateCartItemHandler : IRequestHandler<UpdateCartItemRequest, BaseCommandResponse>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
        public UpdateCartItemHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
        public async Task<BaseCommandResponse> Handle(UpdateCartItemRequest request, CancellationToken cancellationToken)
		{
			var response = new BaseCommandResponse();
			var validator = new UpdateCartItemDtoValidator();
			var validationResult = await validator.ValidateAsync(request.CartItemDto);

			if (validationResult.IsValid == false)
			{
				response.IsSuccess = false;
				response.Message = "Update Failed";
				response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
			}
			else
			{

				var cartItem = await _unitOfWork.CartItemRepository.GetByIdAsync(request.CartItemDto.Id);

				if (cartItem is null)
					throw new NotFoundException(nameof(cartItem), request.CartItemDto.Id);


				_mapper.Map(request.CartItemDto, cartItem);
				await _unitOfWork.CartItemRepository.UpdateAsync(cartItem);
				await _unitOfWork.Save();

				response.IsSuccess = true;
				response.Message = "Updated Successful";
				response.Id = cartItem.Id;
			}
			return response;
		}
	}
}
