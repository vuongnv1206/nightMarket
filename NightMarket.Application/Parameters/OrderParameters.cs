using NightMarket.Application.Parameters.Common;
using NightMarket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Parameters
{
	public class OrderParameters : QueryStringParameters
	{
        public OrderParameters()
        {
			OrderBy = "DateCreated";
		}
		public string? Text { get; set; }
		public OrderStatus Status { get; set; }

		public int? Created { get; set; }
	}
}
