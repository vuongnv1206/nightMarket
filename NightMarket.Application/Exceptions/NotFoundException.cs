﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NightMarket.Application.Exceptions
{
	public class NotFoundException : ApplicationException
	{
		public NotFoundException()
		{
		}

		public NotFoundException(string name, object key) : base($"{name} ({key}) was not found")
		{

		}

		public NotFoundException(string? message) : base(message)
		{
		}

		public NotFoundException(string? message, Exception? innerException) : base(message, innerException)
		{
		}

		protected NotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}
