using NightMarket.Application.Models.Parameters.Common;
using NightMarket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Models.Parameters
{
	public class CategoryParameters : QueryStringParameters
	{
        public CategoryParameters()
        {
            OrderBy = "DateCreated";
        }
        public string? Text { get; set; }
      
        public CategoryStatus? Status { get; set; }
        public int? Published { get; set; }
        public int? Created { get; set; }
        public int? Modified { get; set; }
        public int? ObjectId { get; set; }
    }
}
