using MediatR;
using NightMarket.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Features.Categories.Requests.Commands
{
	public class DeleteACategoryRequest : IRequest<BaseCommandResponse>
	{
        public int CategoryId { get; set; }
    }
}
