using NightMarket.Domain.Common;
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
        public int OrderId { get; set; }
        public int PaymentMethodId { get; set; }
        public double Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string AccountNumber { get; set; }
        public PaymentStatus Status { get; set; }
        public bool IsDefault { get; set; }

    }
}
