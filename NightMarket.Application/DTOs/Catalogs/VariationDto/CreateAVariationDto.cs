using NightMarket.Application.DTOs.Catalogs.VariationOptionDto;
using NightMarket.Domain.Entities.ProductBundles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.DTOs.Catalogs.Variations
{
	public class CreateAVariationDto 
	{
		public int ProductId { get; set; }
		public string Name { get; set; }
        public IEnumerable<CreateAVariationOptionDto> VariationOptionDtos { get; set; }
    }
}
