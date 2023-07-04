using NightMarket.Application.DTOs.Catalogs.ProductDto;
using NightMarket.Application.DTOs.Catalogs.ProductItemDto;
using NightMarket.Application.DTOs.Catalogs.Products;
using NightMarket.Domain.Entities.ProductBundles;
using NightMarket.Domain.Entities.ShoppingBundles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.DTOs.ShoppingBundles.OrderLineDto
{
	public class GetAOrderLineDto
	{
		public int Quantity { get; set; }
		public double Price { get; set; }
		public ProductOrderDto Product { get; set; }
		public ProductItemOrderDto ProductItem { get; set; }
	}
}
