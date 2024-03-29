﻿using NightMarket.Application.DTOs.Catalogs.VariationOptionDto;
using NightMarket.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.DTOs.Catalogs.Variations
{
	public class GetAVariationDto : BaseDto
	{
		public string Name { get; set; }
		public IEnumerable<GetVariationOptionDto> VariationOptions { get; set; }
	}
}
