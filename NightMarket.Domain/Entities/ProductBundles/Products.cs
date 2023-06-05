using NightMarket.Domain.Common;
using NightMarket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Domain.Entities.ProductBundles
{
    public class Products : BaseDomainEntity
    {
        public string Name { get; set; }
        public string ShortDesc { get; set; }
        public string LongDesc { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public ProductStatus Status { get; set; }
        public IEnumerable<Categories> Categories { get; set; }
        public IEnumerable<Suppliers> Suppliers { get; set; }
    }
}
