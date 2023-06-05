﻿using NightMarket.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Domain.Entities.ProductBundles
{
	public class VariationOptions : BaseDomainEntity
	{
        public int VariationId { get; set; }
        public string Value { get; set; }
        public Variations Variations { get; set; }
		public IEnumerable<ProductConfigurations> ProductConfigurations { get; set; }

	}
}
