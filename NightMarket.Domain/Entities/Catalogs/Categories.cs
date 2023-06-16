using NightMarket.Domain.Common;
using NightMarket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Domain.Entities.ProductBundles
{
	public class Categories : BaseDomainEntity
	{
        public int? ParentId { get; set; }
        public string Name { get; set; }
		// xây dựng URL thân thiện với SEO.
		public string Slug { get; set; }
		//để làm hình nền hoặc hình ảnh đại diện cho Category
		public string? PromoImage { get; set; }
        public string? Description { get; set; }
		//sử dụng để hiển thị hình ảnh nhỏ hơn trong danh sách hoặc trang chủ
		public string? ThumbnailImage { get; set; }
        //HomePage
        public string? ShortDescription { get; set; }
        public CategoryStatus Status { get; set; }
		//Sử dụng đề lọc status publish
        public DateTime? PublishDate { get; set; }
        public IEnumerable<ProductCategories> ProductCategories { get; set; }
		public IEnumerable<CategoryPromotions> CategoryPromotions { get; set; }

	}
}
