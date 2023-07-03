using NightMarket.Application.DTOs.Catalogs.ProductCombinationDto;
using NightMarket.Application.DTOs.Catalogs.ProductDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.DTOs.Catalogs.ProductItemDto
{
	public class ProductItemOrderDto
	{
        public ProductOrderDto Product { get; set; }
        public int Quantity { get; set; }
		public string? Image { get; set; }
		public string? SKU { get; set; }
		public double Price { get; set; }
		public double? CompareAtPrice { get; set; }
		public IEnumerable<GetProductCombinationDto> ProductCombinationDtos { get; set; }
	}
}
