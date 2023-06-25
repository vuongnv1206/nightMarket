using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Extensions
{
	public interface ISortHelper<T>
	{
		List<T> ApplySort(List<T> entities, string orderByQueryString);
	}
}
