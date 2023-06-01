using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Domain.Enums
{
	public enum PaymentStatus
	{
		Pending = 0,
		Completed = 1,
		Failed = 2,
		Refund = 3,
		Cancelled = 4,
		Expired = 5,
	}
	/*
Pending: Đang chờ xử lý hoặc chờ thanh toán được xác nhận.
Completed: Thanh toán đã hoàn tất và được chấp nhận.
Failed: Thanh toán không thành công hoặc bị từ chối.
Refunded: Thanh toán đã được hoàn trả lại cho khách hàng.
Cancelled: Thanh toán đã bị hủy hoặc từ chối.

Expired: Thanh toán đã hết hạn hoặc không còn hiệu lực.*/
}
