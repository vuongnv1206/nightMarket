﻿using NightMarket.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Domain.Entities.ProductBundles
{
	public class ProductConfigurations : BaseDomainEntity
	{
        public int ProductItemId { get; set; }
        public int VariationOptionsId { get; set; }

        public ProductItems ProductItems { get; set; }
        public VariationOptions VariationOptions { get; set; }

    }
}
