using NightMarket.Domain.Common;
using NightMarket.Domain.Entities.ShoppingBundles;
using NightMarket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Domain.Entities.PaymentBundles
{
	public class Payments : BaseDomainEntity
	{
        public int UserId { get; set; }
        public int PaymentMethodId { get; set; }
        //MasterCard or VISA
        public string? Provider { get; set; }
        //Ngaỳ hết hạn thanh toán
        public DateTime ExpiryDate { get; set; }
        //STK
        public string AccountNumber { get; set; }
        public PaymentStatus Status { get; set; }
        public bool IsDefault { get; set; }
        public IEnumerable<Orders> Orders { get; set; }
        public PaymentMethods PaymentMethod { get; set; }
    }
}
