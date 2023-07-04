using NightMarket.Domain.Common;
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
		public string? Description { get; set; }

        public IEnumerable<ProductCategories> ProductCategories { get; set; }
		public IEnumerable<Variations> Variations { get; set; }
		public IEnumerable<CategoryPromotions> CategoryPromotions { get; set; }

	}
}
