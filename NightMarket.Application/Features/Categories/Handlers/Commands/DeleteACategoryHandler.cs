using MediatR;
using NightMarket.Application.Features.Categories.Requests.Commands;
using NightMarket.Application.Features.Products.Requests.Commands;
using NightMarket.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Features.Products.Handles.Commands
{
	public class DeleteACategoryHandler : IRequestHandler<DeleteACategoryRequest, BaseCommandResponse>
	{
		public async Task<BaseCommandResponse> Handle(DeleteACategoryRequest request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
