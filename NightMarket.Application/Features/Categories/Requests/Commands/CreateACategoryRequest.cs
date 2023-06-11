using MediatR;
using NightMarket.Application.DTOs.Catalogs.Categories;
using NightMarket.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Features.Categories.Requests.Commands
{
	public class CreateACategoryRequest : IRequest<BaseCommandResponse>
	{
        public CreateACategoryDto CategoryDto { get; set; }
    }
}
