using NightMarket.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.DTOs.Catalogs.Products
{
    public class CreateAProductDto : BaseDto, IProductDto
	{
		public string Name { get; set; }
		public string ShortDesc { get; set; }
		public string LongDesc { get; set; }
		public int CategoryId { get; set; }
		public int? BrandId { get; set; }
	}
}
