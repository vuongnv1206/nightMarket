using NightMarket.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Domain.Entities.ProductBundles
{
	public class ProductCategories : BaseDomainEntity
	{
		public int ProductId { get; set; }
		public int CategoryId { get; set; }
		public Products Product { get; set; }
		public Categories Category { get; set; }
	}
}
