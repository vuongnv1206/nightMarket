using AutoMapper;
using MediatR;
using NightMarket.Application.DTOs.Catalogs.CategoryDto.Validators;
using NightMarket.Application.DTOs.ShoppingBundles.CartItemDto.Validators;
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
	public class CreateCartItemHandler : IRequestHandler<CreateCartItemRequest, BaseCommandResponse>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
        public CreateCartItemHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
        public async Task<BaseCommandResponse> Handle(CreateCartItemRequest request, CancellationToken cancellationToken)
		{
			var response = new BaseCommandResponse();
			var validator = new CreateCartItemDtoValidator();
			var validationResult = await validator.ValidateAsync(request.CartItemDto);

			if (validationResult.IsValid == false)
			{
				response.IsSuccess = false;
				response.Message = "Creation Failed";
				response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
			}
			else
			{

				var cartItem = _mapper.Map<Domain.Entities.ShoppingBundles.CartItems>(request.CartItemDto);

				cartItem = await _unitOfWork.CartItemRepository.AddAsync(cartItem);
				await _unitOfWork.Save();

				response.IsSuccess = true;
				response.Message = "Creation Successful";
				response.Id = cartItem.Id;
			}

			return response;
		}
	}
}
