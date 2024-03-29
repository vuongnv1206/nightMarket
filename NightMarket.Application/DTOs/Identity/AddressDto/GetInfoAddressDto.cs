﻿using NightMarket.Domain.Entities.IdentityBundles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.DTOs.Identity.AddressDto
{
	public class GetInfoAddressDto
	{
        public int Id { get; set; }
        public int? UnitNumber { get; set; } //So nha
		public string? StreetNumber { get; set; }  //So duong
		public string? AddressLine1 { get; set; }
		public string? AddressLine2 { get; set; }
		public string? City { get; set; }
		public string? State { get; set; }  //Bang
		public string? Country { get; set; }
		public int? ZipCode { get; set; }  // Ma buu dien
	}
}
