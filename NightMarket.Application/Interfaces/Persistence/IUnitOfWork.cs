using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NightMarket.Application.Interfaces.Persistence.Catalog;

namespace NightMarket.Application.Interfaces.Persistence
{
    public interface IUnitOfWork : IDisposable
	{
		IProductRepository ProductRepository { get; }
		IVariationRepository VariationRepository { get; }

		ICategoryRepository CategoryRepository { get; }
		IVariationOptionRepository VariationOptionRepository { get; }
		IProductItemRepository ProductItemRepository { get; }
		IProductCombinationRepository ProductCombinationRepository { get; }
		Task Save();
	}
}
