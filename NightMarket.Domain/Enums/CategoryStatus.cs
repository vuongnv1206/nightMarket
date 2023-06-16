using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Domain.Enums
{
	public enum CategoryStatus
	{
		Published = 0,   //Ngày ra mắt
		Draft = 1,		//Nháp
		Scheduled = 2,  //Ngày tương lai sẽ ra mắt
		Archived = 3,   //Lưu trữ (Không còn tồn tại)
	}
}
