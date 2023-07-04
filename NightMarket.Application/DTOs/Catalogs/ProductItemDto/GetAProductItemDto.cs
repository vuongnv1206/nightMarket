using NightMarket.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.DTOs.Catalogs.ProductItemDto
{
    public class GetAProductItemDto : BaseDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string? Image { get; set; }
        public string? SKU { get; set; }
        public double Price { get; set; }
        public int? Stock { get; set; }
        public double? CompareAtPrice { get; set; }
    }
}
