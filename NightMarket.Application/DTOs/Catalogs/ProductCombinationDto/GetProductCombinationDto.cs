using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.DTOs.Catalogs.ProductCombinationDto
{
    public class GetProductCombinationDto
    {
        public int ProductItemId { get; set; }
        public int VariationOptionId { get; set; }
    }
}
