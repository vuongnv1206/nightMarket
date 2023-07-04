using NightMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.DTOs.Catalogs.ProductDto
{
	public class ProductOrderDto
	{
		public string Name { get; set; }
		public string ShortDesc { get; set; }
		public string LongDesc { get; set; }
		public string Image { get; set; }
		//Chỉ hiển thị nếu 0 có Variant
		public double Price { get; set; }
		//thể hiện mức giảm giá hoặc ưu đãi đặc biệt của sản phẩm ,//Chỉ hiển thị nếu 0 có Variant
		public double? CompareAtPrice { get; set; }
		public string? SKU { get; set; }
		public Brands Brand { get; set; }
	}
}
