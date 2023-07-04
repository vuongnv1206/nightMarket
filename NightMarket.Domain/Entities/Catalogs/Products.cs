using NightMarket.Domain.Common;
using NightMarket.Domain.Entities.Catalogs;
using NightMarket.Domain.Entities.ShoppingBundles;
using NightMarket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Domain.Entities.ProductBundles
{
    public class Products : BaseDomainEntity
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
        public bool TrackInventory { get; set; }
        public int? Quantity { get; set; }
        public int? BrandId { get; set; }
        public ProductStatus Status { get; set; }
        public DateTime? PublishDate { get; set; }
        public IEnumerable<ProductItems> ProductItems { get; set; }
		public IEnumerable<ProductCategories> ProductCategories { get; set; }
		public IEnumerable<Variations> Variations { get; set; }
		public IEnumerable<ProductPromotions> ProductPromotions { get; set; }

		public IEnumerable<CartItems> CartItems { get; set; }
        public IEnumerable<OrderLines> OrderLines { get; set; }
        public Brands Brand { get; set; }



    }
}
