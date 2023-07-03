using AutoMapper;
using MediatR;
using NightMarket.Application.DTOs.Catalogs.CategoryDto.Validators;
using NightMarket.Application.DTOs.ShoppingBundles.OrderDto.Validators;
using NightMarket.Application.Exceptions;
using NightMarket.Application.Features.ShoppingCarts.Orders.Request.Commands;
using NightMarket.Application.Interfaces.Persistence;
using NightMarket.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Features.ShoppingCarts.Orders.Handlers.Commands
{	

	public class UpdateAOrderHandler : IRequestHandler<UpdateAOrderRequest, BaseCommandResponse>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
        public UpdateAOrderHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
			_unitOfWork = unitOfWork;
			_mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(UpdateAOrderRequest request, CancellationToken cancellationToken)
		{
			var response = new BaseCommandResponse();
			var validator = new UpdateAOrderDtoValidator();
			var validationResult = await validator.ValidateAsync(request.OrderDto);

			if (validationResult.IsValid == false)
			{
				response.IsSuccess = false;
				response.Message = "Update Failed";
				response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
			}
			else
			{

				var order = await _unitOfWork.OrderRepository.GetByIdAsync(request.OrderDto.Id);

				if (order is null)
					throw new NotFoundException(nameof(order), request.OrderDto.Id);

				
				_mapper.Map(request.OrderDto, order);
				await _unitOfWork.OrderRepository.UpdateAsync(order);
				await _unitOfWork.Save();

				response.IsSuccess = true;
				response.Message = "Updated Successful";
				response.Id = order.Id;
			}
			return response;
		}
	}
}
