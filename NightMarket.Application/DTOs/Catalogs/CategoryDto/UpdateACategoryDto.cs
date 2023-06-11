﻿using NightMarket.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.DTOs.Catalogs.Categories
{
	public class UpdateACategoryDto : BaseDto
	{
		public int? ParentId { get; set; }
		public string Name { get; set; }
		public string? Description { get; set; }
	}
}