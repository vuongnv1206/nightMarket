﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Authentication.Login
{
	public class ExternalLoginModel
	{
		[Required]
		[EmailAddress]
		public string Email { get; set; }
		public ClaimsPrincipal Principal { get; set; }
	}
}
