using NightMarket.Domain.Common;
using NightMarket.Domain.Entities.IdentityBundles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Domain.Entities.ShoppingBundles
{
	public class UserReviews : BaseDomainEntity
	{
        public string UserId { get; set; }
        //Này là Id của OrderLine 
        public int OrderedProductId { get; set; }
        public int RatingValue { get; set; }
        public string Comment { get; set; }
        public ApplicationUsers User { get; set; }
        public OrderLines OrderLine { get; set; }
    }
}
