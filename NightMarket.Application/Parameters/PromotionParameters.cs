using NightMarket.Application.Parameters.Common;
using NightMarket.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Parameters
{
    public class PromotionParameters : QueryStringParameters
    {
        public PromotionParameters()
        {
            OrderBy = "DateCreated";
        }
        public string? Text { get; set; }
        public PromotionType? Type { get; set; }
        public PromotionApplyTo? ApplyTo { get; set; }
        public bool? IsEnabled { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
