using NightMarket.Application.DTOs.Catalogs.Variations;
using NightMarket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.DTOs.Catalogs.ProductDto
{
    public class ProductCartDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SKU { get; set; }
        public string? Image { get; set; }
        public double Price { get; set; }
        public double? CompareAtPrice { get; set; }
        public int? BrandId { get; set; }
        public IEnumerable<GetAVariationDto> VariationDtos { get; set; }
    }
}
