﻿using NightMarket.Application.Interfaces.Persistence;
using NightMarket.Application.Interfaces.Persistence.Catalog;
using NightMarket.Domain.Entities.ProductBundles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Persistence.Repositories.Persisence.Catalog
{
	public class ProductItemRepository : GenericRepository<ProductItems>, IProductItemRepository
	{
		public ProductItemRepository(ApplicationDbContext dbContext) : base(dbContext)
		{
		}
	}
}
