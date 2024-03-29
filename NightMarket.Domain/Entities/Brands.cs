﻿using NightMarket.Domain.Common;
using NightMarket.Domain.Entities.ProductBundles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Domain.Entities
{
	public class Brands : BaseDomainEntity
	{
		public string Name { get; set; }
		public string Logo { get; set; }
		public string Description { get; set; }
        public IEnumerable<Products> Products { get; set; }
    }
}
