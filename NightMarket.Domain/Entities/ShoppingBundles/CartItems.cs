﻿using NightMarket.Domain.Common;
using NightMarket.Domain.Entities.ProductBundles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Domain.Entities.ShoppingBundles
{
	public class CartItems : BaseDomainEntity
	{
        public int CartId { get; set; }
        public int ProductId { get; set; }
        public int? ProductItemId { get; set; }
		public int Quantity { get; set; }
		public Products Product { get; set; }
        public ProductItems ProductItem { get; set; }
        public Carts Cart { get; set; }
    }
}
