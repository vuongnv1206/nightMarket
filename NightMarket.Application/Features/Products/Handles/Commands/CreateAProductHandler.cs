using MediatR;
using NightMarket.Application.Features.Products.Requests.Commands;
using NightMarket.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Features.Products.Handles.Commands
{
	public class CreateAProductHandler : IRequestHandler<CreateAProductRequest, BaseCommandResponse>
	{
		public async Task<BaseCommandResponse> Handle(CreateAProductRequest request, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}
