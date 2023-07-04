using AutoMapper;
using MediatR;
using NightMarket.Application.DTOs.Catalogs.CategoryDto.Validators;
using NightMarket.Application.DTOs.ShoppingBundles.OrderDto.Validators;
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
	public class CreateAOrderHandler : IRequestHandler<CreateAOrderRequest, BaseCommandResponse>
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
        public CreateAOrderHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
			_unitOfWork = unitOfWork;
			_mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateAOrderRequest request, CancellationToken cancellationToken)
		{
			var response = new BaseCommandResponse();
			var validator = new CreateAOrderDtoValidator();
			var validationResult = await validator.ValidateAsync(request.OrderDto);

			if (validationResult.IsValid == false)
			{
				response.IsSuccess = false;
				response.Message = "Creation Failed";
				response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
			}
			else
			{

				var order = _mapper.Map<Domain.Entities.ShoppingBundles.Orders>(request.OrderDto);

				order = await _unitOfWork.OrderRepository.AddAsync(order);
				await _unitOfWork.Save();

				response.IsSuccess = true;
				response.Message = "Creation Successful";
				response.Id = order.Id;
			}

			return response;
		}
	}
}
