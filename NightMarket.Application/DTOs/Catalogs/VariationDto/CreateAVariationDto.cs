using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.DTOs.Catalogs.Variations
{
	public class CreateAVariationDto 
	{
		public int CategoryId { get; set; }
		public string Name { get; set; }
	}
}
