using NightMarket.Application.DTOs.Catalogs.Variations;
using NightMarket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.DTOs.Catalogs.Products
{
    public interface IProductDto
    {
		public string Name { get; set; }
		public string Slug { get; set; }
		public string? ShortDesc { get; set; }
		public string? LongDesc { get; set; }
		public string? Image { get; set; }
		//Chỉ hiển thị nếu 0 có Variant
		public double Price { get; set; }
		//thể hiện mức giảm giá hoặc ưu đãi đặc biệt của sản phẩm ,//Chỉ hiển thị nếu 0 có Variant
		public double? CompareAtPrice { get; set; }
		public string? SKU { get; set; }
		//Hiện tại chưa cần
		//public bool TrackInventory { get; set; }
		public int? BrandId { get; set; }
		public ProductStatus Status { get; set; }
		public DateTime? PublishDate { get; set; }

		public IEnumerable<CreateAVariationDto> VariationDtos { get; set; }
	}
}
