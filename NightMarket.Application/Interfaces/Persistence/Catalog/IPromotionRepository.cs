﻿using NightMarket.Application.Helpers;
using NightMarket.Application.Parameters;
using NightMarket.Domain.Entities.ProductBundles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Interfaces.Persistence.Catalog
{
    public interface IPromotionRepository : IGenericRepository<Promotions>
	{
		Task<PagedList<Promotions>> ListAsync(PromotionParameters parameters);

		
	}
}
